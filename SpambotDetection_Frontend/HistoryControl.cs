using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace demo_AI
{
    public partial class HistoryControl : UserControl
    {
        // ════════════════════════════════════════════════════════════
        //  Màu sắc
        // ════════════════════════════════════════════════════════════
        private static readonly Color ColorSpam = Color.FromArgb(248, 81, 73);
        private static readonly Color ColorReal = Color.FromArgb(63, 185, 80);
        private static readonly Color ColorAccent = Color.FromArgb(0, 212, 170);
        private static readonly Color ColorMuted = Color.FromArgb(110, 118, 129);
        private static readonly Color ColorRowSpam = Color.FromArgb(40, 22, 22);
        private static readonly Color ColorRowReal = Color.FromArgb(18, 35, 25);

        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        // ════════════════════════════════════════════════════════════
        //  State phân trang
        // ════════════════════════════════════════════════════════════
        private int _currentPage = 1;
        private int _totalRecords = 0;
        private const int PageSize = 50;

        // Bản ghi đang chọn
        private Guid? _selectedScanId = null;
        private string _selectedAccountName = null;
        private JToken _selectedItem = null;

        // Cache toàn bộ kết quả trang hiện tại để export
        private readonly List<JToken> _pageCache = new List<JToken>();

        // ════════════════════════════════════════════════════════════
        //  Constructor
        // ════════════════════════════════════════════════════════════
        public HistoryControl()
        {
            InitializeComponent();
            AttachEvents();
        }

        // ════════════════════════════════════════════════════════════
        //  Responsive layout
        // ════════════════════════════════════════════════════════════
        private const int DETAIL_PANEL_MIN_WIDTH = 900;

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            pnlRight.Visible = this.Width >= DETAIL_PANEL_MIN_WIDTH;
        }

        // ════════════════════════════════════════════════════════════
        //  Gắn events
        // ════════════════════════════════════════════════════════════
        private void AttachEvents()
        {
            this.Load += HistoryControl_Load;
            btnFilter.Click += async (s, e) => await LoadHistoryAsync(1);
            btnResetFilter.Click += BtnResetFilter_Click;
            btnDeleteSelected.Click += BtnDeleteSelected_Click;
            btnExportHistory.Click += BtnExportHistory_Click;
            btnAddToBlacklist.Click += BtnAddToBlacklist_Click;
            btnDeleteRecord.Click += BtnDeleteSelected_Click;

            dgvHistory.SelectionChanged += DgvHistory_SelectionChanged;
            dgvHistory.CellClick += DgvHistory_CellClick;
            dgvHistory.CellFormatting += DgvHistory_CellFormatting;
            dgvHistory.RowPrePaint += DgvHistory_RowPrePaint;

            // Enter trên txtSearch → lọc ngay
            txtSearch.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) await LoadHistoryAsync(1);
            };
        }

        // ════════════════════════════════════════════════════════════
        //  Load lần đầu
        // ════════════════════════════════════════════════════════════
        private async void HistoryControl_Load(object sender, EventArgs e)
        {
            cmbFilterResult.SelectedIndex = 0;
            EnsureAuthHeader();
            await LoadHistoryAsync(1);
        }

        // ════════════════════════════════════════════════════════════
        //  Gọi API GET /api/scan/history
        // ════════════════════════════════════════════════════════════
        private async Task LoadHistoryAsync(int page)
        {
            SetGridLoading(true);
            dgvHistory.Rows.Clear();
            _pageCache.Clear();
            ResetDetailPanel();

            try
            {
                string query = BuildQueryString(page);
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/scan/history?{query}";
                var resp = await _http.GetAsync(url);
                string body = await resp.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);

                if (!resp.IsSuccessStatusCode)
                {
                    string err = json["error"]?["message"]?.ToString() ?? "Lỗi tải dữ liệu.";
                    lblRecordCount.Text = err;
                    return;
                }

                var data = json["data"];
                _totalRecords = data?["totalCount"]?.Value<int>() ?? 0;
                _currentPage = page;
                var items = data?["items"] as JArray ?? new JArray();

                foreach (var item in items)
                {
                    _pageCache.Add(item);
                    AddRowToGrid(item);
                }

                lblRecordCount.Text = $"{_totalRecords:N0} bản ghi";
                lblGridHeader.Text = $"LỊCH SỬ QUÉT  ·  Trang {_currentPage} / {TotalPages}  ·  {_totalRecords:N0} bản ghi";
                btnDeleteSelected.Enabled = false;
            }
            catch (Exception ex)
            {
                lblRecordCount.Text = $"Lỗi: {ex.Message}";
            }
            finally
            {
                SetGridLoading(false);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Xây query string
        // ════════════════════════════════════════════════════════════
        private string BuildQueryString(int page)
        {
            var parts = new List<string>
            {
                $"page={page}",
                $"pageSize={PageSize}"
            };

            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
                parts.Add($"keyword={Uri.EscapeDataString(keyword)}");

            // ✅ C# 7.3: dùng switch statement thay vì switch expression
            string result;
            switch (cmbFilterResult.SelectedIndex)
            {
                case 1: result = "spam"; break;
                case 2: result = "real"; break;
                default: result = ""; break;
            }
            if (!string.IsNullOrEmpty(result))
                parts.Add($"prediction={result}");

            parts.Add($"from={dtpFrom.Value:yyyy-MM-dd}");
            parts.Add($"to={dtpTo.Value:yyyy-MM-dd}");

            return string.Join("&", parts);
        }

        private int TotalPages => (int)Math.Ceiling(_totalRecords / (double)PageSize);

        // ════════════════════════════════════════════════════════════
        //  Thêm dòng vào DataGridView
        // ════════════════════════════════════════════════════════════
        private void AddRowToGrid(JToken item)
        {
            string scanId = item["scanId"]?.ToString() ?? "";
            string account = item["accountName"]?.ToString() ?? "—";
            string prediction = item["prediction"]?.ToString()?.ToUpper() ?? "—";
            decimal conf = item["confidence"]?.Value<decimal>() ?? 0m;
            string scannedAt = DateTime.TryParse(item["scannedAt"]?.ToString(), out var dt)
                                ? dt.ToString("dd/MM/yyyy HH:mm")
                                : "—";

            // Hiện số ngắn cho ID
            string shortId = scanId.Length >= 8 ? scanId.Substring(0, 8) + "…" : scanId;

            int idx = dgvHistory.Rows.Add(shortId, account, prediction, $"{conf:F1}%", scannedAt, "👁");
            dgvHistory.Rows[idx].Tag = item;   // lưu toàn bộ JToken
        }

        // ════════════════════════════════════════════════════════════
        //  Tô màu dòng
        // ════════════════════════════════════════════════════════════
        private void DgvHistory_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var item = dgvHistory.Rows[e.RowIndex].Tag as JToken;
            string pred = item?["prediction"]?.ToString()?.ToLower() ?? "";
            dgvHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                pred == "spam" ? ColorRowSpam : ColorRowReal;
        }

        private void DgvHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var item = dgvHistory.Rows[e.RowIndex].Tag as JToken;
            string pred = item?["prediction"]?.ToString()?.ToLower() ?? "";

            if (dgvHistory.Columns[e.ColumnIndex].Name == "colHPrediction")
            {
                e.CellStyle.ForeColor = pred == "spam" ? ColorSpam : ColorReal;
                e.CellStyle.Font = new Font(dgvHistory.Font, FontStyle.Bold);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Click dòng → cập nhật Detail Panel
        // ════════════════════════════════════════════════════════════
        private void DgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                ResetDetailPanel();
                btnDeleteSelected.Enabled = false;
                return;
            }

            var row = dgvHistory.SelectedRows[0];
            var item = row.Tag as JToken;
            if (item == null) return;

            _selectedItem = item;
            _selectedScanId = Guid.TryParse(item["scanId"]?.ToString(), out var g) ? g : (Guid?)null;
            _selectedAccountName = item["accountName"]?.ToString();

            ShowDetailPanel(item);
            btnDeleteSelected.Enabled = AppSession.IsAdmin;
        }

        private void DgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Click nút 👁 (colHAction) = chọn dòng đó (đã handle qua SelectionChanged)
        }

        // ════════════════════════════════════════════════════════════
        //  Hiển thị chi tiết bên phải
        // ════════════════════════════════════════════════════════════
        private void ShowDetailPanel(JToken item)
        {
            string prediction = item["prediction"]?.ToString()?.ToLower() ?? "";
            decimal conf = item["confidence"]?.Value<decimal>() ?? 0m;
            bool isSpam = prediction == "spam";
            Color mainColor = isSpam ? ColorSpam : ColorReal;

            lblDetailIcon.Text = isSpam ? "🤖" : "✅";
            lblDetailIcon.ForeColor = mainColor;
            lblDetailLabel.Text = isSpam ? "SPAMBOT" : "REAL USER";
            lblDetailLabel.ForeColor = mainColor;
            lblDetailSub.Text = item["isBlacklisted"]?.Value<bool>() == true
                                       ? "⛔ Đang trong Blacklist" : "";
            lblDetailSub.ForeColor = ColorSpam;

            // Gauge
            int fillW = (int)(pnlDetailGaugeBg.Width * (double)conf / 100.0);
            pnlDetailGaugeFill.Width = Math.Max(0, Math.Min(fillW, pnlDetailGaugeBg.Width));
            pnlDetailGaugeFill.BackColor = mainColor;
            lblDetailConfPct.Text = $"{conf:F1}%";
            lblDetailConfPct.ForeColor = mainColor;

            // Thông tin chi tiết
            lblDHAccountVal.Text = item["accountName"]?.ToString() ?? "—";
            lblDHDateVal.Text = DateTime.TryParse(item["scannedAt"]?.ToString(), out var dt)
                                    ? dt.ToString("dd/MM/yyyy HH:mm:ss") : "—";

            // Đọc input data nếu có
            var input = item["inputData"] as JObject;
            lblDHFollowersVal.Text = FormatNum(input?["followers_count"]);
            lblDHFollowingVal.Text = FormatNum(input?["friends_count"]);
            lblDHAgeVal.Text = FormatNum(input?["account_age_days"]) + " ngày";
            lblDHLinkVal.Text = input?["link_density"]?.ToString() ?? "—";

            double followers = input?["followers_count"]?.Value<double>() ?? 0;
            double following = input?["friends_count"]?.Value<double>() ?? 1;
            lblDHRatioVal.Text = following > 0
                ? Math.Round(followers / following, 2).ToString("F2")
                : "—";

            // Hiện body + actions, ẩn empty state
            lblDetailEmpty.Visible = false;
            pnlDetailBody.Visible = true;
            pnlDetailActions.Visible = true;
        }

        private string FormatNum(JToken token)
        {
            if (token == null) return "—";
            return double.TryParse(token.ToString(), out var d)
                ? d.ToString("N0") : token.ToString();
        }

        private void ResetDetailPanel()
        {
            lblDetailEmpty.Visible = true;
            pnlDetailBody.Visible = false;
            pnlDetailActions.Visible = false;
            _selectedScanId = null;
            _selectedAccountName = null;
            _selectedItem = null;
        }

        // ════════════════════════════════════════════════════════════
        //  Reset filter
        // ════════════════════════════════════════════════════════════
        private async void BtnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterResult.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            await LoadHistoryAsync(1);
        }

        // ════════════════════════════════════════════════════════════
        //  Xóa bản ghi (chỉ Admin)
        // ════════════════════════════════════════════════════════════
        private async void BtnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (!_selectedScanId.HasValue) return;

            var confirm = MessageBox.Show(
                $"Xóa bản ghi quét tài khoản \"{_selectedAccountName}\"?\nHành động này không thể hoàn tác.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/scan/history/{_selectedScanId}";
                var resp = await _http.DeleteAsync(url);

                if (resp.IsSuccessStatusCode || resp.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    await LoadHistoryAsync(_currentPage);
                }
                else
                {
                    string body = await resp.Content.ReadAsStringAsync();
                    var json = JObject.Parse(body);
                    string err = json["error"]?["message"]?.ToString() ?? "Xóa thất bại.";
                    MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Thêm vào Blacklist từ History (chỉ Admin)
        // ════════════════════════════════════════════════════════════
        private async void BtnAddToBlacklist_Click(object sender, EventArgs e)
        {
            if (!_selectedScanId.HasValue || string.IsNullOrEmpty(_selectedAccountName)) return;

            if (!AppSession.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền thêm vào Blacklist.", "Không có quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reason = Microsoft.VisualBasic.Interaction.InputBox(
                $"Nhập lý do thêm \"{_selectedAccountName}\" vào Blacklist:",
                "Thêm vào Blacklist", "Phát hiện qua AI scan");

            if (reason == null) return; // Cancel

            try
            {
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/blacklist/promote";
                string body = JsonConvert.SerializeObject(new
                {
                    ScanId = _selectedScanId.Value,
                    Reason = reason
                });
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var resp = await _http.PostAsync(url, content);

                if (resp.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Đã thêm \"{_selectedAccountName}\" vào Blacklist!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadHistoryAsync(_currentPage);
                }
                else
                {
                    string respBody = await resp.Content.ReadAsStringAsync();
                    var json = JObject.Parse(respBody);
                    string err = json["error"]?["message"]?.ToString() ?? "Thêm Blacklist thất bại.";
                    MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Xuất CSV
        // ════════════════════════════════════════════════════════════
        private void BtnExportHistory_Click(object sender, EventArgs e)
        {
            if (_pageCache.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ C# 7.3: dùng using(...) { } thay vì using var
            using (var dlg = new SaveFileDialog
            {
                Title = "Xuất lịch sử quét",
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = $"history_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("ScanId,AccountName,Prediction,Confidence,ScannedAt,IsBlacklisted,ScannedBy");

                    foreach (var item in _pageCache)
                    {
                        string scanId = item["scanId"]?.ToString() ?? "";
                        string account = item["accountName"]?.ToString() ?? "";
                        string pred = item["prediction"]?.ToString() ?? "";
                        string conf = item["confidence"]?.ToString() ?? "";
                        string date = item["scannedAt"]?.ToString() ?? "";
                        string bl = item["isBlacklisted"]?.ToString() ?? "false";
                        string by = item["scannedByUsername"]?.ToString() ?? "";

                        sb.AppendLine($"\"{scanId}\",\"{account}\",{pred},{conf},{date},{bl},{by}");
                    }

                    File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show($"Đã xuất {_pageCache.Count:N0} bản ghi!\n{dlg.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi lưu file: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Helpers
        // ════════════════════════════════════════════════════════════
        private void SetGridLoading(bool loading)
        {
            btnFilter.Enabled = !loading;
            btnResetFilter.Enabled = !loading;
            lblGridHeader.Text = loading ? "Đang tải..." : lblGridHeader.Text;
        }

        private void EnsureAuthHeader()
        {
            if (!_http.DefaultRequestHeaders.Contains("Authorization") &&
                !string.IsNullOrEmpty(AppSession.AccessToken))
            {
                _http.DefaultRequestHeaders.Add("Authorization",
                    $"Bearer {AppSession.AccessToken}");
            }
        }
    }
}