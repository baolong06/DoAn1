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
    public partial class BlacklistControl : UserControl
    {
        // ════════════════════════════════════════════════════════════
        //  Màu sắc
        // ════════════════════════════════════════════════════════════
        private static readonly Color ColorSpam = Color.FromArgb(248, 81, 73);
        private static readonly Color ColorAccent = Color.FromArgb(0, 212, 170);
        private static readonly Color ColorMuted = Color.FromArgb(110, 118, 129);
        private static readonly Color ColorRowBg = Color.FromArgb(35, 20, 20);

        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        // ════════════════════════════════════════════════════════════
        //  State
        // ════════════════════════════════════════════════════════════
        private Guid? _selectedEntryId = null;
        private string _selectedAccountId = null;
        private readonly List<JToken> _cache = new List<JToken>();

        // ════════════════════════════════════════════════════════════
        //  Constructor
        // ════════════════════════════════════════════════════════════
        public BlacklistControl()
        {
            InitializeComponent();
            AttachEvents();
        }

        // ════════════════════════════════════════════════════════════
        //  Responsive: ẩn/hiện pnlRight theo chiều rộng
        // ════════════════════════════════════════════════════════════
        private const int DETAIL_PANEL_MIN_WIDTH = 900; // px — dưới ngưỡng này ẩn detail panel

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ApplyResponsiveLayout();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            bool showDetail = this.Width >= DETAIL_PANEL_MIN_WIDTH;
            pnlRight.Visible = showDetail;

            // Cập nhật vị trí toolbar buttons theo chiều rộng thực
            int toolbarW = pnlToolbar.Width;
            if (toolbarW < 10) return;

            int btnExportRight = 8;
            int btnRemoveRight = btnExportRight + btnExport.Width + 6;
            int btnAddRight = btnRemoveRight + btnRemoveEntry.Width + 6;

            btnExport.Left = toolbarW - btnExportRight - btnExport.Width;
            btnRemoveEntry.Left = toolbarW - btnRemoveRight - btnRemoveEntry.Width;
            btnAddNew.Left = toolbarW - btnAddRight - btnAddNew.Width;
        }

        // ════════════════════════════════════════════════════════════
        //  Gắn events
        // ════════════════════════════════════════════════════════════
        private void AttachEvents()
        {
            this.Load += async (s, e) => await LoadBlacklistAsync();
            btnSearch.Click += async (s, e) => await LoadBlacklistAsync();
            btnAddNew.Click += BtnAddNew_Click;
            btnRemoveEntry.Click += BtnRemove_Click;
            btnRemoveDetail.Click += BtnRemove_Click;
            btnSaveEdit.Click += BtnSaveEdit_Click;
            btnExport.Click += BtnExport_Click;

            dgvBlacklist.SelectionChanged += DgvBlacklist_SelectionChanged;
            dgvBlacklist.RowPrePaint += DgvBlacklist_RowPrePaint;

            txtSearch.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) await LoadBlacklistAsync();
            };

            // Chỉ Admin mới thao tác được
            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            bool isAdmin = AppSession.IsAdmin;
            btnAddNew.Visible = isAdmin;
            btnRemoveEntry.Visible = isAdmin;
            btnSaveEdit.Visible = isAdmin;
            btnRemoveDetail.Visible = isAdmin;
            if (!isAdmin)
                lblFReasonHdr.Text = "LÝ DO";
        }

        // ════════════════════════════════════════════════════════════
        //  Load danh sách blacklist
        // ════════════════════════════════════════════════════════════
        private async Task LoadBlacklistAsync()
        {
            EnsureAuthHeader();
            dgvBlacklist.Rows.Clear();
            _cache.Clear();
            ResetDetailPanel();
            btnRemoveEntry.Enabled = false;

            try
            {
                string keyword = txtSearch.Text.Trim();
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/blacklist?page=1&pageSize=200";
                if (!string.IsNullOrEmpty(keyword))
                    url += $"&keyword={Uri.EscapeDataString(keyword)}";

                var resp = await _http.GetAsync(url);
                string body = await resp.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);

                if (!resp.IsSuccessStatusCode)
                {
                    lblTotalCount.Text = "Lỗi tải dữ liệu.";
                    return;
                }

                // Backend trả về ApiResponse<IEnumerable<BlacklistDto>> (không paged)
                JArray items;
                var dataToken = json["data"];
                if (dataToken is JArray arr)
                    items = arr;
                else
                    items = dataToken?["items"] as JArray ?? new JArray();

                int counter = 1;
                foreach (var item in items)
                {
                    _cache.Add(item);
                    AddRowToGrid(item, counter++);
                }

                int total = items.Count;
                lblTotalCount.Text = $"{total:N0} tài khoản trong danh sách đen";
                lblListHeader.Text = keyword.Length > 0
                    ? $"🚫  Kết quả tìm kiếm: \"{keyword}\"  ·  {total} mục"
                    : $"🚫  Danh sách tài khoản bị chặn  ·  {total} mục";
            }
            catch (Exception ex)
            {
                lblTotalCount.Text = $"Lỗi: {ex.Message}";
            }
        }

        private void AddRowToGrid(JToken item, int stt)
        {
            string entryId = item["id"]?.ToString() ?? "";
            string accountId = item["accountId"]?.ToString() ?? "—";
            string reason = item["reason"]?.ToString() ?? "—";
            string addedAt = DateTime.TryParse(item["addedAt"]?.ToString(), out var dt)
                               ? dt.ToString("dd/MM/yyyy") : "—";
            bool hasScan = item["confidenceAtAdd"] != null;
            string source = hasScan ? "AI Scan" : "Manual";

            int idx = dgvBlacklist.Rows.Add(stt, accountId, reason, addedAt, source, "✏️");
            dgvBlacklist.Rows[idx].Tag = item;
        }

        // ════════════════════════════════════════════════════════════
        //  Tô màu dòng
        // ════════════════════════════════════════════════════════════
        private void DgvBlacklist_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvBlacklist.Rows[e.RowIndex].DefaultCellStyle.BackColor = ColorRowBg;
        }

        // ════════════════════════════════════════════════════════════
        //  Chọn dòng → cập nhật Detail Panel
        // ════════════════════════════════════════════════════════════
        private void DgvBlacklist_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBlacklist.SelectedRows.Count == 0)
            {
                ResetDetailPanel();
                btnRemoveEntry.Enabled = false;
                return;
            }

            var row = dgvBlacklist.SelectedRows[0];
            var item = row.Tag as JToken;
            if (item == null) return;

            _selectedEntryId = Guid.TryParse(item["id"]?.ToString(), out var g) ? g : (Guid?)null;
            _selectedAccountId = item["accountId"]?.ToString();

            ShowDetailPanel(item);
            btnRemoveEntry.Enabled = AppSession.IsAdmin;
        }

        private void ShowDetailPanel(JToken item)
        {
            string shortId = _selectedEntryId.HasValue
                ? "#" + _selectedEntryId.Value.ToString().Substring(0, 6).ToUpper()
                : "#—";
            lblFBotIDVal.Text = shortId;
            lblFAccountIDVal.Text = item["accountId"]?.ToString() ?? "—";
            lblFAddedDateVal.Text = DateTime.TryParse(item["addedAt"]?.ToString(), out var dt)
                                     ? dt.ToString("dd/MM/yyyy HH:mm") : "—";

            bool hasScan = item["confidenceAtAdd"] != null;
            string conf = hasScan ? $"AI ({item["confidenceAtAdd"]}%)" : "—";
            lblFSourceVal.Text = hasScan ? "AI Scan" : "Manual";

            txtFReason.Text = item["reason"]?.ToString() ?? "";
            txtFReason.ReadOnly = !AppSession.IsAdmin;

            lblDetailEmpty.Visible = false;
            pnlDetailFields.Visible = true;
            pnlDetailActions.Visible = AppSession.IsAdmin;
        }

        private void ResetDetailPanel()
        {
            lblDetailEmpty.Visible = true;
            pnlDetailFields.Visible = false;
            pnlDetailActions.Visible = false;
            _selectedEntryId = null;
            _selectedAccountId = null;
            lblFBotIDVal.Text = "#—";
            lblFAccountIDVal.Text = "—";
            lblFAddedDateVal.Text = "—";
            lblFSourceVal.Text = "—";
            txtFReason.Clear();
        }

        // ════════════════════════════════════════════════════════════
        //  Nút Thêm mới → mở AddBlacklistForm
        // ════════════════════════════════════════════════════════════
        private async void BtnAddNew_Click(object sender, EventArgs e)
        {
            var form = new AddBlacklistForm();
            if (form.ShowDialog() != DialogResult.OK) return;

            try
            {
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/blacklist";
                string body = JsonConvert.SerializeObject(new
                {
                    AccountId = form.AccountIDValue,
                    AccountName = form.AccountIDValue,
                    Reason = form.ReasonValue
                });
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var resp = await _http.PostAsync(url, content);

                if (resp.IsSuccessStatusCode || resp.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    await LoadBlacklistAsync();
                }
                else
                {
                    string respBody = await resp.Content.ReadAsStringAsync();
                    var json = JObject.Parse(respBody);
                    string err = json["error"]?["message"]?.ToString() ?? "Thêm thất bại.";
                    MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Nút Lưu chỉnh sửa lý do → PUT /api/blacklist/{id}
        // ════════════════════════════════════════════════════════════
        private async void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            if (!_selectedEntryId.HasValue) return;

            string newReason = txtFReason.Text.Trim();
            if (string.IsNullOrEmpty(newReason))
            {
                MessageBox.Show("Lý do không được để trống.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFReason.Focus();
                return;
            }

            btnSaveEdit.Enabled = false;
            btnSaveEdit.Text = "Đang lưu...";

            try
            {
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/blacklist/{_selectedEntryId}";
                string body = JsonConvert.SerializeObject(new { Reason = newReason });
                var content = new StringContent(body, Encoding.UTF8, "application/json");

                // ✅ Dùng PATCH thay vì PUT cho đúng với backend
                var patchReq = new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = content };
                var resp = await _http.SendAsync(patchReq);
                if (resp.IsSuccessStatusCode)
                {
                    // Cập nhật lại cache dòng hiện tại
                    await LoadBlacklistAsync();
                    MessageBox.Show("Đã lưu lý do thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string respBody = await resp.Content.ReadAsStringAsync();
                    var json = JObject.Parse(respBody);
                    string err = json["error"]?["message"]?.ToString() ?? "Lưu thất bại.";
                    MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSaveEdit.Enabled = true;
                btnSaveEdit.Text = "💾  Lưu chỉnh sửa";
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Nút Xóa → DELETE /api/blacklist/{id}
        // ════════════════════════════════════════════════════════════
        private async void BtnRemove_Click(object sender, EventArgs e)
        {
            if (!_selectedEntryId.HasValue) return;

            var confirm = MessageBox.Show(
                $"Xóa tài khoản \"{_selectedAccountId}\" khỏi Blacklist?\n" +
                "Tài khoản sẽ không còn bị đánh dấu trong các lần quét tiếp theo.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/blacklist/{_selectedEntryId}";
                var resp = await _http.DeleteAsync(url);

                if (resp.IsSuccessStatusCode)
                {
                    await LoadBlacklistAsync();
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
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Xuất CSV
        // ════════════════════════════════════════════════════════════
        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (_cache.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dlg = new SaveFileDialog
            {
                Title = "Xuất Blacklist",
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = $"blacklist_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            };

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                dlg.Dispose();
                return;
            }

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("AccountId,AccountName,Reason,Source,AddedAt,ConfidenceAtAdd");

                foreach (var item in _cache)
                {
                    string accountId = item["accountId"]?.ToString() ?? "";
                    string accountName = item["accountName"]?.ToString() ?? "";
                    string reason = (item["reason"]?.ToString() ?? "").Replace("\"", "\"\"");
                    string source = item["confidenceAtAdd"] != null ? "AI Scan" : "Manual";
                    string addedAt = item["addedAt"]?.ToString() ?? "";
                    string conf = item["confidenceAtAdd"]?.ToString() ?? "";

                    sb.AppendLine($"\"{accountId}\",\"{accountName}\",\"{reason}\",{source},{addedAt},{conf}");
                }

                File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show($"Đã xuất {_cache.Count:N0} mục!\n{dlg.FileName}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Helpers
        // ════════════════════════════════════════════════════════════
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