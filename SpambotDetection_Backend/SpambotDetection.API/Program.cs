using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using Serilog;
using SpambotDetection.API.DTOs;
using SpambotDetection.API.Middleware;
using SpambotDetection.Core.Enums;
using SpambotDetection.Core.Interfaces;
using SpambotDetection.Infrastructure.Data;
using SpambotDetection.Infrastructure.Repositories;
using SpambotDetection.Infrastructure.Services;
using System.Security.Claims;
using System.Security.Cryptography;

// ─── Serilog bootstrap ────────────────────────────────────────
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // ─── Serilog ─────────────────────────────────────────────
    builder.Host.UseSerilog((ctx, lc) => lc
        .ReadFrom.Configuration(ctx.Configuration)
        .WriteTo.Console());

    // ─── Database: Supabase / PostgreSQL ─────────────────────
    // ✅ Pool settings đã được đưa vào appsettings.json (key-value format)
    var connectionString = builder.Configuration.GetConnectionString("Supabase")
        ?? "Host=aws-1-ap-southeast-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.zsejvpknqpchddkmlqdb;Password=thechienlan1;SSL Mode=Require;Trust Server Certificate=true;Minimum Pool Size=2;Maximum Pool Size=20;Connection Idle Lifetime=60;Keepalive=30";

    var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
    dataSourceBuilder.MapEnum<UserRole>("user_role");
    dataSourceBuilder.MapEnum<PredictionLabel>("prediction_label");
    var dataSource = dataSourceBuilder.Build();

    builder.Services.AddDbContext<AppDbContext>(opts =>
        opts.UseNpgsql(dataSource, npg =>
        {
            npg.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(2), null);
            npg.CommandTimeout(10);
        })
        .UseSnakeCaseNamingConvention());

    // ─── Repositories ─────────────────────────────────────────
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IScanHistoryRepository, ScanHistoryRepository>();
    builder.Services.AddScoped<IBlacklistRepository, BlacklistRepository>();
    builder.Services.AddScoped<IApiConfigRepository, ApiConfigRepository>();

    // ─── HttpClients ──────────────────────────────────────────
    builder.Services.AddHttpClient<IAIService, AIService>(client =>
    {
        client.Timeout = TimeSpan.FromSeconds(
            builder.Configuration.GetValue("AIService:TimeoutSeconds", 30));
        client.DefaultRequestHeaders.Add("ngrok-skip-browser-warning", "true");
    });

    builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
    {
        client.Timeout = TimeSpan.FromSeconds(15);
    });

    // ─── Domain Services ──────────────────────────────────────
    builder.Services.AddScoped<IScanService, ScanService>();

    // ─── FluentValidation ─────────────────────────────────────
    builder.Services.AddScoped<IValidator<AccountFeaturesRequest>, AccountFeaturesValidator>();

    // ─── Authentication: Supabase JWT (ES256 / ECDSA P-256) ──
    var supabaseUrl = builder.Configuration["Supabase:Url"]
        ?? throw new InvalidOperationException("Supabase:Url chua duoc cau hinh trong appsettings.");

    // ✅ Fetch JWKS một lần khi startup → cache signing keys
    // Supabase JWKS: GET {supabaseUrl}/auth/v1/.well-known/jwks.json
    var jwksUri = $"{supabaseUrl}/auth/v1/.well-known/jwks.json";
    List<SecurityKey> jwksKeys;
    {
        using var jwksClient = new HttpClient();
        var jwksJson = jwksClient.GetStringAsync(jwksUri).GetAwaiter().GetResult();
        var jwks = new JsonWebKeySet(jwksJson);
        jwksKeys = jwks.GetSigningKeys().ToList();
        Log.Information("JWKS loaded: {count} key(s) from {uri}", jwksKeys.Count, jwksUri);
    }

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(opts =>
        {
            // ✅ Giữ nguyên tên claim gốc từ JWT (sub, role, ...)
            opts.MapInboundClaims = false;
            opts.RequireHttpsMetadata = true;

            opts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKeys = jwksKeys,   // EC public keys từ Supabase JWKS
                ValidateIssuer = true,
                ValidIssuer = supabaseUrl + "/auth/v1",
                ValidateAudience = false,
                ClockSkew = TimeSpan.FromMinutes(1)
            };

            opts.Events = new JwtBearerEvents
            {
                // ✅ FIX: Query role từ DB thay vì đọc từ JWT
                // Supabase JWT chỉ có role="authenticated", không có "admin"
                OnTokenValidated = async ctx =>
                {
                    var identity = ctx.Principal?.Identity as ClaimsIdentity;
                    if (identity == null) return;

                    // Lấy Supabase user ID từ claim "sub"
                    var sub = ctx.Principal?.FindFirst("sub")?.Value;
                    if (string.IsNullOrEmpty(sub) || !Guid.TryParse(sub, out var authId))
                    {
                        Log.Warning("OnTokenValidated: Khong tim thay claim 'sub' hop le.");
                        return;
                    }

                    // Query role từ bảng public.users theo auth_id
                    var db = ctx.HttpContext.RequestServices
                        .GetRequiredService<AppDbContext>();

                    var user = await db.Users
                        .AsNoTracking()
                        .FirstOrDefaultAsync(u => u.AuthId == authId);

                    if (user == null)
                    {
                        Log.Warning("OnTokenValidated: Khong tim thay user voi AuthId={authId}", authId);
                        return;
                    }

                    // UserRole.Admin → "admin" | UserRole.User → "user"
                    var roleValue = user.Role == UserRole.Admin ? "admin" : "user";
                    identity.AddClaim(new Claim(ClaimTypes.Role, roleValue));
                    // ✅ Lưu internal public.users.id để GetUserId() dùng cho foreign key
                    identity.AddClaim(new Claim("internal_id", user.Id.ToString()));

                    Log.Debug("OnTokenValidated: AuthId={authId} → Role={role}", authId, roleValue);
                },

                OnAuthenticationFailed = ctx =>
                {
                    Log.Warning("JWT auth failed: {err}", ctx.Exception.Message);
                    return Task.CompletedTask;
                }
            };
        });

    // ─── Authorization ────────────────────────────────────────
    builder.Services.AddAuthorizationBuilder()
        .AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));

    // ─── CORS ─────────────────────────────────────────────────
    builder.Services.AddCors(opts =>
        opts.AddDefaultPolicy(p =>
            p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

    // ─── Controllers ──────────────────────────────────────────
    builder.Services.AddControllers()
        .AddJsonOptions(opts =>
        {
            opts.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        });

    // ─── Swagger / OpenAPI ────────────────────────────────────
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Spambot Detection API",
            Version = "v1",
            Description = "Backend API cho he thong phat hien tai khoan Spambot dua tren GAT+MLP."
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Nhap JWT token tu Supabase Auth: Bearer {token}",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme { Reference = new OpenApiReference
                    { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
                Array.Empty<string>()
            }
        });
        var xmlPath = Path.Combine(AppContext.BaseDirectory, "SpambotDetection.API.xml");
        if (File.Exists(xmlPath)) c.IncludeXmlComments(xmlPath);
    });

    // ─── Health Checks ────────────────────────────────────────
    builder.Services.AddHealthChecks()
        .AddNpgSql(connectionString, name: "supabase-db");

    // ═══════════════════════════════════════════════════════════
    var app = builder.Build();
    // ═══════════════════════════════════════════════════════════

    app.UseMiddleware<GlobalExceptionMiddleware>();
    app.UseMiddleware<RequestLoggingMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spambot Detection v1");
            c.RoutePrefix = string.Empty;
        });
    }

    app.UseCors();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
    app.MapHealthChecks("/health");

    // ─── Warm-up DB connection ────────────────────────────────
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var retries = 0;
        const int maxRetries = 5;
        while (retries < maxRetries)
        {
            try
            {
                await db.Database.CanConnectAsync();
                Log.Information("Database connection OK.");
                break;
            }
            catch (Exception ex)
            {
                retries++;
                if (retries >= maxRetries)
                {
                    Log.Error("Khong the ket noi Database sau {n} lan thu: {err}", maxRetries, ex.Message);
                    break;
                }
                Log.Warning("DB connect that bai lan {n}/{max}, thu lai sau 3s... ({err})",
                    retries, maxRetries, ex.Message);
                await Task.Delay(3000);
            }
        }
    }

    Log.Information("Spambot Detection API dang chay tai {urls}", app.Urls);
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "API khoi dong that bai.");
    throw;
}
finally
{
    Log.CloseAndFlush();
}