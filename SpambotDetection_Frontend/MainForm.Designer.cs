namespace demo_AI
{
    partial class MainForm
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlSidebarTop = new System.Windows.Forms.Panel();
            this.lblSidebarIcon = new System.Windows.Forms.Label();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.lblSidebarVer = new System.Windows.Forms.Label();
            this.pnlSidebarNav = new System.Windows.Forms.Panel();
            this.pnlNavIndicator = new System.Windows.Forms.Panel();
            this.btnNavStats = new System.Windows.Forms.Button();
            this.btnNavSingle = new System.Windows.Forms.Button();
            this.btnNavBatch = new System.Windows.Forms.Button();
            this.btnNavHistory = new System.Windows.Forms.Button();
            this.btnNavBlacklist = new System.Windows.Forms.Button();
            this.pnlNavDivider = new System.Windows.Forms.Panel();
            this.btnNavConfig = new System.Windows.Forms.Button();
            this.pnlSidebarBottom = new System.Windows.Forms.Panel();
            this.pnlUserCard = new System.Windows.Forms.Panel();
            this.lblUserAvatar = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.pnlHeaderRight = new System.Windows.Forms.Panel();
            this.picAIStatusDot = new System.Windows.Forms.PictureBox();
            this.lblAIStatus = new System.Windows.Forms.Label();
            this.btnRefreshStatus = new System.Windows.Forms.Button();
            this.pnlHeaderDivider = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlStatusBar = new System.Windows.Forms.Panel();
            this.lblStatusLeft = new System.Windows.Forms.Label();
            this.lblStatusCenter = new System.Windows.Forms.Label();
            this.lblStatusRight = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlSidebarTop.SuspendLayout();
            this.pnlSidebarNav.SuspendLayout();
            this.pnlSidebarBottom.SuspendLayout();
            this.pnlUserCard.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlHeaderRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAIStatusDot)).BeginInit();
            this.pnlStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlSidebar.Controls.Add(this.pnlSidebarNav);
            this.pnlSidebar.Controls.Add(this.pnlSidebarBottom);
            this.pnlSidebar.Controls.Add(this.pnlSidebarTop);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(197, 669);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlSidebarTop
            // 
            this.pnlSidebarTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlSidebarTop.Controls.Add(this.lblSidebarIcon);
            this.pnlSidebarTop.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebarTop.Controls.Add(this.lblSidebarVer);
            this.pnlSidebarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSidebarTop.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebarTop.Name = "pnlSidebarTop";
            this.pnlSidebarTop.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.pnlSidebarTop.Size = new System.Drawing.Size(197, 100);
            this.pnlSidebarTop.TabIndex = 0;
            // 
            // lblSidebarIcon
            // 
            this.lblSidebarIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 26F);
            this.lblSidebarIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.lblSidebarIcon.Location = new System.Drawing.Point(0, 10);
            this.lblSidebarIcon.Name = "lblSidebarIcon";
            this.lblSidebarIcon.Size = new System.Drawing.Size(197, 38);
            this.lblSidebarIcon.TabIndex = 0;
            this.lblSidebarIcon.Text = "🤖";
            this.lblSidebarIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblSidebarTitle.Location = new System.Drawing.Point(0, 49);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(197, 26);
            this.lblSidebarTitle.TabIndex = 1;
            this.lblSidebarTitle.Text = "SpamBot Detector";
            this.lblSidebarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSidebarVer
            // 
            this.lblSidebarVer.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSidebarVer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblSidebarVer.Location = new System.Drawing.Point(0, 75);
            this.lblSidebarVer.Name = "lblSidebarVer";
            this.lblSidebarVer.Size = new System.Drawing.Size(197, 17);
            this.lblSidebarVer.TabIndex = 2;
            this.lblSidebarVer.Text = "v1.0.0 · GAT + MLP";
            this.lblSidebarVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSidebarNav
            // 
            this.pnlSidebarNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlSidebarNav.Controls.Add(this.pnlNavIndicator);
            this.pnlSidebarNav.Controls.Add(this.btnNavStats);
            this.pnlSidebarNav.Controls.Add(this.btnNavSingle);
            this.pnlSidebarNav.Controls.Add(this.btnNavBatch);
            this.pnlSidebarNav.Controls.Add(this.btnNavHistory);
            this.pnlSidebarNav.Controls.Add(this.btnNavBlacklist);
            this.pnlSidebarNav.Controls.Add(this.pnlNavDivider);
            this.pnlSidebarNav.Controls.Add(this.btnNavConfig);
            this.pnlSidebarNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSidebarNav.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebarNav.Name = "pnlSidebarNav";
            this.pnlSidebarNav.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.pnlSidebarNav.Size = new System.Drawing.Size(197, 574);
            this.pnlSidebarNav.TabIndex = 1;
            // 
            // pnlNavIndicator
            // 
            this.pnlNavIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlNavIndicator.Location = new System.Drawing.Point(0, 7);
            this.pnlNavIndicator.Name = "pnlNavIndicator";
            this.pnlNavIndicator.Size = new System.Drawing.Size(3, 38);
            this.pnlNavIndicator.TabIndex = 0;
            // 
            // btnNavStats
            // 
            this.btnNavStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.btnNavStats.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavStats.FlatAppearance.BorderSize = 0;
            this.btnNavStats.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnNavStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.btnNavStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavStats.Location = new System.Drawing.Point(10, 7);
            this.btnNavStats.Name = "btnNavStats";
            this.btnNavStats.Size = new System.Drawing.Size(177, 38);
            this.btnNavStats.TabIndex = 1;
            this.btnNavStats.Text = "  📊   Thống kê";
            this.btnNavStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavStats.UseVisualStyleBackColor = false;
            // 
            // btnNavSingle
            // 
            this.btnNavSingle.BackColor = System.Drawing.Color.Transparent;
            this.btnNavSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSingle.FlatAppearance.BorderSize = 0;
            this.btnNavSingle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.btnNavSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSingle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavSingle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnNavSingle.Location = new System.Drawing.Point(10, 49);
            this.btnNavSingle.Name = "btnNavSingle";
            this.btnNavSingle.Size = new System.Drawing.Size(177, 38);
            this.btnNavSingle.TabIndex = 2;
            this.btnNavSingle.Text = "  🔍   Kiểm tra đơn lẻ";
            this.btnNavSingle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSingle.UseVisualStyleBackColor = false;
            // 
            // btnNavBatch
            // 
            this.btnNavBatch.BackColor = System.Drawing.Color.Transparent;
            this.btnNavBatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavBatch.FlatAppearance.BorderSize = 0;
            this.btnNavBatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.btnNavBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavBatch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavBatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnNavBatch.Location = new System.Drawing.Point(10, 90);
            this.btnNavBatch.Name = "btnNavBatch";
            this.btnNavBatch.Size = new System.Drawing.Size(177, 38);
            this.btnNavBatch.TabIndex = 3;
            this.btnNavBatch.Text = "  📂   Quét CSV";
            this.btnNavBatch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBatch.UseVisualStyleBackColor = false;
            // 
            // btnNavHistory
            // 
            this.btnNavHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnNavHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavHistory.FlatAppearance.BorderSize = 0;
            this.btnNavHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.btnNavHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnNavHistory.Location = new System.Drawing.Point(10, 132);
            this.btnNavHistory.Name = "btnNavHistory";
            this.btnNavHistory.Size = new System.Drawing.Size(177, 38);
            this.btnNavHistory.TabIndex = 4;
            this.btnNavHistory.Text = "  🕐   Lịch sử quét";
            this.btnNavHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavHistory.UseVisualStyleBackColor = false;
            // 
            // btnNavBlacklist
            // 
            this.btnNavBlacklist.BackColor = System.Drawing.Color.Transparent;
            this.btnNavBlacklist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavBlacklist.FlatAppearance.BorderSize = 0;
            this.btnNavBlacklist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.btnNavBlacklist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavBlacklist.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavBlacklist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnNavBlacklist.Location = new System.Drawing.Point(10, 173);
            this.btnNavBlacklist.Name = "btnNavBlacklist";
            this.btnNavBlacklist.Size = new System.Drawing.Size(177, 38);
            this.btnNavBlacklist.TabIndex = 5;
            this.btnNavBlacklist.Text = "  🚫   Blacklist";
            this.btnNavBlacklist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBlacklist.UseVisualStyleBackColor = false;
            // 
            // pnlNavDivider
            // 
            this.pnlNavDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlNavDivider.Location = new System.Drawing.Point(17, 220);
            this.pnlNavDivider.Name = "pnlNavDivider";
            this.pnlNavDivider.Size = new System.Drawing.Size(163, 1);
            this.pnlNavDivider.TabIndex = 6;
            // 
            // btnNavConfig
            // 
            this.btnNavConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnNavConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavConfig.FlatAppearance.BorderSize = 0;
            this.btnNavConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.btnNavConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavConfig.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnNavConfig.Location = new System.Drawing.Point(10, 228);
            this.btnNavConfig.Name = "btnNavConfig";
            this.btnNavConfig.Size = new System.Drawing.Size(177, 38);
            this.btnNavConfig.TabIndex = 7;
            this.btnNavConfig.Text = "  ⚙️   Cấu hình API";
            this.btnNavConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavConfig.UseVisualStyleBackColor = false;
            this.btnNavConfig.Visible = false;
            // 
            // pnlSidebarBottom
            // 
            this.pnlSidebarBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlSidebarBottom.Controls.Add(this.pnlUserCard);
            this.pnlSidebarBottom.Controls.Add(this.btnLogout);
            this.pnlSidebarBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSidebarBottom.Location = new System.Drawing.Point(0, 574);
            this.pnlSidebarBottom.Name = "pnlSidebarBottom";
            this.pnlSidebarBottom.Padding = new System.Windows.Forms.Padding(10, 7, 10, 10);
            this.pnlSidebarBottom.Size = new System.Drawing.Size(197, 95);
            this.pnlSidebarBottom.TabIndex = 2;
            // 
            // pnlUserCard
            // 
            this.pnlUserCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlUserCard.Controls.Add(this.lblUserAvatar);
            this.pnlUserCard.Controls.Add(this.lblUserName);
            this.pnlUserCard.Controls.Add(this.lblUserRole);
            this.pnlUserCard.Location = new System.Drawing.Point(10, 7);
            this.pnlUserCard.Name = "pnlUserCard";
            this.pnlUserCard.Size = new System.Drawing.Size(177, 45);
            this.pnlUserCard.TabIndex = 0;
            // 
            // lblUserAvatar
            // 
            this.lblUserAvatar.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblUserAvatar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.lblUserAvatar.Location = new System.Drawing.Point(5, 3);
            this.lblUserAvatar.Name = "lblUserAvatar";
            this.lblUserAvatar.Size = new System.Drawing.Size(36, 38);
            this.lblUserAvatar.TabIndex = 0;
            this.lblUserAvatar.Text = "👤";
            this.lblUserAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblUserName.Location = new System.Drawing.Point(45, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(127, 16);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "username";
            // 
            // lblUserRole
            // 
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblUserRole.Location = new System.Drawing.Point(45, 26);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(127, 14);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "User";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.btnLogout.Location = new System.Drawing.Point(10, 57);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(177, 29);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "  🚪  Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Controls.Add(this.lblPageSubtitle);
            this.pnlHeader.Controls.Add(this.pnlHeaderRight);
            this.pnlHeader.Controls.Add(this.pnlHeaderDivider);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(197, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 62);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblPageTitle.Location = new System.Drawing.Point(21, 9);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(343, 26);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Thống kê";
            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblPageSubtitle.Location = new System.Drawing.Point(21, 36);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Size = new System.Drawing.Size(429, 17);
            this.lblPageSubtitle.TabIndex = 1;
            this.lblPageSubtitle.Text = "Tổng quan hệ thống phát hiện tài khoản Spambot";
            // 
            // pnlHeaderRight
            // 
            this.pnlHeaderRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeaderRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeaderRight.Controls.Add(this.picAIStatusDot);
            this.pnlHeaderRight.Controls.Add(this.lblAIStatus);
            this.pnlHeaderRight.Controls.Add(this.btnRefreshStatus);
            this.pnlHeaderRight.Location = new System.Drawing.Point(617, 14);
            this.pnlHeaderRight.Name = "pnlHeaderRight";
            this.pnlHeaderRight.Size = new System.Drawing.Size(266, 35);
            this.pnlHeaderRight.TabIndex = 2;
            // 
            // picAIStatusDot
            // 
            this.picAIStatusDot.BackColor = System.Drawing.Color.Transparent;
            this.picAIStatusDot.Location = new System.Drawing.Point(7, 10);
            this.picAIStatusDot.Name = "picAIStatusDot";
            this.picAIStatusDot.Size = new System.Drawing.Size(10, 10);
            this.picAIStatusDot.TabIndex = 0;
            this.picAIStatusDot.TabStop = false;
            // 
            // lblAIStatus
            // 
            this.lblAIStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAIStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblAIStatus.Location = new System.Drawing.Point(22, 7);
            this.lblAIStatus.Name = "lblAIStatus";
            this.lblAIStatus.Size = new System.Drawing.Size(137, 19);
            this.lblAIStatus.TabIndex = 1;
            this.lblAIStatus.Text = "AI: Đang kiểm tra...";
            // 
            // btnRefreshStatus
            // 
            this.btnRefreshStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnRefreshStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshStatus.FlatAppearance.BorderSize = 0;
            this.btnRefreshStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnRefreshStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnRefreshStatus.Location = new System.Drawing.Point(165, 5);
            this.btnRefreshStatus.Name = "btnRefreshStatus";
            this.btnRefreshStatus.Size = new System.Drawing.Size(94, 24);
            this.btnRefreshStatus.TabIndex = 2;
            this.btnRefreshStatus.Text = "🔄  Ping AI";
            this.btnRefreshStatus.UseVisualStyleBackColor = false;
            // 
            // pnlHeaderDivider
            // 
            this.pnlHeaderDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlHeaderDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderDivider.Location = new System.Drawing.Point(0, 61);
            this.pnlHeaderDivider.Name = "pnlHeaderDivider";
            this.pnlHeaderDivider.Size = new System.Drawing.Size(900, 1);
            this.pnlHeaderDivider.TabIndex = 3;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(197, 62);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(900, 607);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlStatusBar
            // 
            this.pnlStatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlStatusBar.Controls.Add(this.lblStatusLeft);
            this.pnlStatusBar.Controls.Add(this.lblStatusCenter);
            this.pnlStatusBar.Controls.Add(this.lblStatusRight);
            this.pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusBar.Location = new System.Drawing.Point(0, 669);
            this.pnlStatusBar.Name = "pnlStatusBar";
            this.pnlStatusBar.Size = new System.Drawing.Size(1097, 24);
            this.pnlStatusBar.TabIndex = 3;
            // 
            // lblStatusLeft
            // 
            this.lblStatusLeft.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatusLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblStatusLeft.Location = new System.Drawing.Point(7, 4);
            this.lblStatusLeft.Name = "lblStatusLeft";
            this.lblStatusLeft.Size = new System.Drawing.Size(360, 16);
            this.lblStatusLeft.TabIndex = 0;
            this.lblStatusLeft.Text = "Sẵn sàng";
            // 
            // lblStatusCenter
            // 
            this.lblStatusCenter.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatusCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblStatusCenter.Location = new System.Drawing.Point(377, 4);
            this.lblStatusCenter.Name = "lblStatusCenter";
            this.lblStatusCenter.Size = new System.Drawing.Size(343, 16);
            this.lblStatusCenter.TabIndex = 1;
            this.lblStatusCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusRight
            // 
            this.lblStatusRight.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatusRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblStatusRight.Location = new System.Drawing.Point(727, 4);
            this.lblStatusRight.Name = "lblStatusRight";
            this.lblStatusRight.Size = new System.Drawing.Size(363, 16);
            this.lblStatusRight.TabIndex = 2;
            this.lblStatusRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(1097, 693);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlStatusBar);
            this.MinimumSize = new System.Drawing.Size(945, 612);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpamBot Detector";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebarTop.ResumeLayout(false);
            this.pnlSidebarNav.ResumeLayout(false);
            this.pnlSidebarBottom.ResumeLayout(false);
            this.pnlUserCard.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeaderRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAIStatusDot)).EndInit();
            this.pnlStatusBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // ── Root layout ────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlStatusBar;

        // ── Sidebar sub-panels ─────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlSidebarTop;
        private System.Windows.Forms.Panel pnlSidebarNav;
        private System.Windows.Forms.Panel pnlSidebarBottom;
        private System.Windows.Forms.Panel pnlNavIndicator;
        private System.Windows.Forms.Panel pnlNavDivider;

        // ── Sidebar branding ───────────────────────────────────────────────
        private System.Windows.Forms.Label lblSidebarIcon;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Label lblSidebarVer;

        // ── Navigation buttons ─────────────────────────────────────────────
        private System.Windows.Forms.Button btnNavStats;
        private System.Windows.Forms.Button btnNavSingle;
        private System.Windows.Forms.Button btnNavBatch;
        private System.Windows.Forms.Button btnNavHistory;
        private System.Windows.Forms.Button btnNavBlacklist;
        private System.Windows.Forms.Button btnNavConfig;

        // ── User card + logout ─────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlUserCard;
        private System.Windows.Forms.Label lblUserAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Button btnLogout;

        // ── Header ─────────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.Panel pnlHeaderRight;
        private System.Windows.Forms.Panel pnlHeaderDivider;
        private System.Windows.Forms.PictureBox picAIStatusDot;
        private System.Windows.Forms.Label lblAIStatus;
        private System.Windows.Forms.Button btnRefreshStatus;

        // ── Status bar ─────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblStatusLeft;
        private System.Windows.Forms.Label lblStatusCenter;
        private System.Windows.Forms.Label lblStatusRight;
    }
}