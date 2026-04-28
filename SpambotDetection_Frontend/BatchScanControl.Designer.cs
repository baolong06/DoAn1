namespace demo_AI
{
    partial class BatchScanControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ── Panels ────────────────────────────────────────────────────
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlDropZone = new System.Windows.Forms.Panel();
            this.pnlControlBar = new System.Windows.Forms.Panel();
            this.pnlProgressArea = new System.Windows.Forms.Panel();
            this.pnlProgressBg = new System.Windows.Forms.Panel();
            this.pnlProgressFill = new System.Windows.Forms.Panel();
            this.pnlResultArea = new System.Windows.Forms.Panel();
            this.pnlSummaryRow = new System.Windows.Forms.Panel();
            this.pnlCardTotal = new System.Windows.Forms.Panel();
            this.pnlCardSpam = new System.Windows.Forms.Panel();
            this.pnlCardReal = new System.Windows.Forms.Panel();
            this.pnlCardRate = new System.Windows.Forms.Panel();
            this.pnlGridArea = new System.Windows.Forms.Panel();
            this.pnlTopBarDivider = new System.Windows.Forms.Panel();

            // ── Drop zone controls ────────────────────────────────────────
            this.lblDropIcon = new System.Windows.Forms.Label();
            this.lblDropTitle = new System.Windows.Forms.Label();
            this.lblDropSub = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFileSelected = new System.Windows.Forms.Label();

            // ── Control bar ───────────────────────────────────────────────
            this.lblFileInfo = new System.Windows.Forms.Label();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.btnStopScan = new System.Windows.Forms.Button();
            this.btnExportResult = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();

            // ── Progress area ─────────────────────────────────────────────
            this.lblProgressTitle = new System.Windows.Forms.Label();
            this.lblProgressPct = new System.Windows.Forms.Label();
            this.lblProgressDetail = new System.Windows.Forms.Label();
            this.lblETA = new System.Windows.Forms.Label();

            // ── Summary cards ─────────────────────────────────────────────
            // Card: Total
            this.lblTotalVal = new System.Windows.Forms.Label();
            this.lblTotalLbl = new System.Windows.Forms.Label();
            this.lblTotalIcon = new System.Windows.Forms.Label();
            // Card: Spam
            this.lblSpamVal = new System.Windows.Forms.Label();
            this.lblSpamLbl = new System.Windows.Forms.Label();
            this.lblSpamIcon = new System.Windows.Forms.Label();
            // Card: Real
            this.lblRealVal = new System.Windows.Forms.Label();
            this.lblRealLbl = new System.Windows.Forms.Label();
            this.lblRealIcon = new System.Windows.Forms.Label();
            // Card: Rate
            this.lblRateVal = new System.Windows.Forms.Label();
            this.lblRateLbl = new System.Windows.Forms.Label();
            this.lblRateIcon = new System.Windows.Forms.Label();

            // ── Data grid ─────────────────────────────────────────────────
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrediction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConfidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFollowers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFollowing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // ── Tooltip ───────────────────────────────────────────────────
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);

            // ── Suspend ───────────────────────────────────────────────────
            this.pnlMain.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlDropZone.SuspendLayout();
            this.pnlControlBar.SuspendLayout();
            this.pnlProgressArea.SuspendLayout();
            this.pnlProgressBg.SuspendLayout();
            this.pnlResultArea.SuspendLayout();
            this.pnlSummaryRow.SuspendLayout();
            this.pnlCardTotal.SuspendLayout();
            this.pnlCardSpam.SuspendLayout();
            this.pnlCardReal.SuspendLayout();
            this.pnlCardRate.SuspendLayout();
            this.pnlGridArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvResults).BeginInit();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════
            //  Root UserControl
            // ══════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.Controls.Add(this.pnlMain);
            this.Name = "BatchScanControl";
            this.Size = new System.Drawing.Size(1050, 728);

            // ══════════════════════════════════════════════════════════════
            //  pnlMain
            // ══════════════════════════════════════════════════════════════
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.pnlMain.Controls.Add(this.pnlResultArea);
            this.pnlMain.Controls.Add(this.pnlProgressArea);
            this.pnlMain.Controls.Add(this.pnlControlBar);
            this.pnlMain.Controls.Add(this.pnlTopBar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.pnlMain.TabIndex = 0;

            // ══════════════════════════════════════════════════════════════
            //  pnlTopBar — drop zone + file info (Dock: Top, 200px)
            // ══════════════════════════════════════════════════════════════
            this.pnlTopBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopBar.Controls.Add(this.pnlDropZone);
            this.pnlTopBar.Controls.Add(this.pnlTopBarDivider);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1002, 192);
            this.pnlTopBar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlTopBar.TabIndex = 0;

            // pnlTopBarDivider
            this.pnlTopBarDivider.BackColor = System.Drawing.Color.FromArgb(33, 38, 45);
            this.pnlTopBarDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopBarDivider.Name = "pnlTopBarDivider";
            this.pnlTopBarDivider.Size = new System.Drawing.Size(1002, 1);
            this.pnlTopBarDivider.TabIndex = 1;

            // ── pnlDropZone — dashed border drag-drop area ────────────────
            this.pnlDropZone.AllowDrop = true;
            this.pnlDropZone.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.pnlDropZone.Controls.Add(this.lblDropIcon);
            this.pnlDropZone.Controls.Add(this.lblDropTitle);
            this.pnlDropZone.Controls.Add(this.lblDropSub);
            this.pnlDropZone.Controls.Add(this.btnBrowse);
            this.pnlDropZone.Controls.Add(this.lblFileSelected);
            this.pnlDropZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDropZone.Name = "pnlDropZone";
            this.pnlDropZone.Size = new System.Drawing.Size(1002, 179);
            this.pnlDropZone.TabIndex = 0;
            // Note: dashed border drawn via Paint event in code-behind

            this.lblDropIcon.AutoSize = false;
            this.lblDropIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F,
                                           System.Drawing.FontStyle.Regular,
                                           System.Drawing.GraphicsUnit.Point);
            this.lblDropIcon.ForeColor = System.Drawing.Color.FromArgb(0, 212, 170);
            this.lblDropIcon.Location = new System.Drawing.Point(0, 20);
            this.lblDropIcon.Name = "lblDropIcon";
            this.lblDropIcon.Size = new System.Drawing.Size(1002, 56);
            this.lblDropIcon.Text = "📂";
            this.lblDropIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDropIcon.TabIndex = 0;

            this.lblDropTitle.AutoSize = false;
            this.lblDropTitle.Font = new System.Drawing.Font("Segoe UI", 13F,
                                            System.Drawing.FontStyle.Bold,
                                            System.Drawing.GraphicsUnit.Point);
            this.lblDropTitle.ForeColor = System.Drawing.Color.FromArgb(220, 226, 234);
            this.lblDropTitle.Location = new System.Drawing.Point(0, 78);
            this.lblDropTitle.Name = "lblDropTitle";
            this.lblDropTitle.Size = new System.Drawing.Size(1002, 28);
            this.lblDropTitle.Text = "Kéo & thả file CSV vào đây";
            this.lblDropTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDropTitle.TabIndex = 1;

            this.lblDropSub.AutoSize = false;
            this.lblDropSub.Font = new System.Drawing.Font("Segoe UI", 9F,
                                          System.Drawing.FontStyle.Regular,
                                          System.Drawing.GraphicsUnit.Point);
            this.lblDropSub.ForeColor = System.Drawing.Color.FromArgb(110, 118, 129);
            this.lblDropSub.Location = new System.Drawing.Point(0, 108);
            this.lblDropSub.Name = "lblDropSub";
            this.lblDropSub.Size = new System.Drawing.Size(1002, 20);
            this.lblDropSub.Text = "hoặc nhấn nút bên dưới để chọn file  ·  Định dạng: .csv  ·  Tối đa 10,000 dòng";
            this.lblDropSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDropSub.TabIndex = 2;

            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(33, 38, 45);
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(44, 50, 60);
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9.5F,
                                           System.Drawing.FontStyle.Regular,
                                           System.Drawing.GraphicsUnit.Point);
            this.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(0, 212, 170);
            this.btnBrowse.Location = new System.Drawing.Point(426, 136);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(150, 34);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "📁  Chọn file CSV";
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;

            this.lblFileSelected.AutoSize = false;
            this.lblFileSelected.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                               System.Drawing.FontStyle.Regular,
                                               System.Drawing.GraphicsUnit.Point);
            this.lblFileSelected.ForeColor = System.Drawing.Color.FromArgb(68, 76, 86);
            this.lblFileSelected.Location = new System.Drawing.Point(0, 155);
            this.lblFileSelected.Name = "lblFileSelected";
            this.lblFileSelected.Size = new System.Drawing.Size(1002, 18);
            this.lblFileSelected.Text = "Chưa chọn file";
            this.lblFileSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFileSelected.TabIndex = 4;

            // ══════════════════════════════════════════════════════════════
            //  pnlControlBar — action buttons row (Dock: Top, 62px)
            // ══════════════════════════════════════════════════════════════
            this.pnlControlBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlControlBar.Controls.Add(this.lblFileInfo);
            this.pnlControlBar.Controls.Add(this.btnStartScan);
            this.pnlControlBar.Controls.Add(this.btnStopScan);
            this.pnlControlBar.Controls.Add(this.btnExportResult);
            this.pnlControlBar.Controls.Add(this.btnClearAll);
            this.pnlControlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControlBar.Name = "pnlControlBar";
            this.pnlControlBar.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlControlBar.Size = new System.Drawing.Size(1002, 62);
            this.pnlControlBar.TabIndex = 1;

            this.lblFileInfo.AutoSize = false;
            this.lblFileInfo.Font = new System.Drawing.Font("Segoe UI", 9F,
                                           System.Drawing.FontStyle.Regular,
                                           System.Drawing.GraphicsUnit.Point);
            this.lblFileInfo.ForeColor = System.Drawing.Color.FromArgb(110, 118, 129);
            this.lblFileInfo.Location = new System.Drawing.Point(0, 18);
            this.lblFileInfo.Name = "lblFileInfo";
            this.lblFileInfo.Size = new System.Drawing.Size(340, 26);
            this.lblFileInfo.Text = "Chưa tải file — 0 bản ghi";
            this.lblFileInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFileInfo.TabIndex = 0;

            // btnStartScan — primary
            this.btnStartScan.BackColor = System.Drawing.Color.FromArgb(0, 212, 170);
            this.btnStartScan.FlatAppearance.BorderSize = 0;
            this.btnStartScan.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(0, 190, 152);
            this.btnStartScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartScan.Font = new System.Drawing.Font("Segoe UI", 10F,
                                              System.Drawing.FontStyle.Bold,
                                              System.Drawing.GraphicsUnit.Point);
            this.btnStartScan.ForeColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.btnStartScan.Location = new System.Drawing.Point(358, 12);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(168, 40);
            this.btnStartScan.TabIndex = 1;
            this.btnStartScan.Text = "▶  BẮT ĐẦU QUÉT";
            this.btnStartScan.Enabled = false;
            this.btnStartScan.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnStopScan — danger
            this.btnStopScan.BackColor = System.Drawing.Color.FromArgb(40, 22, 22);
            this.btnStopScan.FlatAppearance.BorderSize = 0;
            this.btnStopScan.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(60, 30, 30);
            this.btnStopScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopScan.Font = new System.Drawing.Font("Segoe UI", 10F,
                                             System.Drawing.FontStyle.Regular,
                                             System.Drawing.GraphicsUnit.Point);
            this.btnStopScan.ForeColor = System.Drawing.Color.FromArgb(248, 81, 73);
            this.btnStopScan.Location = new System.Drawing.Point(534, 12);
            this.btnStopScan.Name = "btnStopScan";
            this.btnStopScan.Size = new System.Drawing.Size(130, 40);
            this.btnStopScan.TabIndex = 2;
            this.btnStopScan.Text = "⏹  Dừng";
            this.btnStopScan.Enabled = false;
            this.btnStopScan.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnExportResult — blue
            this.btnExportResult.BackColor = System.Drawing.Color.FromArgb(22, 40, 55);
            this.btnExportResult.FlatAppearance.BorderSize = 0;
            this.btnExportResult.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(28, 50, 68);
            this.btnExportResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportResult.Font = new System.Drawing.Font("Segoe UI", 10F,
                                                System.Drawing.FontStyle.Regular,
                                                System.Drawing.GraphicsUnit.Point);
            this.btnExportResult.ForeColor = System.Drawing.Color.FromArgb(88, 166, 255);
            this.btnExportResult.Location = new System.Drawing.Point(672, 12);
            this.btnExportResult.Name = "btnExportResult";
            this.btnExportResult.Size = new System.Drawing.Size(168, 40);
            this.btnExportResult.TabIndex = 3;
            this.btnExportResult.Text = "💾  Xuất CSV";
            this.btnExportResult.Enabled = false;
            this.btnExportResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolTip1.SetToolTip(this.btnExportResult, "Xuất kết quả phân tích ra file CSV");

            // btnClearAll — ghost
            this.btnClearAll.BackColor = System.Drawing.Color.FromArgb(33, 38, 45);
            this.btnClearAll.FlatAppearance.BorderSize = 0;
            this.btnClearAll.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(44, 50, 60);
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 10F,
                                             System.Drawing.FontStyle.Regular,
                                             System.Drawing.GraphicsUnit.Point);
            this.btnClearAll.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.btnClearAll.Location = new System.Drawing.Point(848, 12);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(130, 40);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "🗑  Xóa tất cả";
            this.btnClearAll.Cursor = System.Windows.Forms.Cursors.Hand;

            // ══════════════════════════════════════════════════════════════
            //  pnlProgressArea — progress bar + status (Dock: Top, 68px)
            // ══════════════════════════════════════════════════════════════
            this.pnlProgressArea.BackColor = System.Drawing.Color.Transparent;
            this.pnlProgressArea.Controls.Add(this.lblProgressTitle);
            this.pnlProgressArea.Controls.Add(this.lblProgressPct);
            this.pnlProgressArea.Controls.Add(this.pnlProgressBg);
            this.pnlProgressArea.Controls.Add(this.lblProgressDetail);
            this.pnlProgressArea.Controls.Add(this.lblETA);
            this.pnlProgressArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProgressArea.Name = "pnlProgressArea";
            this.pnlProgressArea.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlProgressArea.Size = new System.Drawing.Size(1002, 68);
            this.pnlProgressArea.TabIndex = 2;
            this.pnlProgressArea.Visible = false; // shown during scan

            this.lblProgressTitle.AutoSize = false;
            this.lblProgressTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                               System.Drawing.FontStyle.Bold);
            this.lblProgressTitle.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.lblProgressTitle.Location = new System.Drawing.Point(0, 8);
            this.lblProgressTitle.Name = "lblProgressTitle";
            this.lblProgressTitle.Size = new System.Drawing.Size(300, 18);
            this.lblProgressTitle.Text = "ĐANG QUÉT";
            this.lblProgressTitle.TabIndex = 0;

            this.lblProgressPct.AutoSize = false;
            this.lblProgressPct.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                              System.Drawing.FontStyle.Bold);
            this.lblProgressPct.ForeColor = System.Drawing.Color.FromArgb(0, 212, 170);
            this.lblProgressPct.Location = new System.Drawing.Point(940, 8);
            this.lblProgressPct.Name = "lblProgressPct";
            this.lblProgressPct.Size = new System.Drawing.Size(62, 18);
            this.lblProgressPct.Text = "0%";
            this.lblProgressPct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProgressPct.TabIndex = 1;

            // Progress track
            this.pnlProgressBg.BackColor = System.Drawing.Color.FromArgb(33, 38, 45);
            this.pnlProgressBg.Controls.Add(this.pnlProgressFill);
            this.pnlProgressBg.Location = new System.Drawing.Point(0, 30);
            this.pnlProgressBg.Name = "pnlProgressBg";
            this.pnlProgressBg.Size = new System.Drawing.Size(1002, 16);
            this.pnlProgressBg.TabIndex = 2;

            // Progress fill (width set in code-behind)
            this.pnlProgressFill.BackColor = System.Drawing.Color.FromArgb(0, 212, 170);
            this.pnlProgressFill.Location = new System.Drawing.Point(0, 0);
            this.pnlProgressFill.Name = "pnlProgressFill";
            this.pnlProgressFill.Size = new System.Drawing.Size(0, 16);
            this.pnlProgressFill.TabIndex = 0;

            this.lblProgressDetail.AutoSize = false;
            this.lblProgressDetail.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                                System.Drawing.FontStyle.Regular);
            this.lblProgressDetail.ForeColor = System.Drawing.Color.FromArgb(110, 118, 129);
            this.lblProgressDetail.Location = new System.Drawing.Point(0, 50);
            this.lblProgressDetail.Name = "lblProgressDetail";
            this.lblProgressDetail.Size = new System.Drawing.Size(600, 16);
            this.lblProgressDetail.Text = "Đang xử lý...";
            this.lblProgressDetail.TabIndex = 3;

            this.lblETA.AutoSize = false;
            this.lblETA.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                      System.Drawing.FontStyle.Regular);
            this.lblETA.ForeColor = System.Drawing.Color.FromArgb(68, 76, 86);
            this.lblETA.Location = new System.Drawing.Point(700, 50);
            this.lblETA.Name = "lblETA";
            this.lblETA.Size = new System.Drawing.Size(302, 16);
            this.lblETA.Text = "";
            this.lblETA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblETA.TabIndex = 4;

            // ══════════════════════════════════════════════════════════════
            //  pnlResultArea — summary cards + grid (Dock: Fill)
            // ══════════════════════════════════════════════════════════════
            this.pnlResultArea.BackColor = System.Drawing.Color.Transparent;
            this.pnlResultArea.Controls.Add(this.pnlGridArea);
            this.pnlResultArea.Controls.Add(this.pnlSummaryRow);
            this.pnlResultArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultArea.Name = "pnlResultArea";
            this.pnlResultArea.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlResultArea.TabIndex = 3;

            // ── pnlSummaryRow — 4 stat cards (Dock: Top, 96px) ────────────
            this.pnlSummaryRow.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummaryRow.Controls.Add(this.pnlCardTotal);
            this.pnlSummaryRow.Controls.Add(this.pnlCardSpam);
            this.pnlSummaryRow.Controls.Add(this.pnlCardReal);
            this.pnlSummaryRow.Controls.Add(this.pnlCardRate);
            this.pnlSummaryRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummaryRow.Name = "pnlSummaryRow";
            this.pnlSummaryRow.Size = new System.Drawing.Size(1002, 96);
            this.pnlSummaryRow.TabIndex = 0;

            // ── Card: Total ───────────────────────────────────────────────
            this.pnlCardTotal.BackColor = System.Drawing.Color.FromArgb(28, 33, 40);
            this.pnlCardTotal.Controls.Add(this.lblTotalIcon);
            this.pnlCardTotal.Controls.Add(this.lblTotalVal);
            this.pnlCardTotal.Controls.Add(this.lblTotalLbl);
            this.pnlCardTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlCardTotal.Name = "pnlCardTotal";
            this.pnlCardTotal.Size = new System.Drawing.Size(240, 88);
            this.pnlCardTotal.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlCardTotal.TabIndex = 0;

            this.lblTotalIcon.AutoSize = false;
            this.lblTotalIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 22F);
            this.lblTotalIcon.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.lblTotalIcon.Location = new System.Drawing.Point(16, 12);
            this.lblTotalIcon.Name = "lblTotalIcon";
            this.lblTotalIcon.Size = new System.Drawing.Size(48, 48);
            this.lblTotalIcon.Text = "📋";
            this.lblTotalIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalIcon.TabIndex = 0;

            this.lblTotalVal.AutoSize = false;
            this.lblTotalVal.Font = new System.Drawing.Font("Segoe UI", 22F,
                                           System.Drawing.FontStyle.Bold);
            this.lblTotalVal.ForeColor = System.Drawing.Color.FromArgb(240, 246, 252);
            this.lblTotalVal.Location = new System.Drawing.Point(72, 12);
            this.lblTotalVal.Name = "lblTotalVal";
            this.lblTotalVal.Size = new System.Drawing.Size(150, 38);
            this.lblTotalVal.Text = "0";
            this.lblTotalVal.TabIndex = 1;

            this.lblTotalLbl.AutoSize = false;
            this.lblTotalLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                           System.Drawing.FontStyle.Bold);
            this.lblTotalLbl.ForeColor = System.Drawing.Color.FromArgb(110, 118, 129);
            this.lblTotalLbl.Location = new System.Drawing.Point(72, 52);
            this.lblTotalLbl.Name = "lblTotalLbl";
            this.lblTotalLbl.Size = new System.Drawing.Size(150, 18);
            this.lblTotalLbl.Text = "TỔNG TÀI KHOẢN";
            this.lblTotalLbl.TabIndex = 2;

            // ── Card: Spam ────────────────────────────────────────────────
            this.pnlCardSpam.BackColor = System.Drawing.Color.FromArgb(28, 33, 40);
            this.pnlCardSpam.Controls.Add(this.lblSpamIcon);
            this.pnlCardSpam.Controls.Add(this.lblSpamVal);
            this.pnlCardSpam.Controls.Add(this.lblSpamLbl);
            this.pnlCardSpam.Location = new System.Drawing.Point(248, 0);
            this.pnlCardSpam.Name = "pnlCardSpam";
            this.pnlCardSpam.Size = new System.Drawing.Size(240, 88);
            this.pnlCardSpam.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlCardSpam.TabIndex = 1;

            this.lblSpamIcon.AutoSize = false;
            this.lblSpamIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 22F);
            this.lblSpamIcon.ForeColor = System.Drawing.Color.FromArgb(248, 81, 73);
            this.lblSpamIcon.Location = new System.Drawing.Point(16, 12);
            this.lblSpamIcon.Name = "lblSpamIcon";
            this.lblSpamIcon.Size = new System.Drawing.Size(48, 48);
            this.lblSpamIcon.Text = "🤖";
            this.lblSpamIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpamIcon.TabIndex = 0;

            this.lblSpamVal.AutoSize = false;
            this.lblSpamVal.Font = new System.Drawing.Font("Segoe UI", 22F,
                                          System.Drawing.FontStyle.Bold);
            this.lblSpamVal.ForeColor = System.Drawing.Color.FromArgb(248, 81, 73);
            this.lblSpamVal.Location = new System.Drawing.Point(72, 12);
            this.lblSpamVal.Name = "lblSpamVal";
            this.lblSpamVal.Size = new System.Drawing.Size(150, 38);
            this.lblSpamVal.Text = "0";
            this.lblSpamVal.TabIndex = 1;

            this.lblSpamLbl.AutoSize = false;
            this.lblSpamLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                          System.Drawing.FontStyle.Bold);
            this.lblSpamLbl.ForeColor = System.Drawing.Color.FromArgb(110, 118, 129);
            this.lblSpamLbl.Location = new System.Drawing.Point(72, 52);
            this.lblSpamLbl.Name = "lblSpamLbl";
            this.lblSpamLbl.Size = new System.Drawing.Size(150, 18);
            this.lblSpamLbl.Text = "SPAMBOT";
            this.lblSpamLbl.TabIndex = 2;

            // ── Card: Real ────────────────────────────────────────────────
            this.pnlCardReal.BackColor = System.Drawing.Color.FromArgb(28, 33, 40);
            this.pnlCardReal.Controls.Add(this.lblRealIcon);
            this.pnlCardReal.Controls.Add(this.lblRealVal);
            this.pnlCardReal.Controls.Add(this.lblRealLbl);
            this.pnlCardReal.Location = new System.Drawing.Point(496, 0);
            this.pnlCardReal.Name = "pnlCardReal";
            this.pnlCardReal.Size = new System.Drawing.Size(240, 88);
            this.pnlCardReal.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlCardReal.TabIndex = 2;

            this.lblRealIcon.AutoSize = false;
            this.lblRealIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 22F);
            this.lblRealIcon.ForeColor = System.Drawing.Color.FromArgb(63, 185, 80);
            this.lblRealIcon.Location = new System.Drawing.Point(16, 12);
            this.lblRealIcon.Name = "lblRealIcon";
            this.lblRealIcon.Size = new System.Drawing.Size(48, 48);
            this.lblRealIcon.Text = "✅";
            this.lblRealIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRealIcon.TabIndex = 0;

            this.lblRealVal.AutoSize = false;
            this.lblRealVal.Font = new System.Drawing.Font("Segoe UI", 22F,
                                          System.Drawing.FontStyle.Bold);
            this.lblRealVal.ForeColor = System.Drawing.Color.FromArgb(63, 185, 80);
            this.lblRealVal.Location = new System.Drawing.Point(72, 12);
            this.lblRealVal.Name = "lblRealVal";
            this.lblRealVal.Size = new System.Drawing.Size(150, 38);
            this.lblRealVal.Text = "0";
            this.lblRealVal.TabIndex = 1;

            this.lblRealLbl.AutoSize = false;
            this.lblRealLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                          System.Drawing.FontStyle.Bold);
            this.lblRealLbl.ForeColor = System.Drawing.Color.FromArgb(110, 118, 129);
            this.lblRealLbl.Location = new System.Drawing.Point(72, 52);
            this.lblRealLbl.Name = "lblRealLbl";
            this.lblRealLbl.Size = new System.Drawing.Size(150, 18);
            this.lblRealLbl.Text = "TÀI KHOẢN THẬT";
            this.lblRealLbl.TabIndex = 2;

            // ── Card: Spam Rate ───────────────────────────────────────────
            this.pnlCardRate.BackColor = System.Drawing.Color.FromArgb(28, 33, 40);
            this.pnlCardRate.Controls.Add(this.lblRateIcon);
            this.pnlCardRate.Controls.Add(this.lblRateVal);
            this.pnlCardRate.Controls.Add(this.lblRateLbl);
            this.pnlCardRate.Location = new System.Drawing.Point(744, 0);
            this.pnlCardRate.Name = "pnlCardRate";
            this.pnlCardRate.Size = new System.Drawing.Size(240, 88);
            this.pnlCardRate.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlCardRate.TabIndex = 3;

            this.lblRateIcon.AutoSize = false;
            this.lblRateIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 22F);
            this.lblRateIcon.ForeColor = System.Drawing.Color.FromArgb(210, 153, 34);
            this.lblRateIcon.Location = new System.Drawing.Point(16, 12);
            this.lblRateIcon.Name = "lblRateIcon";
            this.lblRateIcon.Size = new System.Drawing.Size(48, 48);
            this.lblRateIcon.Text = "📊";
            this.lblRateIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRateIcon.TabIndex = 0;

            this.lblRateVal.AutoSize = false;
            this.lblRateVal.Font = new System.Drawing.Font("Segoe UI", 22F,
                                          System.Drawing.FontStyle.Bold);
            this.lblRateVal.ForeColor = System.Drawing.Color.FromArgb(210, 153, 34);
            this.lblRateVal.Location = new System.Drawing.Point(72, 12);
            this.lblRateVal.Name = "lblRateVal";
            this.lblRateVal.Size = new System.Drawing.Size(150, 38);
            this.lblRateVal.Text = "0.0%";
            this.lblRateVal.TabIndex = 1;

            this.lblRateLbl.AutoSize = false;
            this.lblRateLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                          System.Drawing.FontStyle.Bold);
            this.lblRateLbl.ForeColor = System.Drawing.Color.FromArgb(110, 118, 129);
            this.lblRateLbl.Location = new System.Drawing.Point(72, 52);
            this.lblRateLbl.Name = "lblRateLbl";
            this.lblRateLbl.Size = new System.Drawing.Size(150, 18);
            this.lblRateLbl.Text = "TỶ LỆ SPAM";
            this.lblRateLbl.TabIndex = 2;

            // ══════════════════════════════════════════════════════════════
            //  pnlGridArea — label + DataGridView (Dock: Fill)
            // ══════════════════════════════════════════════════════════════
            this.pnlGridArea.BackColor = System.Drawing.Color.Transparent;
            this.pnlGridArea.Controls.Add(this.dgvResults);
            this.pnlGridArea.Controls.Add(this.lblGridTitle);
            this.pnlGridArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridArea.Name = "pnlGridArea";
            this.pnlGridArea.TabIndex = 1;

            this.lblGridTitle.AutoSize = false;
            this.lblGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 10F,
                                            System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(500, 36);
            this.lblGridTitle.Padding = new System.Windows.Forms.Padding(0, 8, 0, 4);
            this.lblGridTitle.Text = "KẾT QUẢ PHÂN TÍCH CHI TIẾT";
            this.lblGridTitle.TabIndex = 0;

            // ── DataGridView ──────────────────────────────────────────────
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvResults.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            this.dgvResults.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(33, 38, 45);
            this.dgvResults.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(139, 148, 158);
            this.dgvResults.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvResults.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(33, 38, 45);
            this.dgvResults.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(139, 148, 158);
            this.dgvResults.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvResults.ColumnHeadersHeight = 38;

            this.dgvResults.DefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(22, 27, 34);
            this.dgvResults.DefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(220, 226, 234);
            this.dgvResults.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvResults.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(33, 38, 45);
            this.dgvResults.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(240, 246, 252);
            this.dgvResults.DefaultCellStyle.WrapMode =
                System.Windows.Forms.DataGridViewTriState.False;

            this.dgvResults.GridColor = System.Drawing.Color.FromArgb(33, 38, 45);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowTemplate.Height = 36;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.TabIndex = 1;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colAccount,
                this.colPrediction,
                this.colConfidence,
                this.colFollowers,
                this.colFollowing,
                this.colAge,
                this.colStatus
            });

            // ── Columns ───────────────────────────────────────────────────
            this.colAccount.HeaderText = "TÀI KHOẢN";
            this.colAccount.Name = "colAccount";
            this.colAccount.FillWeight = 20F;
            this.colAccount.MinimumWidth = 120;
            this.colAccount.ReadOnly = true;
            this.colAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

            this.colPrediction.HeaderText = "KẾT QUẢ";
            this.colPrediction.Name = "colPrediction";
            this.colPrediction.FillWeight = 13F;
            this.colPrediction.MinimumWidth = 90;
            this.colPrediction.ReadOnly = true;
            this.colPrediction.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colConfidence.HeaderText = "ĐỘ TIN CẬY";
            this.colConfidence.Name = "colConfidence";
            this.colConfidence.FillWeight = 14F;
            this.colConfidence.MinimumWidth = 95;
            this.colConfidence.ReadOnly = true;
            this.colConfidence.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colFollowers.HeaderText = "FOLLOWERS";
            this.colFollowers.Name = "colFollowers";
            this.colFollowers.FillWeight = 13F;
            this.colFollowers.MinimumWidth = 90;
            this.colFollowers.ReadOnly = true;
            this.colFollowers.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colFollowing.HeaderText = "FOLLOWING";
            this.colFollowing.Name = "colFollowing";
            this.colFollowing.FillWeight = 13F;
            this.colFollowing.MinimumWidth = 90;
            this.colFollowing.ReadOnly = true;
            this.colFollowing.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colAge.HeaderText = "TUỔI TK (ngày)";
            this.colAge.Name = "colAge";
            this.colAge.FillWeight = 14F;
            this.colAge.MinimumWidth = 110;
            this.colAge.ReadOnly = true;
            this.colAge.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colStatus.HeaderText = "TRẠNG THÁI";
            this.colStatus.Name = "colStatus";
            this.colStatus.FillWeight = 13F;
            this.colStatus.MinimumWidth = 90;
            this.colStatus.ReadOnly = true;
            this.colStatus.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // ── Resume ────────────────────────────────────────────────────
            this.pnlProgressBg.ResumeLayout(false);
            this.pnlProgressArea.ResumeLayout(false);
            this.pnlCardTotal.ResumeLayout(false);
            this.pnlCardSpam.ResumeLayout(false);
            this.pnlCardReal.ResumeLayout(false);
            this.pnlCardRate.ResumeLayout(false);
            this.pnlSummaryRow.ResumeLayout(false);
            this.pnlGridArea.ResumeLayout(false);
            this.pnlResultArea.ResumeLayout(false);
            this.pnlDropZone.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlControlBar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvResults).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // ── Layout ────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlTopBarDivider;
        private System.Windows.Forms.Panel pnlControlBar;
        private System.Windows.Forms.Panel pnlProgressArea;
        private System.Windows.Forms.Panel pnlProgressBg;
        private System.Windows.Forms.Panel pnlProgressFill;
        private System.Windows.Forms.Panel pnlResultArea;
        private System.Windows.Forms.Panel pnlSummaryRow;
        private System.Windows.Forms.Panel pnlGridArea;

        // ── Drop zone ─────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlDropZone;
        private System.Windows.Forms.Label lblDropIcon;
        private System.Windows.Forms.Label lblDropTitle;
        private System.Windows.Forms.Label lblDropSub;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFileSelected;

        // ── Control bar ───────────────────────────────────────────────────
        private System.Windows.Forms.Label lblFileInfo;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.Button btnStopScan;
        private System.Windows.Forms.Button btnExportResult;
        private System.Windows.Forms.Button btnClearAll;

        // ── Progress ──────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblProgressTitle;
        private System.Windows.Forms.Label lblProgressPct;
        private System.Windows.Forms.Label lblProgressDetail;
        private System.Windows.Forms.Label lblETA;

        // ── Summary cards ─────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlCardTotal;
        private System.Windows.Forms.Label lblTotalIcon;
        private System.Windows.Forms.Label lblTotalVal;
        private System.Windows.Forms.Label lblTotalLbl;

        private System.Windows.Forms.Panel pnlCardSpam;
        private System.Windows.Forms.Label lblSpamIcon;
        private System.Windows.Forms.Label lblSpamVal;
        private System.Windows.Forms.Label lblSpamLbl;

        private System.Windows.Forms.Panel pnlCardReal;
        private System.Windows.Forms.Label lblRealIcon;
        private System.Windows.Forms.Label lblRealVal;
        private System.Windows.Forms.Label lblRealLbl;

        private System.Windows.Forms.Panel pnlCardRate;
        private System.Windows.Forms.Label lblRateIcon;
        private System.Windows.Forms.Label lblRateVal;
        private System.Windows.Forms.Label lblRateLbl;

        // ── Grid ──────────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrediction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConfidence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFollowers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFollowing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}