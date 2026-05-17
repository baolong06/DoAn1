namespace demo_AI
{
    partial class ConfigControl
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLogCard = new System.Windows.Forms.Panel();
            this.lblLogHeader = new System.Windows.Forms.Label();
            this.pnlLogAccent = new System.Windows.Forms.Panel();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.pnlStatusCard = new System.Windows.Forms.Panel();
            this.lblStatusHeader = new System.Windows.Forms.Label();
            this.pnlStatusAccent = new System.Windows.Forms.Panel();
            this.pnlStatusBadge = new System.Windows.Forms.Panel();
            this.pnlStatusDotBg = new System.Windows.Forms.Panel();
            this.pnlStatusDot = new System.Windows.Forms.Panel();
            this.lblStatusLive = new System.Windows.Forms.Label();
            this.lblStatusUrl = new System.Windows.Forms.Label();
            this.lblStatusUrlVal = new System.Windows.Forms.Label();
            this.lblStatusLatency = new System.Windows.Forms.Label();
            this.lblStatusLatencyVal = new System.Windows.Forms.Label();
            this.lblStatusLastPing = new System.Windows.Forms.Label();
            this.lblStatusLastPingVal = new System.Windows.Forms.Label();
            this.lblStatusModel = new System.Windows.Forms.Label();
            this.lblStatusModelVal = new System.Windows.Forms.Label();
            this.btnRefreshStatus = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlDbCard = new System.Windows.Forms.Panel();
            this.lblDbCardHeader = new System.Windows.Forms.Label();
            this.pnlDbCardAccent = new System.Windows.Forms.Panel();
            this.lblDbPathHdr = new System.Windows.Forms.Label();
            this.pnlDbPathWrap = new System.Windows.Forms.Panel();
            this.txtDbPath = new System.Windows.Forms.TextBox();
            this.btnBrowseDb = new System.Windows.Forms.Button();
            this.lblDbHint = new System.Windows.Forms.Label();
            this.pnlBtnRowDb = new System.Windows.Forms.Panel();
            this.btnSaveDb = new System.Windows.Forms.Button();
            this.btnTestDb = new System.Windows.Forms.Button();
            this.pnlApiCard = new System.Windows.Forms.Panel();
            this.lblApiCardHeader = new System.Windows.Forms.Label();
            this.pnlApiCardAccent = new System.Windows.Forms.Panel();
            this.lblNgrokHdr = new System.Windows.Forms.Label();
            this.pnlNgrokWrap = new System.Windows.Forms.Panel();
            this.txtNgrokUrl = new System.Windows.Forms.TextBox();
            this.lblNgrokHint = new System.Windows.Forms.Label();
            this.lblTimeoutHdr = new System.Windows.Forms.Label();
            this.pnlTimeoutWrap = new System.Windows.Forms.Panel();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblTimeoutUnit = new System.Windows.Forms.Label();
            this.lblRetryHdr = new System.Windows.Forms.Label();
            this.pnlRetryWrap = new System.Windows.Forms.Panel();
            this.nudRetry = new System.Windows.Forms.NumericUpDown();
            this.lblRetryUnit = new System.Windows.Forms.Label();
            this.lblApiKeyHdr = new System.Windows.Forms.Label();
            this.pnlApiKeyWrap = new System.Windows.Forms.Panel();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.chkShowApiKey = new System.Windows.Forms.CheckBox();
            this.pnlBtnRowApi = new System.Windows.Forms.Panel();
            this.btnSaveApi = new System.Windows.Forms.Button();
            this.btnPingApi = new System.Windows.Forms.Button();
            this.btnResetApi = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLogCard.SuspendLayout();
            this.pnlStatusCard.SuspendLayout();
            this.pnlStatusBadge.SuspendLayout();
            this.pnlStatusDotBg.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlDbCard.SuspendLayout();
            this.pnlDbPathWrap.SuspendLayout();
            this.pnlBtnRowDb.SuspendLayout();
            this.pnlApiCard.SuspendLayout();
            this.pnlNgrokWrap.SuspendLayout();
            this.pnlTimeoutWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            this.pnlRetryWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetry)).BeginInit();
            this.pnlApiKeyWrap.SuspendLayout();
            this.pnlBtnRowApi.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.pnlMain.Size = new System.Drawing.Size(900, 631);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.pnlLogCard);
            this.pnlRight.Controls.Add(this.pnlStatusCard);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(483, 20);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(393, 591);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlLogCard
            // 
            this.pnlLogCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlLogCard.Controls.Add(this.lblLogHeader);
            this.pnlLogCard.Controls.Add(this.pnlLogAccent);
            this.pnlLogCard.Controls.Add(this.btnClearLog);
            this.pnlLogCard.Controls.Add(this.txtLog);
            this.pnlLogCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogCard.Location = new System.Drawing.Point(0, 276);
            this.pnlLogCard.Margin = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlLogCard.Name = "pnlLogCard";
            this.pnlLogCard.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.pnlLogCard.Size = new System.Drawing.Size(393, 315);
            this.pnlLogCard.TabIndex = 1;
            // 
            // lblLogHeader
            // 
            this.lblLogHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLogHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblLogHeader.Location = new System.Drawing.Point(14, 12);
            this.lblLogHeader.Name = "lblLogHeader";
            this.lblLogHeader.Size = new System.Drawing.Size(257, 23);
            this.lblLogHeader.TabIndex = 0;
            this.lblLogHeader.Text = "📋  Nhật ký hoạt động";
            // 
            // pnlLogAccent
            // 
            this.pnlLogAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlLogAccent.Location = new System.Drawing.Point(14, 38);
            this.pnlLogAccent.Name = "pnlLogAccent";
            this.pnlLogAccent.Size = new System.Drawing.Size(38, 3);
            this.pnlLogAccent.TabIndex = 1;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnClearLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnClearLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnClearLog.Location = new System.Drawing.Point(537, 12);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(77, 23);
            this.btnClearLog.TabIndex = 2;
            this.btnClearLog.Text = "🗑  Xóa log";
            this.btnClearLog.UseVisualStyleBackColor = false;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.txtLog.Location = new System.Drawing.Point(14, 47);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(615, 331);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "[系統] Nhật ký khởi động...\n";
            this.toolTip1.SetToolTip(this.txtLog, "Log ping, save, error sẽ hiện ở đây");
            // 
            // pnlStatusCard
            // 
            this.pnlStatusCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlStatusCard.Controls.Add(this.lblStatusHeader);
            this.pnlStatusCard.Controls.Add(this.pnlStatusAccent);
            this.pnlStatusCard.Controls.Add(this.pnlStatusBadge);
            this.pnlStatusCard.Controls.Add(this.lblStatusUrl);
            this.pnlStatusCard.Controls.Add(this.lblStatusUrlVal);
            this.pnlStatusCard.Controls.Add(this.lblStatusLatency);
            this.pnlStatusCard.Controls.Add(this.lblStatusLatencyVal);
            this.pnlStatusCard.Controls.Add(this.lblStatusLastPing);
            this.pnlStatusCard.Controls.Add(this.lblStatusLastPingVal);
            this.pnlStatusCard.Controls.Add(this.lblStatusModel);
            this.pnlStatusCard.Controls.Add(this.lblStatusModelVal);
            this.pnlStatusCard.Controls.Add(this.btnRefreshStatus);
            this.pnlStatusCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatusCard.Location = new System.Drawing.Point(0, 0);
            this.pnlStatusCard.Name = "pnlStatusCard";
            this.pnlStatusCard.Padding = new System.Windows.Forms.Padding(4);
            this.pnlStatusCard.Size = new System.Drawing.Size(393, 276);
            this.pnlStatusCard.TabIndex = 0;
            // 
            // lblStatusHeader
            // 
            this.lblStatusHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatusHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblStatusHeader.Location = new System.Drawing.Point(17, 14);
            this.lblStatusHeader.Name = "lblStatusHeader";
            this.lblStatusHeader.Size = new System.Drawing.Size(360, 24);
            this.lblStatusHeader.TabIndex = 0;
            this.lblStatusHeader.Text = "📡  Trạng thái kết nối AI";
            // 
            // pnlStatusAccent
            // 
            this.pnlStatusAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlStatusAccent.Location = new System.Drawing.Point(17, 42);
            this.pnlStatusAccent.Name = "pnlStatusAccent";
            this.pnlStatusAccent.Size = new System.Drawing.Size(38, 3);
            this.pnlStatusAccent.TabIndex = 1;
            // 
            // pnlStatusBadge
            // 
            this.pnlStatusBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlStatusBadge.Controls.Add(this.pnlStatusDotBg);
            this.pnlStatusBadge.Controls.Add(this.lblStatusLive);
            this.pnlStatusBadge.Location = new System.Drawing.Point(17, 56);
            this.pnlStatusBadge.Name = "pnlStatusBadge";
            this.pnlStatusBadge.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pnlStatusBadge.Size = new System.Drawing.Size(365, 60);
            this.pnlStatusBadge.TabIndex = 2;
            // 
            // pnlStatusDotBg
            // 
            this.pnlStatusDotBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlStatusDotBg.Controls.Add(this.pnlStatusDot);
            this.pnlStatusDotBg.Location = new System.Drawing.Point(12, 19);
            this.pnlStatusDotBg.Name = "pnlStatusDotBg";
            this.pnlStatusDotBg.Size = new System.Drawing.Size(17, 17);
            this.pnlStatusDotBg.TabIndex = 0;
            // 
            // pnlStatusDot
            // 
            this.pnlStatusDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.pnlStatusDot.Location = new System.Drawing.Point(0, 0);
            this.pnlStatusDot.Name = "pnlStatusDot";
            this.pnlStatusDot.Size = new System.Drawing.Size(17, 17);
            this.pnlStatusDot.TabIndex = 0;
            // 
            // lblStatusLive
            // 
            this.lblStatusLive.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatusLive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblStatusLive.Location = new System.Drawing.Point(36, 12);
            this.lblStatusLive.Name = "lblStatusLive";
            this.lblStatusLive.Size = new System.Drawing.Size(343, 31);
            this.lblStatusLive.TabIndex = 1;
            this.lblStatusLive.Text = "Chưa kiểm tra";
            // 
            // lblStatusUrl
            // 
            this.lblStatusUrl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblStatusUrl.Location = new System.Drawing.Point(17, 130);
            this.lblStatusUrl.Name = "lblStatusUrl";
            this.lblStatusUrl.Size = new System.Drawing.Size(115, 19);
            this.lblStatusUrl.TabIndex = 3;
            this.lblStatusUrl.Text = "Endpoint";
            // 
            // lblStatusUrlVal
            // 
            this.lblStatusUrlVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusUrlVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblStatusUrlVal.Location = new System.Drawing.Point(135, 130);
            this.lblStatusUrlVal.Name = "lblStatusUrlVal";
            this.lblStatusUrlVal.Size = new System.Drawing.Size(247, 19);
            this.lblStatusUrlVal.TabIndex = 4;
            this.lblStatusUrlVal.Text = "—";
            this.lblStatusUrlVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatusLatency
            // 
            this.lblStatusLatency.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusLatency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblStatusLatency.Location = new System.Drawing.Point(17, 157);
            this.lblStatusLatency.Name = "lblStatusLatency";
            this.lblStatusLatency.Size = new System.Drawing.Size(115, 19);
            this.lblStatusLatency.TabIndex = 5;
            this.lblStatusLatency.Text = "Độ trễ (ms)";
            // 
            // lblStatusLatencyVal
            // 
            this.lblStatusLatencyVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusLatencyVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.lblStatusLatencyVal.Location = new System.Drawing.Point(135, 157);
            this.lblStatusLatencyVal.Name = "lblStatusLatencyVal";
            this.lblStatusLatencyVal.Size = new System.Drawing.Size(247, 19);
            this.lblStatusLatencyVal.TabIndex = 6;
            this.lblStatusLatencyVal.Text = "—";
            this.lblStatusLatencyVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatusLastPing
            // 
            this.lblStatusLastPing.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusLastPing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblStatusLastPing.Location = new System.Drawing.Point(17, 184);
            this.lblStatusLastPing.Name = "lblStatusLastPing";
            this.lblStatusLastPing.Size = new System.Drawing.Size(115, 19);
            this.lblStatusLastPing.TabIndex = 7;
            this.lblStatusLastPing.Text = "Lần ping cuối";
            // 
            // lblStatusLastPingVal
            // 
            this.lblStatusLastPingVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusLastPingVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblStatusLastPingVal.Location = new System.Drawing.Point(135, 184);
            this.lblStatusLastPingVal.Name = "lblStatusLastPingVal";
            this.lblStatusLastPingVal.Size = new System.Drawing.Size(247, 19);
            this.lblStatusLastPingVal.TabIndex = 8;
            this.lblStatusLastPingVal.Text = "—";
            this.lblStatusLastPingVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatusModel
            // 
            this.lblStatusModel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblStatusModel.Location = new System.Drawing.Point(17, 211);
            this.lblStatusModel.Name = "lblStatusModel";
            this.lblStatusModel.Size = new System.Drawing.Size(115, 19);
            this.lblStatusModel.TabIndex = 9;
            this.lblStatusModel.Text = "Model AI";
            // 
            // lblStatusModelVal
            // 
            this.lblStatusModelVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusModelVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblStatusModelVal.Location = new System.Drawing.Point(135, 211);
            this.lblStatusModelVal.Name = "lblStatusModelVal";
            this.lblStatusModelVal.Size = new System.Drawing.Size(247, 19);
            this.lblStatusModelVal.TabIndex = 10;
            this.lblStatusModelVal.Text = "GAT + MLP";
            this.lblStatusModelVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefreshStatus
            // 
            this.btnRefreshStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.btnRefreshStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshStatus.FlatAppearance.BorderSize = 0;
            this.btnRefreshStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(152)))));
            this.btnRefreshStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.btnRefreshStatus.Location = new System.Drawing.Point(17, 242);
            this.btnRefreshStatus.Name = "btnRefreshStatus";
            this.btnRefreshStatus.Size = new System.Drawing.Size(160, 26);
            this.btnRefreshStatus.TabIndex = 11;
            this.btnRefreshStatus.Text = "🔄  Kiểm tra ngay";
            this.btnRefreshStatus.UseVisualStyleBackColor = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Controls.Add(this.pnlDbCard);
            this.pnlLeft.Controls.Add(this.pnlApiCard);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(24, 20);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlLeft.Size = new System.Drawing.Size(459, 591);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlDbCard
            // 
            this.pnlDbCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlDbCard.Controls.Add(this.lblDbCardHeader);
            this.pnlDbCard.Controls.Add(this.pnlDbCardAccent);
            this.pnlDbCard.Controls.Add(this.lblDbPathHdr);
            this.pnlDbCard.Controls.Add(this.pnlDbPathWrap);
            this.pnlDbCard.Controls.Add(this.btnBrowseDb);
            this.pnlDbCard.Controls.Add(this.lblDbHint);
            this.pnlDbCard.Controls.Add(this.pnlBtnRowDb);
            this.pnlDbCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDbCard.Location = new System.Drawing.Point(0, 352);
            this.pnlDbCard.Margin = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlDbCard.Name = "pnlDbCard";
            this.pnlDbCard.Padding = new System.Windows.Forms.Padding(4);
            this.pnlDbCard.Size = new System.Drawing.Size(443, 239);
            this.pnlDbCard.TabIndex = 1;
            // 
            // lblDbCardHeader
            // 
            this.lblDbCardHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDbCardHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblDbCardHeader.Location = new System.Drawing.Point(17, 14);
            this.lblDbCardHeader.Name = "lblDbCardHeader";
            this.lblDbCardHeader.Size = new System.Drawing.Size(394, 24);
            this.lblDbCardHeader.TabIndex = 0;
            this.lblDbCardHeader.Text = "🗄️  Cấu hình Cơ sở dữ liệu";
            // 
            // pnlDbCardAccent
            // 
            this.pnlDbCardAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlDbCardAccent.Location = new System.Drawing.Point(17, 42);
            this.pnlDbCardAccent.Name = "pnlDbCardAccent";
            this.pnlDbCardAccent.Size = new System.Drawing.Size(38, 3);
            this.pnlDbCardAccent.TabIndex = 1;
            // 
            // lblDbPathHdr
            // 
            this.lblDbPathHdr.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblDbPathHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblDbPathHdr.Location = new System.Drawing.Point(17, 56);
            this.lblDbPathHdr.Name = "lblDbPathHdr";
            this.lblDbPathHdr.Size = new System.Drawing.Size(394, 14);
            this.lblDbPathHdr.TabIndex = 2;
            this.lblDbPathHdr.Text = "ĐƯỜNG DẪN FILE DATABASE (SQLite)";
            // 
            // pnlDbPathWrap
            // 
            this.pnlDbPathWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlDbPathWrap.Controls.Add(this.txtDbPath);
            this.pnlDbPathWrap.Location = new System.Drawing.Point(17, 74);
            this.pnlDbPathWrap.Name = "pnlDbPathWrap";
            this.pnlDbPathWrap.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.pnlDbPathWrap.Size = new System.Drawing.Size(317, 36);
            this.pnlDbPathWrap.TabIndex = 3;
            // 
            // txtDbPath
            // 
            this.txtDbPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.txtDbPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDbPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDbPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDbPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.txtDbPath.Location = new System.Drawing.Point(9, 7);
            this.txtDbPath.Name = "txtDbPath";
            this.txtDbPath.Size = new System.Drawing.Size(299, 18);
            this.txtDbPath.TabIndex = 0;
            this.txtDbPath.Text = "spambot.db";
            this.toolTip1.SetToolTip(this.txtDbPath, "Đường dẫn tuyệt đối hoặc tương đối đến file .db");
            // 
            // btnBrowseDb
            // 
            this.btnBrowseDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnBrowseDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseDb.FlatAppearance.BorderSize = 0;
            this.btnBrowseDb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnBrowseDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseDb.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBrowseDb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnBrowseDb.Location = new System.Drawing.Point(341, 74);
            this.btnBrowseDb.Name = "btnBrowseDb";
            this.btnBrowseDb.Size = new System.Drawing.Size(72, 36);
            this.btnBrowseDb.TabIndex = 4;
            this.btnBrowseDb.Text = "📁  Duyệt";
            this.toolTip1.SetToolTip(this.btnBrowseDb, "Chọn file SQLite từ hộp thoại");
            this.btnBrowseDb.UseVisualStyleBackColor = false;
            // 
            // lblDbHint
            // 
            this.lblDbHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDbHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblDbHint.Location = new System.Drawing.Point(17, 116);
            this.lblDbHint.Name = "lblDbHint";
            this.lblDbHint.Size = new System.Drawing.Size(394, 15);
            this.lblDbHint.TabIndex = 5;
            this.lblDbHint.Text = "💡  Khuyến nghị đặt file .db cùng thư mục với .exe để tiện di chuyển";
            // 
            // pnlBtnRowDb
            // 
            this.pnlBtnRowDb.BackColor = System.Drawing.Color.Transparent;
            this.pnlBtnRowDb.Controls.Add(this.btnSaveDb);
            this.pnlBtnRowDb.Controls.Add(this.btnTestDb);
            this.pnlBtnRowDb.Location = new System.Drawing.Point(17, 140);
            this.pnlBtnRowDb.Name = "pnlBtnRowDb";
            this.pnlBtnRowDb.Size = new System.Drawing.Size(394, 46);
            this.pnlBtnRowDb.TabIndex = 6;
            // 
            // btnSaveDb
            // 
            this.btnSaveDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.btnSaveDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveDb.FlatAppearance.BorderSize = 0;
            this.btnSaveDb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(152)))));
            this.btnSaveDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveDb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.btnSaveDb.Location = new System.Drawing.Point(0, 0);
            this.btnSaveDb.Name = "btnSaveDb";
            this.btnSaveDb.Size = new System.Drawing.Size(146, 40);
            this.btnSaveDb.TabIndex = 0;
            this.btnSaveDb.Text = "💾  Lưu đường dẫn";
            this.btnSaveDb.UseVisualStyleBackColor = false;
            // 
            // btnTestDb
            // 
            this.btnTestDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnTestDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestDb.FlatAppearance.BorderSize = 0;
            this.btnTestDb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.btnTestDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestDb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTestDb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.btnTestDb.Location = new System.Drawing.Point(153, 0);
            this.btnTestDb.Name = "btnTestDb";
            this.btnTestDb.Size = new System.Drawing.Size(132, 40);
            this.btnTestDb.TabIndex = 1;
            this.btnTestDb.Text = "🔌  Test kết nối";
            this.toolTip1.SetToolTip(this.btnTestDb, "Mở kết nối SQLite và đọc schema để kiểm tra");
            this.btnTestDb.UseVisualStyleBackColor = false;
            // 
            // pnlApiCard
            // 
            this.pnlApiCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlApiCard.Controls.Add(this.lblApiCardHeader);
            this.pnlApiCard.Controls.Add(this.pnlApiCardAccent);
            this.pnlApiCard.Controls.Add(this.lblNgrokHdr);
            this.pnlApiCard.Controls.Add(this.pnlNgrokWrap);
            this.pnlApiCard.Controls.Add(this.lblNgrokHint);
            this.pnlApiCard.Controls.Add(this.lblTimeoutHdr);
            this.pnlApiCard.Controls.Add(this.pnlTimeoutWrap);
            this.pnlApiCard.Controls.Add(this.lblTimeoutUnit);
            this.pnlApiCard.Controls.Add(this.lblRetryHdr);
            this.pnlApiCard.Controls.Add(this.pnlRetryWrap);
            this.pnlApiCard.Controls.Add(this.lblRetryUnit);
            this.pnlApiCard.Controls.Add(this.lblApiKeyHdr);
            this.pnlApiCard.Controls.Add(this.pnlApiKeyWrap);
            this.pnlApiCard.Controls.Add(this.chkShowApiKey);
            this.pnlApiCard.Controls.Add(this.pnlBtnRowApi);
            this.pnlApiCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlApiCard.Location = new System.Drawing.Point(0, 0);
            this.pnlApiCard.Name = "pnlApiCard";
            this.pnlApiCard.Padding = new System.Windows.Forms.Padding(4);
            this.pnlApiCard.Size = new System.Drawing.Size(443, 352);
            this.pnlApiCard.TabIndex = 0;
            // 
            // lblApiCardHeader
            // 
            this.lblApiCardHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblApiCardHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblApiCardHeader.Location = new System.Drawing.Point(17, 14);
            this.lblApiCardHeader.Name = "lblApiCardHeader";
            this.lblApiCardHeader.Size = new System.Drawing.Size(394, 24);
            this.lblApiCardHeader.TabIndex = 0;
            this.lblApiCardHeader.Text = "⚙️  Cấu hình AI Service (Ngrok)";
            // 
            // pnlApiCardAccent
            // 
            this.pnlApiCardAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlApiCardAccent.Location = new System.Drawing.Point(17, 42);
            this.pnlApiCardAccent.Name = "pnlApiCardAccent";
            this.pnlApiCardAccent.Size = new System.Drawing.Size(38, 3);
            this.pnlApiCardAccent.TabIndex = 1;
            // 
            // lblNgrokHdr
            // 
            this.lblNgrokHdr.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNgrokHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblNgrokHdr.Location = new System.Drawing.Point(17, 56);
            this.lblNgrokHdr.Name = "lblNgrokHdr";
            this.lblNgrokHdr.Size = new System.Drawing.Size(394, 14);
            this.lblNgrokHdr.TabIndex = 2;
            this.lblNgrokHdr.Text = "NGROK ENDPOINT URL";
            // 
            // pnlNgrokWrap
            // 
            this.pnlNgrokWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlNgrokWrap.Controls.Add(this.txtNgrokUrl);
            this.pnlNgrokWrap.Location = new System.Drawing.Point(17, 74);
            this.pnlNgrokWrap.Name = "pnlNgrokWrap";
            this.pnlNgrokWrap.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.pnlNgrokWrap.Size = new System.Drawing.Size(394, 36);
            this.pnlNgrokWrap.TabIndex = 3;
            // 
            // txtNgrokUrl
            // 
            this.txtNgrokUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.txtNgrokUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNgrokUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgrokUrl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNgrokUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.txtNgrokUrl.Location = new System.Drawing.Point(9, 7);
            this.txtNgrokUrl.Name = "txtNgrokUrl";
            this.txtNgrokUrl.Size = new System.Drawing.Size(376, 18);
            this.txtNgrokUrl.TabIndex = 0;
            this.txtNgrokUrl.Text = "https://xxxx-xx-xx-xxx-xx.ngrok-free.app";
            this.toolTip1.SetToolTip(this.txtNgrokUrl, "URL public do Ngrok cấp khi khởi động Google Colab");
            // 
            // lblNgrokHint
            // 
            this.lblNgrokHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNgrokHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblNgrokHint.Location = new System.Drawing.Point(17, 116);
            this.lblNgrokHint.Name = "lblNgrokHint";
            this.lblNgrokHint.Size = new System.Drawing.Size(394, 15);
            this.lblNgrokHint.TabIndex = 4;
            this.lblNgrokHint.Text = "💡  Lấy URL từ output cell Ngrok trong Google Colab";
            // 
            // lblTimeoutHdr
            // 
            this.lblTimeoutHdr.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTimeoutHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblTimeoutHdr.Location = new System.Drawing.Point(17, 140);
            this.lblTimeoutHdr.Name = "lblTimeoutHdr";
            this.lblTimeoutHdr.Size = new System.Drawing.Size(180, 14);
            this.lblTimeoutHdr.TabIndex = 5;
            this.lblTimeoutHdr.Text = "REQUEST TIMEOUT";
            // 
            // pnlTimeoutWrap
            // 
            this.pnlTimeoutWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlTimeoutWrap.Controls.Add(this.nudTimeout);
            this.pnlTimeoutWrap.Location = new System.Drawing.Point(17, 158);
            this.pnlTimeoutWrap.Name = "pnlTimeoutWrap";
            this.pnlTimeoutWrap.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.pnlTimeoutWrap.Size = new System.Drawing.Size(140, 36);
            this.pnlTimeoutWrap.TabIndex = 6;
            // 
            // nudTimeout
            // 
            this.nudTimeout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.nudTimeout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudTimeout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudTimeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.nudTimeout.Location = new System.Drawing.Point(7, 5);
            this.nudTimeout.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudTimeout.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(126, 23);
            this.nudTimeout.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nudTimeout, "Thời gian chờ tối đa mỗi request (giây)");
            this.nudTimeout.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblTimeoutUnit
            // 
            this.lblTimeoutUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimeoutUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblTimeoutUnit.Location = new System.Drawing.Point(163, 164);
            this.lblTimeoutUnit.Name = "lblTimeoutUnit";
            this.lblTimeoutUnit.Size = new System.Drawing.Size(50, 20);
            this.lblTimeoutUnit.TabIndex = 7;
            this.lblTimeoutUnit.Text = "giây";
            // 
            // lblRetryHdr
            // 
            this.lblRetryHdr.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRetryHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblRetryHdr.Location = new System.Drawing.Point(228, 140);
            this.lblRetryHdr.Name = "lblRetryHdr";
            this.lblRetryHdr.Size = new System.Drawing.Size(180, 14);
            this.lblRetryHdr.TabIndex = 8;
            this.lblRetryHdr.Text = "SỐ LẦN THỬ LẠI";
            // 
            // pnlRetryWrap
            // 
            this.pnlRetryWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlRetryWrap.Controls.Add(this.nudRetry);
            this.pnlRetryWrap.Location = new System.Drawing.Point(228, 158);
            this.pnlRetryWrap.Name = "pnlRetryWrap";
            this.pnlRetryWrap.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.pnlRetryWrap.Size = new System.Drawing.Size(140, 36);
            this.pnlRetryWrap.TabIndex = 9;
            // 
            // nudRetry
            // 
            this.nudRetry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.nudRetry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudRetry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudRetry.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudRetry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.nudRetry.Location = new System.Drawing.Point(7, 5);
            this.nudRetry.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRetry.Name = "nudRetry";
            this.nudRetry.Size = new System.Drawing.Size(126, 23);
            this.nudRetry.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nudRetry, "Số lần retry khi request thất bại");
            this.nudRetry.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblRetryUnit
            // 
            this.lblRetryUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRetryUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblRetryUnit.Location = new System.Drawing.Point(374, 164);
            this.lblRetryUnit.Name = "lblRetryUnit";
            this.lblRetryUnit.Size = new System.Drawing.Size(50, 20);
            this.lblRetryUnit.TabIndex = 10;
            this.lblRetryUnit.Text = "lần";
            // 
            // lblApiKeyHdr
            // 
            this.lblApiKeyHdr.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblApiKeyHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblApiKeyHdr.Location = new System.Drawing.Point(17, 208);
            this.lblApiKeyHdr.Name = "lblApiKeyHdr";
            this.lblApiKeyHdr.Size = new System.Drawing.Size(394, 14);
            this.lblApiKeyHdr.TabIndex = 11;
            this.lblApiKeyHdr.Text = "API SECRET KEY (tuỳ chọn — dùng nếu backend có xác thực)";
            // 
            // pnlApiKeyWrap
            // 
            this.pnlApiKeyWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlApiKeyWrap.Controls.Add(this.txtApiKey);
            this.pnlApiKeyWrap.Location = new System.Drawing.Point(17, 226);
            this.pnlApiKeyWrap.Name = "pnlApiKeyWrap";
            this.pnlApiKeyWrap.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.pnlApiKeyWrap.Size = new System.Drawing.Size(394, 36);
            this.pnlApiKeyWrap.TabIndex = 12;
            // 
            // txtApiKey
            // 
            this.txtApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.txtApiKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApiKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApiKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApiKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.txtApiKey.Location = new System.Drawing.Point(9, 7);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.PasswordChar = '●';
            this.txtApiKey.Size = new System.Drawing.Size(376, 18);
            this.txtApiKey.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtApiKey, "Để trống nếu backend không yêu cầu xác thực");
            // 
            // chkShowApiKey
            // 
            this.chkShowApiKey.BackColor = System.Drawing.Color.Transparent;
            this.chkShowApiKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowApiKey.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkShowApiKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.chkShowApiKey.Location = new System.Drawing.Point(17, 268);
            this.chkShowApiKey.Name = "chkShowApiKey";
            this.chkShowApiKey.Size = new System.Drawing.Size(110, 18);
            this.chkShowApiKey.TabIndex = 13;
            this.chkShowApiKey.Text = "Hiện API Key";
            this.chkShowApiKey.UseVisualStyleBackColor = false;
            // 
            // pnlBtnRowApi
            // 
            this.pnlBtnRowApi.BackColor = System.Drawing.Color.Transparent;
            this.pnlBtnRowApi.Controls.Add(this.btnSaveApi);
            this.pnlBtnRowApi.Controls.Add(this.btnPingApi);
            this.pnlBtnRowApi.Controls.Add(this.btnResetApi);
            this.pnlBtnRowApi.Location = new System.Drawing.Point(17, 296);
            this.pnlBtnRowApi.Name = "pnlBtnRowApi";
            this.pnlBtnRowApi.Size = new System.Drawing.Size(394, 46);
            this.pnlBtnRowApi.TabIndex = 14;
            // 
            // btnSaveApi
            // 
            this.btnSaveApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.btnSaveApi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveApi.FlatAppearance.BorderSize = 0;
            this.btnSaveApi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(152)))));
            this.btnSaveApi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveApi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveApi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.btnSaveApi.Location = new System.Drawing.Point(0, 0);
            this.btnSaveApi.Name = "btnSaveApi";
            this.btnSaveApi.Size = new System.Drawing.Size(146, 40);
            this.btnSaveApi.TabIndex = 0;
            this.btnSaveApi.Text = "💾  Lưu cấu hình";
            this.btnSaveApi.UseVisualStyleBackColor = false;
            // 
            // btnPingApi
            // 
            this.btnPingApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnPingApi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPingApi.FlatAppearance.BorderSize = 0;
            this.btnPingApi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.btnPingApi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPingApi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPingApi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.btnPingApi.Location = new System.Drawing.Point(153, 0);
            this.btnPingApi.Name = "btnPingApi";
            this.btnPingApi.Size = new System.Drawing.Size(132, 40);
            this.btnPingApi.TabIndex = 1;
            this.btnPingApi.Text = "🔄  Ping AI";
            this.toolTip1.SetToolTip(this.btnPingApi, "Kiểm tra kết nối đến AI Service qua Ngrok");
            this.btnPingApi.UseVisualStyleBackColor = false;
            // 
            // btnResetApi
            // 
            this.btnResetApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnResetApi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetApi.FlatAppearance.BorderSize = 0;
            this.btnResetApi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnResetApi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetApi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnResetApi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnResetApi.Location = new System.Drawing.Point(291, 0);
            this.btnResetApi.Name = "btnResetApi";
            this.btnResetApi.Size = new System.Drawing.Size(103, 40);
            this.btnResetApi.TabIndex = 2;
            this.btnResetApi.Text = "↺  Mặc định";
            this.toolTip1.SetToolTip(this.btnResetApi, "Khôi phục về giá trị mặc định");
            this.btnResetApi.UseVisualStyleBackColor = false;
            // 
            // ConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.Controls.Add(this.pnlMain);
            this.Name = "ConfigControl";
            this.Size = new System.Drawing.Size(900, 631);
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlLogCard.ResumeLayout(false);
            this.pnlStatusCard.ResumeLayout(false);
            this.pnlStatusBadge.ResumeLayout(false);
            this.pnlStatusDotBg.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlDbCard.ResumeLayout(false);
            this.pnlDbPathWrap.ResumeLayout(false);
            this.pnlDbPathWrap.PerformLayout();
            this.pnlBtnRowDb.ResumeLayout(false);
            this.pnlApiCard.ResumeLayout(false);
            this.pnlNgrokWrap.ResumeLayout(false);
            this.pnlNgrokWrap.PerformLayout();
            this.pnlTimeoutWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            this.pnlRetryWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRetry)).EndInit();
            this.pnlApiKeyWrap.ResumeLayout(false);
            this.pnlApiKeyWrap.PerformLayout();
            this.pnlBtnRowApi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // ── Layout ────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;

        // ── API card ──────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlApiCard;
        private System.Windows.Forms.Panel pnlApiCardAccent;
        private System.Windows.Forms.Label lblApiCardHeader;
        private System.Windows.Forms.Label lblNgrokHdr;
        private System.Windows.Forms.Panel pnlNgrokWrap;
        private System.Windows.Forms.TextBox txtNgrokUrl;
        private System.Windows.Forms.Label lblNgrokHint;
        private System.Windows.Forms.Label lblTimeoutHdr;
        private System.Windows.Forms.Panel pnlTimeoutWrap;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.Label lblTimeoutUnit;
        private System.Windows.Forms.Label lblRetryHdr;
        private System.Windows.Forms.Panel pnlRetryWrap;
        private System.Windows.Forms.NumericUpDown nudRetry;
        private System.Windows.Forms.Label lblRetryUnit;
        private System.Windows.Forms.Label lblApiKeyHdr;
        private System.Windows.Forms.Panel pnlApiKeyWrap;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.CheckBox chkShowApiKey;
        private System.Windows.Forms.Panel pnlBtnRowApi;
        private System.Windows.Forms.Button btnSaveApi;
        private System.Windows.Forms.Button btnPingApi;
        private System.Windows.Forms.Button btnResetApi;

        // ── DB card ───────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlDbCard;
        private System.Windows.Forms.Panel pnlDbCardAccent;
        private System.Windows.Forms.Label lblDbCardHeader;
        private System.Windows.Forms.Label lblDbPathHdr;
        private System.Windows.Forms.Panel pnlDbPathWrap;
        private System.Windows.Forms.TextBox txtDbPath;
        private System.Windows.Forms.Button btnBrowseDb;
        private System.Windows.Forms.Label lblDbHint;
        private System.Windows.Forms.Panel pnlBtnRowDb;
        private System.Windows.Forms.Button btnSaveDb;
        private System.Windows.Forms.Button btnTestDb;

        // ── Status card ───────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlStatusCard;
        private System.Windows.Forms.Panel pnlStatusAccent;
        private System.Windows.Forms.Label lblStatusHeader;
        private System.Windows.Forms.Panel pnlStatusBadge;
        private System.Windows.Forms.Panel pnlStatusDotBg;
        private System.Windows.Forms.Panel pnlStatusDot;
        private System.Windows.Forms.Label lblStatusLive;
        private System.Windows.Forms.Label lblStatusUrl;
        private System.Windows.Forms.Label lblStatusUrlVal;
        private System.Windows.Forms.Label lblStatusLatency;
        private System.Windows.Forms.Label lblStatusLatencyVal;
        private System.Windows.Forms.Label lblStatusLastPing;
        private System.Windows.Forms.Label lblStatusLastPingVal;
        private System.Windows.Forms.Label lblStatusModel;
        private System.Windows.Forms.Label lblStatusModelVal;
        private System.Windows.Forms.Button btnRefreshStatus;

        // ── Log card ──────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlLogCard;
        private System.Windows.Forms.Panel pnlLogAccent;
        private System.Windows.Forms.Label lblLogHeader;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}