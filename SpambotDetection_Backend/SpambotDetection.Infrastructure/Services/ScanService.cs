using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using SpambotDetection.Core.Entities;
using SpambotDetection.Core.Enums;
using SpambotDetection.Core.Interfaces;
using System.Globalization;

namespace SpambotDetection.Infrastructure.Services;

public sealed class ScanService : IScanService
{
    private readonly IAIService _ai;
    private readonly IScanHistoryRepository _scans;
    private readonly IBlacklistRepository _blacklist;
    private readonly ILogger<ScanService> _logger;

    public ScanService(
        IAIService ai,
        IScanHistoryRepository scans,
        IBlacklistRepository blacklist,
        ILogger<ScanService> logger)
    {
        _ai = ai;
        _scans = scans;
        _blacklist = blacklist;
        _logger = logger;
    }

    public async Task<ScanHistory> ScanSingleAsync(
        Guid userId, string accountName, AccountFeatureInput features,
        string? note, CancellationToken ct = default)
    {
        _logger.LogInformation("Scanning account {acc} by user {uid}", accountName, userId);

        var result = await _ai.PredictSingleAsync(features, ct);

        var inputData = new Dictionary<string, object>
        {
            ["followers_count"] = features.FollowersCount,
            ["friends_count"] = features.FriendsCount,
            ["statuses_count"] = features.StatusesCount,
            ["listed_count"] = features.ListedCount,
            ["favourites_count"] = features.FavouritesCount,
            ["verified"] = features.Verified,
            ["default_profile"] = features.DefaultProfile,
            ["default_profile_image"] = features.DefaultProfileImage,
            ["geo_enabled"] = features.GeoEnabled,
            ["account_age_days"] = features.AccountAgeDays,
            ["name_length"] = features.NameLength,
            ["desc_length"] = features.DescLength
        };

        var scan = new ScanHistory
        {
            ScannedBy = userId,
            AccountName = accountName,
            InputData = inputData,
            Prediction = result.Label,
            Confidence = result.Confidence,
            ProbSpam = result.ProbSpam,
            ProbReal = result.ProbReal,
            ScanSource = ScanSource.Single,
            Note = note,
            ApiResponse = new Dictionary<string, object>
            {
                ["feature_cols"] = string.Join(",", result.FeatureCols),
                ["feature_vector"] = string.Join(",", result.FeatureVector.Select(v => v.ToString("F4")))
            }
        };

        return await _scans.CreateAsync(scan, ct);
    }

    public async Task<IEnumerable<ScanHistory>> ScanBatchFromCsvAsync(
        Guid userId, Stream csvStream, CancellationToken ct = default)
    {
        var records = ParseCsv(csvStream);
        if (!records.Any())
            throw new InvalidDataException("File CSV không có dữ liệu hoặc format không đúng.");

        _logger.LogInformation("Batch scan {count} accounts by user {uid}", records.Count, userId);

        // ✅ TỐI ƯU 1: Gọi AI 1 lần duy nhất cho toàn bộ batch (thay vì từng record)
        var inputs = records.Select(r => r.ToFeatureInput()).ToList();
        var batchResult = await _ai.PredictBatchAsync(inputs, ct);

        // ✅ TỐI ƯU 2: Build tất cả ScanHistory object trước
        var now = DateTime.UtcNow;
        var scans = records.Zip(batchResult.Results, (rec, res) => new ScanHistory
        {
            ScannedBy = userId,
            AccountName = rec.AccountName ?? $"row_{res.Index}",
            InputData = rec.ToInputDict(),
            Prediction = res.Label,
            Confidence = res.Confidence,
            ProbSpam = res.Label == PredictionLabel.Spam ? res.Confidence : 1 - res.Confidence,
            ProbReal = res.Label == PredictionLabel.Real ? res.Confidence : 1 - res.Confidence,
            ScanSource = ScanSource.BatchCsv,
            CreatedAt = now
        }).ToList();

        // ✅ TỐI ƯU 3: Bulk insert 1 lần SaveChanges thay vì N lần
        return await _scans.CreateBatchAsync(scans, ct);
    }

    // ── CSV Parsing ───────────────────────────────────────────
    private static List<CsvRow> ParseCsv(Stream stream)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            HeaderValidated = null,
            BadDataFound = null,
            PrepareHeaderForMatch = args => args.Header.ToLower()
        };
        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, config);
        csv.Context.RegisterClassMap<CsvRowMap>();
        return csv.GetRecords<CsvRow>().ToList();
    }

    public class CsvRow
    {
        public string? AccountName { get; set; }
        public double FollowersCount { get; set; }
        public double FriendsCount { get; set; }
        public double StatusesCount { get; set; }
        public double ListedCount { get; set; }
        public double FavouritesCount { get; set; }
        public int Verified { get; set; }
        public int DefaultProfile { get; set; }
        public int DefaultProfileImage { get; set; }
        public int GeoEnabled { get; set; }
        public double AccountAgeDays { get; set; }
        public double NameLength { get; set; }
        public double DescLength { get; set; }

        public AccountFeatureInput ToFeatureInput() => new(
            FollowersCount, FriendsCount, StatusesCount, ListedCount,
            FavouritesCount, Verified, DefaultProfile, DefaultProfileImage,
            GeoEnabled, AccountAgeDays, NameLength, DescLength);

        public Dictionary<string, object> ToInputDict() => new()
        {
            ["followers_count"] = FollowersCount,
            ["friends_count"] = FriendsCount,
            ["statuses_count"] = StatusesCount,
            ["listed_count"] = ListedCount,
            ["favourites_count"] = FavouritesCount,
            ["verified"] = Verified,
            ["default_profile"] = DefaultProfile,
            ["default_profile_image"] = DefaultProfileImage,
            ["geo_enabled"] = GeoEnabled,
            ["account_age_days"] = AccountAgeDays,
            ["name_length"] = NameLength,
            ["desc_length"] = DescLength
        };
    }

    public sealed class CsvRowMap : ClassMap<CsvRow>
    {
        public CsvRowMap()
        {
            Map(m => m.AccountName).Name("accountName", "account_name");
            Map(m => m.FollowersCount).Name("followersCount", "followers_count", "follower_count");
            Map(m => m.FriendsCount).Name("friendsCount", "friends_count", "following_count");
            Map(m => m.StatusesCount).Name("statusesCount", "statuses_count", "status_count");
            Map(m => m.ListedCount).Name("listedCount", "listed_count");
            Map(m => m.FavouritesCount).Name("favouritesCount", "favourites_count");
            Map(m => m.Verified).Name("verified");
            Map(m => m.DefaultProfile).Name("defaultProfile", "default_profile");
            Map(m => m.DefaultProfileImage).Name("defaultProfileImage", "default_profile_image");
            Map(m => m.GeoEnabled).Name("geoEnabled", "geo_enabled");
            Map(m => m.AccountAgeDays).Name("accountAgeDays", "account_age_days", "account_age");
            Map(m => m.NameLength).Name("nameLength", "name_length");
            Map(m => m.DescLength).Name("descLength", "desc_length");
        }
    }
}