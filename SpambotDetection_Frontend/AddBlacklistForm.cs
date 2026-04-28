using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace demo_AI
{
    public partial class AddBlacklistForm : Form
    {
        // ════════════════════════════════════════════════════════════
        //  Win32 — placeholder cho single-line TextBox (.NET Framework)
        // ════════════════════════════════════════════════════════════
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        // ════════════════════════════════════════════════════════════
        //  Placeholder cho Reason (multiline — Win32 không hỗ trợ)
        // ════════════════════════════════════════════════════════════
        private readonly string _reasonPlaceholder =
            "Mô tả lý do xác nhận tài khoản này là spambot...";

        private readonly System.Drawing.Color _colorPlaceholder =
            System.Drawing.Color.FromArgb(100, 110, 120);

        private readonly System.Drawing.Color _colorInput =
            System.Drawing.Color.FromArgb(220, 226, 234);

        private bool _reasonIsPlaceholder = true;

        // ════════════════════════════════════════════════════════════
        //  Constructor
        // ════════════════════════════════════════════════════════════
        public AddBlacklistForm()
        {
            InitializeComponent();
            AttachEvents();
            InitReasonPlaceholder();
        }

        // ════════════════════════════════════════════════════════════
        //  Gắn events (KHÔNG đặt trong Designer)
        // ════════════════════════════════════════════════════════════
        private void AttachEvents()
        {
            this.Load += AddBlacklistForm_Load;
            this.btnConfirm.Click += BtnConfirm_Click;

            // Live char counter
            this.txtReason.TextChanged += TxtReason_TextChanged;

            // Placeholder multiline
            this.txtReason.Enter += TxtReason_Enter;
            this.txtReason.Leave += TxtReason_Leave;

            // Border highlight khi focus
            this.txtAccountID.Enter += (s, e) => HighlightWrap(pnlAccountIDWrap, true);
            this.txtAccountID.Leave += (s, e) => HighlightWrap(pnlAccountIDWrap, false);
            this.txtReason.Enter += (s, e) => HighlightWrap(pnlReasonWrap, true);
            this.txtReason.Leave += (s, e) => HighlightWrap(pnlReasonWrap, false);
        }

        // ════════════════════════════════════════════════════════════
        //  Load — đặt placeholder single-line sau khi Handle tồn tại
        // ════════════════════════════════════════════════════════════
        private void AddBlacklistForm_Load(object sender, EventArgs e)
        {
            SendMessage(txtAccountID.Handle, EM_SETCUEBANNER, 1,
                        "Nhập ID tài khoản mạng xã hội...");
        }

        // ════════════════════════════════════════════════════════════
        //  Placeholder giả cho Multiline txtReason
        // ════════════════════════════════════════════════════════════
        private void InitReasonPlaceholder()
        {
            txtReason.Text = _reasonPlaceholder;
            txtReason.ForeColor = _colorPlaceholder;
            _reasonIsPlaceholder = true;
        }

        private void TxtReason_Enter(object sender, EventArgs e)
        {
            if (_reasonIsPlaceholder)
            {
                txtReason.Text = string.Empty;
                txtReason.ForeColor = _colorInput;
                _reasonIsPlaceholder = false;
            }
        }

        private void TxtReason_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                txtReason.Text = _reasonPlaceholder;
                txtReason.ForeColor = _colorPlaceholder;
                _reasonIsPlaceholder = true;
                lblCharCount.Text = "0 / 500";
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Live character counter
        // ════════════════════════════════════════════════════════════
        private void TxtReason_TextChanged(object sender, EventArgs e)
        {
            if (_reasonIsPlaceholder) return;
            int len = txtReason.Text.Length;
            lblCharCount.Text = $"{len} / 500";
            lblCharCount.ForeColor = len > 450
                ? System.Drawing.Color.FromArgb(248, 81, 73)
                : _colorPlaceholder;
        }

        // ════════════════════════════════════════════════════════════
        //  Highlight wrap panel khi focus
        // ════════════════════════════════════════════════════════════
        private void HighlightWrap(Panel wrap, bool focused)
        {
            wrap.BackColor = focused
                ? System.Drawing.Color.FromArgb(40, 46, 56)
                : System.Drawing.Color.FromArgb(33, 38, 45);
        }

        // ════════════════════════════════════════════════════════════
        //  Validate & Confirm
        // ════════════════════════════════════════════════════════════
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // Ẩn banner cũ
            pnlValidation.Visible = false;

            string accountID = txtAccountID.Text.Trim();
            string reason = _reasonIsPlaceholder ? string.Empty
                                                    : txtReason.Text.Trim();

            if (string.IsNullOrEmpty(accountID) && string.IsNullOrEmpty(reason))
            {
                ShowValidation("Vui lòng nhập đầy đủ Account ID và Lý do.");
                txtAccountID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(accountID))
            {
                ShowValidation("Account ID không được để trống.");
                txtAccountID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(reason))
            {
                ShowValidation("Vui lòng nhập Lý do blacklist.");
                txtReason.Focus();
                return;
            }

            // Lưu kết quả vào properties
            AccountIDValue = accountID;
            ReasonValue = reason;
            AddedDateValue = DateTime.Today;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ShowValidation(string message)
        {
            lblValidation.Text = message;
            pnlValidation.Visible = true;
        }

        // ════════════════════════════════════════════════════════════
        //  Public properties — form cha đọc kết quả sau DialogResult.OK
        // ════════════════════════════════════════════════════════════
        public string AccountIDValue { get; private set; }
        public string ReasonValue { get; private set; }
        public DateTime AddedDateValue { get; private set; }
    }
}