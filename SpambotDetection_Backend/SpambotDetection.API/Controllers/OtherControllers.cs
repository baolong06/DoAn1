using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpambotDetection.API.DTOs;
using SpambotDetection.API.Extensions;
using SpambotDetection.Core.Entities;
using SpambotDetection.Core.Interfaces;

namespace SpambotDetection.API.Controllers;

// ──────────────────────────────────────────────────────────────
//  UC04: Quản lý Blacklist
// ──────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
[Authorize]
[Produces("application/json")]
public sealed class BlacklistController : ControllerBase
{
    private readonly IBlacklistRepository _repo;
    public BlacklistController(IBlacklistRepository repo) => _repo = repo;

    /// <summary>Lấy danh sách đen đang hoạt động (paginated).</summary>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<PagedResponse<BlacklistDto>>), 200)]
    public async Task<IActionResult> GetAll(
        [FromQuery] int page = 1, [FromQuery] int pageSize = 50, CancellationToken ct = default)
    {
        pageSize = Math.Clamp(pageSize, 1, 200);
        var entries = await _repo.GetAllActiveAsync(page, pageSize, ct);
        return Ok(new ApiResponse<IEnumerable<BlacklistDto>>(true, entries.Select(Map)));
    }

    /// <summary>Kiểm tra một tài khoản có trong blacklist không.</summary>
    [HttpGet("check/{accountId}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), 200)]
    public async Task<IActionResult> Check(string accountId, CancellationToken ct)
    {
        var result = await _repo.IsBlacklistedAsync(accountId, ct);
        return Ok(new ApiResponse<bool>(true, result));
    }

    /// <summary>Thêm thủ công vào blacklist (Admin).</summary>
    [HttpPost]
    [Authorize(Roles = "admin")]
    [ProducesResponseType(typeof(ApiResponse<BlacklistDto>), 201)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    public async Task<IActionResult> Add([FromBody] AddToBlacklistRequest request, CancellationToken ct)
    {
        if (await _repo.IsBlacklistedAsync(request.AccountId, ct))
            return BadRequest(new ApiResponse<object>(false, null,
                new ApiError("ALREADY_BLACKLISTED", $"AccountId '{request.AccountId}' đã có trong blacklist.")));

        var adminId = User.GetUserId();
        var entry = new BlacklistEntry
        {
            AccountId   = request.AccountId,
            AccountName = request.AccountName,
            Reason      = request.Reason,
            AddedBy     = adminId,
            IsActive    = true
        };
        var created = await _repo.CreateAsync(entry, ct);
        return CreatedAtAction(nameof(GetAll), new ApiResponse<BlacklistDto>(true, Map(created)));
    }

    /// <summary>Promote scan result lên blacklist (Admin) — UC04 via scan.</summary>
    [HttpPost("promote")]
    [Authorize(Roles = "admin")]
    [ProducesResponseType(typeof(ApiResponse<Guid>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    public async Task<IActionResult> Promote([FromBody] PromoteToBlacklistRequest request, CancellationToken ct)
    {
        try
        {
            var adminId = User.GetUserId();
            var id = await _repo.PromoteFromScanAsync(request.ScanId, request.Reason, adminId, ct);
            return Ok(new ApiResponse<Guid>(true, id));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse<object>(false, null, new ApiError("NOT_FOUND", ex.Message)));
        }
    }

    /// <summary>Cập nhật lý do blacklist (Admin).</summary>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "admin")]
    [ProducesResponseType(typeof(ApiResponse<BlacklistDto>), 200)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBlacklistRequest request, CancellationToken ct)
    {
        var entry = await _repo.GetByIdAsync(id, ct);
        if (entry is null)
            return NotFound(new ApiResponse<object>(false, null, new ApiError("NOT_FOUND", $"Entry {id} không tồn tại.")));

        entry.Reason = request.Reason;
        var updated = await _repo.UpdateAsync(entry, ct);
        return Ok(new ApiResponse<BlacklistDto>(true, Map(updated)));
    }

    /// <summary>Xóa mềm khỏi blacklist (Admin).</summary>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "admin")]
    [ProducesResponseType(typeof(ApiResponse<BlacklistDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Remove(Guid id, CancellationToken ct)
    {
        try
        {
            var updated = await _repo.SoftDeleteAsync(id, ct);
            return Ok(new ApiResponse<BlacklistDto>(true, Map(updated)));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse<object>(false, null, new ApiError("NOT_FOUND", ex.Message)));
        }
    }

    private static BlacklistDto Map(BlacklistEntry e) =>
        new(e.Id, e.AccountId, e.AccountName, e.Reason, e.ConfidenceAtAdd, e.IsActive, e.AddedAt);
}

// ──────────────────────────────────────────────────────────────
//  UC05: Cấu hình Endpoint API
// ──────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
[Authorize]
[Produces("application/json")]
public sealed class ConfigController : ControllerBase
{
    private readonly IApiConfigRepository _repo;
    private readonly IAIService _aiSvc;
    public ConfigController(IApiConfigRepository repo, IAIService aiSvc)
    {
        _repo  = repo;
        _aiSvc = aiSvc;
    }

    /// <summary>Lấy tất cả config (sensitive values bị mask).</summary>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<ApiConfigDto>>), 200)]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var configs = await _repo.GetAllAsync(ct);
        var dtos = configs.Select(c => new ApiConfigDto(
            c.ConfigKey,
            c.IsSensitive ? "***" : c.ConfigValue,
            c.Description,
            c.IsSensitive,
            c.UpdatedAt));
        return Ok(new ApiResponse<IEnumerable<ApiConfigDto>>(true, dtos));
    }

    /// <summary>Cập nhật một config key (Admin).</summary>
    [HttpPut("{key}")]
    [Authorize(Roles = "admin")]
    [ProducesResponseType(typeof(ApiResponse<ApiConfigDto>), 200)]
    public async Task<IActionResult> Update(string key, [FromBody] UpdateConfigRequest request, CancellationToken ct)
    {
        var adminId = User.GetUserId();
        var config = await _repo.UpsertAsync(key, request.Value, adminId, ct);
        return Ok(new ApiResponse<ApiConfigDto>(true,
            new ApiConfigDto(config.ConfigKey,
                config.IsSensitive ? "***" : config.ConfigValue,
                config.Description, config.IsSensitive, config.UpdatedAt)));
    }

    /// <summary>Kiểm tra kết nối đến AI server (health check). Ưu tiên localhost:8000.</summary>
    [HttpGet("health")]
    [ProducesResponseType(typeof(ApiResponse<object>), 200)]
    public async Task<IActionResult> CheckHealth(CancellationToken ct)
    {
        // Thử local trước
        bool localOk = false;
        try
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.CancelAfter(TimeSpan.FromSeconds(2));
            var r = await new HttpClient().GetAsync("http://localhost:8000/health", cts.Token);
            localOk = r.IsSuccessStatusCode;
        }
        catch { /* không có local server */ }

        var isAlive = localOk || await _aiSvc.HealthCheckAsync(ct);
        var source  = localOk ? "local (localhost:8000)" : "ngrok (remote)";

        return Ok(new ApiResponse<object>(isAlive,
            new { alive = isAlive, ai_source = source },
            isAlive ? null : new ApiError("AI_UNREACHABLE",
                "Server AI không phản hồi. Hãy chạy start_all.bat hoặc cấu hình Ngrok URL.")));
    }
}

// ──────────────────────────────────────────────────────────────
//  UC06: Xem báo cáo thống kê
// ──────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
[Authorize]
[Produces("application/json")]
public sealed class StatisticsController : ControllerBase
{
    private readonly IScanHistoryRepository _history;
    public StatisticsController(IScanHistoryRepository history) => _history = history;

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<StatisticsDto>), 200)]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var stats = await _history.GetStatisticsAsync(ct);
        return Ok(new ApiResponse<StatisticsDto>(true, new StatisticsDto(
            stats.TotalScans, stats.TotalSpam, stats.TotalReal,
            stats.AvgConfidence, stats.BatchScans, stats.SingleScans,
            stats.ScansLast24h, stats.ActiveBlacklistCount)));
    }
}
