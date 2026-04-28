namespace demo_AI
{
    partial class LoginForm
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblRobotIcon = new System.Windows.Forms.Label();
            this.pnlDividerLeft = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.lblBadge = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLoginCard = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSigninSub = new System.Windows.Forms.Label();
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.lblUsernameHdr = new System.Windows.Forms.Label();
            this.pnlUserInput = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPasswordHdr = new System.Windows.Forms.Label();
            this.pnlPassInput = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.picSpinner = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLoginCard.SuspendLayout();
            this.pnlUserInput.SuspendLayout();
            this.pnlPassInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.pnlLeft.Controls.Add(this.lblRobotIcon);
            this.pnlLeft.Controls.Add(this.pnlDividerLeft);
            this.pnlLeft.Controls.Add(this.lblAppTitle);
            this.pnlLeft.Controls.Add(this.lblTagline);
            this.pnlLeft.Controls.Add(this.lblBadge);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(317, 537);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblRobotIcon
            // 
            this.lblRobotIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 56F);
            this.lblRobotIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.lblRobotIcon.Location = new System.Drawing.Point(0, 113);
            this.lblRobotIcon.Name = "lblRobotIcon";
            this.lblRobotIcon.Size = new System.Drawing.Size(317, 87);
            this.lblRobotIcon.TabIndex = 0;
            this.lblRobotIcon.Text = "🤖";
            this.lblRobotIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDividerLeft
            // 
            this.pnlDividerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlDividerLeft.Location = new System.Drawing.Point(124, 217);
            this.pnlDividerLeft.Name = "pnlDividerLeft";
            this.pnlDividerLeft.Size = new System.Drawing.Size(69, 3);
            this.pnlDividerLeft.TabIndex = 1;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblAppTitle.Location = new System.Drawing.Point(9, 232);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(300, 48);
            this.lblAppTitle.TabIndex = 2;
            this.lblAppTitle.Text = "SpamBot Detector";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTagline
            // 
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblTagline.Location = new System.Drawing.Point(17, 286);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(283, 48);
            this.lblTagline.TabIndex = 3;
            this.lblTagline.Text = "Phát hiện tài khoản ảo (Spambot)\ndựa trên mô hình Graph Attention Network";
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBadge
            // 
            this.lblBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.lblBadge.Location = new System.Drawing.Point(86, 351);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Padding = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.lblBadge.Size = new System.Drawing.Size(146, 24);
            this.lblBadge.TabIndex = 4;
            this.lblBadge.Text = "📊  Cresci-2017 Dataset";
            this.lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlRight.Controls.Add(this.pnlLoginCard);
            this.pnlRight.Controls.Add(this.lblVersion);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(317, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(454, 537);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlLoginCard
            // 
            this.pnlLoginCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.pnlLoginCard.Controls.Add(this.lblWelcome);
            this.pnlLoginCard.Controls.Add(this.lblSigninSub);
            this.pnlLoginCard.Controls.Add(this.pnlAccent);
            this.pnlLoginCard.Controls.Add(this.lblUsernameHdr);
            this.pnlLoginCard.Controls.Add(this.pnlUserInput);
            this.pnlLoginCard.Controls.Add(this.lblPasswordHdr);
            this.pnlLoginCard.Controls.Add(this.pnlPassInput);
            this.pnlLoginCard.Controls.Add(this.chkShowPass);
            this.pnlLoginCard.Controls.Add(this.btnLogin);
            this.pnlLoginCard.Controls.Add(this.picSpinner);
            this.pnlLoginCard.Controls.Add(this.lblStatus);
            this.pnlLoginCard.Location = new System.Drawing.Point(47, 82);
            this.pnlLoginCard.Name = "pnlLoginCard";
            this.pnlLoginCard.Padding = new System.Windows.Forms.Padding(34, 35, 34, 26);
            this.pnlLoginCard.Size = new System.Drawing.Size(360, 381);
            this.pnlLoginCard.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.lblWelcome.Location = new System.Drawing.Point(34, 35);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(291, 38);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Đăng nhập";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSigninSub
            // 
            this.lblSigninSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSigninSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.lblSigninSub.Location = new System.Drawing.Point(34, 74);
            this.lblSigninSub.Name = "lblSigninSub";
            this.lblSigninSub.Size = new System.Drawing.Size(291, 19);
            this.lblSigninSub.TabIndex = 1;
            this.lblSigninSub.Text = "Vui lòng đăng nhập để tiếp tục sử dụng hệ thống.";
            this.lblSigninSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAccent
            // 
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.pnlAccent.Location = new System.Drawing.Point(34, 97);
            this.pnlAccent.Name = "pnlAccent";
            this.pnlAccent.Size = new System.Drawing.Size(43, 3);
            this.pnlAccent.TabIndex = 2;
            // 
            // lblUsernameHdr
            // 
            this.lblUsernameHdr.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblUsernameHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblUsernameHdr.Location = new System.Drawing.Point(34, 114);
            this.lblUsernameHdr.Name = "lblUsernameHdr";
            this.lblUsernameHdr.Size = new System.Drawing.Size(291, 17);
            this.lblUsernameHdr.TabIndex = 3;
            this.lblUsernameHdr.Text = "TÊN ĐĂNG NHẬP";
            this.lblUsernameHdr.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlUserInput
            // 
            this.pnlUserInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlUserInput.Controls.Add(this.txtUsername);
            this.pnlUserInput.Location = new System.Drawing.Point(34, 134);
            this.pnlUserInput.Name = "pnlUserInput";
            this.pnlUserInput.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.pnlUserInput.Size = new System.Drawing.Size(291, 38);
            this.pnlUserInput.TabIndex = 4;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.txtUsername.Location = new System.Drawing.Point(9, 7);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(273, 21);
            this.txtUsername.TabIndex = 0;
            // 
            // lblPasswordHdr
            // 
            this.lblPasswordHdr.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPasswordHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.lblPasswordHdr.Location = new System.Drawing.Point(34, 185);
            this.lblPasswordHdr.Name = "lblPasswordHdr";
            this.lblPasswordHdr.Size = new System.Drawing.Size(291, 17);
            this.lblPasswordHdr.TabIndex = 5;
            this.lblPasswordHdr.Text = "MẬT KHẨU";
            this.lblPasswordHdr.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlPassInput
            // 
            this.pnlPassInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.pnlPassInput.Controls.Add(this.txtPassword);
            this.pnlPassInput.Location = new System.Drawing.Point(34, 205);
            this.pnlPassInput.Name = "pnlPassInput";
            this.pnlPassInput.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.pnlPassInput.Size = new System.Drawing.Size(291, 38);
            this.pnlPassInput.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.txtPassword.Location = new System.Drawing.Point(9, 7);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(273, 21);
            this.txtPassword.TabIndex = 0;
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.chkShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.chkShowPass.Location = new System.Drawing.Point(34, 250);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(104, 19);
            this.chkShowPass.TabIndex = 7;
            this.chkShowPass.Text = "Hiện mật khẩu";
            this.chkShowPass.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(170)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(134)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(152)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.btnLogin.Location = new System.Drawing.Point(34, 279);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(291, 43);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // picSpinner
            // 
            this.picSpinner.Location = new System.Drawing.Point(165, 329);
            this.picSpinner.Name = "picSpinner";
            this.picSpinner.Size = new System.Drawing.Size(29, 29);
            this.picSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSpinner.TabIndex = 9;
            this.picSpinner.TabStop = false;
            this.picSpinner.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.lblStatus.Location = new System.Drawing.Point(34, 331);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(291, 35);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblVersion.Location = new System.Drawing.Point(0, 514);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(454, 19);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "SpamBot Detector v1.0.0  ·  GAT + MLP  ·  Cresci-2017";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(771, 537);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpamBot Detector — Đăng nhập";
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlLoginCard.ResumeLayout(false);
            this.pnlLoginCard.PerformLayout();
            this.pnlUserInput.ResumeLayout(false);
            this.pnlUserInput.PerformLayout();
            this.pnlPassInput.ResumeLayout(false);
            this.pnlPassInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpinner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // ── Left branding panel ────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblRobotIcon;
        private System.Windows.Forms.Panel pnlDividerLeft;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Label lblBadge;

        // ── Right content panel ────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblVersion;

        // ── Login card ────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlLoginCard;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSigninSub;
        private System.Windows.Forms.Panel pnlAccent;

        // ── Form controls ─────────────────────────────────────────────────
        private System.Windows.Forms.Label lblUsernameHdr;
        private System.Windows.Forms.Panel pnlUserInput;
        private System.Windows.Forms.TextBox txtUsername;

        private System.Windows.Forms.Label lblPasswordHdr;
        private System.Windows.Forms.Panel pnlPassInput;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox picSpinner;
        private System.Windows.Forms.Label lblStatus;
    }
}