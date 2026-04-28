using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace demo_AI
{
    public partial class ConfigControl : UserControl
    {
        // ════════════════════════════════════════════════════════════
        //  Màu sắc trạng thái
        // ════════════════════════════════════════════════════════════
        private static readonly Color ColorOnline = Color.FromArgb(63, 185, 80);
        private static readonly Color ColorOffline = Color.FromArgb(248, 81, 73);
        private static readonly Color ColorWaiting = Color.FromArgb(210, 153, 34);
        private static readonly Color ColorMuted = Color.FromArgb(68, 76, 86);
        private static readonly Color ColorAccent = Color.FromArgb(0, 212, 170);

        // Giá trị mặc định
        private const string DefaultNgrokUrl = "https://xxxx-xx-xx-xxx-xx.ngrok-free.app";
        private const int DefaultTimeout = 30;
        private const int DefaultRetry = 3;

        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        // ════════════════════════════════════════════════════════════
        //  Constructor
        // ════════════════════════════════════════════════════════════
        public ConfigControl()
        {
            InitializeComponent();
            AttachEvents();
        }

        // ════════════════════════════════════════════════════════════
        //  Gắn events
        // ════════════════════════════════════════════════════════════
        private void AttachEvents()
        {
            this.Load += ConfigControl_Load;
            btnSaveApi.Click += BtnSaveApi_Click;
            btnPingApi.Click += async (s, e) => await PingAiAsync();
            btnResetApi.Click += BtnResetApi_Click;
            btnRefreshStatus.Click += async (s, e) => await PingAiAsync();
            btnSaveDb.Click += BtnSaveDb_Click;
            btnTestDb.Click += BtnTestDb_Click;
            btnBrowseDb.Click += BtnBrowseDb_Click;
            btnClearLog.Click += (s, e) => { txtLog.Clear(); AppendLog("Log đã được xóa."); };
            chkShowApiKey.CheckedChanged += (s, e) =>
                txtApiKey.UseSystemPasswordChar = !chkShowApiKey.Checked;
        }

        // ════════════════════════════════════════════════════════════
        //  Load — đọc config từ App.config / AppSession
        // ════════════════════════════════════════════════════════════
        private async void ConfigControl_Load(object sender, EventArgs e)
        {
            LoadSettings();
            AppendLog("[SYSTEM] ConfigControl khởi động.");
            AppendLog($"[SYSTEM] Người dùng: {AppSession.DisplayName}  ({(AppSession.IsAdmin ? "Admin" : "User")})");
            await PingAiAsync();
        }

        private void LoadSettings()
        {
            // Ngrok URL — đọc từ AppSession (đã load từ App.config khi login)
            txtNgrokUrl.Text = AppSession.ApiBaseUrl;

            // Timeout và Retry từ App.config
            if (int.TryParse(ConfigurationManager.AppSettings["TimeoutSeconds"], out int t) && t > 0)
                nudTimeout.Value = Math.Min((decimal)t, nudTimeout.Maximum);
            else
                nudTimeout.Value = DefaultTimeout;

            if (int.TryParse(ConfigurationManager.AppSettings["RetryCount"], out int r) && r >= 0)
                nudRetry.Value = Math.Min((decimal)r, nudRetry.Maximum);
            else
                nudRetry.Value = DefaultRetry;

            // DB path
            string dbPath = ConfigurationManager.AppSettings["DbPath"] ?? "spambot.db";
            txtDbPath.Text = dbPath;

            // Cập nhật status card URL
            lblStatusUrlVal.Text = AppSession.ApiBaseUrl;
        }

        // ════════════════════════════════════════════════════════════
        //  Lưu cấu hình API + Ngrok
        // ════════════════════════════════════════════════════════════
        private async void BtnSaveApi_Click(object sender, EventArgs e)
        {
            string ngrokUrl = txtNgrokUrl.Text.Trim();

            if (string.IsNullOrEmpty(ngrokUrl) ||
                (!ngrokUrl.StartsWith("http://") && !ngrokUrl.StartsWith("https://")))
            {
                AppendLog("[ERROR] URL không hợp lệ — phải bắt đầu bằng http:// hoặc https://");
                HighlightError(pnlNgrokWrap);
                return;
            }

            ResetHighlight(pnlNgrokWrap);

            btnSaveApi.Enabled = false;
            btnSaveApi.Text = "Đang lưu...";

            try
            {
                // ✅ Luôn gọi localhost:5000 — không dùng ngrokUrl làm base URL
                string localBase = "http://localhost:5000";
                string apiUrl = $"{localBase}/api/config/ngrok_base_url";

                string body = Newtonsoft.Json.JsonConvert.SerializeObject(
                    new { value = ngrokUrl.TrimEnd('/') });
                var requestContent = new System.Net.Http.StringContent(
                    body, System.Text.Encoding.UTF8, "application/json");

                // ✅ Tạo HttpRequestMessage để set Authorization header đúng cách
                var request = new System.Net.Http.HttpRequestMessage(
                    System.Net.Http.HttpMethod.Put, apiUrl)
                {
                    Content = requestContent
                };
                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer", AppSession.AccessToken);

                var resp = await _http.SendAsync(request);

                if (resp.IsSuccessStatusCode)
                {
                    AppendLog($"[SAVE] ✅ Đã cập nhật ngrok_base_url lên server: {ngrokUrl}");
                }
                else
                {
                    string respBody = await resp.Content.ReadAsStringAsync();
                    AppendLog($"[SAVE] ❌ Lưu server thất bại ({(int)resp.StatusCode}): {respBody}");
                    MessageBox.Show(
                        $"Không thể lưu URL lên server ({(int)resp.StatusCode}).\nKiểm tra lại quyền Admin.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                AppendLog($"[SAVE] ❌ Lỗi kết nối server: {ex.Message}");
                MessageBox.Show($"Không thể kết nối server để lưu URL.\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                btnSaveApi.Enabled = true;
                btnSaveApi.Text = "💾  Lưu cấu hình";
            }

            // ✅ KHÔNG ghi ngrokUrl vào AppSession.ApiBaseUrl
            // ApiBaseUrl luôn là localhost:5000 để các API khác hoạt động đúng
            SaveAppSetting("TimeoutSeconds", ((int)nudTimeout.Value).ToString());
            SaveAppSetting("RetryCount", ((int)nudRetry.Value).ToString());

            // Cập nhật status display (hiển thị ngrok URL để user biết đã lưu)
            lblStatusUrlVal.Text = ngrokUrl;

            AppendLog($"[SAVE] Ngrok URL đã lưu lên DB → {ngrokUrl}");
            AppendLog($"[SAVE] Timeout → {(int)nudTimeout.Value}s  |  Retry → {(int)nudRetry.Value} lần");
            AppendLog($"[INFO] ApiBaseUrl vẫn là localhost:5000 — không thay đổi.");

            MessageBox.Show(
                $"Đã lưu Ngrok URL lên server thành công!\n\nURL AI: {ngrokUrl}\nAPI Backend: localhost:5000",
                "Đã lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ════════════════════════════════════════════════════════════
        //  Reset về mặc định
        // ════════════════════════════════════════════════════════════
        private void BtnResetApi_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Khôi phục tất cả cấu hình API về mặc định?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            txtNgrokUrl.Text = DefaultNgrokUrl;
            nudTimeout.Value = DefaultTimeout;
            nudRetry.Value = DefaultRetry;
            txtApiKey.Clear();
            ResetHighlight(pnlNgrokWrap);

            AppendLog("[RESET] Cấu hình API đã được khôi phục về mặc định.");
        }

        // ════════════════════════════════════════════════════════════
        //  Ping AI Service
        // ════════════════════════════════════════════════════════════
        private async Task PingAiAsync()
        {
            string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/health";

            SetStatusChecking();
            AppendLog($"[PING] → {url}");

            var sw = Stopwatch.StartNew();
            try
            {
                // Đặt Authorization header
                if (!_http.DefaultRequestHeaders.Contains("Authorization") &&
                    !string.IsNullOrEmpty(AppSession.AccessToken))
                {
                    _http.DefaultRequestHeaders.Add("Authorization",
                        $"Bearer {AppSession.AccessToken}");
                }

                var resp = await _http.GetAsync(url);
                sw.Stop();
                long ms = sw.ElapsedMilliseconds;

                if (resp.IsSuccessStatusCode)
                {
                    SetStatusOnline(ms);
                    AppendLog($"[PING] ✅ Online — {ms} ms  ({(int)resp.StatusCode} {resp.ReasonPhrase})");

                    // Thử đọc model info từ response
                    try
                    {
                        string body = await resp.Content.ReadAsStringAsync();
                        var json = JObject.Parse(body);
                        string model = json["data"]?["model"]?.ToString()
                                    ?? json["model"]?.ToString()
                                    ?? "GAT + MLP";
                        lblStatusModelVal.Text = model;
                    }
                    catch { /* không bắt buộc */ }
                }
                else
                {
                    sw.Stop();
                    SetStatusOffline();
                    AppendLog($"[PING] ❌ Lỗi {(int)resp.StatusCode} — {resp.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                sw.Stop();
                SetStatusOffline();
                AppendLog($"[PING] ❌ Không thể kết nối: {ex.Message}");
            }
            catch (TaskCanceledException)
            {
                sw.Stop();
                SetStatusOffline();
                AppendLog("[PING] ❌ Timeout — AI Service không phản hồi.");
            }
            catch (Exception ex)
            {
                sw.Stop();
                SetStatusOffline();
                AppendLog($"[PING] ❌ Lỗi: {ex.Message}");
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Status card helpers
        // ════════════════════════════════════════════════════════════
        private void SetStatusChecking()
        {
            SafeInvoke(() =>
            {
                pnlStatusDot.BackColor = ColorWaiting;
                lblStatusLive.Text = "Đang kiểm tra...";
                lblStatusLive.ForeColor = ColorWaiting;
                lblStatusLatencyVal.Text = "—";
                lblStatusLastPingVal.Text = DateTime.Now.ToString("HH:mm:ss");
                btnPingApi.Enabled = false;
                btnRefreshStatus.Enabled = false;
            });
        }

        private void SetStatusOnline(long ms)
        {
            SafeInvoke(() =>
            {
                pnlStatusDot.BackColor = ColorOnline;
                lblStatusLive.Text = "Online";
                lblStatusLive.ForeColor = ColorOnline;
                lblStatusLatencyVal.Text = $"{ms} ms";
                lblStatusLatencyVal.ForeColor = ms < 500 ? ColorOnline
                    : ms < 1500 ? ColorWaiting : ColorOffline;
                lblStatusLastPingVal.Text = DateTime.Now.ToString("HH:mm:ss");
                lblStatusUrlVal.Text = AppSession.ApiBaseUrl;
                btnPingApi.Enabled = true;
                btnRefreshStatus.Enabled = true;
            });
        }

        private void SetStatusOffline()
        {
            SafeInvoke(() =>
            {
                pnlStatusDot.BackColor = ColorOffline;
                lblStatusLive.Text = "Offline";
                lblStatusLive.ForeColor = ColorOffline;
                lblStatusLatencyVal.Text = "—";
                lblStatusLastPingVal.Text = DateTime.Now.ToString("HH:mm:ss");
                btnPingApi.Enabled = true;
                btnRefreshStatus.Enabled = true;
            });
        }

        // ════════════════════════════════════════════════════════════
        //  Lưu DB path
        // ════════════════════════════════════════════════════════════
        private void BtnSaveDb_Click(object sender, EventArgs e)
        {
            string path = txtDbPath.Text.Trim();
            if (string.IsNullOrEmpty(path))
            {
                AppendLog("[ERROR] Đường dẫn DB không được để trống.");
                HighlightError(pnlDbPathWrap);
                return;
            }

            ResetHighlight(pnlDbPathWrap);
            SaveAppSetting("DbPath", path);
            AppendLog($"[SAVE] DbPath → {path}");
            MessageBox.Show("Đã lưu đường dẫn database.\nKhởi động lại ứng dụng để áp dụng.",
                "Đã lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ════════════════════════════════════════════════════════════
        //  Browse DB file
        // ════════════════════════════════════════════════════════════
        private void BtnBrowseDb_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Title = "Chọn file SQLite",
                Filter = "SQLite DB (*.db;*.sqlite)|*.db;*.sqlite|All files (*.*)|*.*",
                CheckFileExists = false
            };

            if (dlg.ShowDialog() == DialogResult.OK)
                txtDbPath.Text = dlg.FileName;

            dlg.Dispose();
        }

        // ════════════════════════════════════════════════════════════
        //  Test DB connection
        // ════════════════════════════════════════════════════════════
        private void BtnTestDb_Click(object sender, EventArgs e)
        {
            string path = txtDbPath.Text.Trim();
            AppendLog($"[DB] Test kết nối → {path}");

            // Gọi API kiểm tra DB health
            _ = TestDbViaApiAsync(path);
        }

        private async Task TestDbViaApiAsync(string path)
        {
            try
            {
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/health/db";
                var resp = await _http.GetAsync(url);

                if (resp.IsSuccessStatusCode)
                {
                    AppendLog("[DB] ✅ Kết nối database OK.");
                    SafeInvoke(() => MessageBox.Show(
                        "Kết nối database thành công!", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information));
                }
                else
                {
                    AppendLog($"[DB] ❌ Lỗi {(int)resp.StatusCode}.");
                    SafeInvoke(() => MessageBox.Show(
                        $"Kết nối thất bại ({(int)resp.StatusCode}).\nKiểm tra lại đường dẫn.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                }
            }
            catch
            {
                // Nếu endpoint không tồn tại → báo không kiểm tra được qua API
                AppendLog("[DB] ℹ️  Không thể kiểm tra qua API — hãy chạy backend và thử lại.");
                SafeInvoke(() => MessageBox.Show(
                    "Không thể kiểm tra qua API.\nHãy đảm bảo backend đang chạy.",
                    "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Log panel
        // ════════════════════════════════════════════════════════════
        private void AppendLog(string message)
        {
            SafeInvoke(() =>
            {
                string line = $"[{DateTime.Now:HH:mm:ss}]  {message}";

                // Chọn màu theo loại log
                Color color;
                if (message.Contains("✅") || message.Contains("[SAVE]") || message.Contains("OK"))
                    color = ColorOnline;
                else if (message.Contains("❌") || message.Contains("[ERROR]"))
                    color = ColorOffline;
                else if (message.Contains("[PING]") || message.Contains("[RESET]"))
                    color = Color.FromArgb(88, 166, 255);
                else if (message.Contains("[SYSTEM]"))
                    color = ColorAccent;
                else
                    color = Color.FromArgb(110, 118, 129);

                int start = txtLog.TextLength;
                txtLog.AppendText(line + "\n");
                txtLog.Select(start, line.Length);
                txtLog.SelectionColor = color;
                txtLog.SelectionLength = 0;
                txtLog.ScrollToCaret();
            });
        }

        // ════════════════════════════════════════════════════════════
        //  Helpers
        // ════════════════════════════════════════════════════════════

        /// <summary>Ghi một key vào App.config (appSettings).</summary>
        private static void SaveAppSetting(string key, string value)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);
                var settings = config.AppSettings.Settings;

                if (settings[key] == null)
                    settings.Add(key, value);
                else
                    settings[key].Value = value;

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch
            {
                // Ghi App.config thất bại (môi trường read-only) → bỏ qua
            }
        }

        private void HighlightError(Panel panel)
            => panel.BackColor = Color.FromArgb(60, 30, 30);

        private void ResetHighlight(Panel panel)
            => panel.BackColor = Color.FromArgb(33, 38, 45);

        private void SafeInvoke(Action action)
        {
            if (IsDisposed) return;
            if (InvokeRequired) Invoke(action);
            else action();
        }
    }
}