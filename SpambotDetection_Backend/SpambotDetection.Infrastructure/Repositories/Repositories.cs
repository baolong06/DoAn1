using Microsoft.EntityFrameworkCore;
using SpambotDetection.Core.Entities;
using SpambotDetection.Core.Interfaces;
using SpambotDetection.Infrastructure.Data;

namespace SpambotDetection.Infrastructure.Repositories;

// ── USER REPOSITORY ───────────────────────────────────────────
public sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;
    public UserRepository(AppDbContext db) => _db = db;

    public Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, ct);

    public Task<User?> GetByAuthIdAsync(Guid authId, CancellationToken ct = default)
        => _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.AuthId == authId, ct);

    public Task<User?> GetByUsernameAsync(string username, CancellationToken ct = default)
        => _db.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower(), ct);

    public Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default)
        => _db.Users.AsNoTracking().OrderBy(u => u.Username)
            .ToListAsync(ct).ContinueWith(t => t.Result.AsEnumerable(), ct);

    public async Task<User> CreateAsync(User user, CancellationToken ct = default)
    {
        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        _db.Users.Add(user);
        await _db.SaveChangesAsync(ct);
        return user;
    }

    public async Task<User> UpdateAsync(User user, CancellationToken ct = default)
    {
        _db.Users.Update(user);
        await _db.SaveChangesAsync(ct);
        return user;
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken ct = default)
        => _db.Users.AnyAsync(u => u.Id == id, ct);
}

// ── SCAN HISTORY REPOSITORY ───────────────────────────────────
public sealed class ScanHistoryRepository : IScanHistoryRepository
{
    private readonly AppDbContext _db;
    public ScanHistoryRepository(AppDbContext db) => _db = db;

    public Task<ScanHistory?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => _db.ScanHistories.AsNoTracking()
            .Include(s => s.Scanner)
            .FirstOrDefaultAsync(s => s.Id == id, ct);

