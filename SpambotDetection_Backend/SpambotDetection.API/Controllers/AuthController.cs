using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpambotDetection.API.DTOs;
using SpambotDetection.Core.Interfaces;

namespace SpambotDetection.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService _auth;

    public AuthController(IAuthService auth) => _auth = auth;

    /// <summary>UC01: Đăng nhập — trả về JWT Supabase token.</summary>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<LoginResponse>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request, CancellationToken ct)
    {
        var result = await _auth.LoginAsync(request.Username, request.Password, ct);

        if (!result.Success || result.User is null)
            return Unauthorized(new ApiResponse<object>(false, null,
                new ApiError("AUTH_FAILED", result.Error ?? "Đăng nhập thất bại.")));

        var userDto = MapUser(result.User);
        return Ok(new ApiResponse<LoginResponse>(true,
            new LoginResponse(result.Token!, result.RefreshToken, userDto)));
    }

    /// <summary>Đăng ký tài khoản mới (User thường).</summary>
    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<UserDto>), 201)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    public async Task<IActionResult> Register(
        [FromBody] RegisterRequest request, CancellationToken ct)
    {
        try
        {
            var user = await _auth.RegisterAsync(request.Username, request.Password, request.DisplayName, ct);
            return CreatedAtAction(nameof(Login), new ApiResponse<UserDto>(true, MapUser(user)));
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new ApiResponse<object>(false, null,
                new ApiError("REGISTER_FAILED", ex.Message)));
        }
    }

    private static UserDto MapUser(Core.Entities.User u) =>
        new(u.Id, u.Username, u.DisplayName, u.Role.ToString().ToLower(), u.IsActive, u.CreatedAt);
}
