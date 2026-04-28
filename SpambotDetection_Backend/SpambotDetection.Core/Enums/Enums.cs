namespace SpambotDetection.Core.Enums;

public enum UserRole
{
    User,
    Admin
}

public enum PredictionLabel
{
    Real,
    Spam,
    Unknown
}

public enum ScanSource
{
    Single,
    BatchCsv,
    Api
}
