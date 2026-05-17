using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using SpambotDetection.Core.Enums;
using SpambotDetection.Core.Interfaces;

namespace SpambotDetection.Infrastructure.Services;

/// <summary>
/// Gọi FastAPI AI Server.
/// ✅ Ưu tiên server LOCAL (http://localhost:8000) — không cần Ngrok.
/// ✅ Fallback: đọc ngrok_base_url từ bảng api_config trong Supabase.
/// ✅ Cache config 60s để tránh query DB mỗi request.
/// </summary>
public sealed class AIService : IAIService
{
    // ── Địa chỉ local Python FastAPI server ──────────────────────────────────
    private const string LocalAiUrl = "http://localhost:8000";

    private readonly HttpClient _http;
    private readonly IApiConfigRepository _configRepo;
    private readonly ILogger<AIService> _logger;

    private static readonly JsonSerializerOptions _jsonOpts = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    // ── Cache config ──────────────────────────────────────────────────────────
    private string? _cachedBaseUrl;
    private string? _cachedPredictEndpoint;
    private string? _cachedBatchEndpoint;
    private int?    _cachedMaxBatch;
    private DateTime _cacheExpiry = DateTime.MinValue;
    private readonly TimeSpan _cacheTtl = TimeSpan.FromSeconds(60);

    public AIService(HttpClient http, IApiConfigRepository configRepo, ILogger<AIService> logger)
    {
        _http       = http;
        _configRepo = configRepo;
        _logger     = logger;
    }

    // ── Resolve URL: Local → DB (Ngrok fallback) ─────────────────────────────
    private async Task LoadConfigAsync(CancellationToken ct)
    {
        if (DateTime.UtcNow < _cacheExpiry) return;

        // 1️⃣ Thử kết nối local FastAPI trước
        if (await IsReachableAsync(LocalAiUrl, ct))
        {
            _logger.LogDebug("✅ Dùng local AI server: {url}", LocalAiUrl);
            _cachedBaseUrl          = LocalAiUrl;
            _cachedPredictEndpoint  = "/predict";
            _cachedBatchEndpoint    = "/predict/batch";
            _cachedMaxBatch         = 500;
            _cacheExpiry            = DateTime.UtcNow + _cacheTtl;
            return;
        }

        // 2️⃣ Fallback: đọc ngrok_base_url từ Supabase
        _logger.LogDebug("⚠️  Local AI server không phản hồi → fallback ngrok URL từ DB...");

        var url = await _configRepo.GetValueAsync("ngrok_base_url", ct);
        if (string.IsNullOrWhiteSpace(url))
            throw new InvalidOperationException(
                "Không thể kết nối đến AI server (local:8000 hoặc ngrok).\n" +
                "Hãy chạy python_ai_server hoặc vào UC05 để cấu hình Ngrok URL.");

        _cachedBaseUrl         = url.TrimEnd('/');
        _cachedPredictEndpoint = await _configRepo.GetValueAsync("predict_endpoint", ct) ?? "/predict";
        _cachedBatchEndpoint   = await _configRepo.GetValueAsync("batch_endpoint", ct)   ?? "/predict/batch";
        _cachedMaxBatch        = int.TryParse(
            await _configRepo.GetValueAsync("max_batch_size", ct), out var mb) ? mb : 500;

        _cacheExpiry = DateTime.UtcNow + _cacheTtl;
        _logger.LogInformation("AI config (ngrok): {url}", _cachedBaseUrl);
    }

    private async Task<bool> IsReachableAsync(string baseUrl, CancellationToken ct)
    {
        try
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.CancelAfter(TimeSpan.FromSeconds(2));
            var resp = await _http.GetAsync($"{baseUrl}/health", cts.Token);
            return resp.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    // ── Public API ────────────────────────────────────────────────────────────
    public async Task<bool> HealthCheckAsync(CancellationToken ct = default)
    {
        try
        {
            await LoadConfigAsync(ct);
            var response = await _http.GetAsync($"{_cachedBaseUrl}/health", ct);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "AI health check thất bại.");
            return false;
        }
    }

    public async Task<AIPredictionResult> PredictSingleAsync(
        AccountFeatureInput input, CancellationToken ct = default)
    {
        await LoadConfigAsync(ct);

        var payload = BuildPayload(input);
        _logger.LogDebug("POST {url}{ep}", _cachedBaseUrl, _cachedPredictEndpoint);

        var response = await _http.PostAsJsonAsync(
            $"{_cachedBaseUrl}{_cachedPredictEndpoint}", payload, _jsonOpts, ct);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync(ct);
            _logger.LogError("AI API lỗi {code}: {body}", response.StatusCode, err);
            throw new HttpRequestException($"AI API lỗi [{response.StatusCode}]: {err}");
        }

