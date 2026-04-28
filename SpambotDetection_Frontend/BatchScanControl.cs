using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace demo_AI
{
    public partial class BatchScanControl : UserControl
    {
        // ════════════════════════════════════════════════════════════
        //  Màu sắc
        // ════════════════════════════════════════════════════════════
        private static readonly Color ColorSpam = Color.FromArgb(248, 81, 73);
        private static readonly Color ColorReal = Color.FromArgb(63, 185, 80);
        private static readonly Color ColorAccent = Color.FromArgb(0, 212, 170);
        private static readonly Color ColorWarning = Color.FromArgb(210, 153, 34);
        private static readonly Color ColorMuted = Color.FromArgb(110, 118, 129);
        private static readonly Color ColorRowSpam = Color.FromArgb(40, 22, 22);
        private static readonly Color ColorRowReal = Color.FromArgb(18, 35, 25);

        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(5)   // batch có thể lâu
        };

        // ════════════════════════════════════════════════════════════
        //  State
        // ════════════════════════════════════════════════════════════
        private string _selectedFilePath = null;
        private int _totalRows = 0;
        private CancellationTokenSource _cts = null;

        // Lưu kết quả để export
        private readonly List<ScanRow> _scanResults = new List<ScanRow>();

        private class ScanRow
        {
            public string AccountName { get; set; }
            public string Prediction { get; set; }
            public string Confidence { get; set; }
            public string Followers { get; set; }
            public string Following { get; set; }
            public string Age { get; set; }
            public string StatusNote { get; set; }
        }

        // ════════════════════════════════════════════════════════════
        //  Constructor
        // ════════════════════════════════════════════════════════════
        public BatchScanControl()
        {
            InitializeComponent();
            AttachEvents();
        }

        // ════════════════════════════════════════════════════════════
        //  Gắn events
        // ════════════════════════════════════════════════════════════
        private void AttachEvents()
        {
            btnBrowse.Click += BtnBrowse_Click;
            btnStartScan.Click += BtnStartScan_Click;
            btnStopScan.Click += BtnStopScan_Click;
            btnExportResult.Click += BtnExportResult_Click;
            btnClearAll.Click += BtnClearAll_Click;

            // Drag & Drop trên drop zone
            pnlDropZone.DragEnter += PnlDropZone_DragEnter;
            pnlDropZone.DragDrop += PnlDropZone_DragDrop;
            pnlDropZone.Paint += PnlDropZone_Paint;

            // Tô màu từng dòng DataGridView
            dgvResults.CellFormatting += DgvResults_CellFormatting;
            dgvResults.RowPrePaint += DgvResults_RowPrePaint;
        }

        // ════════════════════════════════════════════════════════════
        //  Vẽ viền dashed cho Drop Zone
        // ════════════════════════════════════════════════════════════
        private void PnlDropZone_Paint(object sender, PaintEventArgs e)
        {
            // ✅ C# 7.3: dùng using(...) { } thay vì using var
            using (var pen = new Pen(Color.FromArgb(48, 54, 61), 2f))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, 1, 1,
                    pnlDropZone.Width - 3, pnlDropZone.Height - 3);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Browse file
        // ════════════════════════════════════════════════════════════
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            // ✅ C# 7.3: dùng using(...) { } thay vì using var
            using (var dlg = new OpenFileDialog
            {
                Title = "Chọn file CSV",
                Filter = "CSV Files (*.csv)|*.csv",
                CheckFileExists = true
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;
                LoadFile(dlg.FileName);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Drag & Drop
        // ════════════════════════════════════════════════════════════
        private void PnlDropZone_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                e.Effect = (files.Length == 1 && files[0].EndsWith(".csv",
                    StringComparison.OrdinalIgnoreCase))
                    ? DragDropEffects.Copy
                    : DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PnlDropZone_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files?.Length > 0) LoadFile(files[0]);
        }

        // ════════════════════════════════════════════════════════════
        //  Load file CSV
        // ════════════════════════════════════════════════════════════
        private void LoadFile(string filePath)
        {
            if (!File.Exists(filePath) ||
                !filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Chỉ chấp nhận file .csv!", "Lỗi định dạng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Đếm số dòng dữ liệu (bỏ header)
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                int dataRows = Math.Max(0, lines.Length - 1);

                if (dataRows > 10000)
                {
                    MessageBox.Show($"File có {dataRows:N0} dòng, vượt quá giới hạn 10,000 dòng.",
                        "File quá lớn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataRows == 0)
                {
                    MessageBox.Show("File CSV không có dữ liệu (chỉ có header hoặc rỗng).",
                        "File trống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _selectedFilePath = filePath;
                _totalRows = dataRows;

                // Cập nhật UI
                string fileName = Path.GetFileName(filePath);
                lblFileSelected.Text = $"✅  {fileName}";
                lblFileSelected.ForeColor = ColorAccent;
                lblFileInfo.Text = $"📄  {fileName}  ·  {dataRows:N0} tài khoản";

                btnStartScan.Enabled = true;
                lblDropTitle.Text = "File đã được chọn";
                lblDropIcon.Text = "✅";
                lblDropIcon.ForeColor = ColorAccent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể đọc file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Bắt đầu quét
        // ════════════════════════════════════════════════════════════
        private async void BtnStartScan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedFilePath)) return;

            // Reset kết quả cũ
            _scanResults.Clear();
            dgvResults.Rows.Clear();
            ResetSummaryCards();

            SetScanningState(true);

            _cts = new CancellationTokenSource();

            try
            {
                await RunBatchScanAsync(_cts.Token);
            }
            catch (OperationCanceledException)
            {
                UpdateProgress(0, "Đã dừng bởi người dùng.", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình quét:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetScanningState(false);
                _cts?.Dispose();
                _cts = null;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Gọi API POST /api/scan/batch/csv (upload multipart)
        // ════════════════════════════════════════════════════════════
        private async Task RunBatchScanAsync(CancellationToken ct)
        {
            // Đặt Authorization
            if (!_http.DefaultRequestHeaders.Contains("Authorization") &&
                !string.IsNullOrEmpty(AppSession.AccessToken))
            {
                _http.DefaultRequestHeaders.Add("Authorization",
                    $"Bearer {AppSession.AccessToken}");
            }

            string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/scan/batch/csv";

            UpdateProgress(0, $"Đang tải lên {Path.GetFileName(_selectedFilePath)}...", "");

            // ✅ C# 7.3: dùng using(...) { } thay vì using var
            using (var fileStream = new FileStream(_selectedFilePath, FileMode.Open, FileAccess.Read))
            using (var multipart = new MultipartFormDataContent())
            using (var fileContent = new StreamContent(fileStream))
            {
                fileContent.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv");
                multipart.Add(fileContent, "file", Path.GetFileName(_selectedFilePath));

                HttpResponseMessage response;
                try
                {
                    UpdateProgress(10, "Đang gửi đến AI Service...", "");
                    response = await _http.PostAsync(url, multipart, ct);
                }
                // ✅ Sau - phân biệt timeout vs user cancel bằng kiểm tra CancellationToken
                catch (OperationCanceledException ex)
                {
                    if (ct.IsCancellationRequested)
                        throw; // người dùng bấm Dừng → để BtnStartScan_Click xử lý
                    else
                        UpdateProgress(0, "Yêu cầu quá thời gian (5 phút).", "");
                    return;
                }
                catch (HttpRequestException)
                {
                    UpdateProgress(0, "Không thể kết nối đến máy chủ.", "");
                    return;
                }

                string body = await response.Content.ReadAsStringAsync();
                JObject json;
                try { json = JObject.Parse(body); }
                catch
                {
                    UpdateProgress(0, "Phản hồi không hợp lệ từ máy chủ.", "");
                    return;
                }

                if (!response.IsSuccessStatusCode)
                {
                    string errMsg = json["error"]?["message"]?.ToString()
                                    ?? $"Lỗi {(int)response.StatusCode}";
                    UpdateProgress(0, $"Lỗi: {errMsg}", "");
                    MessageBox.Show(errMsg, "Lỗi quét batch",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ── Xử lý kết quả ────────────────────────────────────
                var data = json["data"];
                int total = data?["total"]?.Value<int>() ?? 0;
                int spamCnt = data?["spamCount"]?.Value<int>() ?? 0;
                int realCnt = data?["realCount"]?.Value<int>() ?? 0;
                int errCnt = data?["errorCount"]?.Value<int>() ?? 0;

                var results = data?["results"] as JArray ?? new JArray();

                // Điền lần lượt vào grid với animation progress
                int processed = 0;
                DateTime startTime = DateTime.Now;

                foreach (var item in results)
                {
                    ct.ThrowIfCancellationRequested();

                    string account = item["accountName"]?.ToString() ?? "—";
                    string prediction = item["prediction"]?.ToString() ?? "unknown";
                    decimal conf = item["confidence"]?.Value<decimal>() ?? 0m;
                    bool isBlacklisted = item["isBlacklisted"]?.Value<bool>() ?? false;

                    // Đọc input data từ API response (nếu có)
                    string followers = item["inputData"]?["followers_count"]?.ToString() ?? "—";
                    string following = item["inputData"]?["friends_count"]?.ToString() ?? "—";
                    string age = item["inputData"]?["account_age_days"]?.ToString() ?? "—";

                    string statusNote = isBlacklisted ? "⛔ Blacklist" : "—";

                    var row = new ScanRow
                    {
                        AccountName = account,
                        Prediction = prediction.ToUpper(),
                        Confidence = $"{conf:F1}%",
                        Followers = followers,
                        Following = following,
                        Age = age,
                        StatusNote = statusNote
                    };
                    _scanResults.Add(row);

                    // Thêm vào grid trên UI thread
                    if (InvokeRequired)
                        Invoke(new Action(() => AddRowToGrid(row)));
                    else
                        AddRowToGrid(row);

                    processed++;

                    // Cập nhật progress
                    int pct = (int)((double)processed / results.Count * 90) + 10;
                    double elapsed = (DateTime.Now - startTime).TotalSeconds;
                    double eta = elapsed > 0 && processed > 0
                        ? elapsed / processed * (results.Count - processed) : 0;
                    string etaText = eta > 0 ? $"ETA: {TimeSpan.FromSeconds(eta):mm\\:ss}" : "";

                    UpdateProgress(pct,
                        $"Đã xử lý {processed:N0} / {results.Count:N0} tài khoản",
                        etaText);

                    // Nhường CPU để UI không bị đơ
                    if (processed % 50 == 0)
                        await Task.Delay(1, ct);
                }

                // ── Cập nhật summary cards ─────────────────────────────
                SafeInvoke(() =>
                {
                    lblTotalVal.Text = total.ToString("N0");
                    lblSpamVal.Text = spamCnt.ToString("N0");
                    lblRealVal.Text = realCnt.ToString("N0");
                    double spamRate = total > 0 ? (double)spamCnt / total * 100.0 : 0;
                    lblRateVal.Text = $"{spamRate:F1}%";

                    lblGridTitle.Text = $"KẾT QUẢ PHÂN TÍCH CHI TIẾT  ·  {total:N0} tài khoản"
                                      + (errCnt > 0 ? $"  ·  {errCnt} lỗi" : "");

                    btnExportResult.Enabled = _scanResults.Count > 0;
                });

                UpdateProgress(100,
                    $"Hoàn thành! {total:N0} tài khoản — {spamCnt} spam / {realCnt} thật.", "");
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Thêm 1 dòng vào DataGridView
        // ════════════════════════════════════════════════════════════
        private void AddRowToGrid(ScanRow row)
        {
            int idx = dgvResults.Rows.Add(
                row.AccountName,
                row.Prediction,
                row.Confidence,
                row.Followers,
                row.Following,
                row.Age,
                row.StatusNote);

            // Lưu tag để tô màu
            dgvResults.Rows[idx].Tag = row.Prediction;
        }

        // ════════════════════════════════════════════════════════════
        //  Tô màu dòng theo kết quả
        // ════════════════════════════════════════════════════════════
        private void DgvResults_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvResults.Rows.Count) return;
            var row = dgvResults.Rows[e.RowIndex];
            string tag = row.Tag?.ToString() ?? "";

            row.DefaultCellStyle.BackColor = tag == "SPAM"
                ? ColorRowSpam : ColorRowReal;
        }

        private void DgvResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvResults.Rows[e.RowIndex];
            string tag = row.Tag?.ToString() ?? "";

            // Tô màu cột KẾT QUẢ
            if (dgvResults.Columns[e.ColumnIndex].Name == "colPrediction")
            {
                e.CellStyle.ForeColor = tag == "SPAM" ? ColorSpam : ColorReal;
                e.CellStyle.Font = new Font(dgvResults.Font, FontStyle.Bold);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Dừng quét
        // ════════════════════════════════════════════════════════════
        private void BtnStopScan_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            btnStopScan.Enabled = false;
        }

        // ════════════════════════════════════════════════════════════
        //  Xuất CSV
        // ════════════════════════════════════════════════════════════
        private void BtnExportResult_Click(object sender, EventArgs e)
        {
            if (_scanResults.Count == 0) return;

            // ✅ C# 7.3: dùng using(...) { } thay vì using var
            using (var dlg = new SaveFileDialog
            {
                Title = "Lưu kết quả phân tích",
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = $"scan_result_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("AccountName,Prediction,Confidence,Followers,Following,AgeDays,Status");

                    foreach (var r in _scanResults)
                    {
                        sb.AppendLine(
                            $"\"{r.AccountName}\",{r.Prediction},{r.Confidence}," +
                            $"{r.Followers},{r.Following},{r.Age},\"{r.StatusNote}\"");
                    }

                    File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show(
                        $"Đã xuất {_scanResults.Count:N0} kết quả thành công!\n{dlg.FileName}",
                        "Xuất thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể lưu file:\n{ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Xóa tất cả
        // ════════════════════════════════════════════════════════════
        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            _selectedFilePath = null;
            _totalRows = 0;
            _scanResults.Clear();
            dgvResults.Rows.Clear();

            ResetSummaryCards();
            ResetDropZone();

            lblFileInfo.Text = "Chưa tải file — 0 bản ghi";
            pnlProgressArea.Visible = false;
            btnStartScan.Enabled = false;
            btnExportResult.Enabled = false;
        }

        // ════════════════════════════════════════════════════════════
        //  Helpers
        // ════════════════════════════════════════════════════════════

        private void SetScanningState(bool scanning)
        {
            SafeInvoke(() =>
            {
                btnStartScan.Enabled = !scanning;
                btnBrowse.Enabled = !scanning;
                btnClearAll.Enabled = !scanning;
                btnStopScan.Enabled = scanning;
                pnlProgressArea.Visible = scanning || (!scanning && _scanResults.Count > 0);
                btnStartScan.Text = scanning ? "Đang quét..." : "▶  BẮT ĐẦU QUÉT";
            });
        }

        private void UpdateProgress(int pct, string detail, string eta)
        {
            SafeInvoke(() =>
            {
                pnlProgressArea.Visible = true;
                int fillWidth = (int)(pnlProgressBg.Width * (pct / 100.0));
                pnlProgressFill.Width = Math.Max(0, Math.Min(fillWidth, pnlProgressBg.Width));
                lblProgressPct.Text = $"{pct}%";
                lblProgressDetail.Text = detail;
                lblETA.Text = eta;
            });
        }

        private void ResetSummaryCards()
        {
            lblTotalVal.Text = "0";
            lblSpamVal.Text = "0";
            lblRealVal.Text = "0";
            lblRateVal.Text = "0.0%";
            lblGridTitle.Text = "KẾT QUẢ PHÂN TÍCH CHI TIẾT";
        }

        private void ResetDropZone()
        {
            lblDropTitle.Text = "Kéo & thả file CSV vào đây";
            lblDropIcon.Text = "📂";
            lblDropIcon.ForeColor = ColorAccent;
            lblFileSelected.Text = "Chưa chọn file";
            lblFileSelected.ForeColor = Color.FromArgb(68, 76, 86);
        }

        /// <summary>Gọi action trên UI thread an toàn.</summary>
        private void SafeInvoke(Action action)
        {
            if (IsDisposed) return;
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }
    }
}