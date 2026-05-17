using System.Drawing;

namespace demo_AI
{
    partial class HistoryControl
    {
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlGridCard = new System.Windows.Forms.Panel();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.colHScanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPrediction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHConfidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlGridTop = new System.Windows.Forms.Panel();
            this.lblGridHeader = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlDetailCard = new System.Windows.Forms.Panel();
            this.pnlDetailActions = new System.Windows.Forms.Panel();
            this.btnAddToBlacklist = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.pnlDetailBody = new System.Windows.Forms.Panel();
            this.pnlDetailBadge = new System.Windows.Forms.Panel();
            this.lblDetailIcon = new System.Windows.Forms.Label();
            this.lblDetailLabel = new System.Windows.Forms.Label();
            this.lblDetailSub = new System.Windows.Forms.Label();
            this.lblDetailConfHdr = new System.Windows.Forms.Label();
            this.pnlDetailGaugeBg = new System.Windows.Forms.Panel();
            this.pnlDetailGaugeFill = new System.Windows.Forms.Panel();
            this.lblDetailConfPct = new System.Windows.Forms.Label();
            this.lblDHAccount = new System.Windows.Forms.Label();
            this.lblDHAccountVal = new System.Windows.Forms.Label();
            this.lblDHDate = new System.Windows.Forms.Label();
            this.lblDHDateVal = new System.Windows.Forms.Label();
            this.lblDHFollowers = new System.Windows.Forms.Label();
            this.lblDHFollowersVal = new System.Windows.Forms.Label();
            this.lblDHFollowing = new System.Windows.Forms.Label();
            this.lblDHFollowingVal = new System.Windows.Forms.Label();
            this.lblDHAge = new System.Windows.Forms.Label();
            this.lblDHAgeVal = new System.Windows.Forms.Label();
            this.lblDHLink = new System.Windows.Forms.Label();
            this.lblDHLinkVal = new System.Windows.Forms.Label();
            this.lblDHRatio = new System.Windows.Forms.Label();
            this.lblDHRatioVal = new System.Windows.Forms.Label();
            this.lblDetailEmpty = new System.Windows.Forms.Label();
            this.pnlDetailDivider = new System.Windows.Forms.Panel();
            this.pnlDetailTop = new System.Windows.Forms.Panel();
            this.lblDetailHeader = new System.Windows.Forms.Label();
            this.pnlFilterBar = new System.Windows.Forms.Panel();
            this.lblFilterSearch = new System.Windows.Forms.Label();
            this.pnlSearchWrap = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterResult = new System.Windows.Forms.Label();
            this.cmbFilterResult = new System.Windows.Forms.ComboBox();
            this.lblFilterDate = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnExportHistory = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.pnlFilterBarLine = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.pnlGridTop.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlDetailCard.SuspendLayout();
            this.pnlDetailActions.SuspendLayout();
            this.pnlDetailBody.SuspendLayout();
            this.pnlDetailBadge.SuspendLayout();
            this.pnlDetailGaugeBg.SuspendLayout();
            this.pnlDetailTop.SuspendLayout();
            this.pnlFilterBar.SuspendLayout();
            this.pnlSearchWrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Controls.Add(this.pnlFilterBar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.pnlMain.Size = new System.Drawing.Size(886, 597);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.pnlLeft);
            this.pnlBody.Controls.Add(this.pnlRight);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(21, 97);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlBody.Size = new System.Drawing.Size(844, 483);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Controls.Add(this.pnlGridCard);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 12);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(549, 471);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlGridCard
            // 
            this.pnlGridCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlGridCard.Controls.Add(this.dgvHistory);
            this.pnlGridCard.Controls.Add(this.pnlGridTop);
            this.pnlGridCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridCard.Location = new System.Drawing.Point(0, 0);
            this.pnlGridCard.Name = "pnlGridCard";
            this.pnlGridCard.Size = new System.Drawing.Size(549, 471);
            this.pnlGridCard.TabIndex = 0;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistory.ColumnHeadersHeight = 36;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHScanID,
            this.colHAccount,
            this.colHPrediction,
            this.colHConfidence,
            this.colHDate,
            this.colHAction});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.dgvHistory.Location = new System.Drawing.Point(0, 40);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowTemplate.Height = 36;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(549, 431);
            this.dgvHistory.TabIndex = 1;
            // 
            // colHScanID
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colHScanID.DefaultCellStyle = dataGridViewCellStyle2;
            this.colHScanID.FillWeight = 8F;
            this.colHScanID.HeaderText = "ID";
            this.colHScanID.MinimumWidth = 48;
            this.colHScanID.Name = "colHScanID";
            this.colHScanID.ReadOnly = true;
            // 
            // colHAccount
            // 
            this.colHAccount.FillWeight = 28F;
            this.colHAccount.HeaderText = "TÀI KHOẢN";
            this.colHAccount.MinimumWidth = 100;
            this.colHAccount.Name = "colHAccount";
            this.colHAccount.ReadOnly = true;
            // 
            // colHPrediction
            // 
            this.colHPrediction.DefaultCellStyle = dataGridViewCellStyle2;
            this.colHPrediction.FillWeight = 18F;
            this.colHPrediction.HeaderText = "KẾT QUẢ";
            this.colHPrediction.MinimumWidth = 80;
            this.colHPrediction.Name = "colHPrediction";
            this.colHPrediction.ReadOnly = true;
            // 
            // colHConfidence
            // 
            this.colHConfidence.DefaultCellStyle = dataGridViewCellStyle2;
            this.colHConfidence.FillWeight = 16F;
            this.colHConfidence.HeaderText = "TIN CẬY";
            this.colHConfidence.MinimumWidth = 70;
            this.colHConfidence.Name = "colHConfidence";
            this.colHConfidence.ReadOnly = true;
            // 
            // colHDate
            // 
            this.colHDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colHDate.FillWeight = 22F;
            this.colHDate.HeaderText = "THỜI GIAN";
            this.colHDate.MinimumWidth = 130;
            this.colHDate.Name = "colHDate";
            this.colHDate.ReadOnly = true;
            // 
            // colHAction
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.colHAction.DefaultCellStyle = dataGridViewCellStyle3;
            this.colHAction.FillWeight = 8F;
            this.colHAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colHAction.HeaderText = "";
            this.colHAction.MinimumWidth = 48;
            this.colHAction.Name = "colHAction";
            this.colHAction.ReadOnly = true;
            this.colHAction.Text = "👁";
            this.colHAction.UseColumnTextForButtonValue = true;
            // 
            // pnlGridTop
            // 
            this.pnlGridTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlGridTop.Controls.Add(this.lblGridHeader);
            this.pnlGridTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridTop.Location = new System.Drawing.Point(0, 0);
            this.pnlGridTop.Name = "pnlGridTop";
            this.pnlGridTop.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.pnlGridTop.Size = new System.Drawing.Size(549, 40);
            this.pnlGridTop.TabIndex = 0;
            // 
            // lblGridHeader
            // 
            this.lblGridHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGridHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGridHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblGridHeader.Location = new System.Drawing.Point(14, 0);
            this.lblGridHeader.Name = "lblGridHeader";
            this.lblGridHeader.Size = new System.Drawing.Size(521, 40);
            this.lblGridHeader.TabIndex = 0;
            this.lblGridHeader.Text = "LỊCH SỬ QUÉT";
            this.lblGridHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.pnlDetailCard);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(549, 12);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlRight.Size = new System.Drawing.Size(295, 471);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlDetailCard
            // 
            this.pnlDetailCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlDetailCard.Controls.Add(this.pnlDetailActions);
            this.pnlDetailCard.Controls.Add(this.pnlDetailBody);
            this.pnlDetailCard.Controls.Add(this.lblDetailEmpty);
            this.pnlDetailCard.Controls.Add(this.pnlDetailDivider);
            this.pnlDetailCard.Controls.Add(this.pnlDetailTop);
            this.pnlDetailCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailCard.Location = new System.Drawing.Point(8, 0);
            this.pnlDetailCard.Name = "pnlDetailCard";
            this.pnlDetailCard.Padding = new System.Windows.Forms.Padding(17, 14, 17, 14);
            this.pnlDetailCard.Size = new System.Drawing.Size(287, 471);
            this.pnlDetailCard.TabIndex = 0;
            // 
            // pnlDetailActions
            // 
            this.pnlDetailActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetailActions.Controls.Add(this.btnAddToBlacklist);
            this.pnlDetailActions.Controls.Add(this.btnDeleteRecord);
            this.pnlDetailActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetailActions.Location = new System.Drawing.Point(17, 399);
            this.pnlDetailActions.Name = "pnlDetailActions";
            this.pnlDetailActions.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlDetailActions.Size = new System.Drawing.Size(253, 58);
            this.pnlDetailActions.TabIndex = 4;
            this.pnlDetailActions.Visible = false;
            // 
            // btnAddToBlacklist
            // 
            this.btnAddToBlacklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnAddToBlacklist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToBlacklist.FlatAppearance.BorderSize = 0;
            this.btnAddToBlacklist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnAddToBlacklist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToBlacklist.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnAddToBlacklist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.btnAddToBlacklist.Location = new System.Drawing.Point(0, 8);
            this.btnAddToBlacklist.Name = "btnAddToBlacklist";
            this.btnAddToBlacklist.Size = new System.Drawing.Size(154, 34);
            this.btnAddToBlacklist.TabIndex = 0;
            this.btnAddToBlacklist.Text = "🚫  Thêm Blacklist";
            this.toolTip1.SetToolTip(this.btnAddToBlacklist, "Thêm tài khoản này vào danh sách đen");
            this.btnAddToBlacklist.UseVisualStyleBackColor = false;
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnDeleteRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteRecord.FlatAppearance.BorderSize = 0;
            this.btnDeleteRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnDeleteRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRecord.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDeleteRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnDeleteRecord.Location = new System.Drawing.Point(162, 8);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(95, 34);
            this.btnDeleteRecord.TabIndex = 1;
            this.btnDeleteRecord.Text = "🗑  Xóa";
            this.btnDeleteRecord.UseVisualStyleBackColor = false;
            // 
            // pnlDetailBody
            // 
            this.pnlDetailBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetailBody.Controls.Add(this.pnlDetailBadge);
            this.pnlDetailBody.Controls.Add(this.lblDetailConfHdr);
            this.pnlDetailBody.Controls.Add(this.pnlDetailGaugeBg);
            this.pnlDetailBody.Controls.Add(this.lblDetailConfPct);
            this.pnlDetailBody.Controls.Add(this.lblDHAccount);
            this.pnlDetailBody.Controls.Add(this.lblDHAccountVal);
            this.pnlDetailBody.Controls.Add(this.lblDHDate);
            this.pnlDetailBody.Controls.Add(this.lblDHDateVal);
            this.pnlDetailBody.Controls.Add(this.lblDHFollowers);
            this.pnlDetailBody.Controls.Add(this.lblDHFollowersVal);
            this.pnlDetailBody.Controls.Add(this.lblDHFollowing);
            this.pnlDetailBody.Controls.Add(this.lblDHFollowingVal);
            this.pnlDetailBody.Controls.Add(this.lblDHAge);
            this.pnlDetailBody.Controls.Add(this.lblDHAgeVal);
            this.pnlDetailBody.Controls.Add(this.lblDHLink);
            this.pnlDetailBody.Controls.Add(this.lblDHLinkVal);
            this.pnlDetailBody.Controls.Add(this.lblDHRatio);
            this.pnlDetailBody.Controls.Add(this.lblDHRatioVal);
            this.pnlDetailBody.Location = new System.Drawing.Point(17, 52);
            this.pnlDetailBody.Name = "pnlDetailBody";
            this.pnlDetailBody.Size = new System.Drawing.Size(257, 340);
            this.pnlDetailBody.TabIndex = 3;
            this.pnlDetailBody.Visible = false;
            // 
            // pnlDetailBadge
            // 
            this.pnlDetailBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlDetailBadge.Controls.Add(this.lblDetailIcon);
            this.pnlDetailBadge.Controls.Add(this.lblDetailLabel);
            this.pnlDetailBadge.Controls.Add(this.lblDetailSub);
            this.pnlDetailBadge.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailBadge.Name = "pnlDetailBadge";
            this.pnlDetailBadge.Size = new System.Drawing.Size(257, 78);
            this.pnlDetailBadge.TabIndex = 0;
            // 
            // lblDetailIcon
            // 
            this.lblDetailIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 28F);
            this.lblDetailIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblDetailIcon.Location = new System.Drawing.Point(6, 7);
            this.lblDetailIcon.Name = "lblDetailIcon";
            this.lblDetailIcon.Size = new System.Drawing.Size(54, 64);
            this.lblDetailIcon.TabIndex = 0;
            this.lblDetailIcon.Text = "❓";
            this.lblDetailIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDetailLabel
            // 
            this.lblDetailLabel.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblDetailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblDetailLabel.Location = new System.Drawing.Point(66, 10);
            this.lblDetailLabel.Name = "lblDetailLabel";
            this.lblDetailLabel.Size = new System.Drawing.Size(185, 32);
            this.lblDetailLabel.TabIndex = 1;
            this.lblDetailLabel.Text = "—";
            // 
            // lblDetailSub
            // 
            this.lblDetailSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDetailSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblDetailSub.Location = new System.Drawing.Point(66, 44);
            this.lblDetailSub.Name = "lblDetailSub";
            this.lblDetailSub.Size = new System.Drawing.Size(185, 26);
            this.lblDetailSub.TabIndex = 2;
            // 
            // lblDetailConfHdr
            // 
            this.lblDetailConfHdr.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailConfHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblDetailConfHdr.Location = new System.Drawing.Point(0, 86);
            this.lblDetailConfHdr.Name = "lblDetailConfHdr";
            this.lblDetailConfHdr.Size = new System.Drawing.Size(257, 14);
            this.lblDetailConfHdr.TabIndex = 3;
            this.lblDetailConfHdr.Text = "ĐỘ TIN CẬY";
            // 
            // pnlDetailGaugeBg
            // 
            this.pnlDetailGaugeBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlDetailGaugeBg.Controls.Add(this.pnlDetailGaugeFill);
            this.pnlDetailGaugeBg.Location = new System.Drawing.Point(0, 103);
            this.pnlDetailGaugeBg.Name = "pnlDetailGaugeBg";
            this.pnlDetailGaugeBg.Size = new System.Drawing.Size(257, 12);
            this.pnlDetailGaugeBg.TabIndex = 4;
            // 
            // pnlDetailGaugeFill
            // 
            this.pnlDetailGaugeFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlDetailGaugeFill.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailGaugeFill.Name = "pnlDetailGaugeFill";
            this.pnlDetailGaugeFill.Size = new System.Drawing.Size(0, 12);
            this.pnlDetailGaugeFill.TabIndex = 0;
            // 
            // lblDetailConfPct
            // 
            this.lblDetailConfPct.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDetailConfPct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.lblDetailConfPct.Location = new System.Drawing.Point(0, 117);
            this.lblDetailConfPct.Name = "lblDetailConfPct";
            this.lblDetailConfPct.Size = new System.Drawing.Size(257, 26);
            this.lblDetailConfPct.TabIndex = 5;
            this.lblDetailConfPct.Text = "--.--%";
            // 
            // lblDHAccount
            // 
            this.lblDHAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDHAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblDHAccount.Location = new System.Drawing.Point(0, 150);
            this.lblDHAccount.Name = "lblDHAccount";
            this.lblDHAccount.Size = new System.Drawing.Size(115, 19);
            this.lblDHAccount.TabIndex = 6;
            this.lblDHAccount.Text = "Tài khoản";
            // 
            // lblDHAccountVal
            // 
            this.lblDHAccountVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDHAccountVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblDHAccountVal.Location = new System.Drawing.Point(120, 150);
            this.lblDHAccountVal.Name = "lblDHAccountVal";
            this.lblDHAccountVal.Size = new System.Drawing.Size(137, 19);
            this.lblDHAccountVal.TabIndex = 7;
            this.lblDHAccountVal.Text = "—";
            this.lblDHAccountVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDHDate
            // 
            this.lblDHDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDHDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblDHDate.Location = new System.Drawing.Point(0, 174);
            this.lblDHDate.Name = "lblDHDate";
            this.lblDHDate.Size = new System.Drawing.Size(115, 19);
            this.lblDHDate.TabIndex = 8;
            this.lblDHDate.Text = "Thời gian";
            // 
            // lblDHDateVal
            // 
            this.lblDHDateVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDHDateVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblDHDateVal.Location = new System.Drawing.Point(120, 174);
            this.lblDHDateVal.Name = "lblDHDateVal";
            this.lblDHDateVal.Size = new System.Drawing.Size(137, 19);
            this.lblDHDateVal.TabIndex = 9;
            this.lblDHDateVal.Text = "—";
            this.lblDHDateVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDHFollowers
            // 
            this.lblDHFollowers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDHFollowers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblDHFollowers.Location = new System.Drawing.Point(0, 198);
            this.lblDHFollowers.Name = "lblDHFollowers";
            this.lblDHFollowers.Size = new System.Drawing.Size(115, 19);
            this.lblDHFollowers.TabIndex = 10;
            this.lblDHFollowers.Text = "Followers";
            // 
            // lblDHFollowersVal
            // 
            this.lblDHFollowersVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDHFollowersVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblDHFollowersVal.Location = new System.Drawing.Point(120, 198);
            this.lblDHFollowersVal.Name = "lblDHFollowersVal";
            this.lblDHFollowersVal.Size = new System.Drawing.Size(137, 19);
            this.lblDHFollowersVal.TabIndex = 11;
            this.lblDHFollowersVal.Text = "—";
            this.lblDHFollowersVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDHFollowing
            // 
            this.lblDHFollowing.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDHFollowing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblDHFollowing.Location = new System.Drawing.Point(0, 222);
            this.lblDHFollowing.Name = "lblDHFollowing";
            this.lblDHFollowing.Size = new System.Drawing.Size(115, 19);
            this.lblDHFollowing.TabIndex = 12;
            this.lblDHFollowing.Text = "Following";
            // 
            // lblDHFollowingVal
            // 
            this.lblDHFollowingVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDHFollowingVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblDHFollowingVal.Location = new System.Drawing.Point(120, 222);
            this.lblDHFollowingVal.Name = "lblDHFollowingVal";
            this.lblDHFollowingVal.Size = new System.Drawing.Size(137, 19);
            this.lblDHFollowingVal.TabIndex = 13;
            this.lblDHFollowingVal.Text = "—";
            this.lblDHFollowingVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDHAge
            // 
            this.lblDHAge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDHAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblDHAge.Location = new System.Drawing.Point(0, 246);
            this.lblDHAge.Name = "lblDHAge";
            this.lblDHAge.Size = new System.Drawing.Size(115, 19);
            this.lblDHAge.TabIndex = 14;
            this.lblDHAge.Text = "Account Age";
            // 
            // lblDHAgeVal
            // 
            this.lblDHAgeVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDHAgeVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblDHAgeVal.Location = new System.Drawing.Point(120, 246);
            this.lblDHAgeVal.Name = "lblDHAgeVal";
            this.lblDHAgeVal.Size = new System.Drawing.Size(137, 19);
            this.lblDHAgeVal.TabIndex = 15;
            this.lblDHAgeVal.Text = "—";
            this.lblDHAgeVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDHLink
            // 
            this.lblDHLink.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDHLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblDHLink.Location = new System.Drawing.Point(0, 270);
            this.lblDHLink.Name = "lblDHLink";
            this.lblDHLink.Size = new System.Drawing.Size(115, 19);
            this.lblDHLink.TabIndex = 16;
            this.lblDHLink.Text = "Link Density";
            // 
            // lblDHLinkVal
            // 
            this.lblDHLinkVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDHLinkVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblDHLinkVal.Location = new System.Drawing.Point(120, 270);
            this.lblDHLinkVal.Name = "lblDHLinkVal";
            this.lblDHLinkVal.Size = new System.Drawing.Size(137, 19);
            this.lblDHLinkVal.TabIndex = 17;
            this.lblDHLinkVal.Text = "—";
            this.lblDHLinkVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDHRatio
            // 
            this.lblDHRatio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDHRatio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblDHRatio.Location = new System.Drawing.Point(0, 294);
            this.lblDHRatio.Name = "lblDHRatio";
            this.lblDHRatio.Size = new System.Drawing.Size(115, 19);
            this.lblDHRatio.TabIndex = 18;
            this.lblDHRatio.Text = "Follower Ratio";
            // 
            // lblDHRatioVal
            // 
            this.lblDHRatioVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDHRatioVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblDHRatioVal.Location = new System.Drawing.Point(120, 294);
            this.lblDHRatioVal.Name = "lblDHRatioVal";
            this.lblDHRatioVal.Size = new System.Drawing.Size(137, 19);
            this.lblDHRatioVal.TabIndex = 19;
            this.lblDHRatioVal.Text = "—";
            this.lblDHRatioVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetailEmpty
            // 
            this.lblDetailEmpty.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDetailEmpty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblDetailEmpty.Location = new System.Drawing.Point(17, 120);
            this.lblDetailEmpty.Name = "lblDetailEmpty";
            this.lblDetailEmpty.Size = new System.Drawing.Size(257, 52);
            this.lblDetailEmpty.TabIndex = 2;
            this.lblDetailEmpty.Text = "Chọn một bản ghi trong danh sách\nđể xem chi tiết.";
            this.lblDetailEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDetailDivider
            // 
            this.pnlDetailDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlDetailDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailDivider.Location = new System.Drawing.Point(17, 46);
            this.pnlDetailDivider.Name = "pnlDetailDivider";
            this.pnlDetailDivider.Size = new System.Drawing.Size(253, 3);
            this.pnlDetailDivider.TabIndex = 1;
            // 
            // pnlDetailTop
            // 
            this.pnlDetailTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetailTop.Controls.Add(this.lblDetailHeader);
            this.pnlDetailTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailTop.Location = new System.Drawing.Point(17, 14);
            this.pnlDetailTop.Name = "pnlDetailTop";
            this.pnlDetailTop.Size = new System.Drawing.Size(253, 32);
            this.pnlDetailTop.TabIndex = 0;
            // 
            // lblDetailHeader
            // 
            this.lblDetailHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblDetailHeader.Location = new System.Drawing.Point(0, 0);
            this.lblDetailHeader.Name = "lblDetailHeader";
            this.lblDetailHeader.Size = new System.Drawing.Size(253, 32);
            this.lblDetailHeader.TabIndex = 0;
            this.lblDetailHeader.Text = "🔎  Chi tiết bản ghi";
            // 
            // pnlFilterBar
            // 
            this.pnlFilterBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlFilterBar.Controls.Add(this.lblFilterSearch);
            this.pnlFilterBar.Controls.Add(this.pnlSearchWrap);
            this.pnlFilterBar.Controls.Add(this.lblFilterResult);
            this.pnlFilterBar.Controls.Add(this.cmbFilterResult);
            this.pnlFilterBar.Controls.Add(this.lblFilterDate);
            this.pnlFilterBar.Controls.Add(this.dtpFrom);
            this.pnlFilterBar.Controls.Add(this.lblDateTo);
            this.pnlFilterBar.Controls.Add(this.dtpTo);
            this.pnlFilterBar.Controls.Add(this.btnFilter);
            this.pnlFilterBar.Controls.Add(this.btnResetFilter);
            this.pnlFilterBar.Controls.Add(this.btnDeleteSelected);
            this.pnlFilterBar.Controls.Add(this.btnExportHistory);
            this.pnlFilterBar.Controls.Add(this.lblRecordCount);
            this.pnlFilterBar.Controls.Add(this.pnlFilterBarLine);
            this.pnlFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBar.Location = new System.Drawing.Point(21, 17);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Padding = new System.Windows.Forms.Padding(14, 10, 14, 0);
            this.pnlFilterBar.Size = new System.Drawing.Size(844, 80);
            this.pnlFilterBar.TabIndex = 0;
            // 
            // lblFilterSearch
            // 
            this.lblFilterSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFilterSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblFilterSearch.Location = new System.Drawing.Point(14, 10);
            this.lblFilterSearch.Name = "lblFilterSearch";
            this.lblFilterSearch.Size = new System.Drawing.Size(72, 14);
            this.lblFilterSearch.TabIndex = 0;
            this.lblFilterSearch.Text = "TÌM KIẾM";
            // 
            // pnlSearchWrap
            // 
            this.pnlSearchWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlSearchWrap.Controls.Add(this.txtSearch);
            this.pnlSearchWrap.Location = new System.Drawing.Point(14, 28);
            this.pnlSearchWrap.Name = "pnlSearchWrap";
            this.pnlSearchWrap.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.pnlSearchWrap.Size = new System.Drawing.Size(176, 30);
            this.pnlSearchWrap.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.txtSearch.Location = new System.Drawing.Point(7, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(162, 18);
            this.txtSearch.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtSearch, "Tìm theo tên tài khoản");
            // 
            // lblFilterResult
            // 
            this.lblFilterResult.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFilterResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblFilterResult.Location = new System.Drawing.Point(200, 10);
            this.lblFilterResult.Name = "lblFilterResult";
            this.lblFilterResult.Size = new System.Drawing.Size(60, 14);
            this.lblFilterResult.TabIndex = 2;
            this.lblFilterResult.Text = "KẾT QUẢ";
            // 
            // cmbFilterResult
            // 
            this.cmbFilterResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.cmbFilterResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilterResult.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFilterResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.cmbFilterResult.Items.AddRange(new object[] {
            "Tất cả",
            "Spambot",
            "Real"});
            this.cmbFilterResult.Location = new System.Drawing.Point(200, 28);
            this.cmbFilterResult.Name = "cmbFilterResult";
            this.cmbFilterResult.Size = new System.Drawing.Size(108, 25);
            this.cmbFilterResult.TabIndex = 3;
            // 
            // lblFilterDate
            // 
            this.lblFilterDate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFilterDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblFilterDate.Location = new System.Drawing.Point(318, 10);
            this.lblFilterDate.Name = "lblFilterDate";
            this.lblFilterDate.Size = new System.Drawing.Size(60, 14);
            this.lblFilterDate.TabIndex = 4;
            this.lblFilterDate.Text = "TỪ NGÀY";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.dtpFrom.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.dtpFrom.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.dtpFrom.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(318, 28);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(116, 25);
            this.dtpFrom.TabIndex = 5;
            this.dtpFrom.Value = new System.DateTime(2026, 3, 25, 0, 0, 0, 0);
            // 
            // lblDateTo
            // 
            this.lblDateTo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDateTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblDateTo.Location = new System.Drawing.Point(445, 10);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(65, 14);
            this.lblDateTo.TabIndex = 6;
            this.lblDateTo.Text = "ĐẾN NGÀY";
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.dtpTo.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.dtpTo.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.dtpTo.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(445, 28);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(116, 25);
            this.dtpTo.TabIndex = 7;
            this.dtpTo.Value = new System.DateTime(2026, 4, 25, 0, 0, 0, 0);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(152)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.btnFilter.Location = new System.Drawing.Point(572, 26);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(86, 32);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "🔍  Lọc";
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnResetFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFilter.FlatAppearance.BorderSize = 0;
            this.btnResetFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnResetFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnResetFilter.Location = new System.Drawing.Point(665, 26);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(80, 32);
            this.btnResetFilter.TabIndex = 9;
            this.btnResetFilter.Text = "↺  Reset";
            this.btnResetFilter.UseVisualStyleBackColor = false;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnDeleteSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSelected.Enabled = false;
            this.btnDeleteSelected.FlatAppearance.BorderSize = 0;
            this.btnDeleteSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelected.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDeleteSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.btnDeleteSelected.Location = new System.Drawing.Point(752, 26);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(68, 32);
            this.btnDeleteSelected.TabIndex = 10;
            this.btnDeleteSelected.Text = "🗑  Xóa";
            this.toolTip1.SetToolTip(this.btnDeleteSelected, "Xóa bản ghi đang chọn");
            this.btnDeleteSelected.UseVisualStyleBackColor = false;
            // 
            // btnExportHistory
            // 
            this.btnExportHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnExportHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportHistory.FlatAppearance.BorderSize = 0;
            this.btnExportHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.btnExportHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportHistory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnExportHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.btnExportHistory.Location = new System.Drawing.Point(826, 26);
            this.btnExportHistory.Name = "btnExportHistory";
            this.btnExportHistory.Size = new System.Drawing.Size(46, 32);
            this.btnExportHistory.TabIndex = 11;
            this.btnExportHistory.Text = "💾";
            this.toolTip1.SetToolTip(this.btnExportHistory, "Xuất lịch sử ra CSV");
            this.btnExportHistory.UseVisualStyleBackColor = false;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblRecordCount.Location = new System.Drawing.Point(14, 64);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(200, 14);
            this.lblRecordCount.TabIndex = 12;
            this.lblRecordCount.Text = "0 bản ghi";
            // 
            // pnlFilterBarLine
            // 
            this.pnlFilterBarLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlFilterBarLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFilterBarLine.Location = new System.Drawing.Point(14, 79);
            this.pnlFilterBarLine.Name = "pnlFilterBarLine";
            this.pnlFilterBarLine.Size = new System.Drawing.Size(816, 1);
            this.pnlFilterBarLine.TabIndex = 13;
            // 
            // HistoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.Controls.Add(this.pnlMain);
            this.Name = "HistoryControl";
            this.Size = new System.Drawing.Size(886, 597);
            this.pnlMain.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlGridCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlGridTop.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlDetailCard.ResumeLayout(false);
            this.pnlDetailActions.ResumeLayout(false);
            this.pnlDetailBody.ResumeLayout(false);
            this.pnlDetailBadge.ResumeLayout(false);
            this.pnlDetailGaugeBg.ResumeLayout(false);
            this.pnlDetailTop.ResumeLayout(false);
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlSearchWrap.ResumeLayout(false);
            this.pnlSearchWrap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ── Layout ────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlFilterBar;
        private System.Windows.Forms.Panel pnlFilterBarLine;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlGridCard;
        private System.Windows.Forms.Panel pnlGridTop;

        // ── Filter bar ────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblFilterSearch;
        private System.Windows.Forms.Panel pnlSearchWrap;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterResult;
        private System.Windows.Forms.ComboBox cmbFilterResult;
        private System.Windows.Forms.Label lblFilterDate;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnExportHistory;
        private System.Windows.Forms.Label lblRecordCount;

        // ── Grid ──────────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblGridHeader;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHScanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPrediction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHConfidence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDate;
        private System.Windows.Forms.DataGridViewButtonColumn colHAction;

        // ── Detail card ───────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlDetailCard;
        private System.Windows.Forms.Panel pnlDetailTop;
        private System.Windows.Forms.Panel pnlDetailDivider;
        private System.Windows.Forms.Panel pnlDetailBody;
        private System.Windows.Forms.Panel pnlDetailBadge;
        private System.Windows.Forms.Panel pnlDetailGaugeBg;
        private System.Windows.Forms.Panel pnlDetailGaugeFill;
        private System.Windows.Forms.Panel pnlDetailActions;

        private System.Windows.Forms.Label lblDetailHeader;
        private System.Windows.Forms.Label lblDetailEmpty;
        private System.Windows.Forms.Label lblDetailIcon;
        private System.Windows.Forms.Label lblDetailLabel;
        private System.Windows.Forms.Label lblDetailSub;
        private System.Windows.Forms.Label lblDetailConfHdr;
        private System.Windows.Forms.Label lblDetailConfPct;

        private System.Windows.Forms.Label lblDHAccount;
        private System.Windows.Forms.Label lblDHAccountVal;
        private System.Windows.Forms.Label lblDHDate;
        private System.Windows.Forms.Label lblDHDateVal;
        private System.Windows.Forms.Label lblDHFollowers;
        private System.Windows.Forms.Label lblDHFollowersVal;
        private System.Windows.Forms.Label lblDHFollowing;
        private System.Windows.Forms.Label lblDHFollowingVal;
        private System.Windows.Forms.Label lblDHAge;
        private System.Windows.Forms.Label lblDHAgeVal;
        private System.Windows.Forms.Label lblDHLink;
        private System.Windows.Forms.Label lblDHLinkVal;
        private System.Windows.Forms.Label lblDHRatio;
        private System.Windows.Forms.Label lblDHRatioVal;

        private System.Windows.Forms.Button btnAddToBlacklist;
        private System.Windows.Forms.Button btnDeleteRecord;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}