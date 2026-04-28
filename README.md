# 🤖 Spambot Detection — Twitter Bot Detection System

Hệ thống phát hiện tài khoản Spam Bot trên Twitter sử dụng mô hình **Hybrid GAT + MLP** (Graph Attention Network + Multilayer Perceptron).

> **Đồ Án 2** · Trường Đại Học Sư Phạm Kỹ Thuật Hưng Yên · Khoa Công Nghệ Thông Tin  
> Dataset: Cresci-2017 · Framework: PyTorch Geometric · GPU T4

---

## 📋 Mục Lục

- [Giới Thiệu](#giới-thiệu)
- [Kết Quả Mô Hình](#kết-quả-mô-hình)
- [Kiến Trúc Hệ Thống](#kiến-trúc-hệ-thống)
- [Cài Đặt & Khởi Động](#cài-đặt--khởi-động)
- [Hướng Dẫn Sử Dụng](#hướng-dẫn-sử-dụng)
- [API Documentation](#api-documentation)
- [Cơ Sở Dữ Liệu](#cơ-sở-dữ-liệu)
- [Dataset](#dataset)
- [Cấu Trúc Thư Mục](#cấu-trúc-thư-mục)

---

## Giới Thiệu

Spam bot trên Twitter gây ra nhiều hậu quả nghiêm trọng: lan truyền tin giả, thao túng xu hướng, ảnh hưởng đến trải nghiệm người dùng và làm sai lệch dữ liệu phân tích quảng cáo. Hệ thống này xây dựng một pipeline học máy hoàn chỉnh để **tự động phân loại tài khoản Bot/Human** dựa trên:

- **Đặc trưng hành vi cá nhân** (tweet rate, account age, follower ratio, ...)
- **Cấu trúc đồ thị xã hội** (bot thường follow bot — graph homophily)

Mô hình đề xuất **GAT + MLP** kết hợp hai nguồn thông tin trên trong một kiến trúc hybrid duy nhất, vượt trội so với baseline GCN trên mọi chỉ số.

---

## Kết Quả Mô Hình

| Model | Accuracy | AUC-ROC | F1 Macro | Bot Recall | Params | Epochs |
|---|---|---|---|---|---|---|
| GCN (Baseline) | 95.79% | 0.9909 | 0.9442 | 0.96 | 4,354 | 358 (early stop) |
| **GAT+MLP (Proposed) ★** | **97.46%** | **0.9944** | **0.9657** | **0.98** | **9,798** | **700** |

**★ GAT+MLP vượt GCN:** +1.67% Accuracy · +0.0035 AUC-ROC · +0.0215 F1 Macro · +0.02 Bot Recall

### Chi tiết GAT+MLP (Test Set)

| Class | Precision | Recall | F1 |
|---|---|---|---|
| Human | 0.94 | 0.96 | 0.95 |
| Bot | 0.99 | 0.98 | 0.98 |

---

## Kiến Trúc Hệ Thống

Hệ thống được thiết kế theo mô hình **Hybrid Cloud Architecture**:

```
┌─────────────────┐      ┌──────────────┐      ┌─────────────────────┐
│  Client (WinForms)│ ──► │ Ngrok Tunnel │ ──►  │ AI Server (Colab)   │
│  C# / .NET       │      │  (Bridge)    │      │ Flask + GAT+MLP     │
│  SQLite DB       │ ◄──  │              │ ◄──  │ PyTorch Geometric   │
└─────────────────┘      └──────────────┘      └─────────────────────┘
```

| Thành Phần | Công Nghệ | Chức Năng |
|---|---|---|
| Client (WinForms) | C# / .NET | Giao diện người dùng, quản lý phiên |
| Communication | Ngrok Tunnel | Kết nối Client ↔ Server qua Internet |
| AI Server | Google Colab + Flask | Chạy mô hình GAT+MLP, trả kết quả |
| Cơ sở dữ liệu | SQLite | Lưu lịch sử quét, blacklist, users |

### Kiến Trúc Mô Hình GAT+MLP

```
Node features (14)
       │
       ├──────────────────────────────┐
       │                              │
  GAT Layer 1                   MLP Branch
  (8 heads)                          │
       │                             │
  GAT Layer 2                        │
  (song song)                        │
       │                             │
       └──────── Concat + Fusion ────┘
                        │
                   P(Bot) ∈ [0,1]
```

---

## Cài Đặt & Khởi Động

### Yêu Cầu Hệ Thống

- **OS:** Windows 10 / 11 (64-bit)
- **RAM:** Tối thiểu 4 GB (khuyến nghị 8 GB)
- **Ổ cứng:** Tối thiểu 500 MB trống
- **Internet:** Bắt buộc (giao tiếp với Colab qua Ngrok)
- **Runtime:** .NET Framework 4.8 hoặc .NET 6+

### Bước 1 — Khởi Động AI Server (Google Colab)

> ⚠️ **Bắt buộc làm trước khi mở ứng dụng Client.**

1. Mở file `deploy_api_fixed.ipynb` trên Google Colab.
2. Chạy tất cả cell theo thứ tự: **Runtime → Run All**.
3. Chờ đến khi xuất hiện dòng:
   ```
   Running on public URL: https://xxxx.ngrok-free.app
   ```
4. Sao chép toàn bộ URL Ngrok đó.

> 💡 **Lưu ý:** URL Ngrok thay đổi mỗi lần khởi động lại Colab. Cần cập nhật lại trong phần Cấu hình (UC05) sau mỗi lần reset.

### Bước 2 — Cài Đặt Ứng Dụng Client

1. Giải nén `SpambotDetection_Backend.zip` vào thư mục mong muốn.
2. Chạy file `SpambotDetection.Client.exe`.
3. Lần đầu chạy, hệ thống tự động tạo database SQLite.
4. Màn hình đăng nhập sẽ hiện ra.

### Tài Khoản Mặc Định

| Vai Trò | Tên Đăng Nhập | Mật Khẩu |
|---|---|---|
| Admin | `admin` | `admin123` |
| User | `user` | `user123` |

> ⚠️ Nên đổi mật khẩu sau lần đăng nhập đầu tiên.

---

## Hướng Dẫn Sử Dụng

### Danh Sách Use Case

| Mã UC | Tên Chức Năng | Phân Quyền |
|---|---|---|
| UC01 | Đăng nhập | User / Admin |
| UC02 | Kiểm tra tài khoản đơn lẻ | User / Admin |
| UC03 | Quét hàng loạt từ file CSV | User / Admin |
| UC04 | Quản lý Blacklist | Admin only |
| UC05 | Cấu hình API Endpoint | Admin only |
| UC06 | Xem báo cáo thống kê | Admin only |

### UC02 — Kiểm Tra Tài Khoản Đơn Lẻ

Nhập các thông số tài khoản cần kiểm tra:

| Trường | Kiểu | Mô Tả |
|---|---|---|
| `accountName` | string | Tên tài khoản |
| `followersCount` | int ≥ 0 | Số người theo dõi |
| `friendsCount` | int ≥ 0 | Số tài khoản đang follow |
| `statusesCount` | int ≥ 0 | Tổng số tweet đã đăng |
| `listedCount` | int ≥ 0 | Số list chứa tài khoản |
| `favouritesCount` | int ≥ 0 | Số tweet đã like |
| `verified` | 0\|1 | Xác minh chính thức |
| `defaultProfile` | 0\|1 | Dùng profile mặc định |
| `defaultProfileImage` | 0\|1 | Dùng avatar mặc định |
| `geoEnabled` | 0\|1 | Bật định vị |
| `accountAgeDays` | int | Tuổi tài khoản (ngày) |
| `nameLength` | int | Độ dài tên |
| `descLength` | int | Độ dài phần mô tả |

**Kết quả trả về:**
- 🔴 **Spambot** — tài khoản có khả năng cao là bot tự động
- 🟢 **Real** — tài khoản có vẻ là người thật
- Độ tin cậy (%): dưới 60% → cần kiểm tra thêm bằng tay

### UC03 — Quét Hàng Loạt từ CSV

File CSV cần có header với các cột:

```
accountName, followersCount, friendsCount, statusesCount, listedCount,
favouritesCount, verified, defaultProfile, defaultProfileImage,
geoEnabled, accountAgeDays, nameLength, descLength
```

Sau khi quét xong, nhấn **"Xuất kết quả"** để lưu file CSV mới có thêm cột `Prediction` và `Confidence`.

---

## API Documentation

Base URL: `https://<ngrok-url>/api`  
Authentication: JWT Bearer Token

### Endpoints Tổng Quan

#### Auth
| Method | Endpoint | Mô Tả |
|---|---|---|
| POST | `/auth/login` | Đăng nhập, trả về JWT |
| POST | `/auth/register` | Đăng ký tài khoản mới |

#### Scan
| Method | Endpoint | Mô Tả |
|---|---|---|
| POST | `/scan/single` | Kiểm tra tài khoản đơn lẻ |
| POST | `/scan/batch/csv` | Quét danh sách từ file CSV |
| GET | `/scan/history` | Lấy lịch sử scan (paginated) |
| PATCH | `/scan/history/{id}/note` | Cập nhật ghi chú scan |
| DELETE | `/scan/history/{id}` | Xóa bản ghi scan *(Admin)* |

#### Blacklist
| Method | Endpoint | Mô Tả |
|---|---|---|
| GET | `/blacklist` | Lấy danh sách đen (paginated) |
| GET | `/blacklist/check/{accountId}` | Kiểm tra tài khoản trong blacklist |
| POST | `/blacklist` | Thêm vào blacklist *(Admin)* |
| POST | `/blacklist/promote` | Promote scan result lên blacklist *(Admin)* |
| PATCH | `/blacklist/{id}` | Cập nhật lý do *(Admin)* |
| DELETE | `/blacklist/{id}` | Xóa mềm khỏi blacklist *(Admin)* |

#### Config & Stats
| Method | Endpoint | Mô Tả |
|---|---|---|
| GET | `/config` | Lấy tất cả config |
| PUT | `/config/{key}` | Cập nhật config *(Admin)* |
| GET | `/config/health` | Kiểm tra kết nối AI server |
| GET | `/statistics` | Xem báo cáo thống kê |

### Ví Dụ — Scan Đơn Lẻ

**Request:**
```json
POST /api/scan/single
{
  "accountName": "suspicious_user",
  "followersCount": 12,
  "friendsCount": 980,
  "statusesCount": 45000,
  "listedCount": 0,
  "favouritesCount": 0,
  "verified": 0,
  "defaultProfile": 1,
  "defaultProfileImage": 1,
  "geoEnabled": 0,
  "accountAgeDays": 30,
  "nameLength": 14,
  "descLength": 0
}
```

**Response:**
```json
{
  "success": true,
  "data": {
    "scanId": "uuid",
    "accountName": "suspicious_user",
    "prediction": "spam",
    "confidence": 0.982,
    "probSpam": 0.982,
    "probReal": 0.018,
    "scanSource": "single",
    "isBlacklisted": false,
    "scannedAt": "2025-01-01T00:00:00Z"
  }
}
```

---

## Cơ Sở Dữ Liệu

Hệ thống sử dụng **SQLite** (embedded, không cần cài đặt thêm).

```
Users (1) ──────── (n) ScanHistory
                              │
                         (n) ──── (1) Blacklist
```

| Bảng | Mô Tả |
|---|---|
| `Users` | Tài khoản hệ thống (UserID, Username, PasswordHash, Role) |
| `ScanHistory` | Lịch sử quét (ScanID, AccountName, Prediction, Confidence, Timestamp) |
| `Blacklist` | Danh sách tài khoản bot đã xác nhận (BotID, AccountID, Reason, AddedDate) |

---

## Dataset

**Cresci-2017** — Dataset chuẩn benchmark cho bài toán Twitter Bot Detection.

| Subset | Loại | Số Users | Nhãn |
|---|---|---|---|
| genuine_accounts | Người dùng thật | 3,474 | 0 (Human) |
| social_spambots_1 | Bot bầu cử Ý 2014 | 1,000 | 1 (Bot) |
| social_spambots_2 | Bot spam ứng dụng di động | 431 | 1 (Bot) |
| social_spambots_3 | Bot spam sản phẩm Amazon | 372 | 1 (Bot) |
| traditional_spambots (1–4) | Bot spam URL, việc làm | ~2,550 | 1 (Bot) |
| fake_followers | Bot mua follow | 3,351 | 1 (Bot) |
| **TỔNG** | | **~9,628** | 64% Bot / 36% Human |

**14 Features được sử dụng:**
`followers_count`, `friends_count`, `statuses_count`, `listed_count`, `favourites_count`, `verified`, `default_profile`, `default_profile_image`, `geo_enabled`, `account_age_days`, `tweet_rate`, `follower_friend_ratio`, `name_length`, `desc_length`

**Graph:**
- Loại: KNN (K=10) dựa trên feature similarity (Euclidean)
- Nodes: 14,368 · Edges: 191,050 · Homophily: 0.929

**Split:** Train 60% / Val 20% / Test 20% (stratified)

---

## Cấu Trúc Thư Mục

```
SpambotDetection/
├── Client/                         # WinForms C# application
│   ├── SpambotDetection.Client.exe
│   ├── SpambotDetection.db         # SQLite database (auto-created)
│   └── ...
├── Server/                         # Google Colab AI backend
│   ├── deploy_api_fixed.ipynb      # Notebook khởi động server
│   ├── model/
│   │   ├── gat_mlp_model.pt        # Trained GAT+MLP weights
│   │   └── scaler.pkl              # StandardScaler fitted on training data
│   └── app.py                      # Flask API
├── notebooks/
│   ├── train_gat_mlp.ipynb         # Training notebook
│   └── train_gcn_baseline.ipynb    # GCN baseline notebook
└── README.md
```

---

## Tham Khảo

- Cresci, S. et al. (2017). *Social Fingerprinting: Detection of Spambot Groups Through DNA-Inspired Behavioral Modeling.* IEEE TKDE.
- Veličković, P. et al. (2018). *Graph Attention Networks.* ICLR.
- PyTorch Geometric: https://pyg.org
- Dataset: [Indiana University Bot Repository](https://botometer.osome.iu.edu/bot-repository/)

---

*Đồ Án 2 · Khoa CNTT · ĐHSPKT Hưng Yên · 2024–2025*
