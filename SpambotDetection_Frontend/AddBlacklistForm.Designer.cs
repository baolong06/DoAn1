namespace demo_AI
{
    partial class AddBlacklistForm
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
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlCardAccent = new System.Windows.Forms.Panel();
            this.lblCardHeader = new System.Windows.Forms.Label();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.pnlRowAccountID = new System.Windows.Forms.Panel();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.lblAccountIDReq = new System.Windows.Forms.Label();
            this.pnlAccountIDWrap = new System.Windows.Forms.Panel();
            this.picAccountIDIcon = new System.Windows.Forms.PictureBox();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.lblAccountIDHint = new System.Windows.Forms.Label();
            this.pnlRowReason = new System.Windows.Forms.Panel();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblReasonReq = new System.Windows.Forms.Label();
            this.pnlReasonWrap = new System.Windows.Forms.Panel();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblCharCount = new System.Windows.Forms.Label();
            this.pnlRowDate = new System.Windows.Forms.Panel();
            this.lblAddedDate = new System.Windows.Forms.Label();
            this.pnlDateWrap = new System.Windows.Forms.Panel();
            this.picDateIcon = new System.Windows.Forms.PictureBox();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.pnlValidation = new System.Windows.Forms.Panel();
            this.picWarnIcon = new System.Windows.Forms.PictureBox();
            this.lblValidation = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterLine = new System.Windows.Forms.Panel();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderAccent = new System.Windows.Forms.Panel();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlRoot.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.pnlFields.SuspendLayout();
            this.pnlRowAccountID.SuspendLayout();
            this.pnlAccountIDWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAccountIDIcon)).BeginInit();
            this.pnlRowReason.SuspendLayout();
            this.pnlReasonWrap.SuspendLayout();
            this.pnlRowDate.SuspendLayout();
            this.pnlDateWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDateIcon)).BeginInit();
            this.pnlValidation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWarnIcon)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlRoot.Controls.Add(this.pnlBody);
            this.pnlRoot.Controls.Add(this.pnlHeader);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Size = new System.Drawing.Size(446, 485);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.pnlCard);
            this.pnlBody.Controls.Add(this.pnlValidation);
            this.pnlBody.Controls.Add(this.pnlFooter);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 83);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(17, 14, 17, 0);
            this.pnlBody.Size = new System.Drawing.Size(446, 402);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlCard.Controls.Add(this.pnlCardAccent);
            this.pnlCard.Controls.Add(this.lblCardHeader);
            this.pnlCard.Controls.Add(this.pnlFields);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCard.Location = new System.Drawing.Point(17, 43);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlCard.Size = new System.Drawing.Size(412, 286);
            this.pnlCard.TabIndex = 0;
            // 
            // pnlCardAccent
            // 
            this.pnlCardAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlCardAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCardAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlCardAccent.Name = "pnlCardAccent";
            this.pnlCardAccent.Size = new System.Drawing.Size(3, 33);
            this.pnlCardAccent.TabIndex = 0;
            // 
            // lblCardHeader
            // 
            this.lblCardHeader.AutoSize = true;
            this.lblCardHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblCardHeader.Location = new System.Drawing.Point(15, 12);
            this.lblCardHeader.Name = "lblCardHeader";
            this.lblCardHeader.Size = new System.Drawing.Size(140, 15);
            this.lblCardHeader.TabIndex = 1;
            this.lblCardHeader.Text = "THÔNG TIN TÀI KHOẢN";
            // 
            // pnlFields
            // 
            this.pnlFields.BackColor = System.Drawing.Color.Transparent;
            this.pnlFields.Controls.Add(this.pnlRowAccountID);
            this.pnlFields.Controls.Add(this.pnlRowReason);
            this.pnlFields.Controls.Add(this.pnlRowDate);
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFields.Location = new System.Drawing.Point(0, 33);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Padding = new System.Windows.Forms.Padding(13, 3, 13, 0);
            this.pnlFields.Size = new System.Drawing.Size(412, 241);
            this.pnlFields.TabIndex = 2;
            // 
            // pnlRowAccountID
            // 
            this.pnlRowAccountID.BackColor = System.Drawing.Color.Transparent;
            this.pnlRowAccountID.Controls.Add(this.lblAccountID);
            this.pnlRowAccountID.Controls.Add(this.lblAccountIDReq);
            this.pnlRowAccountID.Controls.Add(this.pnlAccountIDWrap);
            this.pnlRowAccountID.Controls.Add(this.lblAccountIDHint);
            this.pnlRowAccountID.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRowAccountID.Location = new System.Drawing.Point(13, 163);
            this.pnlRowAccountID.Name = "pnlRowAccountID";
            this.pnlRowAccountID.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlRowAccountID.Size = new System.Drawing.Size(386, 75);
            this.pnlRowAccountID.TabIndex = 0;
            // 
            // lblAccountID
            // 
            this.lblAccountID.AutoSize = true;
            this.lblAccountID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAccountID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblAccountID.Location = new System.Drawing.Point(0, 0);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(69, 15);
            this.lblAccountID.TabIndex = 0;
            this.lblAccountID.Text = "Account ID";
            // 
            // lblAccountIDReq
            // 
            this.lblAccountIDReq.AutoSize = true;
            this.lblAccountIDReq.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAccountIDReq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.lblAccountIDReq.Location = new System.Drawing.Point(76, -2);
            this.lblAccountIDReq.Name = "lblAccountIDReq";
            this.lblAccountIDReq.Size = new System.Drawing.Size(15, 19);
            this.lblAccountIDReq.TabIndex = 1;
            this.lblAccountIDReq.Text = "*";
            // 
            // pnlAccountIDWrap
            // 
            this.pnlAccountIDWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlAccountIDWrap.Controls.Add(this.picAccountIDIcon);
            this.pnlAccountIDWrap.Controls.Add(this.txtAccountID);
            this.pnlAccountIDWrap.Location = new System.Drawing.Point(0, 17);
            this.pnlAccountIDWrap.Name = "pnlAccountIDWrap";
            this.pnlAccountIDWrap.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pnlAccountIDWrap.Size = new System.Drawing.Size(383, 31);
            this.pnlAccountIDWrap.TabIndex = 2;
            // 
            // picAccountIDIcon
            // 
            this.picAccountIDIcon.BackColor = System.Drawing.Color.Transparent;
            this.picAccountIDIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picAccountIDIcon.Location = new System.Drawing.Point(5, 0);
            this.picAccountIDIcon.Name = "picAccountIDIcon";
            this.picAccountIDIcon.Size = new System.Drawing.Size(24, 31);
            this.picAccountIDIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAccountIDIcon.TabIndex = 0;
            this.picAccountIDIcon.TabStop = false;
            // 
            // txtAccountID
            // 
            this.txtAccountID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.txtAccountID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccountID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAccountID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAccountID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.txtAccountID.Location = new System.Drawing.Point(5, 0);
            this.txtAccountID.MaxLength = 100;
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(373, 18);
            this.txtAccountID.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtAccountID, "ID tài khoản trên mạng xã hội (tối đa 100 ký tự)");
            // 
            // lblAccountIDHint
            // 
            this.lblAccountIDHint.AutoSize = true;
            this.lblAccountIDHint.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblAccountIDHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblAccountIDHint.Location = new System.Drawing.Point(1, 54);
            this.lblAccountIDHint.Name = "lblAccountIDHint";
            this.lblAccountIDHint.Size = new System.Drawing.Size(209, 12);
            this.lblAccountIDHint.TabIndex = 3;
            this.lblAccountIDHint.Text = "Ví dụ: user_12345678  |  @handle  |  uid:987654";
            // 
            // pnlRowReason
            // 
            this.pnlRowReason.BackColor = System.Drawing.Color.Transparent;
            this.pnlRowReason.Controls.Add(this.lblReason);
            this.pnlRowReason.Controls.Add(this.lblReasonReq);
            this.pnlRowReason.Controls.Add(this.pnlReasonWrap);
            this.pnlRowReason.Controls.Add(this.lblCharCount);
            this.pnlRowReason.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRowReason.Location = new System.Drawing.Point(13, 52);
            this.pnlRowReason.Name = "pnlRowReason";
            this.pnlRowReason.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlRowReason.Size = new System.Drawing.Size(386, 111);
            this.pnlRowReason.TabIndex = 1;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblReason.Location = new System.Drawing.Point(0, 5);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(44, 15);
            this.lblReason.TabIndex = 0;
            this.lblReason.Text = "Lý do *";
            // 
            // lblReasonReq
            // 
            this.lblReasonReq.AutoSize = true;
            this.lblReasonReq.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReasonReq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.lblReasonReq.Location = new System.Drawing.Point(48, 3);
            this.lblReasonReq.Name = "lblReasonReq";
            this.lblReasonReq.Size = new System.Drawing.Size(15, 19);
            this.lblReasonReq.TabIndex = 1;
            this.lblReasonReq.Text = "*";
            this.lblReasonReq.Visible = false;
            // 
            // pnlReasonWrap
            // 
            this.pnlReasonWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlReasonWrap.Controls.Add(this.txtReason);
            this.pnlReasonWrap.Location = new System.Drawing.Point(0, 23);
            this.pnlReasonWrap.Name = "pnlReasonWrap";
            this.pnlReasonWrap.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.pnlReasonWrap.Size = new System.Drawing.Size(383, 71);
            this.pnlReasonWrap.TabIndex = 2;
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReason.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.txtReason.Location = new System.Drawing.Point(7, 5);
            this.txtReason.MaxLength = 500;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(369, 61);
            this.txtReason.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtReason, "Tối đa 500 ký tự");
            // 
            // lblCharCount
            // 
            this.lblCharCount.AutoSize = true;
            this.lblCharCount.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblCharCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblCharCount.Location = new System.Drawing.Point(317, 97);
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.Size = new System.Drawing.Size(35, 12);
            this.lblCharCount.TabIndex = 3;
            this.lblCharCount.Text = "0 / 500";
            // 
            // pnlRowDate
            // 
            this.pnlRowDate.BackColor = System.Drawing.Color.Transparent;
            this.pnlRowDate.Controls.Add(this.lblAddedDate);
            this.pnlRowDate.Controls.Add(this.pnlDateWrap);
            this.pnlRowDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRowDate.Location = new System.Drawing.Point(13, 3);
            this.pnlRowDate.Name = "pnlRowDate";
            this.pnlRowDate.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.pnlRowDate.Size = new System.Drawing.Size(386, 49);
            this.pnlRowDate.TabIndex = 2;
            // 
            // lblAddedDate
            // 
            this.lblAddedDate.AutoSize = true;
            this.lblAddedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblAddedDate.Location = new System.Drawing.Point(0, 5);
            this.lblAddedDate.Name = "lblAddedDate";
            this.lblAddedDate.Size = new System.Drawing.Size(68, 15);
            this.lblAddedDate.TabIndex = 0;
            this.lblAddedDate.Text = "Ngày thêm";
            // 
            // pnlDateWrap
            // 
            this.pnlDateWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlDateWrap.Controls.Add(this.picDateIcon);
            this.pnlDateWrap.Controls.Add(this.lblDateValue);
            this.pnlDateWrap.Location = new System.Drawing.Point(0, 21);
            this.pnlDateWrap.Name = "pnlDateWrap";
            this.pnlDateWrap.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pnlDateWrap.Size = new System.Drawing.Size(240, 24);
            this.pnlDateWrap.TabIndex = 1;
            // 
            // picDateIcon
            // 
            this.picDateIcon.BackColor = System.Drawing.Color.Transparent;
            this.picDateIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picDateIcon.Location = new System.Drawing.Point(5, 0);
            this.picDateIcon.Name = "picDateIcon";
            this.picDateIcon.Size = new System.Drawing.Size(21, 24);
            this.picDateIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picDateIcon.TabIndex = 0;
            this.picDateIcon.TabStop = false;
            // 
            // lblDateValue
            // 
            this.lblDateValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblDateValue.Location = new System.Drawing.Point(5, 0);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(230, 24);
            this.lblDateValue.TabIndex = 1;
            this.lblDateValue.Text = "26/04/2026  (tự động)";
            this.lblDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.lblDateValue, "Ngày thêm được ghi nhận tự động theo ngày hiện tại");
            // 
            // pnlValidation
            // 
            this.pnlValidation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.pnlValidation.Controls.Add(this.picWarnIcon);
            this.pnlValidation.Controls.Add(this.lblValidation);
            this.pnlValidation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlValidation.Location = new System.Drawing.Point(17, 14);
            this.pnlValidation.Name = "pnlValidation";
            this.pnlValidation.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlValidation.Size = new System.Drawing.Size(412, 29);
            this.pnlValidation.TabIndex = 1;
            this.pnlValidation.Visible = false;
            // 
            // picWarnIcon
            // 
            this.picWarnIcon.BackColor = System.Drawing.Color.Transparent;
            this.picWarnIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picWarnIcon.Location = new System.Drawing.Point(10, 0);
            this.picWarnIcon.Name = "picWarnIcon";
            this.picWarnIcon.Size = new System.Drawing.Size(19, 29);
            this.picWarnIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picWarnIcon.TabIndex = 0;
            this.picWarnIcon.TabStop = false;
            // 
            // lblValidation
            // 
            this.lblValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValidation.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.lblValidation.Location = new System.Drawing.Point(10, 0);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(392, 29);
            this.lblValidation.TabIndex = 1;
            this.lblValidation.Text = "Vui lòng nhập đầy đủ các trường bắt buộc.";
            this.lblValidation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlFooter.Controls.Add(this.pnlFooterLine);
            this.pnlFooter.Controls.Add(this.lblNote);
            this.pnlFooter.Controls.Add(this.btnConfirm);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(17, 347);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.pnlFooter.Size = new System.Drawing.Size(412, 55);
            this.pnlFooter.TabIndex = 2;
            // 
            // pnlFooterLine
            // 
            this.pnlFooterLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlFooterLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterLine.Location = new System.Drawing.Point(14, 0);
            this.pnlFooterLine.Name = "pnlFooterLine";
            this.pnlFooterLine.Size = new System.Drawing.Size(384, 1);
            this.pnlFooterLine.TabIndex = 0;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblNote.Location = new System.Drawing.Point(14, 9);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(229, 12);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "* Trường bắt buộc  |  Dữ liệu sẽ lưu vào BLACKLIST";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(152)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.btnConfirm.Location = new System.Drawing.Point(316, 24);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 28);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "✔  Xác nhận";
            this.toolTip1.SetToolTip(this.btnConfirm, "Lưu tài khoản vào danh sách đen (Enter)");
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(58)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.btnCancel.Location = new System.Drawing.Point(227, 24);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy bỏ";
            this.toolTip1.SetToolTip(this.btnCancel, "Đóng dialog mà không lưu (Esc)");
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlHeader.Controls.Add(this.pnlHeaderAccent);
            this.pnlHeader.Controls.Add(this.lblIcon);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(17, 16, 17, 12);
            this.pnlHeader.Size = new System.Drawing.Size(446, 83);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlHeaderAccent
            // 
            this.pnlHeaderAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlHeaderAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderAccent.Location = new System.Drawing.Point(17, 68);
            this.pnlHeaderAccent.Name = "pnlHeaderAccent";
            this.pnlHeaderAccent.Size = new System.Drawing.Size(412, 3);
            this.pnlHeaderAccent.TabIndex = 0;
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 22F);
            this.lblIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.lblIcon.Location = new System.Drawing.Point(17, 14);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(58, 40);
            this.lblIcon.TabIndex = 1;
            this.lblIcon.Text = "🚫";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.lblTitle.Location = new System.Drawing.Point(60, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(228, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Thêm vào Danh sách Đen";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblSubtitle.Location = new System.Drawing.Point(61, 41);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(304, 15);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "Nhập thông tin tài khoản cần đưa vào blacklist thủ công";
            // 
            // AddBlacklistForm
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(446, 485);
            this.Controls.Add(this.pnlRoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBlacklistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm vào Danh sách Đen — SpambotDetection";
            this.pnlRoot.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlFields.ResumeLayout(false);
            this.pnlRowAccountID.ResumeLayout(false);
            this.pnlRowAccountID.PerformLayout();
            this.pnlAccountIDWrap.ResumeLayout(false);
            this.pnlAccountIDWrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAccountIDIcon)).EndInit();
            this.pnlRowReason.ResumeLayout(false);
            this.pnlRowReason.PerformLayout();
            this.pnlReasonWrap.ResumeLayout(false);
            this.pnlReasonWrap.PerformLayout();
            this.pnlRowDate.ResumeLayout(false);
            this.pnlRowDate.PerformLayout();
            this.pnlDateWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDateIcon)).EndInit();
            this.pnlValidation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWarnIcon)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ── Controls declaration ──────────────────────────────────────
        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlHeaderAccent;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlCardAccent;
        private System.Windows.Forms.Label lblCardHeader;
        private System.Windows.Forms.Panel pnlFields;

        private System.Windows.Forms.Panel pnlRowAccountID;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.Label lblAccountIDReq;
        private System.Windows.Forms.Panel pnlAccountIDWrap;
        private System.Windows.Forms.PictureBox picAccountIDIcon;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.Label lblAccountIDHint;

        private System.Windows.Forms.Panel pnlRowReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblReasonReq;
        private System.Windows.Forms.Panel pnlReasonWrap;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblCharCount;

        private System.Windows.Forms.Panel pnlRowDate;
        private System.Windows.Forms.Label lblAddedDate;
        private System.Windows.Forms.Panel pnlDateWrap;
        private System.Windows.Forms.PictureBox picDateIcon;
        private System.Windows.Forms.Label lblDateValue;

        private System.Windows.Forms.Panel pnlValidation;
        private System.Windows.Forms.PictureBox picWarnIcon;
        private System.Windows.Forms.Label lblValidation;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterLine;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}