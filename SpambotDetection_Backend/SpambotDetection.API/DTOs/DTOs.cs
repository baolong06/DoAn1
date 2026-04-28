using FluentValidation;
using SpambotDetection.Core.Enums;

namespace SpambotDetection.API.DTOs;

// ── AUTH ──────────────────────────────────────────────────────
public record LoginRequest(string Username, string Password);
public record LoginResponse(string AccessToken, string? RefreshToken, UserDto User);
public record RegisterRequest(string Username, string Password, string? DisplayName);

// ── USER ──────────────────────────────────────────────────────
public record UserDto(Guid Id, string Username, string? DisplayName, string Role, bool IsActive, DateTime CreatedAt);

// ── ACCOUNT FEATURES ──────────────────────────────────────────
public record AccountFeaturesRequest
{
    public string AccountName { get; init; } = string.Empty;
    public double FollowersCount { get; init; }
    public double FriendsCount { get; init; }
    public double StatusesCount { get; init; }
    public double ListedCount { get; init; }
    public double FavouritesCount { get; init; }
    public int Verified { get; init; }
    public int DefaultProfile { get; init; }
    public int DefaultProfileImage { get; init; }
    public int GeoEnabled { get; init; }
    public double AccountAgeDays { get; init; }
    public double NameLength { get; init; }
    public double DescLength { get; init; }
    public string? Note { get; init; }
}

public class AccountFeaturesValidator : AbstractValidator<AccountFeaturesRequest>
{
    public AccountFeaturesValidator()
    {
        RuleFor(x => x.AccountName).NotEmpty().MaximumLength(150);
        RuleFor(x => x.AccountAgeDays).GreaterThan(0).WithMessage("AccountAgeDays phải > 0");
        RuleFor(x => x.FollowersCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.FriendsCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.StatusesCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Verified).InclusiveBetween(0, 1);
        RuleFor(x => x.DefaultProfile).InclusiveBetween(0, 1);
        RuleFor(x => x.DefaultProfileImage).InclusiveBetween(0, 1);
        RuleFor(x => x.GeoEnabled).InclusiveBetween(0, 1);
    }
}

// ── SCAN RESULTS ──────────────────────────────────────────────
public record ScanResultDto(
    Guid ScanId,
    string AccountName,
    string Prediction,
    decimal Confidence,
    decimal? ProbSpam,
    decimal? ProbReal,
    string ScanSource,
    string? Note,
    bool IsBlacklisted,
    DateTime ScannedAt,
    string? ScannedByUsername
);

public record BatchScanResponse(
    int Total, int SpamCount, int RealCount, int ErrorCount,
    IEnumerable<ScanResultDto> Results
);

public record PagedResponse<T>(IEnumerable<T> Items, int TotalCount, int Page, int PageSize);

// ── BLACKLIST ──────────────────────────────────────────────────
public record BlacklistDto(
    Guid Id, string AccountId, string? AccountName, string? Reason,
    decimal? ConfidenceAtAdd, bool IsActive, DateTime AddedAt
);

public record AddToBlacklistRequest(string AccountId, string? AccountName, string? Reason);
public record PromoteToBlacklistRequest(Guid ScanId, string? Reason);
public record UpdateBlacklistRequest(string? Reason);

// ── API CONFIG ─────────────────────────────────────────────────
public record ApiConfigDto(string Key, string Value, string? Description, bool IsSensitive, DateTime UpdatedAt);
public record UpdateConfigRequest(string Value);

// ── STATISTICS ────────────────────────────────────────────────
public record StatisticsDto(
    int TotalScans, int TotalSpam, int TotalReal,
    decimal AvgConfidence, int BatchScans, int SingleScans,
    int ScansLast24h, int ActiveBlacklistCount
);

// ── API ERROR ─────────────────────────────────────────────────
public record ApiError(string Code, string Message, object? Details = null);
public record ApiResponse<T>(bool Success, T? Data, ApiError? Error = null);