    public async Task<IEnumerable<ScanHistory>> GetByUserAsync(Guid userId, int page, int pageSize, CancellationToken ct = default)
        => await _db.ScanHistories.AsNoTracking()
            .Where(s => s.ScannedBy == userId)
            .OrderByDescending(s => s.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(s => s.Scanner)
            .ToListAsync(ct);

    public async Task<IEnumerable<ScanHistory>> GetAllAsync(int page, int pageSize, CancellationToken ct = default)
        => await _db.ScanHistories.AsNoTracking()
            .OrderByDescending(s => s.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(s => s.Scanner)
            .ToListAsync(ct);

    public async Task<IEnumerable<ScanHistory>> GetByAccountNameAsync(string accountName, CancellationToken ct = default)
        => await _db.ScanHistories.AsNoTracking()
            .Where(s => s.AccountName.ToLower() == accountName.ToLower())
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync(ct);

    public Task<int> CountByUserAsync(Guid userId, CancellationToken ct = default)
        => _db.ScanHistories.CountAsync(s => s.ScannedBy == userId, ct);

    public Task<int> CountAllAsync(CancellationToken ct = default)
        => _db.ScanHistories.CountAsync(ct);

    public async Task<ScanHistory> CreateAsync(ScanHistory scan, CancellationToken ct = default)
    {
        scan.CreatedAt = DateTime.UtcNow;
        _db.ScanHistories.Add(scan);
        await _db.SaveChangesAsync(ct);
        return scan;
    }

    public async Task<ScanHistory> UpdateNoteAsync(Guid id, string note, CancellationToken ct = default)
    {
        var scan = await _db.ScanHistories.FindAsync([id], ct)
            ?? throw new KeyNotFoundException($"Scan {id} không tồn tại.");
        scan.Note = note;
        await _db.SaveChangesAsync(ct);
        return scan;
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var scan = await _db.ScanHistories.FindAsync([id], ct)
            ?? throw new KeyNotFoundException($"Scan {id} không tồn tại.");
        _db.ScanHistories.Remove(scan);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<StatisticsSummary> GetStatisticsAsync(CancellationToken ct = default)
    {
        var cutoff = DateTime.UtcNow.AddHours(-24);
        var stats = await _db.ScanHistories
            .GroupBy(_ => 1)
            .Select(g => new
            {
                Total       = g.Count(),
                SpamCount   = g.Count(s => s.Prediction == Core.Enums.PredictionLabel.Spam),
                RealCount   = g.Count(s => s.Prediction == Core.Enums.PredictionLabel.Real),
                AvgConf     = g.Average(s => (double)s.Confidence),
                BatchCount  = g.Count(s => s.ScanSource == Core.Enums.ScanSource.BatchCsv),
                SingleCount = g.Count(s => s.ScanSource == Core.Enums.ScanSource.Single),
                Last24h     = g.Count(s => s.CreatedAt >= cutoff)
            })
            .FirstOrDefaultAsync(ct);

        var blacklistCount = await _db.Blacklists.CountAsync(b => b.IsActive, ct);

        return new StatisticsSummary(
            stats?.Total ?? 0,
            stats?.SpamCount ?? 0,
            stats?.RealCount ?? 0,
            (decimal)(stats?.AvgConf ?? 0),
            stats?.BatchCount ?? 0,
            stats?.SingleCount ?? 0,
            stats?.Last24h ?? 0,
            blacklistCount
        );
    }
    public async Task<IEnumerable<ScanHistory>> CreateBatchAsync(
    IEnumerable<ScanHistory> scans, CancellationToken ct = default)
    {
        var list = scans.ToList();
        var now = DateTime.UtcNow;

        foreach (var scan in list)
            scan.CreatedAt = now;

        // ✅ AddRange + 1 lần SaveChanges = nhanh hơn N lần SaveChanges riêng lẻ
        await _db.ScanHistories.AddRangeAsync(list, ct);
        await _db.SaveChangesAsync(ct);
        return list;
    }
}

// ── BLACKLIST REPOSITORY ──────────────────────────────────────
public sealed class BlacklistRepository : IBlacklistRepository
{
    private readonly AppDbContext _db;
    public BlacklistRepository(AppDbContext db) => _db = db;

    public Task<BlacklistEntry?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => _db.Blacklists.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id, ct);

    public Task<BlacklistEntry?> GetByAccountIdAsync(string accountId, CancellationToken ct = default)
        => _db.Blacklists.AsNoTracking()
            .FirstOrDefaultAsync(b => b.AccountId == accountId && b.IsActive, ct);

    public async Task<IEnumerable<BlacklistEntry>> GetAllActiveAsync(int page, int pageSize, CancellationToken ct = default)
        => await _db.Blacklists.AsNoTracking()
            .Where(b => b.IsActive)
            .OrderByDescending(b => b.AddedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

    public Task<bool> IsBlacklistedAsync(string accountId, CancellationToken ct = default)
        => _db.Blacklists.AnyAsync(b => b.AccountId == accountId && b.IsActive, ct);

    public async Task<BlacklistEntry> CreateAsync(BlacklistEntry entry, CancellationToken ct = default)
    {
        entry.AddedAt = DateTime.UtcNow;
        entry.UpdatedAt = DateTime.UtcNow;
        _db.Blacklists.Add(entry);
        await _db.SaveChangesAsync(ct);
        return entry;
    }

    public async Task<BlacklistEntry> UpdateAsync(BlacklistEntry entry, CancellationToken ct = default)
    {
        _db.Blacklists.Update(entry);
        await _db.SaveChangesAsync(ct);
        return entry;
    }

    public async Task<BlacklistEntry> SoftDeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entry = await _db.Blacklists.FindAsync([id], ct)
            ?? throw new KeyNotFoundException($"Blacklist entry {id} không tồn tại.");
        entry.IsActive = false;
        await _db.SaveChangesAsync(ct);
        return entry;
    }

    public async Task<Guid> PromoteFromScanAsync(Guid scanId, string? reason, Guid? adminId, CancellationToken ct = default)
    {
        var scan = await _db.ScanHistories.FindAsync([scanId], ct)
            ?? throw new KeyNotFoundException($"Scan {scanId} không tồn tại.");

        var existing = await _db.Blacklists
            .FirstOrDefaultAsync(b => b.AccountId == scan.AccountName, ct);

        if (existing is not null)
        {
            existing.IsActive = true;
            existing.Reason = reason ?? "Promoted from scan result";
            existing.ConfidenceAtAdd = scan.Confidence;
            existing.SourceScanId = scanId;
            existing.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync(ct);
            return existing.Id;
        }

        var entry = new BlacklistEntry
        {
            AccountId = scan.AccountName,
            AccountName = scan.AccountName,
            Reason = reason ?? "Promoted from scan result",
            ConfidenceAtAdd = scan.Confidence,
            SourceScanId = scanId,
            AddedBy = adminId,
            IsActive = true,
            AddedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        _db.Blacklists.Add(entry);
        await _db.SaveChangesAsync(ct);
        return entry.Id;
    }
}

// ── API CONFIG REPOSITORY ─────────────────────────────────────
public sealed class ApiConfigRepository : IApiConfigRepository
{
    private readonly AppDbContext _db;
    public ApiConfigRepository(AppDbContext db) => _db = db;

    public async Task<string?> GetValueAsync(string key, CancellationToken ct = default)
    {
        var config = await _db.ApiConfigs.AsNoTracking()
            .FirstOrDefaultAsync(c => c.ConfigKey == key, ct);
        return config?.ConfigValue;
    }

    public async Task<IEnumerable<ApiConfig>> GetAllAsync(CancellationToken ct = default)
        => await _db.ApiConfigs.AsNoTracking().OrderBy(c => c.ConfigKey).ToListAsync(ct);

    public async Task<ApiConfig> UpsertAsync(string key, string value, Guid? updatedBy, CancellationToken ct = default)
    {
        var config = await _db.ApiConfigs.FirstOrDefaultAsync(c => c.ConfigKey == key, ct);
        if (config is null)
        {
            config = new ApiConfig { ConfigKey = key, ConfigValue = value, UpdatedBy = updatedBy, UpdatedAt = DateTime.UtcNow };
            _db.ApiConfigs.Add(config);
        }
        else
        {
            config.ConfigValue = value;
            config.UpdatedBy = updatedBy;
            config.UpdatedAt = DateTime.UtcNow;
        }
        await _db.SaveChangesAsync(ct);
        return config;
    }
}
