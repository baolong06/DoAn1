using SpambotDetection.Core.Entities;
using SpambotDetection.Core.Enums;

namespace SpambotDetection.Core.Interfaces;

// ── Repositories ─────────────────────────────────────────────

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<User?> GetByAuthIdAsync(Guid authId, CancellationToken ct = default);
    Task<User?> GetByUsernameAsync(string username, CancellationToken ct = default);
    Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default);
    Task<User> CreateAsync(User user, CancellationToken ct = default);
    Task<User> UpdateAsync(User user, CancellationToken ct = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);
}

public interface IScanHistoryRepository
{
    Task<ScanHistory?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<ScanHistory>> GetByUserAsync(Guid userId, int page, int pageSize, CancellationToken ct = default);
    Task<IEnumerable<ScanHistory>> GetAllAsync(int page, int pageSize, CancellationToken ct = default);
    Task<IEnumerable<ScanHistory>> GetByAccountNameAsync(string accountName, CancellationToken ct = default);
    Task<int> CountByUserAsync(Guid userId, CancellationToken ct = default);
    Task<int> CountAllAsync(CancellationToken ct = default);
    Task<ScanHistory> CreateAsync(ScanHistory scan, CancellationToken ct = default);
    // ✅ MỚI: Bulk insert toàn bộ batch trong 1 lần SaveChanges
    Task<IEnumerable<ScanHistory>> CreateBatchAsync(IEnumerable<ScanHistory> scans, CancellationToken ct = default);
    Task<ScanHistory> UpdateNoteAsync(Guid id, string note, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
    Task<StatisticsSummary> GetStatisticsAsync(CancellationToken ct = default);
}

public interface IBlacklistRepository
{
    Task<BlacklistEntry?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<BlacklistEntry?> GetByAccountIdAsync(string accountId, CancellationToken ct = default);
    Task<IEnumerable<BlacklistEntry>> GetAllActiveAsync(int page, int pageSize, CancellationToken ct = default);
    Task<bool> IsBlacklistedAsync(string accountId, CancellationToken ct = default);
    Task<BlacklistEntry> CreateAsync(BlacklistEntry entry, CancellationToken ct = default);
    Task<BlacklistEntry> UpdateAsync(BlacklistEntry entry, CancellationToken ct = default);
    Task<BlacklistEntry> SoftDeleteAsync(Guid id, CancellationToken ct = default);
    Task<Guid> PromoteFromScanAsync(Guid scanId, string? reason, Guid? adminId, CancellationToken ct = default);
}

public interface IApiConfigRepository
{
    Task<string?> GetValueAsync(string key, CancellationToken ct = default);
    Task<IEnumerable<ApiConfig>> GetAllAsync(CancellationToken ct = default);
    Task<ApiConfig> UpsertAsync(string key, string value, Guid? updatedBy, CancellationToken ct = default);
}

// ── Services ─────────────────────────────────────────────────

public interface IAIService
{
    Task<AIPredictionResult> PredictSingleAsync(AccountFeatureInput input, CancellationToken ct = default);
    Task<BatchPredictionResult> PredictBatchAsync(IEnumerable<AccountFeatureInput> inputs, CancellationToken ct = default);
    Task<bool> HealthCheckAsync(CancellationToken ct = default);
}

public interface IScanService
{
    Task<ScanHistory> ScanSingleAsync(Guid userId, string accountName, AccountFeatureInput features, string? note, CancellationToken ct = default);
    Task<IEnumerable<ScanHistory>> ScanBatchFromCsvAsync(Guid userId, Stream csvStream, CancellationToken ct = default);
}

public interface IAuthService
{
    Task<AuthResult> LoginAsync(string username, string password, CancellationToken ct = default);
    Task<User> RegisterAsync(string username, string password, string? displayName, CancellationToken ct = default);
    Task<bool> ValidateTokenAsync(string token, CancellationToken ct = default);
}

// ── Value Objects / DTOs used in interfaces ──────────────────

public record AccountFeatureInput(
    double FollowersCount,
    double FriendsCount,
    double StatusesCount,
    double ListedCount,
    double FavouritesCount,
    int Verified,
    int DefaultProfile,
    int DefaultProfileImage,
    int GeoEnabled,
    double AccountAgeDays,
    double NameLength,
    double DescLength
);

public record AIPredictionResult(
    PredictionLabel Label,
    decimal Confidence,
    decimal ProbReal,
    decimal ProbSpam,
    string[] FeatureCols,
    double[] FeatureVector
);

public record BatchPredictionResult(
    int Total,
    int SpamCount,
    int RealCount,
    int ErrorCount,
    IEnumerable<SingleBatchResult> Results
);

public record SingleBatchResult(
    int Index,
    PredictionLabel Label,
    decimal Confidence,
    string? Error = null
);

public record AuthResult(
    bool Success,
    string? Token,
    string? RefreshToken,
    User? User,
    string? Error = null
);

public record StatisticsSummary(
    int TotalScans,
    int TotalSpam,
    int TotalReal,
    decimal AvgConfidence,
    int BatchScans,
    int SingleScans,
    int ScansLast24h,
    int ActiveBlacklistCount
);