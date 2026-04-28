using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SpambotDetection.Core.Entities;
using SpambotDetection.Core.Enums;
using SpambotDetection.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpambotDetection.Infrastructure.Services;

/// <summary>
/// Xác thực qua Supabase Auth REST API.
/// Không lưu password trong DB — toàn bộ do Supabase quản lý.
/// JWT từ Supabase được relay về WinForms client.
/// </summary>
public sealed class AuthService : IAuthService
{
    private readonly HttpClient _http;
    private readonly IUserRepository _users;
    private readonly IConfiguration _config;
    private readonly ILogger<AuthService> _logger;

    private string SupabaseUrl => _config["Supabase:Url"]
        ?? throw new InvalidOperationException("Supabase:Url chưa cấu hình.");
    private string SupabaseAnonKey => _config["Supabase:AnonKey"]
        ?? throw new InvalidOperationException("Supabase:AnonKey chưa cấu hình.");

    public AuthService(HttpClient http, IUserRepository users,
        IConfiguration config, ILogger<AuthService> logger)
    {
        _http = http;
        _users = users;
        _config = config;
        _logger = logger;
    }

    public async Task<AuthResult> LoginAsync(string username, string password, CancellationToken ct = default)
    {
        // Lookup user profile to get email (Supabase Auth dùng email)
        var user = await _users.GetByUsernameAsync(username, ct);
        if (user is null)
            return new AuthResult(false, null, null, null, "Tên đăng nhập không tồn tại.");

        if (!user.IsActive)
            return new AuthResult(false, null, null, null, "Tài khoản đã bị vô hiệu hóa.");

        // Call Supabase Auth sign-in endpoint
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"{SupabaseUrl}/auth/v1/token?grant_type=password");
            request.Headers.Add("apikey", SupabaseAnonKey);
            request.Content = JsonContent.Create(new
            {
                email = $"{username}@internal-users.com",  // convention nếu không dùng email thật
                password = password
            });

            var response = await _http.SendAsync(request, ct);
            if (!response.IsSuccessStatusCode)
            {
                var errBody = await response.Content.ReadAsStringAsync(ct);
                _logger.LogWarning("Supabase login failed for {user}: {err}", username, errBody);
                return new AuthResult(false, null, null, null, "Sai mật khẩu.");
            }

            var tokenData = await response.Content
                .ReadFromJsonAsync<SupabaseTokenResponse>(cancellationToken: ct);

            return new AuthResult(true, tokenData?.AccessToken, tokenData?.RefreshToken, user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi kết nối Supabase Auth khi login.");
            return new AuthResult(false, null, null, null, "Không thể kết nối máy chủ xác thực.");
        }
    }

    public async Task<User> RegisterAsync(string username, string password,
    string? displayName, CancellationToken ct = default)
    {
        // 1. Đăng ký trong Supabase Auth
        var request = new HttpRequestMessage(HttpMethod.Post, $"{SupabaseUrl}/auth/v1/signup");
        request.Headers.Add("apikey", SupabaseAnonKey);
        request.Content = JsonContent.Create(new
        {
            email = $"{username}@internal-users.com",
            password = password
        });

        var response = await _http.SendAsync(request, ct);
        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync(ct);
            throw new InvalidOperationException($"Đăng ký Supabase Auth thất bại: {err}");
        }

        var tokenData = await response.Content
            .ReadFromJsonAsync<SupabaseTokenResponse>(cancellationToken: ct)
            ?? throw new InvalidDataException("Supabase signup trả về response rỗng.");

        // Confirm email OFF → id nằm ở root level (tokenData.Id)
        // Confirm email ON  → id nằm trong user object (tokenData.User.Id)
        var authId = tokenData.User?.Id ?? tokenData.Id
            ?? throw new InvalidDataException("Supabase không trả về user ID sau signup.");

        // 2. Lưu profile vào public.users
        var user = new User
        {
            AuthId = authId,
            Username = username,
            DisplayName = displayName,
            Role = UserRole.User,
            IsActive = true
        };

        return await _users.CreateAsync(user, ct);
    }

    public async Task<bool> ValidateTokenAsync(string token, CancellationToken ct = default)
    {
        // Verify JWT signature bằng Supabase JWT secret
        var jwtSecret = _config["Supabase:JwtSecret"];
        if (string.IsNullOrEmpty(jwtSecret)) return false;

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var key     = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
            handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey        = key,
                ValidateIssuer          = false,
                ValidateAudience        = false,
                ClockSkew               = TimeSpan.FromMinutes(1)
            }, out _);
            return true;
        }
        catch
        {
            return false;
        }
    }

    // ── Private DTOs ──────────────────────────────────────────
    private sealed class SupabaseTokenResponse
    {
        [JsonPropertyName("access_token")] public string? AccessToken { get; set; }
        [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }
        [JsonPropertyName("user")] public SupabaseUser? User { get; set; }
        [JsonPropertyName("id")] public Guid? Id { get; set; } // ← thêm
    }

    private sealed class SupabaseUser
    {
        [JsonPropertyName("id")] public Guid Id { get; set; }
    }
}
