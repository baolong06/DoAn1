using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpambotDetection.API.DTOs;
using SpambotDetection.API.Extensions;
using SpambotDetection.Core.Entities;
using SpambotDetection.Core.Interfaces;

namespace SpambotDetection.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[Produces("application/json")]
public sealed class ScanController : ControllerBase
{
    private readonly IScanService _scanSvc;
    private readonly IScanHistoryRepository _history;
    private readonly IBlacklistRepository _blacklist;
    private readonly IValidator<AccountFeaturesRequest> _validator;

    public ScanController(
        IScanService scanSvc,
        IScanHistoryRepository history,
        IBlacklistRepository blacklist,
        IValidator<AccountFeaturesRequest> validator)
    {
        _scanSvc   = scanSvc;
        _history   = history;
        _blacklist = blacklist;
        _validator = validator;
    }

    /// <summary>UC02: Kiểm tra tài khoản đơn lẻ.</summary>
    [HttpPost("single")]
    [ProducesResponseType(typeof(ApiResponse<ScanResultDto>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 503)]
    public async Task<IActionResult> ScanSingle(
        [FromBody] AccountFeaturesRequest request, CancellationToken ct)
    {
        var validation = await _validator.ValidateAsync(request, ct);
        if (!validation.IsValid)
            return BadRequest(new ApiResponse<object>(false, null,
                new ApiError("VALIDATION_ERROR", "Dữ liệu đầu vào không hợp lệ.",
                    validation.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }))));

        var userId = User.GetUserId();
        if (userId is null)
            return Unauthorized();

        try
        {
            var features = request.ToFeatureInput();
            var scan = await _scanSvc.ScanSingleAsync(userId.Value, request.AccountName, features, request.Note, ct);
            var isBlacklisted = await _blacklist.IsBlacklistedAsync(request.AccountName, ct);
            return Ok(new ApiResponse<ScanResultDto>(true, MapScan(scan, isBlacklisted)));
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("ngrok"))
        {
            return StatusCode(503, new ApiResponse<object>(false, null,
                new ApiError("AI_UNAVAILABLE", ex.Message)));
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(503, new ApiResponse<object>(false, null,
                new ApiError("AI_ERROR", $"Server AI không phản hồi: {ex.Message}")));
        }
    }

    /// <summary>UC03: Quét danh sách từ file CSV.</summary>
    [HttpPost("batch/csv")]
    [ProducesResponseType(typeof(ApiResponse<BatchScanResponse>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    public async Task<IActionResult> ScanBatchCsv(
        IFormFile file, CancellationToken ct)
    {
        if (file is null || file.Length == 0)
            return BadRequest(new ApiResponse<object>(false, null,
                new ApiError("FILE_EMPTY", "File CSV không được rỗng.")));

        if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            return BadRequest(new ApiResponse<object>(false, null,
                new ApiError("INVALID_FILE", "Chỉ chấp nhận file .csv")));

        var userId = User.GetUserId();
        if (userId is null) return Unauthorized();

        try
        {
            using var stream = file.OpenReadStream();
            var scans = (await _scanSvc.ScanBatchFromCsvAsync(userId.Value, stream, ct)).ToList();

            var resultDtos = new List<ScanResultDto>();
            foreach (var scan in scans)
            {
                var isBl = await _blacklist.IsBlacklistedAsync(scan.AccountName, ct);
                resultDtos.Add(MapScan(scan, isBl));
            }

            return Ok(new ApiResponse<BatchScanResponse>(true, new BatchScanResponse(
                scans.Count,
                scans.Count(s => s.Prediction == Core.Enums.PredictionLabel.Spam),
                scans.Count(s => s.Prediction == Core.Enums.PredictionLabel.Real),
                scans.Count(s => s.Prediction == Core.Enums.PredictionLabel.Unknown),
                resultDtos
            )));
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(new ApiResponse<object>(false, null,
                new ApiError("CSV_PARSE_ERROR", ex.Message)));
        }
    }

    /// <summary>Lấy lịch sử scan của user hiện tại (paginated).</summary>
    [HttpGet("history")]
    [ProducesResponseType(typeof(ApiResponse<PagedResponse<ScanResultDto>>), 200)]
    public async Task<IActionResult> GetMyHistory(
        [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        pageSize = Math.Clamp(pageSize, 1, 100);
        var userId = User.GetUserId();
        if (userId is null) return Unauthorized();

        var isAdmin = User.IsInRole("admin");
        IEnumerable<ScanHistory> scans;
        int total;

        if (isAdmin)
        {
            scans = await _history.GetAllAsync(page, pageSize, ct);
            total = await _history.CountAllAsync(ct);
        }
        else
        {
            scans = await _history.GetByUserAsync(userId.Value, page, pageSize, ct);
            total = await _history.CountByUserAsync(userId.Value, ct);
        }

        var dtos = new List<ScanResultDto>();
        foreach (var s in scans)
        {
            var isBl = await _blacklist.IsBlacklistedAsync(s.AccountName, ct);
            dtos.Add(MapScan(s, isBl));
        }

        return Ok(new ApiResponse<PagedResponse<ScanResultDto>>(true,
            new PagedResponse<ScanResultDto>(dtos, total, page, pageSize)));
    }

    /// <summary>Cập nhật ghi chú cho một lần scan (luồng phụ UC02).</summary>
    [HttpPatch("history/{id:guid}/note")]
    [ProducesResponseType(typeof(ApiResponse<ScanResultDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateNote(
        Guid id, [FromBody] string note, CancellationToken ct)
    {
        try
        {
            var updated = await _history.UpdateNoteAsync(id, note, ct);
            var isBl = await _blacklist.IsBlacklistedAsync(updated.AccountName, ct);
            return Ok(new ApiResponse<ScanResultDto>(true, MapScan(updated, isBl)));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse<object>(false, null, new ApiError("NOT_FOUND", ex.Message)));
        }
    }

    /// <summary>Admin xóa một bản ghi scan (audit trail — chỉ admin).</summary>
    [HttpDelete("history/{id:guid}")]
    [Authorize(Roles = "admin")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteScan(Guid id, CancellationToken ct)
    {
        try
        {
            await _history.DeleteAsync(id, ct);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse<object>(false, null, new ApiError("NOT_FOUND", ex.Message)));
        }
    }

    // ── Mapper ────────────────────────────────────────────────
    private static ScanResultDto MapScan(ScanHistory s, bool isBlacklisted) => new(
        s.Id, s.AccountName,
        s.Prediction.ToString().ToLower(),
        s.Confidence, s.ProbSpam, s.ProbReal,
        s.ScanSource.ToString().ToLower(),
        s.Note, isBlacklisted, s.CreatedAt,
        s.Scanner?.Username
    );
}
