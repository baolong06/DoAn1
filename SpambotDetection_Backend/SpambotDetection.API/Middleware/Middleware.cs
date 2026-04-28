using System.Net;
using System.Text.Json;
using SpambotDetection.API.DTOs;

namespace SpambotDetection.API.Middleware;

/// <summary>
/// Bắt toàn bộ unhandled exception, log, và trả về JSON chuẩn.
/// KHÔNG để stack trace lộ ra ngoài production.
/// </summary>
public sealed class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger,
        IHostEnvironment env)
    {
        _next   = next;
        _logger = logger;
        _env    = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        _logger.LogError(ex, "Unhandled exception tại {path}", context.Request.Path);

        context.Response.ContentType = "application/json";

        var (statusCode, code, message) = ex switch
        {
            KeyNotFoundException  => (HttpStatusCode.NotFound,            "NOT_FOUND",          ex.Message),
            UnauthorizedAccessException => (HttpStatusCode.Unauthorized,  "UNAUTHORIZED",       "Không có quyền truy cập."),
            ArgumentException     => (HttpStatusCode.BadRequest,          "BAD_REQUEST",        ex.Message),
            InvalidDataException  => (HttpStatusCode.UnprocessableEntity, "UNPROCESSABLE",      ex.Message),
            InvalidOperationException => (HttpStatusCode.BadRequest,      "INVALID_OPERATION",  ex.Message),
            HttpRequestException  => (HttpStatusCode.ServiceUnavailable,  "AI_UNAVAILABLE",     "Server AI không phản hồi."),
            _                     => (HttpStatusCode.InternalServerError, "INTERNAL_ERROR",     "Lỗi máy chủ nội bộ.")
        };

        context.Response.StatusCode = (int)statusCode;

        object? details = _env.IsDevelopment() ? ex.ToString() : null;
        var response = new ApiResponse<object>(false, null, new ApiError(code, message, details));

        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(json);
    }
}

/// <summary>Log mỗi request với thời gian xử lý.</summary>
public sealed class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next   = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        await _next(context);
        sw.Stop();

        _logger.LogInformation(
            "{method} {path} → {status} ({elapsed}ms)",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            sw.ElapsedMilliseconds);
    }
}
