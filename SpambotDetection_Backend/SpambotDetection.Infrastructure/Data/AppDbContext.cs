using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpambotDetection.Core.Entities;
using SpambotDetection.Core.Enums;
using System.Text.Json;

namespace SpambotDetection.Infrastructure.Data;

/// <summary>
/// EF Core DbContext mapped to Supabase/PostgreSQL schema defined in supabase_schema.sql.
/// Connection: postgresql://postgres.qeytthpoaakymfltnfpt:***@aws-1-ap-northeast-2.pooler.supabase.com:6543/postgres
/// </summary>
public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<ScanHistory> ScanHistories => Set<ScanHistory>();
    public DbSet<BlacklistEntry> Blacklists => Set<BlacklistEntry>();
    public DbSet<ApiConfig> ApiConfigs => Set<ApiConfig>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ── Converters ────────────────────────────────────────
        var jsonOptions = new JsonSerializerOptions();
        var dictConverter = new ValueConverter<Dictionary<string, object>, string>(
            v => JsonSerializer.Serialize(v, jsonOptions),
            v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, jsonOptions) ?? new()
        );
        var dictComparer = new ValueComparer<Dictionary<string, object>>(
            (c1, c2) => JsonSerializer.Serialize(c1, jsonOptions) == JsonSerializer.Serialize(c2, jsonOptions),
            c => JsonSerializer.Serialize(c, jsonOptions).GetHashCode(),
            c => JsonSerializer.Deserialize<Dictionary<string, object>>(JsonSerializer.Serialize(c, jsonOptions), jsonOptions) ?? new()
        );

        // ── USER ──────────────────────────────────────────────
        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("users", "public");
            e.HasKey(u => u.Id);
            e.Property(u => u.Id).HasColumnName("id").HasDefaultValueSql("uuid_generate_v4()");
            e.Property(u => u.AuthId).HasColumnName("auth_id").IsRequired();
            e.Property(u => u.Username).HasColumnName("username").HasMaxLength(50).IsRequired();
            e.Property(u => u.DisplayName).HasColumnName("display_name").HasMaxLength(100);
            e.Property(u => u.Role)
                .HasColumnName("role")
                .HasColumnType("user_role");
            e.Property(u => u.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            e.Property(u => u.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
            e.Property(u => u.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("NOW()");
            e.HasIndex(u => u.AuthId).IsUnique().HasDatabaseName("uq_users_auth_id");
            e.HasIndex(u => u.Username).IsUnique().HasDatabaseName("uq_users_username");
        });

        // ── SCAN HISTORY ──────────────────────────────────────
        modelBuilder.Entity<ScanHistory>(e =>
        {
            e.ToTable("scan_history", "public");
            e.HasKey(s => s.Id);
            e.Property(s => s.Id).HasColumnName("id").HasDefaultValueSql("uuid_generate_v4()");
            e.Property(s => s.ScannedBy).HasColumnName("scanned_by");
            e.Property(s => s.AccountName).HasColumnName("account_name").HasMaxLength(150).IsRequired();
            e.Property(s => s.InputData)
                .HasColumnName("input_data")
                .HasColumnType("jsonb")
                .HasConversion(dictConverter, dictComparer);
            e.Property(s => s.Prediction)
                .HasColumnName("prediction")
                .HasColumnType("prediction_label");
            e.Property(s => s.Confidence)
                .HasColumnName("confidence")
                .HasColumnType("numeric(5,4)");
            e.Property(s => s.ProbSpam)
                .HasColumnName("prob_spam")
                .HasColumnType("numeric(5,4)");
            e.Property(s => s.ProbReal)
                .HasColumnName("prob_real")
                .HasColumnType("numeric(5,4)");
            e.Property(s => s.ApiResponse)
                .HasColumnName("api_response")
                .HasColumnType("jsonb")
                .HasConversion(
                    v => v == null ? "{}" : JsonSerializer.Serialize(v, jsonOptions),
                    v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, jsonOptions)
                );
            e.Property(s => s.ScanSource)
                .HasColumnName("scan_source")
                .HasConversion(
                    v => v == ScanSource.Single ? "single" : v == ScanSource.BatchCsv ? "batch_csv" : "api",
                    v => v == "batch_csv" ? ScanSource.BatchCsv : v == "api" ? ScanSource.Api : ScanSource.Single
                )
                .HasMaxLength(20);
            e.Property(s => s.Note).HasColumnName("note");
            e.Property(s => s.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");

            e.HasOne(s => s.Scanner)
                .WithMany(u => u.ScanHistories)
                .HasForeignKey(s => s.ScannedBy)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // ── BLACKLIST ─────────────────────────────────────────
        modelBuilder.Entity<BlacklistEntry>(e =>
        {
            e.ToTable("blacklist", "public");
            e.HasKey(b => b.Id);
            e.Property(b => b.Id).HasColumnName("id").HasDefaultValueSql("uuid_generate_v4()");
            e.Property(b => b.AccountId).HasColumnName("account_id").HasMaxLength(150).IsRequired();
            e.Property(b => b.AccountName).HasColumnName("account_name").HasMaxLength(150);
            e.Property(b => b.Reason).HasColumnName("reason");
            e.Property(b => b.ConfidenceAtAdd).HasColumnName("confidence_at_add").HasColumnType("numeric(5,4)");
            e.Property(b => b.SourceScanId).HasColumnName("source_scan_id");
            e.Property(b => b.AddedBy).HasColumnName("added_by");
            e.Property(b => b.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            e.Property(b => b.AddedAt).HasColumnName("added_at").HasDefaultValueSql("NOW()");
            e.Property(b => b.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("NOW()");
            e.HasIndex(b => b.AccountId).IsUnique().HasDatabaseName("uq_blacklist_account");

            e.HasOne(b => b.SourceScan)
                .WithOne(s => s.BlacklistEntry)
                .HasForeignKey<BlacklistEntry>(b => b.SourceScanId)
                .OnDelete(DeleteBehavior.SetNull);
            e.HasOne(b => b.AddedByUser)
                .WithMany(u => u.BlacklistEntries)
                .HasForeignKey(b => b.AddedBy)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // ── API CONFIG ────────────────────────────────────────
        modelBuilder.Entity<ApiConfig>(e =>
        {
            e.ToTable("api_config", "public");
            e.HasKey(c => c.Id);
            e.Property(c => c.Id).HasColumnName("id").HasDefaultValueSql("uuid_generate_v4()");
            e.Property(c => c.ConfigKey).HasColumnName("config_key").HasMaxLength(100).IsRequired();
            e.Property(c => c.ConfigValue).HasColumnName("config_value").IsRequired();
            e.Property(c => c.Description).HasColumnName("description");
            e.Property(c => c.IsSensitive).HasColumnName("is_sensitive").HasDefaultValue(false);
            e.Property(c => c.UpdatedBy).HasColumnName("updated_by");
            e.Property(c => c.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("NOW()");
            e.HasIndex(c => c.ConfigKey).IsUnique().HasDatabaseName("uq_config_key");
        });
    }

    /// <summary>
    /// Auto-update UpdatedAt on Save — mirrors Supabase trigger set_updated_at().
    /// </summary>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Modified)
            {
                if (entry.Entity is User u) u.UpdatedAt = now;
                if (entry.Entity is BlacklistEntry b) b.UpdatedAt = now;
                if (entry.Entity is ApiConfig c) c.UpdatedAt = now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