        var body = await response.Content.ReadFromJsonAsync<AIPredictResponse>(_jsonOpts, ct)
            ?? throw new InvalidDataException("AI API trả về body rỗng.");

        if (!body.Success || body.Result is null)
            throw new InvalidDataException($"AI API báo lỗi: {body.Error}");

        return MapToResult(body.Result);
    }

    public async Task<BatchPredictionResult> PredictBatchAsync(
        IEnumerable<AccountFeatureInput> inputs, CancellationToken ct = default)
    {
        await LoadConfigAsync(ct);

        var inputList = inputs.ToList();
        if (inputList.Count > _cachedMaxBatch!.Value)
            throw new ArgumentException(
                $"Batch vượt giới hạn {_cachedMaxBatch} accounts/request.");

        var payload  = new { accounts = inputList.Select(BuildPayload).ToList() };
        var response = await _http.PostAsJsonAsync(
            $"{_cachedBaseUrl}{_cachedBatchEndpoint}", payload, _jsonOpts, ct);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync(ct);
            throw new HttpRequestException($"AI Batch API lỗi [{response.StatusCode}]: {err}");
        }

        var body = await response.Content.ReadFromJsonAsync<BatchPredictResponse>(_jsonOpts, ct)
            ?? throw new InvalidDataException("AI Batch API trả về body rỗng.");

        return new BatchPredictionResult(
            body.Total, body.SpamCount, body.RealCount, body.ErrorCount,
            body.Results.Select(r => new SingleBatchResult(
                r.Index,
                r.Label == "spam" ? PredictionLabel.Spam
                    : r.Label == "real" ? PredictionLabel.Real
                    : PredictionLabel.Unknown,
                (decimal)r.Confidence,
                r.Error
            ))
        );
    }

    // ── Helpers ───────────────────────────────────────────────────────────────
    private static Dictionary<string, object> BuildPayload(AccountFeatureInput i) => new()
    {
        ["followers_count"]       = i.FollowersCount,
        ["friends_count"]         = i.FriendsCount,
        ["statuses_count"]        = i.StatusesCount,
        ["listed_count"]          = i.ListedCount,
        ["favourites_count"]      = i.FavouritesCount,
        ["verified"]              = i.Verified,
        ["default_profile"]       = i.DefaultProfile,
        ["default_profile_image"] = i.DefaultProfileImage,
        ["geo_enabled"]           = i.GeoEnabled,
        ["account_age_days"]      = i.AccountAgeDays,
        ["name_length"]           = i.NameLength,
        ["desc_length"]           = i.DescLength
    };

    private static AIPredictionResult MapToResult(AIPredictData r)
    {
        var label = r.Label == "spam" ? PredictionLabel.Spam
                  : r.Label == "real" ? PredictionLabel.Real
                  : PredictionLabel.Unknown;
        return new AIPredictionResult(
            label,
            (decimal)r.Confidence,
            (decimal)r.ProbReal,
            (decimal)r.ProbSpam,
            r.FeatureCols ?? [],
            r.FeatureVector ?? []
        );
    }

    // ── Private DTOs ──────────────────────────────────────────────────────────
    private sealed class AIPredictResponse
    {
        public bool         Success { get; set; }
        public AIPredictData? Result { get; set; }
        public string?      Error   { get; set; }
    }

    private sealed class AIPredictData
    {
        public string   Label         { get; set; } = "unknown";
        public double   Confidence    { get; set; }
        public double   ProbReal      { get; set; }
        public double   ProbSpam      { get; set; }
        public string[]? FeatureCols  { get; set; }
        public double[]? FeatureVector { get; set; }
    }

    private sealed class BatchPredictResponse
    {
        public bool               Success    { get; set; }
        public int                Total      { get; set; }
        public int                SpamCount  { get; set; }
        public int                RealCount  { get; set; }
        public int                ErrorCount { get; set; }
        public List<BatchResultItem> Results { get; set; } = [];
    }

    private sealed class BatchResultItem
    {
        public int     Index      { get; set; }
        public string  Label      { get; set; } = "unknown";
        public double  Confidence { get; set; }
        public string? Error      { get; set; }
    }
}