using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace demo_AI
{
    public partial class StatisticsControl : UserControl
    {
        // ════════════════════════════════════════════════════════════
        //  Màu sắc
        // ════════════════════════════════════════════════════════════
        private static readonly Color ColorSpam = Color.FromArgb(248, 81, 73);
        private static readonly Color ColorReal = Color.FromArgb(63, 185, 80);
        private static readonly Color ColorAccent = Color.FromArgb(0, 212, 170);
        private static readonly Color ColorAmber = Color.FromArgb(210, 153, 34);
        private static readonly Color ColorBlue = Color.FromArgb(88, 166, 255);
        private static readonly Color ColorMuted = Color.FromArgb(110, 118, 129);
        private static readonly Color ColorBg2 = Color.FromArgb(22, 27, 34);

        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        // Cache dữ liệu lịch sử để vẽ trend + export
        private readonly List<JToken> _historyCache = new List<JToken>();
        private int _totalScans, _totalSpam, _totalReal;
        private decimal _avgConf;

        // ════════════════════════════════════════════════════════════
        //  Constructor
        // ════════════════════════════════════════════════════════════
        public StatisticsControl()
        {
            InitializeComponent();
            AttachEvents();
        }

        // ════════════════════════════════════════════════════════════
        //  Responsive layout — tự scale khi resize
        // ════════════════════════════════════════════════════════════
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            if (pnlKpiRow == null || Width < 100) return;

            // ── KPI row: chia 4 card đều nhau với gap 10px ──
            int kpiGap = 10;
            int kpiW = pnlKpiRow.ClientSize.Width;
            int totalGap = kpiGap * 3; // 3 khoảng giữa 4 card
            int cardW = Math.Max(180, (kpiW - totalGap) / 4);
            int cardH = pnlKpiRow.ClientSize.Height - pnlKpiRow.Padding.Vertical;

            Panel[] kpis = { pnlKpi1, pnlKpi2, pnlKpi3, pnlKpi4 };
            for (int i = 0; i < kpis.Length; i++)
            {
                kpis[i].SetBounds(i * (cardW + kpiGap), pnlKpiRow.Padding.Top, cardW, cardH);
                // Accent bar luôn full width của card
                var accent = kpis[i].Controls.Count > 0 ? kpis[i].Controls[0] as Panel : null;
                if (accent != null) accent.Width = cardW;
                // Icon luôn nằm góc phải
                var icon = kpis[i].Controls.Count > 1 ? kpis[i].Controls[1] as Label : null;
                if (icon != null) icon.Left = cardW - icon.Width - 14;
            }

            // ── Content area: pnlLeft 38%, pnlRight 62% (với gap 14px) ──
            if (pnlContent == null) return;
            int contentW = pnlContent.ClientSize.Width;
            int gap = 14;
            int leftW = (int)(contentW * 0.38) - gap / 2;
            leftW = Math.Max(300, leftW);
            pnlLeft.Width = leftW;

            // Pie canvas chiều rộng theo card
            if (pnlPieCanvas != null)
                pnlPieCanvas.Width = pnlPieCard.ClientSize.Width - pnlPieCard.Padding.Horizontal;
            if (pnlPieLegendRow != null)
                pnlPieLegendRow.Width = pnlPieCard.ClientSize.Width - pnlPieCard.Padding.Horizontal;
            if (lblPieHeader != null)
                lblPieHeader.Width = pnlPieCard.ClientSize.Width - pnlPieCard.Padding.Horizontal;

            // Conf bars chiều rộng
            if (pnlConfBars != null)
            {
                pnlConfBars.Width = pnlConfCard.ClientSize.Width - pnlConfCard.Padding.Horizontal;
                int barW = pnlConfBars.Width - 66 - 36; // label(66) + val(36)
                barW = Math.Max(80, barW);
                Panel[] bgBars = { pnlConfBar1Bg, pnlConfBar2Bg, pnlConfBar3Bg, pnlConfBar4Bg, pnlConfBar5Bg };
                Label[] valLbls = { lblConfBar1Val, lblConfBar2Val, lblConfBar3Val, lblConfBar4Val, lblConfBar5Val };
                foreach (var bg in bgBars) bg.Width = barW;
                foreach (var vl in valLbls) vl.Left = 66 + barW + 4;
            }

            // Trend + TopList resize
            if (pnlTrendCanvas != null)
            {
                pnlTrendCanvas.Width = pnlTrendCard.ClientSize.Width - pnlTrendCard.Padding.Horizontal;
                pnlTrendCanvas.Invalidate();
            }

            pnlPieCanvas?.Invalidate();
        }

        // ════════════════════════════════════════════════════════════
        //  Gắn events
        // ════════════════════════════════════════════════════════════
        private void AttachEvents()
        {
            this.Load += async (s, e) => await LoadAllAsync();
            btnRefresh.Click += async (s, e) => await LoadAllAsync();
            btnExportCsv.Click += BtnExportCsv_Click;
            pnlPieCanvas.Paint += PnlPieCanvas_Paint;
            pnlTrendCanvas.Paint += PnlTrendCanvas_Paint;

            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
        }

        // ════════════════════════════════════════════════════════════
        //  Load tất cả dữ liệu
        // ════════════════════════════════════════════════════════════
        private async Task LoadAllAsync()
        {
            EnsureAuthHeader();
            SetLoading(true);

            try
            {
                // Gọi song song: statistics + history
                var statsTask = LoadStatisticsAsync();
                var historyTask = LoadHistoryAsync();
                await Task.WhenAll(statsTask, historyTask);
            }
            catch (Exception ex)
            {
                lblKpi1Sub.Text = $"Lỗi: {ex.Message}";
            }
            finally
            {
                SetLoading(false);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  GET /api/statistics
        // ════════════════════════════════════════════════════════════
        private async Task LoadStatisticsAsync()
        {
            try
            {
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/statistics";
                var resp = await _http.GetAsync(url);
                string body = await resp.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);

                if (!resp.IsSuccessStatusCode) return;

                var d = json["data"];
                if (d == null) return;

                _totalScans = d["totalScans"]?.Value<int>() ?? 0;
                _totalSpam = d["totalSpam"]?.Value<int>() ?? 0;
                _totalReal = d["totalReal"]?.Value<int>() ?? 0;
                _avgConf = d["avgConfidence"]?.Value<decimal>() ?? 0m;
                int last24h = d["scansLast24h"]?.Value<int>() ?? 0;
                int blCount = d["activeBlacklistCount"]?.Value<int>() ?? 0;
                int batch = d["batchScans"]?.Value<int>() ?? 0;
                int single = d["singleScans"]?.Value<int>() ?? 0;

                double spamRate = _totalScans > 0
                    ? Math.Round((double)_totalSpam / _totalScans * 100.0, 1) : 0;

                SafeInvoke(() =>
                {
                    // KPI cards
                    lblKpi1Val.Text = _totalScans.ToString("N0");
                    lblKpi1Sub.Text = $"{last24h:N0} trong 24 giờ qua";

                    lblKpi2Val.Text = _totalSpam.ToString("N0");
                    lblKpi2Sub.Text = $"🚫 Blacklist: {blCount}";

                    lblKpi3Val.Text = _totalReal.ToString("N0");
                    lblKpi3Sub.Text = $"Avg confidence: {_avgConf:F1}%";

                    lblKpi4Val.Text = $"{spamRate:F1}%";
                    lblKpi4Sub.Text = $"Batch: {batch}  |  Single: {single}";

                    // Pie chart % labels
                    lblPieSpamPct.Text = $"{spamRate:F1}%";
                    lblLegSpam.Text = $"Spambot  {_totalSpam:N0}";

                    double realRate = 100.0 - spamRate;
                    lblPieRealPct.Text = $"{realRate:F1}%";
                    lblLegReal.Text = $"Thật  {_totalReal:N0}";

                    // Trigger repaint pie chart
                    pnlPieCanvas.Invalidate();
                });
            }
            catch { /* không break UI */ }
        }

        // ════════════════════════════════════════════════════════════
        //  GET /api/scan/history — lấy top 50 + dữ liệu confidence
        // ════════════════════════════════════════════════════════════
        private async Task LoadHistoryAsync()
        {
            try
            {
                string from = dtpFrom.Value.ToString("yyyy-MM-dd");
                string to = dtpTo.Value.ToString("yyyy-MM-dd");
                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/scan/history" +
                              $"?page=1&pageSize=50&from={from}&to={to}";
                var resp = await _http.GetAsync(url);
                string body = await resp.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);

                if (!resp.IsSuccessStatusCode) return;

                var items = (json["data"]?["items"] as JArray) ?? new JArray();

                _historyCache.Clear();
                foreach (var item in items)
                    _historyCache.Add(item);

                SafeInvoke(() =>
                {
                    // Top list grid
                    dgvTopList.Rows.Clear();
                    int rank = 1;
                    foreach (var item in _historyCache)
                    {
                        string pred = item["prediction"]?.ToString()?.ToUpper() ?? "—";
                        decimal conf = item["confidence"]?.Value<decimal>() ?? 0m;
                        string date = DateTime.TryParse(item["scannedAt"]?.ToString(), out var dt)
                                       ? dt.ToString("dd/MM HH:mm") : "—";
                        int idx = dgvTopList.Rows.Add(rank++,
                            item["accountName"]?.ToString() ?? "—",
                            pred, $"{conf:F1}%", date);

                        // Tô màu cột kết quả
                        dgvTopList.Rows[idx].Cells["colPrediction"].Style.ForeColor =
                            pred == "SPAM" ? ColorSpam : ColorReal;
                        dgvTopList.Rows[idx].Cells["colPrediction"].Style.Font =
                            new Font(dgvTopList.Font, FontStyle.Bold);
                    }

                    // Confidence bars
                    DrawConfidenceBars(items);

                    // Trend chart
                    pnlTrendCanvas.Invalidate();
                });
            }
            catch { /* không break UI */ }
        }

        // ════════════════════════════════════════════════════════════
        //  Vẽ PIE CHART (GDI+, không cần thư viện)
        // ════════════════════════════════════════════════════════════
        private void PnlPieCanvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(ColorBg2);

            int w = pnlPieCanvas.Width;
            int h = pnlPieCanvas.Height;
            int diameter = Math.Min(w, h) - 24;
            int x = (w - diameter) / 2;
            int y = (h - diameter) / 2;
            var rect = new Rectangle(x, y, diameter, diameter);

            double spamRate = _totalScans > 0
                ? (double)_totalSpam / _totalScans * 100.0 : 0;
            float spamAngle = (float)(spamRate / 100.0 * 360.0);
            float realAngle = 360f - spamAngle;

            if (_totalScans == 0)
            {
                // Vòng tròn placeholder
                using (var pen = new Pen(Color.FromArgb(33, 38, 45), 24f))
                    g.DrawEllipse(pen, rect);

                using (var font = new Font("Segoe UI", 9f))
                using (var brush = new SolidBrush(ColorMuted))
                {
                    var fmt = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString("Chưa có dữ liệu", font, brush, new RectangleF(0, 0, w, h), fmt);
                }
                return;
            }

            // Vẽ donut
            int thick = 28;
            var innerRect = new Rectangle(
                rect.X + thick, rect.Y + thick,
                rect.Width - thick * 2, rect.Height - thick * 2);

            using (var path = new GraphicsPath())
            {
                // Spam slice
                using (var brush = new SolidBrush(ColorSpam))
                    g.FillPie(brush, rect, -90f, spamAngle);

                // Real slice
                using (var brush = new SolidBrush(ColorReal))
                    g.FillPie(brush, rect, -90f + spamAngle, realAngle);

                // Khoét giữa (donut hole)
                using (var brush = new SolidBrush(ColorBg2))
                    g.FillEllipse(brush, innerRect);
            }

            // Text giữa
            using (var fontBig = new Font("Segoe UI", 13f, FontStyle.Bold))
            using (var fontSmall = new Font("Segoe UI", 8f))
            using (var brushWhite = new SolidBrush(Color.FromArgb(220, 226, 234)))
            using (var brushMuted = new SolidBrush(ColorMuted))
            {
                var fmtC = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                var center = new RectangleF(0, y + thick, w, diameter - thick * 2);
                g.DrawString($"{spamRate:F0}%", fontBig, brushWhite, center, fmtC);
                var below = new RectangleF(0, y + thick + 22, w, diameter - thick * 2);
                g.DrawString("Spam", fontSmall, brushMuted, below, fmtC);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Confidence bars
        // ════════════════════════════════════════════════════════════
        private void DrawConfidenceBars(JArray items)
        {
            int[] buckets = new int[5]; // 0-20, 20-40, 40-60, 60-80, 80-100

            foreach (var item in items)
            {
                decimal conf = item["confidence"]?.Value<decimal>() ?? 0m;
                int bucket = conf >= 80 ? 4
                           : conf >= 60 ? 3
                           : conf >= 40 ? 2
                           : conf >= 20 ? 1 : 0;
                buckets[bucket]++;
            }

            int maxVal = 1;
            foreach (int b in buckets) if (b > maxVal) maxVal = b;

            Panel[] fills = { pnlConfBar1Fill, pnlConfBar2Fill, pnlConfBar3Fill, pnlConfBar4Fill, pnlConfBar5Fill };
            Label[] vals = { lblConfBar1Val, lblConfBar2Val, lblConfBar3Val, lblConfBar4Val, lblConfBar5Val };
            Panel[] bgs = { pnlConfBar1Bg, pnlConfBar2Bg, pnlConfBar3Bg, pnlConfBar4Bg, pnlConfBar5Bg };

            for (int i = 0; i < 5; i++)
            {
                int pct = (int)((double)buckets[i] / maxVal * bgs[i].Width);
                fills[i].Width = Math.Max(0, Math.Min(pct, bgs[i].Width));
                vals[i].Text = buckets[i].ToString();
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Vẽ TREND CHART (line chart đơn giản bằng GDI+)
        // ════════════════════════════════════════════════════════════
        private void PnlTrendCanvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(ColorBg2);

            int w = pnlTrendCanvas.Width;
            int h = pnlTrendCanvas.Height;
            int padL = 36, padR = 16, padT = 12, padB = 24;

            if (_historyCache.Count == 0)
            {
                using (var font = new Font("Segoe UI", 9f))
                using (var brush = new SolidBrush(ColorMuted))
                {
                    var fmt = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString("Chưa có dữ liệu trong khoảng thời gian đã chọn",
                        font, brush, new RectangleF(0, 0, w, h), fmt);
                }
                return;
            }

            // Gom dữ liệu theo ngày
            var daily = new SortedDictionary<string, int>();
            foreach (var item in _historyCache)
            {
                if (!DateTime.TryParse(item["scannedAt"]?.ToString(), out var dt)) continue;
                string key = dt.ToString("dd/MM");
                if (!daily.ContainsKey(key)) daily[key] = 0;
                daily[key]++;
            }

            var days = new List<string>(daily.Keys);
            var vals = new List<int>(daily.Values);
            if (days.Count == 0) return;

            int maxV = 1;
            foreach (int v in vals) if (v > maxV) maxV = v;

            float chartW = w - padL - padR;
            float chartH = h - padT - padB;
            float stepX = days.Count > 1 ? chartW / (days.Count - 1) : chartW;

            // Grid lines
            using (var gridPen = new Pen(Color.FromArgb(33, 38, 45), 1f))
            {
                gridPen.DashStyle = DashStyle.Dot;
                for (int i = 0; i <= 4; i++)
                {
                    float gy = padT + chartH * i / 4f;
                    g.DrawLine(gridPen, padL, gy, w - padR, gy);
                }
            }

            // Y-axis labels
            using (var font = new Font("Segoe UI", 7f))
            using (var brush = new SolidBrush(ColorMuted))
            {
                for (int i = 0; i <= 4; i++)
                {
                    float gy = padT + chartH * i / 4f;
                    int val = (int)Math.Round(maxV * (1 - i / 4.0));
                    g.DrawString(val.ToString(), font, brush,
                        new RectangleF(0, gy - 7, padL - 2, 14),
                        new StringFormat { Alignment = StringAlignment.Far });
                }
            }

            // Line + points
            var points = new PointF[days.Count];
            for (int i = 0; i < days.Count; i++)
            {
                float px = padL + i * stepX;
                float py = padT + chartH * (1f - (float)vals[i] / maxV);
                points[i] = new PointF(px, py);
            }

            // Gradient fill under line
            if (points.Length > 1)
            {
                var fillPts = new List<PointF>(points)
                {
                    new PointF(points[points.Length - 1].X, padT + chartH),
                    new PointF(points[0].X, padT + chartH)
                };
                using (var brush = new LinearGradientBrush(
                    new PointF(0, padT), new PointF(0, padT + chartH),
                    Color.FromArgb(60, ColorAccent), Color.FromArgb(0, ColorAccent)))
                    g.FillPolygon(brush, fillPts.ToArray());

                using (var pen = new Pen(ColorAccent, 2f))
                    g.DrawLines(pen, points);
            }

            // Dots + X labels
            using (var dotBrush = new SolidBrush(ColorAccent))
            using (var labelBrush = new SolidBrush(ColorMuted))
            using (var font = new Font("Segoe UI", 7f))
            {
                for (int i = 0; i < points.Length; i++)
                {
                    g.FillEllipse(dotBrush,
                        points[i].X - 3.5f, points[i].Y - 3.5f, 7f, 7f);

                    // X label — chỉ hiện 1 số lẻ để tránh chồng nhau
                    if (i % Math.Max(1, days.Count / 8) == 0)
                    {
                        g.DrawString(days[i], font, labelBrush,
                            new RectangleF(points[i].X - 18, padT + chartH + 4, 36, 16),
                            new StringFormat { Alignment = StringAlignment.Center });
                    }
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Xuất CSV
        // ════════════════════════════════════════════════════════════
        private void BtnExportCsv_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                Title = "Xuất báo cáo thống kê",
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = $"statistics_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
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
                // Header tổng quan
                sb.AppendLine("=== BÁO CÁO THỐNG KÊ SPAMBOT DETECTION ===");
                sb.AppendLine($"Xuất lúc:,{DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine($"Khoảng thời gian:,{dtpFrom.Value:dd/MM/yyyy} – {dtpTo.Value:dd/MM/yyyy}");
                sb.AppendLine();
                sb.AppendLine("Tổng lượt quét,Spambot,Thật,Tỷ lệ Spam,Avg Confidence");
                double spamRate = _totalScans > 0 ? (double)_totalSpam / _totalScans * 100.0 : 0;
                sb.AppendLine($"{_totalScans},{_totalSpam},{_totalReal},{spamRate:F1}%,{_avgConf:F1}%");
                sb.AppendLine();

                // Chi tiết từng bản ghi
                sb.AppendLine("AccountName,Prediction,Confidence,ScannedAt");
                foreach (var item in _historyCache)
                {
                    string acct = $"\"{item["accountName"]?.ToString() ?? ""}\"";
                    string pred = item["prediction"]?.ToString() ?? "";
                    string conf = item["confidence"]?.ToString() ?? "";
                    string date = item["scannedAt"]?.ToString() ?? "";
                    sb.AppendLine($"{acct},{pred},{conf},{date}");
                }

                File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show($"Đã xuất báo cáo thành công!\n{dlg.FileName}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dlg.Dispose();
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Helpers
        // ════════════════════════════════════════════════════════════
        private void SetLoading(bool loading)
        {
            SafeInvoke(() =>
            {
                btnRefresh.Enabled = !loading;
                btnExportCsv.Enabled = !loading;
                btnRefresh.Text = loading ? "Đang tải..." : "🔄  Làm mới";
            });
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

        private void SafeInvoke(Action action)
        {
            if (IsDisposed) return;
            if (InvokeRequired) Invoke(action);
            else action();
        }
    }
}