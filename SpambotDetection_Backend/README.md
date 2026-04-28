# 🤖 Spambot Detection — ASP.NET Backend

## Kiến trúc tổng quan

```
SpambotDetection/
├── SpambotDetection.Core/              # Domain layer (zero dependencies)
│   ├── Entities/Entities.cs            # User, ScanHistory, BlacklistEntry, ApiConfig
│   ├── Enums/Enums.cs                  # UserRole, PredictionLabel, ScanSource
│   └── Interfaces/Interfaces.cs        # Contracts cho Repositories + Services
│
├── SpambotDetection.Infrastructure/    # Data access + external integrations
│   ├── Data/AppDbContext.cs            # EF Core → Supabase/PostgreSQL
│   ├── Repositories/Repositories.cs   # 4 Repository implementations
│   └── Services/
│       ├── AIService.cs               # HTTP client → Flask/Ngrok AI API
│       ├── ScanService.cs             # Orchestration: scan + persist
│       └── AuthService.cs             # Supabase Auth integration
│
└── SpambotDetection.API/               # Presentation layer (ASP.NET 8)
    ├── Controllers/
    │   ├── AuthController.cs           # UC01: Login / Register
    │   ├── ScanController.cs           # UC02: Single scan | UC03: Batch CSV
    │   └── OtherControllers.cs         # UC04: Blacklist | UC05: Config | UC06: Stats
    ├── DTOs/DTOs.cs                    # Request/Response models + FluentValidation
    ├── Extensions/Extensions.cs        # ClaimsPrincipal helpers
    ├── Middleware/Middleware.cs         # Global exception + request logging
    ├── Program.cs                      # DI registration + pipeline
    └── appsettings.json
```

---

## ⚙️ Cài đặt & Chạy

### 1. Prerequisites

```bash
# .NET 8 SDK
dotnet --version   # >= 8.0

# PostgreSQL client (kiểm tra kết nối)
psql "postgresql://postgres.qeytthpoaakymfltnfpt:***@aws-1-ap-northeast-2.pooler.supabase.com:6543/postgres"
```

### 2. Lấy Supabase keys

Vào [Supabase Dashboard](https://supabase.com/dashboard) → Project Settings → API:
- **Anon Key** → `Supabase:AnonKey`
- **JWT Secret** → `Supabase:JwtSecret` (tab "JWT Settings")
- **Project URL** → `Supabase:Url`

Điền vào `appsettings.json`:
```json
{
  "Supabase": {
    "Url": "https://qeytthpoaakymfltnfpt.supabase.co",
    "AnonKey": "eyJhbGciOiJIUzI1NiIsInR5cCI6...",
    "JwtSecret": "super-secret-jwt-token-with-at-least-32-characters..."
  }
}
```

### 3. Chạy backend

```bash
cd SpambotDetection/SpambotDetection.API
dotnet run
```

API sẽ chạy tại:
- `http://localhost:5000`
- Swagger UI: `http://localhost:5000` (dev mode)

### 4. Cấu hình Ngrok URL qua API (UC05)

Sau khi đăng nhập, Admin gọi:
```http
PUT /api/config/ngrok_base_url
Authorization: Bearer {token}
Content-Type: application/json

"https://repulsive-decussately-vashti.ngrok-free.dev"
```

---

## 📡 API Endpoints

| Method | Path | Auth | Mô tả |
|--------|------|------|-------|
| POST | `/api/auth/login` | ❌ | UC01: Đăng nhập |
| POST | `/api/auth/register` | ❌ | Đăng ký |
| POST | `/api/scan/single` | ✅ | UC02: Scan đơn lẻ |
| POST | `/api/scan/batch/csv` | ✅ | UC03: Scan từ CSV |
| GET  | `/api/scan/history` | ✅ | Lịch sử scan |
| PATCH | `/api/scan/history/{id}/note` | ✅ | Lưu ghi chú |
| DELETE | `/api/scan/history/{id}` | Admin | Xóa scan |
| GET  | `/api/blacklist` | ✅ | UC04: Danh sách đen |
| POST | `/api/blacklist` | Admin | Thêm thủ công |
| POST | `/api/blacklist/promote` | Admin | Promote từ scan |
| DELETE | `/api/blacklist/{id}` | Admin | Xóa mềm |
| GET  | `/api/config` | ✅ | UC05: Xem config |
| PUT  | `/api/config/{key}` | Admin | Cập nhật config |
| GET  | `/api/config/health` | ✅ | Kiểm tra AI server |
| GET  | `/api/statistics` | ✅ | UC06: Thống kê |
| GET  | `/health` | ❌ | Health check DB |

---

## 🔗 Kết nối từ WinForms

WinForms client gọi các endpoint trên qua `HttpClient`:

```csharp
// Ví dụ scan đơn lẻ từ WinForms
var payload = new {
    accountName = txtAccountName.Text,
    followersCount = double.Parse(txtFollowers.Text),
    // ...
};
var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/scan/single", payload);
var result = await response.Content.ReadFromJsonAsync<ApiResponse<ScanResultDto>>();
```

---

## ⚠️ Lưu ý bảo mật

1. **KHÔNG commit** `appsettings.json` có thật lên Git — dùng `dotnet user-secrets` hoặc biến môi trường.
2. Connection string trong code chỉ là fallback — luôn ưu tiên environment variable:
   ```bash
   export ConnectionStrings__Supabase="postgresql://..."
   ```
3. Password trong DB được quản lý hoàn toàn bởi Supabase Auth — backend KHÔNG lưu hash.
4. JWT Secret phải >= 32 ký tự và được giữ bí mật tuyệt đối.
