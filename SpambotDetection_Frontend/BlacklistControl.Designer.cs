namespace demo_AI
{
    partial class BlacklistControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlListCard = new System.Windows.Forms.Panel();
            this.lblListHeader = new System.Windows.Forms.Label();
            this.pnlListAccent = new System.Windows.Forms.Panel();
            this.dgvBlacklist = new System.Windows.Forms.DataGridView();
            this.colBotID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBLAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlDetailCard = new System.Windows.Forms.Panel();
            this.lblDetailHeader = new System.Windows.Forms.Label();
            this.pnlDetailAccent = new System.Windows.Forms.Panel();
            this.lblDetailEmpty = new System.Windows.Forms.Label();
            this.pnlDetailFields = new System.Windows.Forms.Panel();
            this.lblFBotID = new System.Windows.Forms.Label();
            this.lblFBotIDVal = new System.Windows.Forms.Label();
            this.pnlFBotIDSep = new System.Windows.Forms.Panel();
            this.lblFAccountID = new System.Windows.Forms.Label();
            this.pnlFAccountIDWrap = new System.Windows.Forms.Panel();
            this.lblFAccountIDVal = new System.Windows.Forms.Label();
            this.lblFAddedDate = new System.Windows.Forms.Label();
            this.lblFAddedDateVal = new System.Windows.Forms.Label();
            this.lblFSource = new System.Windows.Forms.Label();
            this.lblFSourceVal = new System.Windows.Forms.Label();
            this.lblFReasonHdr = new System.Windows.Forms.Label();
            this.pnlFReasonWrap = new System.Windows.Forms.Panel();
            this.txtFReason = new System.Windows.Forms.TextBox();
            this.pnlDetailActions = new System.Windows.Forms.Panel();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.btnRemoveDetail = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblSearchHdr = new System.Windows.Forms.Label();
            this.pnlSearchWrap = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnRemoveEntry = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.pnlToolbarLine = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlListCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlacklist)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlDetailCard.SuspendLayout();
            this.pnlDetailFields.SuspendLayout();
            this.pnlFAccountIDWrap.SuspendLayout();
            this.pnlFReasonWrap.SuspendLayout();
            this.pnlDetailActions.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlSearchWrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Controls.Add(this.pnlToolbar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.pnlMain.Size = new System.Drawing.Size(900, 631);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.pnlLeft);
            this.pnlBody.Controls.Add(this.pnlRight);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(21, 86);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlBody.Size = new System.Drawing.Size(858, 528);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Controls.Add(this.pnlListCard);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 12);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(555, 516);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlListCard
            // 
            this.pnlListCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlListCard.Controls.Add(this.lblListHeader);
            this.pnlListCard.Controls.Add(this.pnlListAccent);
            this.pnlListCard.Controls.Add(this.dgvBlacklist);
            this.pnlListCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListCard.Location = new System.Drawing.Point(0, 0);
            this.pnlListCard.Name = "pnlListCard";
            this.pnlListCard.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.pnlListCard.Size = new System.Drawing.Size(555, 516);
            this.pnlListCard.TabIndex = 0;
            // 
            // lblListHeader
            // 
            this.lblListHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblListHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblListHeader.Location = new System.Drawing.Point(14, 12);
            this.lblListHeader.Name = "lblListHeader";
            this.lblListHeader.Size = new System.Drawing.Size(343, 23);
            this.lblListHeader.TabIndex = 0;
            this.lblListHeader.Text = "🚫  Danh sách tài khoản bị chặn";
            // 
            // pnlListAccent
            // 
            this.pnlListAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.pnlListAccent.Location = new System.Drawing.Point(14, 38);
            this.pnlListAccent.Name = "pnlListAccent";
            this.pnlListAccent.Size = new System.Drawing.Size(38, 3);
            this.pnlListAccent.TabIndex = 1;
            // 
            // dgvBlacklist
            // 
            this.dgvBlacklist.AllowUserToAddRows = false;
            this.dgvBlacklist.AllowUserToDeleteRows = false;
            this.dgvBlacklist.AllowUserToResizeRows = false;
            this.dgvBlacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBlacklist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBlacklist.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvBlacklist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.dgvBlacklist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBlacklist.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBlacklist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBlacklist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBlacklist.ColumnHeadersHeight = 36;
            this.dgvBlacklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBlacklist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBotID,
            this.colAccountID,
            this.colReason,
            this.colAddedDate,
            this.colSource,
            this.colBLAction});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBlacklist.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBlacklist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.dgvBlacklist.Location = new System.Drawing.Point(14, 47);
            this.dgvBlacklist.MultiSelect = false;
            this.dgvBlacklist.Name = "dgvBlacklist";
            this.dgvBlacklist.ReadOnly = true;
            this.dgvBlacklist.RowHeadersVisible = false;
            this.dgvBlacklist.RowTemplate.Height = 36;
            this.dgvBlacklist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBlacklist.Size = new System.Drawing.Size(527, 457);
            this.dgvBlacklist.TabIndex = 2;
            // 
            // colBotID
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colBotID.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBotID.FillWeight = 8F;
            this.colBotID.HeaderText = "ID";
            this.colBotID.MinimumWidth = 44;
            this.colBotID.Name = "colBotID";
            this.colBotID.ReadOnly = true;
            // 
            // colAccountID
            // 
            this.colAccountID.FillWeight = 22F;
            this.colAccountID.HeaderText = "ACCOUNT ID";
            this.colAccountID.MinimumWidth = 110;
            this.colAccountID.Name = "colAccountID";
            this.colAccountID.ReadOnly = true;
            // 
            // colReason
            // 
            this.colReason.FillWeight = 32F;
            this.colReason.HeaderText = "LÝ DO";
            this.colReason.MinimumWidth = 130;
            this.colReason.Name = "colReason";
            this.colReason.ReadOnly = true;
            // 
            // colAddedDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAddedDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAddedDate.FillWeight = 18F;
            this.colAddedDate.HeaderText = "NGÀY THÊM";
            this.colAddedDate.MinimumWidth = 100;
            this.colAddedDate.Name = "colAddedDate";
            this.colAddedDate.ReadOnly = true;
            // 
            // colSource
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSource.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSource.FillWeight = 13F;
            this.colSource.HeaderText = "NGUỒN";
            this.colSource.MinimumWidth = 70;
            this.colSource.Name = "colSource";
            this.colSource.ReadOnly = true;
            // 
            // colBLAction
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.colBLAction.DefaultCellStyle = dataGridViewCellStyle5;
            this.colBLAction.FillWeight = 7F;
            this.colBLAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colBLAction.HeaderText = "";
            this.colBLAction.MinimumWidth = 44;
            this.colBLAction.Name = "colBLAction";
            this.colBLAction.ReadOnly = true;
            this.colBLAction.Text = "✏️";
            this.colBLAction.UseColumnTextForButtonValue = true;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.pnlDetailCard);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(555, 12);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlRight.Size = new System.Drawing.Size(303, 516);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlDetailCard
            // 
            this.pnlDetailCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlDetailCard.Controls.Add(this.lblDetailHeader);
            this.pnlDetailCard.Controls.Add(this.pnlDetailAccent);
            this.pnlDetailCard.Controls.Add(this.lblDetailEmpty);
            this.pnlDetailCard.Controls.Add(this.pnlDetailFields);
            this.pnlDetailCard.Controls.Add(this.pnlDetailActions);
            this.pnlDetailCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailCard.Location = new System.Drawing.Point(12, 0);
            this.pnlDetailCard.Name = "pnlDetailCard";
            this.pnlDetailCard.Size = new System.Drawing.Size(291, 516);
            this.pnlDetailCard.TabIndex = 0;
            // 
            // lblDetailHeader
            // 
            this.lblDetailHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblDetailHeader.Location = new System.Drawing.Point(14, 14);
            this.lblDetailHeader.Name = "lblDetailHeader";
            this.lblDetailHeader.Size = new System.Drawing.Size(262, 24);
            this.lblDetailHeader.TabIndex = 0;
            this.lblDetailHeader.Text = "📋  Chi tiết mục";
            // 
            // pnlDetailAccent
            // 
            this.pnlDetailAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.pnlDetailAccent.Location = new System.Drawing.Point(14, 42);
            this.pnlDetailAccent.Name = "pnlDetailAccent";
            this.pnlDetailAccent.Size = new System.Drawing.Size(38, 3);
            this.pnlDetailAccent.TabIndex = 1;
            // 
            // lblDetailEmpty
            // 
            this.lblDetailEmpty.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDetailEmpty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblDetailEmpty.Location = new System.Drawing.Point(14, 191);
            this.lblDetailEmpty.Name = "lblDetailEmpty";
            this.lblDetailEmpty.Size = new System.Drawing.Size(262, 43);
            this.lblDetailEmpty.TabIndex = 2;
            this.lblDetailEmpty.Text = "Chọn một mục trong danh sách\nđể xem và chỉnh sửa.";
            this.lblDetailEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDetailFields
            // 
            this.pnlDetailFields.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetailFields.Controls.Add(this.lblFBotID);
            this.pnlDetailFields.Controls.Add(this.lblFBotIDVal);
            this.pnlDetailFields.Controls.Add(this.pnlFBotIDSep);
            this.pnlDetailFields.Controls.Add(this.lblFAccountID);
            this.pnlDetailFields.Controls.Add(this.pnlFAccountIDWrap);
            this.pnlDetailFields.Controls.Add(this.lblFAddedDate);
            this.pnlDetailFields.Controls.Add(this.lblFAddedDateVal);
            this.pnlDetailFields.Controls.Add(this.lblFSource);
            this.pnlDetailFields.Controls.Add(this.lblFSourceVal);
            this.pnlDetailFields.Controls.Add(this.lblFReasonHdr);
            this.pnlDetailFields.Controls.Add(this.pnlFReasonWrap);
            this.pnlDetailFields.Location = new System.Drawing.Point(14, 50);
            this.pnlDetailFields.Name = "pnlDetailFields";
            this.pnlDetailFields.Size = new System.Drawing.Size(262, 390);
            this.pnlDetailFields.TabIndex = 3;
            this.pnlDetailFields.Visible = false;
            // 
            // lblFBotID
            // 
            this.lblFBotID.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFBotID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblFBotID.Location = new System.Drawing.Point(0, 0);
            this.lblFBotID.Name = "lblFBotID";
            this.lblFBotID.Size = new System.Drawing.Size(69, 14);
            this.lblFBotID.TabIndex = 0;
            this.lblFBotID.Text = "BOT ID";
            // 
            // lblFBotIDVal
            // 
            this.lblFBotIDVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblFBotIDVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.lblFBotIDVal.Location = new System.Drawing.Point(0, 16);
            this.lblFBotIDVal.Name = "lblFBotIDVal";
            this.lblFBotIDVal.Size = new System.Drawing.Size(262, 29);
            this.lblFBotIDVal.TabIndex = 1;
            this.lblFBotIDVal.Text = "#—";
            // 
            // pnlFBotIDSep
            // 
            this.pnlFBotIDSep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlFBotIDSep.Location = new System.Drawing.Point(0, 49);
            this.pnlFBotIDSep.Name = "pnlFBotIDSep";
            this.pnlFBotIDSep.Size = new System.Drawing.Size(262, 1);
            this.pnlFBotIDSep.TabIndex = 2;
            // 
            // lblFAccountID
            // 
            this.lblFAccountID.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFAccountID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblFAccountID.Location = new System.Drawing.Point(0, 57);
            this.lblFAccountID.Name = "lblFAccountID";
            this.lblFAccountID.Size = new System.Drawing.Size(262, 14);
            this.lblFAccountID.TabIndex = 3;
            this.lblFAccountID.Text = "ACCOUNT ID (trên mạng xã hội)";
            // 
            // pnlFAccountIDWrap
            // 
            this.pnlFAccountIDWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlFAccountIDWrap.Controls.Add(this.lblFAccountIDVal);
            this.pnlFAccountIDWrap.Location = new System.Drawing.Point(0, 75);
            this.pnlFAccountIDWrap.Name = "pnlFAccountIDWrap";
            this.pnlFAccountIDWrap.Padding = new System.Windows.Forms.Padding(9, 6, 9, 6);
            this.pnlFAccountIDWrap.Size = new System.Drawing.Size(262, 31);
            this.pnlFAccountIDWrap.TabIndex = 4;
            // 
            // lblFAccountIDVal
            // 
            this.lblFAccountIDVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.lblFAccountIDVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFAccountIDVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFAccountIDVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblFAccountIDVal.Location = new System.Drawing.Point(9, 6);
            this.lblFAccountIDVal.Name = "lblFAccountIDVal";
            this.lblFAccountIDVal.Size = new System.Drawing.Size(244, 19);
            this.lblFAccountIDVal.TabIndex = 0;
            this.lblFAccountIDVal.Text = "—";
            // 
            // lblFAddedDate
            // 
            this.lblFAddedDate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFAddedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblFAddedDate.Location = new System.Drawing.Point(0, 116);
            this.lblFAddedDate.Name = "lblFAddedDate";
            this.lblFAddedDate.Size = new System.Drawing.Size(120, 14);
            this.lblFAddedDate.TabIndex = 5;
            this.lblFAddedDate.Text = "NGÀY THÊM";
            // 
            // lblFAddedDateVal
            // 
            this.lblFAddedDateVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFAddedDateVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblFAddedDateVal.Location = new System.Drawing.Point(0, 133);
            this.lblFAddedDateVal.Name = "lblFAddedDateVal";
            this.lblFAddedDateVal.Size = new System.Drawing.Size(120, 19);
            this.lblFAddedDateVal.TabIndex = 6;
            this.lblFAddedDateVal.Text = "—";
            // 
            // lblFSource
            // 
            this.lblFSource.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblFSource.Location = new System.Drawing.Point(137, 116);
            this.lblFSource.Name = "lblFSource";
            this.lblFSource.Size = new System.Drawing.Size(125, 14);
            this.lblFSource.TabIndex = 7;
            this.lblFSource.Text = "NGUỒN";
            // 
            // lblFSourceVal
            // 
            this.lblFSourceVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFSourceVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblFSourceVal.Location = new System.Drawing.Point(137, 133);
            this.lblFSourceVal.Name = "lblFSourceVal";
            this.lblFSourceVal.Size = new System.Drawing.Size(125, 19);
            this.lblFSourceVal.TabIndex = 8;
            this.lblFSourceVal.Text = "—";
            this.lblFSourceVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFReasonHdr
            // 
            this.lblFReasonHdr.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFReasonHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblFReasonHdr.Location = new System.Drawing.Point(0, 165);
            this.lblFReasonHdr.Name = "lblFReasonHdr";
            this.lblFReasonHdr.Size = new System.Drawing.Size(262, 14);
            this.lblFReasonHdr.TabIndex = 9;
            this.lblFReasonHdr.Text = "LÝ DO (có thể chỉnh sửa)";
            // 
            // pnlFReasonWrap
            // 
            this.pnlFReasonWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlFReasonWrap.Controls.Add(this.txtFReason);
            this.pnlFReasonWrap.Location = new System.Drawing.Point(0, 182);
            this.pnlFReasonWrap.Name = "pnlFReasonWrap";
            this.pnlFReasonWrap.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.pnlFReasonWrap.Size = new System.Drawing.Size(262, 95);
            this.pnlFReasonWrap.TabIndex = 10;
            // 
            // txtFReason
            // 
            this.txtFReason.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.txtFReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFReason.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.txtFReason.Location = new System.Drawing.Point(9, 7);
            this.txtFReason.Multiline = true;
            this.txtFReason.Name = "txtFReason";
            this.txtFReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFReason.Size = new System.Drawing.Size(244, 81);
            this.txtFReason.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtFReason, "Chỉnh sửa lý do sau đó nhấn Lưu");
            // 
            // pnlDetailActions
            // 
            this.pnlDetailActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetailActions.Controls.Add(this.btnSaveEdit);
            this.pnlDetailActions.Controls.Add(this.btnRemoveDetail);
            this.pnlDetailActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetailActions.Location = new System.Drawing.Point(14, 459);
            this.pnlDetailActions.Name = "pnlDetailActions";
            this.pnlDetailActions.Size = new System.Drawing.Size(262, 42);
            this.pnlDetailActions.TabIndex = 4;
            this.pnlDetailActions.Visible = false;
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.btnSaveEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveEdit.FlatAppearance.BorderSize = 0;
            this.btnSaveEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(152)))));
            this.btnSaveEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSaveEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.btnSaveEdit.Location = new System.Drawing.Point(0, 0);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(151, 35);
            this.btnSaveEdit.TabIndex = 0;
            this.btnSaveEdit.Text = "💾  Lưu chỉnh sửa";
            this.btnSaveEdit.UseVisualStyleBackColor = false;
            // 
            // btnRemoveDetail
            // 
            this.btnRemoveDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnRemoveDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveDetail.FlatAppearance.BorderSize = 0;
            this.btnRemoveDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnRemoveDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveDetail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnRemoveDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.btnRemoveDetail.Location = new System.Drawing.Point(158, 0);
            this.btnRemoveDetail.Name = "btnRemoveDetail";
            this.btnRemoveDetail.Size = new System.Drawing.Size(86, 35);
            this.btnRemoveDetail.TabIndex = 1;
            this.btnRemoveDetail.Text = "🗑  Xóa";
            this.btnRemoveDetail.UseVisualStyleBackColor = false;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlToolbar.Controls.Add(this.lblSearchHdr);
            this.pnlToolbar.Controls.Add(this.pnlSearchWrap);
            this.pnlToolbar.Controls.Add(this.btnSearch);
            this.pnlToolbar.Controls.Add(this.btnAddNew);
            this.pnlToolbar.Controls.Add(this.btnRemoveEntry);
            this.pnlToolbar.Controls.Add(this.btnExport);
            this.pnlToolbar.Controls.Add(this.lblTotalCount);
            this.pnlToolbar.Controls.Add(this.pnlToolbarLine);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(21, 17);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(858, 69);
            this.pnlToolbar.TabIndex = 0;
            // 
            // lblSearchHdr
            // 
            this.lblSearchHdr.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSearchHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblSearchHdr.Location = new System.Drawing.Point(10, 9);
            this.lblSearchHdr.Name = "lblSearchHdr";
            this.lblSearchHdr.Size = new System.Drawing.Size(189, 14);
            this.lblSearchHdr.TabIndex = 0;
            this.lblSearchHdr.Text = "TÌM KIẾM ACCOUNT ID / LÝ DO";
            // 
            // pnlSearchWrap
            // 
            this.pnlSearchWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlSearchWrap.Controls.Add(this.txtSearch);
            this.pnlSearchWrap.Location = new System.Drawing.Point(10, 26);
            this.pnlSearchWrap.Name = "pnlSearchWrap";
            this.pnlSearchWrap.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.pnlSearchWrap.Size = new System.Drawing.Size(223, 31);
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
            this.txtSearch.Size = new System.Drawing.Size(209, 18);
            this.txtSearch.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtSearch, "Tìm theo Account ID hoặc lý do");
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.btnSearch.Location = new System.Drawing.Point(240, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 31);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍  Tìm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(152)))));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.btnAddNew.Location = new System.Drawing.Point(530, 23);
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(120, 36);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "➕  Thêm mới";
            this.toolTip1.SetToolTip(this.btnAddNew, "Thêm tài khoản mới vào danh sách đen");
            this.btnAddNew.UseVisualStyleBackColor = false;
            // 
            // btnRemoveEntry
            // 
            this.btnRemoveEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnRemoveEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveEntry.Enabled = false;
            this.btnRemoveEntry.FlatAppearance.BorderSize = 0;
            this.btnRemoveEntry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnRemoveEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveEntry.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnRemoveEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.btnRemoveEntry.Location = new System.Drawing.Point(657, 23);
            this.btnRemoveEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEntry.Name = "btnRemoveEntry";
            this.btnRemoveEntry.Size = new System.Drawing.Size(103, 36);
            this.btnRemoveEntry.TabIndex = 4;
            this.btnRemoveEntry.Text = "🗑  Xóa mục";
            this.toolTip1.SetToolTip(this.btnRemoveEntry, "Xóa mục đang chọn khỏi danh sách đen");
            this.btnRemoveEntry.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.btnExport.Location = new System.Drawing.Point(766, 23);
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(82, 36);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "💾  Xuất CSV";
            this.toolTip1.SetToolTip(this.btnExport, "Xuất danh sách đen ra file CSV");
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))));
            this.lblTotalCount.Location = new System.Drawing.Point(10, 54);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(257, 14);
            this.lblTotalCount.TabIndex = 6;
            this.lblTotalCount.Text = "0 tài khoản trong danh sách đen";
            // 
            // pnlToolbarLine
            // 
            this.pnlToolbarLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlToolbarLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlToolbarLine.Location = new System.Drawing.Point(0, 68);
            this.pnlToolbarLine.Name = "pnlToolbarLine";
            this.pnlToolbarLine.Size = new System.Drawing.Size(858, 1);
            this.pnlToolbarLine.TabIndex = 10;
            // 
            // BlacklistControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.Controls.Add(this.pnlMain);
            this.Name = "BlacklistControl";
            this.Size = new System.Drawing.Size(900, 631);
            this.pnlMain.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlListCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlacklist)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlDetailCard.ResumeLayout(false);
            this.pnlDetailFields.ResumeLayout(false);
            this.pnlFAccountIDWrap.ResumeLayout(false);
            this.pnlFReasonWrap.ResumeLayout(false);
            this.pnlFReasonWrap.PerformLayout();
            this.pnlDetailActions.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlSearchWrap.ResumeLayout(false);
            this.pnlSearchWrap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ── Layout ────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlToolbarLine;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlListCard;
        private System.Windows.Forms.Panel pnlListAccent;
        private System.Windows.Forms.Panel pnlDetailCard;
        private System.Windows.Forms.Panel pnlDetailAccent;
        private System.Windows.Forms.Panel pnlDetailFields;
        private System.Windows.Forms.Panel pnlDetailActions;
        private System.Windows.Forms.Panel pnlSearchWrap;

        // ── Toolbar ───────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblSearchHdr;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnRemoveEntry;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblTotalCount;

        // ── Grid ──────────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblListHeader;
        private System.Windows.Forms.DataGridView dgvBlacklist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBotID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSource;
        private System.Windows.Forms.DataGridViewButtonColumn colBLAction;

        // ── Detail fields ─────────────────────────────────────────────────
        private System.Windows.Forms.Label lblDetailHeader;
        private System.Windows.Forms.Label lblDetailEmpty;
        private System.Windows.Forms.Label lblFBotID;
        private System.Windows.Forms.Label lblFBotIDVal;
        private System.Windows.Forms.Panel pnlFBotIDSep;
        private System.Windows.Forms.Label lblFAccountID;
        private System.Windows.Forms.Panel pnlFAccountIDWrap;
        private System.Windows.Forms.Label lblFAccountIDVal;
        private System.Windows.Forms.Label lblFAddedDate;
        private System.Windows.Forms.Label lblFAddedDateVal;
        private System.Windows.Forms.Label lblFSource;
        private System.Windows.Forms.Label lblFSourceVal;
        private System.Windows.Forms.Label lblFReasonHdr;
        private System.Windows.Forms.Panel pnlFReasonWrap;
        private System.Windows.Forms.TextBox txtFReason;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Button btnRemoveDetail;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}