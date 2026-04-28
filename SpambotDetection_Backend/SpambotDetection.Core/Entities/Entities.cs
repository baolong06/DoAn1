using SpambotDetection.Core.Enums;

namespace SpambotDetection.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public Guid AuthId { get; set; }           // Supabase auth.users.id
    public string Username { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation
    public ICollection<ScanHistory> ScanHistories { get; set; } = [];
    public ICollection<BlacklistEntry> BlacklistEntries { get; set; } = [];
}

public class ScanHistory
{
    public Guid Id { get; set; }
    public Guid? ScannedBy { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public Dictionary<string, object> InputData { get; set; } = [];
    public PredictionLabel Prediction { get; set; } = PredictionLabel.Unknown;
    public decimal Confidence { get; set; }
    public decimal? ProbSpam { get; set; }
    public decimal? ProbReal { get; set; }
    public Dictionary<string, object>? ApiResponse { get; set; }
    public ScanSource ScanSource { get; set; } = ScanSource.Single;
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation
    public User? Scanner { get; set; }
    public BlacklistEntry? BlacklistEntry { get; set; }
}

public class BlacklistEntry
{
    public Guid Id { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public string? AccountName { get; set; }
    public string? Reason { get; set; }
    public decimal? ConfidenceAtAdd { get; set; }
    public Guid? SourceScanId { get; set; }
    public Guid? AddedBy { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime AddedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation
    public ScanHistory? SourceScan { get; set; }
    public User? AddedByUser { get; set; }
}

public class ApiConfig
{
    public Guid Id { get; set; }
    public string ConfigKey { get; set; } = string.Empty;
    public string ConfigValue { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsSensitive { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}
