using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace demo_AI
{
    public partial class SingleScanControl : UserControl
    {
        // ════════════════════════════════════════════════════════════
        //  Màu sắc
        // ════════════════════════════════════════════════════════════
        private static readonly Color ColorSpam = Color.FromArgb(248, 81, 73);
        private static readonly Color ColorReal = Color.FromArgb(0, 212, 170);
        private static readonly Color ColorWarning = Color.FromArgb(210, 153, 34);
        private static readonly Color ColorMuted = Color.FromArgb(110, 118, 129);
        private static readonly Color ColorBorderError = Color.FromArgb(248, 81, 73);
        private static readonly Color ColorBorderNormal = Color.FromArgb(33, 38, 45);

        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        // Lưu ScanId của lần quét gần nhất (để btnSaveResult dùng)
        private Guid? _lastScanId = null;

        // ════════════════════════════════════════════════════════════
        //  Constructor
        // ════════════════════════════════════════════════════════════
        public SingleScanControl()
        {
            InitializeComponent();
            AttachEvents();
        }

        // ════════════════════════════════════════════════════════════
        //  Responsive layout
        // ════════════════════════════════════════════════════════════
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            if (pnlLeft == null || pnlMain == null || Width < 100) return;

            int gap = 14;
            int contentW = pnlMain.ClientSize.Width - pnlMain.Padding.Horizontal;

            // Left = 53%, Right fills the rest
            int leftW = (int)(contentW * 0.53) - gap / 2;
            leftW = Math.Max(320, leftW);
            pnlLeft.Width = leftW;

            // Stretch input panels (pnlAccountName full width)
            int inputW = pnlInputCard.ClientSize.Width - pnlInputCard.Padding.Horizontal;
            if (pnlAccountName != null) pnlAccountName.Width = inputW;

            // Half-width inputs (Followers/Following, StatusCount/Favourites, etc.)
            int halfW = (inputW - 16) / 2;
            halfW = Math.Max(120, halfW);
            Panel[] leftCols = { pnlFollowers, pnlStatusCount, pnlListedCount, pnlLinkDensity };
            Panel[] rightCols = { pnlFollowing, pnlFavourites, pnlAccountAge, pnlFollowerRatio };
            foreach (var p in leftCols) if (p != null) p.Width = halfW;
            foreach (var p in rightCols)
            {
                if (p != null)
                {
                    p.Width = halfW;
                    p.Left = halfW + 16;
                }
            }

            // Labels for right-column
            Label[] rightLbls = { lblFollowing, lblFavourites, lblAccountAge, lblFollowerRatio };
            foreach (var lbl in rightLbls)
                if (lbl != null) lbl.Left = halfW + 16;

            // Button row full width
            if (pnlBtnRow != null) pnlBtnRow.Width = inputW;

            // Result card: gauge + detail stretch to full right panel width
            if (pnlGaugeBg != null)
            {
                int resultInner = pnlResultCard.ClientSize.Width - pnlResultCard.Padding.Horizontal;
                pnlGaugeBg.Width = resultInner;
                pnlResultBadge.Width = resultInner;
                pnlDetailSection.Width = resultInner;
                lblConfidencePct.Width = resultInner;
                lblTimestamp.Width = resultInner;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Gắn events
        // ════════════════════════════════════════════════════════════
        private void AttachEvents()
        {
            btnAnalyze.Click += BtnAnalyze_Click;
            btnClear.Click += BtnClear_Click;
            btnSaveResult.Click += BtnSaveResult_Click;

            // Chỉ cho nhập số vào các TextBox số
            TextBox[] numericBoxes =
            {
                txtFollowers, txtFollowing, txtStatusCount,
                txtFavourites, txtListedCount, txtAccountAge
            };
            foreach (var tb in numericBoxes)
                tb.KeyPress += NumericOnly_KeyPress;

            // Cho nhập số thập phân vào Link Density và Follower Ratio
            txtLinkDensity.KeyPress += DecimalOnly_KeyPress;
            txtFollowerRatio.KeyPress += DecimalOnly_KeyPress;
        }

        // ════════════════════════════════════════════════════════════
        //  Keyboard filter
        // ════════════════════════════════════════════════════════════
        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void DecimalOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar == '.' && !tb.Text.Contains("."))
                    return; // cho phép 1 dấu chấm
                e.Handled = true;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Nút PHÂN TÍCH
        // ════════════════════════════════════════════════════════════
        private async void BtnAnalyze_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out var request)) return;

            SetLoadingState(true);
            ResetResultPanel();

            try
            {
                await CallScanApiAsync(request);
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi không xác định: {ex.Message}");
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Validate đầu vào
        // ════════════════════════════════════════════════════════════
        private bool ValidateInputs(out object request)
        {
            request = null;
            bool valid = true;

            // Reset viền lỗi
            ResetBorderErrors();

            // AccountName
            if (string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                MarkError(pnlAccountName);
                valid = false;
            }

            // Followers
            if (!double.TryParse(txtFollowers.Text, out double followers) || followers < 0)
            {
                MarkError(pnlFollowers);
                valid = false;
            }

            // Following
            if (!double.TryParse(txtFollowing.Text, out double following) || following < 0)
            {
                MarkError(pnlFollowing);
                valid = false;
            }

            // Statuses
            if (!double.TryParse(txtStatusCount.Text, out double statuses) || statuses < 0)
            {
                MarkError(pnlStatusCount);
                valid = false;
            }

            // Favourites
            if (!double.TryParse(txtFavourites.Text, out double favourites) || favourites < 0)
            {
                MarkError(pnlFavourites);
                valid = false;
            }

            // Listed
            if (!double.TryParse(txtListedCount.Text, out double listed) || listed < 0)
            {
                MarkError(pnlListedCount);
                valid = false;
            }

            // Account Age
            if (!double.TryParse(txtAccountAge.Text, out double age) || age <= 0)
            {
                MarkError(pnlAccountAge);
                valid = false;
            }

            // Link Density (0.0 – 1.0)
            double linkDensity = 0;
            if (!string.IsNullOrWhiteSpace(txtLinkDensity.Text))
            {
                if (!double.TryParse(txtLinkDensity.Text, out linkDensity)
                    || linkDensity < 0 || linkDensity > 1)
                {
                    MarkError(pnlLinkDensity);
                    valid = false;
                }
            }

            // Follower Ratio
            double followerRatio = 0;
            if (!string.IsNullOrWhiteSpace(txtFollowerRatio.Text))
            {
                if (!double.TryParse(txtFollowerRatio.Text, out followerRatio)
                    || followerRatio < 0)
                {
                    MarkError(pnlFollowerRatio);
                    valid = false;
                }
            }

            if (!valid)
            {
                ShowError("Vui lòng kiểm tra lại các ô được đánh dấu đỏ.");
                return false;
            }

            // Tính NameLength và DescLength từ tên tài khoản
            string accountName = txtAccountName.Text.Trim();

            request = new
            {
                AccountName = accountName,
                FollowersCount = followers,
                FriendsCount = following,
                StatusesCount = statuses,
                ListedCount = listed,
                FavouritesCount = favourites,
                Verified = chkVerified.Checked ? 1 : 0,
                DefaultProfile = chkDefaultProfile.Checked ? 1 : 0,
                DefaultProfileImage = chkDefaultPic.Checked ? 1 : 0,
                GeoEnabled = chkGeoEnabled.Checked ? 1 : 0,
                AccountAgeDays = age,
                NameLength = (double)accountName.Length,
                DescLength = 0.0,   // không có trường desc trong form
                Note = (string)null
            };

            return true;
        }

        // ════════════════════════════════════════════════════════════
        //  Gọi API POST /api/scan/single
        // ════════════════════════════════════════════════════════════
        private async Task CallScanApiAsync(object payload)
        {
            // Đặt Authorization header
            if (!_http.DefaultRequestHeaders.Contains("Authorization") &&
                !string.IsNullOrEmpty(AppSession.AccessToken))
            {
                _http.DefaultRequestHeaders.Add("Authorization",
                    $"Bearer {AppSession.AccessToken}");
            }

            string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/scan/single";
            string body = JsonConvert.SerializeObject(payload);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage response;
            try
            {
                response = await _http.PostAsync(url, content);
            }
            catch (HttpRequestException)
            {
                ShowError("Không thể kết nối đến máy chủ.\nKiểm tra URL API trong Cấu hình.");
                return;
            }
            catch (TaskCanceledException)
            {
                ShowError("Yêu cầu quá thời gian (30s).\nAI Service có thể đang bận.");
                return;
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject json;
            try { json = JObject.Parse(responseBody); }
            catch
            {
                ShowError("Phản hồi từ máy chủ không hợp lệ.");
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                var data = json["data"];
                if (data == null) { ShowError("Phản hồi không chứa dữ liệu."); return; }

                string prediction = data["prediction"]?.ToString() ?? "unknown";
                decimal confidence = data["confidence"]?.Value<decimal>() ?? 0m;
                decimal probSpam = data["probSpam"]?.Value<decimal>() ?? 0m;
                decimal probReal = data["probReal"]?.Value<decimal>() ?? 0m;
                bool isBlacklisted = data["isBlacklisted"]?.Value<bool>() ?? false;
                _lastScanId = Guid.TryParse(data["scanId"]?.ToString(), out var sid) ? sid : (Guid?)null;

                DisplayResult(prediction, confidence, probSpam, probReal, isBlacklisted);
            }
            else if ((int)response.StatusCode == 503)
            {
                string msg = json["error"]?["message"]?.ToString() ?? "AI Service không khả dụng.";
                ShowError($"⚠️  {msg}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var details = json["error"]?["details"];
                string msg = details != null
                    ? details.ToString()
                    : (json["error"]?["message"]?.ToString() ?? "Dữ liệu không hợp lệ.");
                ShowError($"Lỗi dữ liệu:\n{msg}");
            }
            else
            {
                ShowError($"Lỗi máy chủ ({(int)response.StatusCode}).");
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Hiển thị kết quả lên Result Card
        // ════════════════════════════════════════════════════════════
        private void DisplayResult(string prediction, decimal confidence,
                                   decimal probSpam, decimal probReal, bool isBlacklisted)
        {
            bool isSpam = prediction.Equals("spam", StringComparison.OrdinalIgnoreCase);
            Color mainColor = isSpam ? ColorSpam : ColorReal;

            // Badge
            lblResultIcon.Text = isSpam ? "🤖" : "✅";
            lblResultIcon.ForeColor = mainColor;
            lblResultLabel.Text = isSpam ? "SPAMBOT" : "REAL USER";
            lblResultLabel.ForeColor = mainColor;
            lblResultSub.Text = isSpam
                ? "Tài khoản này có khả năng cao là bot spam."
                : "Tài khoản này có vẻ là người dùng thật.";
            lblResultSub.ForeColor = ColorMuted;

            // Nếu nằm trong blacklist → cảnh báo thêm
            if (isBlacklisted)
            {
                lblResultSub.Text += "\n⛔ Tài khoản đang có trong Blacklist!";
                lblResultSub.ForeColor = ColorWarning;
            }

            // Confidence gauge
            int gaugeWidth = (int)(pnlGaugeBg.Width * (double)confidence);
            pnlGaugeFill.Width = Math.Max(0, Math.Min(gaugeWidth, pnlGaugeBg.Width));
            pnlGaugeFill.BackColor = mainColor;
            lblConfidencePct.Text = $"{confidence * 100:F1}%";
            lblConfidencePct.ForeColor = mainColor;

            // Detail section
            double followers = double.TryParse(txtFollowers.Text, out var f) ? f : 0;
            double following = double.TryParse(txtFollowing.Text, out var fw) ? fw : 0;
            double age = double.TryParse(txtAccountAge.Text, out var a) ? a : 0;
            double linkD = double.TryParse(txtLinkDensity.Text, out var ld) ? ld : 0;
            double ratio = following > 0 ? Math.Round(followers / following, 2) : 0;

            lblDFollowersVal.Text = followers.ToString("N0");
            lblDFollowingVal.Text = following.ToString("N0");
            lblDRatioVal.Text = ratio.ToString("F2");
            lblDAgeVal.Text = $"{age:N0} ngày";
            lblDLinkVal.Text = linkD.ToString("F2");

            // Timestamp & nút Lưu
            lblTimestamp.Text = $"Phân tích lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            btnSaveResult.Enabled = _lastScanId.HasValue;

            // Hiện result, ẩn loading
            SetResultVisible(true);
        }

        // ════════════════════════════════════════════════════════════
        //  Nút LƯU KẾT QUẢ (thêm ghi chú vào scan đã có)
        // ════════════════════════════════════════════════════════════
        private async void BtnSaveResult_Click(object sender, EventArgs e)
        {
            if (!_lastScanId.HasValue) return;

            string note = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập ghi chú cho kết quả quét này (tùy chọn):",
                "Lưu ghi chú",
                string.Empty);

            if (note == null) return; // người dùng bấm Cancel

            btnSaveResult.Enabled = false;
            btnSaveResult.Text = "Đang lưu...";

            try
            {
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/scan/history/{_lastScanId}/note";
                string body = JsonConvert.SerializeObject(note); // ✅ plain JSON string, không phải object
                var content = new StringContent(body, Encoding.UTF8, "application/json");

                // ✅ Dùng SendAsync thay PatchAsync (tương thích .NET Framework)
                var patchRequest = new HttpRequestMessage(new HttpMethod("PATCH"), url)
                {
                    Content = content
                };
                var response = await _http.SendAsync(patchRequest);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã lưu ghi chú thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lưu ghi chú thất bại. Vui lòng thử lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Không thể kết nối máy chủ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSaveResult.Text = "💾  Lưu";
                btnSaveResult.Enabled = true;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Nút XÓA
        // ════════════════════════════════════════════════════════════
        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Xóa tất cả input
            txtAccountName.Clear();
            txtFollowers.Clear();
            txtFollowing.Clear();
            txtStatusCount.Clear();
            txtFavourites.Clear();
            txtListedCount.Clear();
            txtAccountAge.Clear();
            txtLinkDensity.Clear();
            txtFollowerRatio.Clear();

            chkVerified.Checked = false;
            chkGeoEnabled.Checked = false;
            chkDefaultProfile.Checked = false;
            chkDefaultPic.Checked = false;

            // Reset result panel
            ResetResultPanel();
            ResetBorderErrors();

            _lastScanId = null;
            btnSaveResult.Enabled = false;

            txtAccountName.Focus();
        }

        // ════════════════════════════════════════════════════════════
        //  Helpers UI
        // ════════════════════════════════════════════════════════════
        private void SetLoadingState(bool loading)
        {
            btnAnalyze.Enabled = !loading;
            btnClear.Enabled = !loading;
            picLoading.Visible = loading;
            lblLoadingMsg.Visible = loading;
            btnAnalyze.Text = loading ? "Đang phân tích..." : "⚡  PHÂN TÍCH";
        }

        private void ResetResultPanel()
        {
            lblResultIcon.Text = "❓";
            lblResultIcon.ForeColor = ColorMuted;
            lblResultLabel.Text = "Chưa phân tích";
            lblResultLabel.ForeColor = ColorMuted;
            lblResultSub.Text = "Nhập dữ liệu và nhấn Phân Tích để bắt đầu.";
            lblResultSub.ForeColor = ColorMuted;

            pnlGaugeFill.Width = 0;
            pnlGaugeFill.BackColor = ColorReal;
            lblConfidencePct.Text = "--.--%";
            lblConfidencePct.ForeColor = ColorReal;

            lblDFollowersVal.Text = "—";
            lblDFollowingVal.Text = "—";
            lblDRatioVal.Text = "—";
            lblDAgeVal.Text = "—";
            lblDLinkVal.Text = "—";

            lblTimestamp.Text = string.Empty;
            picLoading.Visible = false;
            lblLoadingMsg.Visible = false;
        }

        private void SetResultVisible(bool visible)
        {
            picLoading.Visible = false;
            lblLoadingMsg.Visible = false;
        }

        private void ShowError(string message)
        {
            lblResultIcon.Text = "⚠️";
            lblResultIcon.ForeColor = ColorWarning;
            lblResultLabel.Text = "Lỗi";
            lblResultLabel.ForeColor = ColorWarning;
            lblResultSub.Text = message;
            lblResultSub.ForeColor = ColorWarning;
            pnlGaugeFill.Width = 0;
            lblConfidencePct.Text = "--.--%";
            lblTimestamp.Text = string.Empty;
            btnSaveResult.Enabled = false;
        }

        private void MarkError(Panel panel)
        {
            panel.BackColor = Color.FromArgb(60, 30, 30);
        }

        private void ResetBorderErrors()
        {
            Panel[] panels =
            {
                pnlAccountName, pnlFollowers, pnlFollowing, pnlStatusCount,
                pnlFavourites, pnlListedCount, pnlAccountAge,
                pnlLinkDensity, pnlFollowerRatio
            };
            var normalColor = Color.FromArgb(33, 38, 45);
            foreach (var p in panels)
                p.BackColor = normalColor;
        }
    }
}