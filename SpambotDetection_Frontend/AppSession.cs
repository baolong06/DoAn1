using System;

namespace demo_AI
{
    /// <summary>
    /// Lưu thông tin phiên đăng nhập hiện tại (static, tồn tại suốt vòng đời ứng dụng).
    /// Tất cả các Form/Control đều đọc dữ liệu từ đây.
    /// </summary>
    public static class AppSession
    {
        // ── Token ────────────────────────────────────────────────
        public static string AccessToken { get; private set; } = string.Empty;
        public static string RefreshToken { get; private set; } = string.Empty;

        // ── User info ────────────────────────────────────────────
        public static Guid UserId { get; private set; }
        public static string Username { get; private set; } = string.Empty;
        public static string DisplayName { get; private set; } = string.Empty;
        public static string Role { get; private set; } = string.Empty;   // "admin" | "user"

        // ── Computed ─────────────────────────────────────────────
        public static bool IsLoggedIn => !string.IsNullOrEmpty(AccessToken);
        public static bool IsAdmin => Role.Equals("admin", StringComparison.OrdinalIgnoreCase);

        // ── API base URL (đọc từ App.config, có thể bị Admin ghi đè) ──
        private static string _apiBaseUrl = string.Empty;
        public static string ApiBaseUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(_apiBaseUrl)) return _apiBaseUrl;

                // Đọc từ App.config key="ApiBaseUrl", fallback localhost
                _apiBaseUrl = System.Configuration.ConfigurationManager
                                    .AppSettings["ApiBaseUrl"]
                              ?? "http://localhost:5000";
                return _apiBaseUrl;
            }
            set => _apiBaseUrl = value ?? string.Empty;
        }

        // ── Methods ──────────────────────────────────────────────

        /// <summary>Ghi phiên đăng nhập sau khi login thành công.</summary>
        public static void SetSession(
            string accessToken,
            string refreshToken,
            Guid userId,
            string username,
            string displayName,
            string role)
        {
            AccessToken = accessToken ?? string.Empty;
            RefreshToken = refreshToken ?? string.Empty;
            UserId = userId;
            Username = username ?? string.Empty;
            DisplayName = string.IsNullOrEmpty(displayName) ? username : displayName;
            Role = role ?? "user";
        }

        /// <summary>Xóa toàn bộ phiên (logout).</summary>
        public static void Clear()
        {
            AccessToken = string.Empty;
            RefreshToken = string.Empty;
            UserId = Guid.Empty;
            Username = string.Empty;
            DisplayName = string.Empty;
            Role = string.Empty;
        }
    }
}