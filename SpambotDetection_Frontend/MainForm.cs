using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_AI
{
    public partial class MainForm : Form
    {
        // ════════════════════════════════════════════════════════════
        //  Màu sắc
        // ════════════════════════════════════════════════════════════
        private static readonly Color ColorActive = Color.FromArgb(22, 27, 34);      // nền nút active
        private static readonly Color ColorInactive = Color.Transparent;               // nền nút thường
        private static readonly Color ColorAccent = Color.FromArgb(0, 212, 170);     // chữ active
        private static readonly Color ColorMuted = Color.FromArgb(139, 148, 158);   // chữ inactive
        private static readonly Color ColorSidebar = Color.FromArgb(13, 17, 23);      // nền sidebar

        private static readonly Color ColorOnline = Color.FromArgb(0, 212, 170);
        private static readonly Color ColorOffline = Color.FromArgb(248, 81, 73);
        private static readonly Color ColorChecking = Color.FromArgb(210, 153, 34);

        // ════════════════════════════════════════════════════════════
        //  UserControl instances (lazy, tạo một lần duy nhất)
        // ════════════════════════════════════════════════════════════
        private StatisticsControl _statsCtrl;
        private SingleScanControl _singleCtrl;
        private BatchScanControl _batchCtrl;
        private HistoryControl _historyCtrl;
        private BlacklistControl _blacklistCtrl;
        private ConfigControl _configCtrl;

        // Nút đang được chọn hiện tại
        private Button _activeBtn;

        // HttpClient dùng chung (cùng instance với LoginForm qua AppSession)
        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        // ════════════════════════════════════════════════════════════
        //  Constructor
        // ════════════════════════════════════════════════════════════
        public MainForm()
        {
            InitializeComponent();
            AttachEvents();
        }

        // ════════════════════════════════════════════════════════════
        //  Gắn events
        // ════════════════════════════════════════════════════════════
        private void AttachEvents()
        {
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;

            btnNavStats.Click += (s, e) => NavigateTo(btnNavStats, "Thống kê", "Tổng quan hệ thống");
            btnNavSingle.Click += (s, e) => NavigateTo(btnNavSingle, "Kiểm tra đơn lẻ", "Nhập thông tin tài khoản để kiểm tra");
            btnNavBatch.Click += (s, e) => NavigateTo(btnNavBatch, "Quét CSV", "Tải lên file CSV để quét hàng loạt");
            btnNavHistory.Click += (s, e) => NavigateTo(btnNavHistory, "Lịch sử quét", "Danh sách các lần kiểm tra trước đây");
            btnNavBlacklist.Click += (s, e) => NavigateTo(btnNavBlacklist, "Blacklist", "Danh sách tài khoản bị chặn");
            btnNavConfig.Click += (s, e) => NavigateTo(btnNavConfig, "Cấu hình API", "Quản lý URL kết nối và tài khoản");

            btnLogout.Click += BtnLogout_Click;
            btnRefreshStatus.Click += BtnRefreshStatus_Click;
        }

        // ════════════════════════════════════════════════════════════
        //  Load
        // ════════════════════════════════════════════════════════════
        private async void MainForm_Load(object sender, EventArgs e)
        {
            // 1. Hiển thị thông tin user từ session
            LoadUserInfo();

            // 2. Phân quyền: chỉ Admin thấy Blacklist và Config
            ApplyRolePermissions();

            // 3. Cập nhật status bar
            UpdateStatusBar();

            // 4. Mặc định mở trang Thống kê
            NavigateTo(btnNavStats, "Thống kê", "Tổng quan hệ thống");

            // 5. Kiểm tra trạng thái AI server
            await CheckAIStatusAsync();
        }

        // ════════════════════════════════════════════════════════════
        //  Hiển thị thông tin user trên sidebar
        // ════════════════════════════════════════════════════════════
        private void LoadUserInfo()
        {
            lblUserName.Text = AppSession.DisplayName;
            lblUserRole.Text = AppSession.IsAdmin ? "Quản trị viên" : "Người dùng";
        }

        // ════════════════════════════════════════════════════════════
        //  Phân quyền theo Role
        // ════════════════════════════════════════════════════════════
        private void ApplyRolePermissions()
        {
            bool isAdmin = AppSession.IsAdmin;

            // Blacklist: tất cả đều xem được (Admin mới thêm/xóa — sẽ xử lý trong BlacklistControl)
            btnNavBlacklist.Visible = true;

            // Config: chỉ Admin
            btnNavConfig.Visible = isAdmin;
        }

        // ════════════════════════════════════════════════════════════
        //  Điều hướng sang UserControl tương ứng
        // ════════════════════════════════════════════════════════════
        private void NavigateTo(Button btn, string pageTitle, string pageSubtitle)
        {
            // ── Cập nhật trạng thái nút sidebar ──────────────────
            SetActiveButton(btn);

            // ── Cập nhật tiêu đề header ───────────────────────────
            lblPageTitle.Text = pageTitle;
            lblPageSubtitle.Text = pageSubtitle;

            // ── Lấy (hoặc tạo mới) UserControl tương ứng ─────────
            UserControl ctrl = GetOrCreateControl(btn);
            if (ctrl == null) return;

            // ── Load vào pnlContent ───────────────────────────────
            pnlContent.SuspendLayout();
            pnlContent.Controls.Clear();

            ctrl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(ctrl);
            ctrl.BringToFront();

            pnlContent.ResumeLayout(true);
        }

        /// <summary>Lazy-create UserControl, mỗi loại chỉ tạo 1 lần.</summary>
        private UserControl GetOrCreateControl(Button btn)
        {
            if (btn == btnNavStats)
            {
                if (_statsCtrl == null) _statsCtrl = new StatisticsControl();
                return _statsCtrl;
            }
            if (btn == btnNavSingle)
            {
                if (_singleCtrl == null) _singleCtrl = new SingleScanControl();
                return _singleCtrl;
            }
            if (btn == btnNavBatch)
            {
                if (_batchCtrl == null) _batchCtrl = new BatchScanControl();
                return _batchCtrl;
            }
            if (btn == btnNavHistory)
            {
                if (_historyCtrl == null) _historyCtrl = new HistoryControl();
                return _historyCtrl;
            }
            if (btn == btnNavBlacklist)
            {
                if (_blacklistCtrl == null) _blacklistCtrl = new BlacklistControl();
                return _blacklistCtrl;
            }
            if (btn == btnNavConfig)
            {
                if (_configCtrl == null) _configCtrl = new ConfigControl();
                return _configCtrl;
            }
            return null;
        }

        // ════════════════════════════════════════════════════════════
        //  Highlight nút active trên sidebar
        // ════════════════════════════════════════════════════════════
        private void SetActiveButton(Button btn)
        {
            // Reset tất cả nút về trạng thái inactive
            Button[] navBtns = { btnNavStats, btnNavSingle, btnNavBatch,
                                  btnNavHistory, btnNavBlacklist, btnNavConfig };

            foreach (var b in navBtns)
            {
                b.BackColor = ColorInactive;
                b.ForeColor = ColorMuted;
                b.Font = new Font(b.Font, FontStyle.Regular);
            }

            // Đặt nút được chọn là active
            btn.BackColor = ColorActive;
            btn.ForeColor = ColorAccent;
            btn.Font = new Font(btn.Font, FontStyle.Bold);

            _activeBtn = btn;
        }

        // ════════════════════════════════════════════════════════════
        //  Kiểm tra trạng thái AI server (header)
        // ════════════════════════════════════════════════════════════
        private async Task CheckAIStatusAsync()
        {
            SetAIStatusUI("Đang kiểm tra...", ColorChecking);

            try
            {
                // Đặt Authorization header nếu chưa có
                if (!_http.DefaultRequestHeaders.Contains("Authorization") &&
                    !string.IsNullOrEmpty(AppSession.AccessToken))
                {
                    _http.DefaultRequestHeaders.Add("Authorization",
                        $"Bearer {AppSession.AccessToken}");
                }

                string url = $"{AppSession.ApiBaseUrl.TrimEnd('/')}/api/config/health"; // ✅ endpoint đúng
                var response = await _http.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    SetAIStatusUI("AI Online", ColorOnline);
                else
                    SetAIStatusUI("AI Lỗi", ColorOffline);
            }
            catch
            {
                SetAIStatusUI("AI Offline", ColorOffline);
            }
        }

        private void SetAIStatusUI(string text, Color color)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetAIStatusUI(text, color)));
                return;
            }

            lblAIStatus.Text = text;
            lblAIStatus.ForeColor = color;

            // Đổi màu chấm tròn bằng cách vẽ lại PictureBox
            var bmp = new System.Drawing.Bitmap(12, 12);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(color))
                    g.FillEllipse(brush, 1, 1, 10, 10);
            }
            picAIStatusDot.Image = bmp;
        }

        private async void BtnRefreshStatus_Click(object sender, EventArgs e)
        {
            btnRefreshStatus.Enabled = false;
            await CheckAIStatusAsync();
            btnRefreshStatus.Enabled = true;
        }

        // ════════════════════════════════════════════════════════════
        //  Status bar dưới cùng
        // ════════════════════════════════════════════════════════════
        private void UpdateStatusBar()
        {
            lblStatusLeft.Text = $"👤 {AppSession.DisplayName}  ({(AppSession.IsAdmin ? "Admin" : "User")})";
            lblStatusCenter.Text = $"🔗 {AppSession.ApiBaseUrl}";
            lblStatusRight.Text = $"🕐 {DateTime.Now:dd/MM/yyyy HH:mm}";
        }

        // ════════════════════════════════════════════════════════════
        //  Đăng xuất
        // ════════════════════════════════════════════════════════════
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            // Xóa session
            AppSession.Clear();
            _http.DefaultRequestHeaders.Remove("Authorization");

            // Mở lại LoginForm
            var loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }

        // ════════════════════════════════════════════════════════════
        //  FormClosing: nếu đóng MainForm mà chưa logout → thoát app
        // ════════════════════════════════════════════════════════════
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && AppSession.IsLoggedIn)
            {
                var result = MessageBox.Show(
                    "Bạn có muốn thoát ứng dụng không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            // Thoát hoàn toàn
            Application.Exit();
        }

        // ════════════════════════════════════════════════════════════
        //  Public helper: các UserControl con gọi để refresh status bar
        //  Ví dụ: MainForm.Instance.RefreshStatusBar()
        // ════════════════════════════════════════════════════════════
        public static MainForm Instance { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            Instance = this;
            base.OnLoad(e);
        }

        public void RefreshStatusBar() => UpdateStatusBar();

        /// <summary>
        /// Điều hướng từ bên ngoài (ví dụ HistoryControl bấm "Xem Blacklist").
        /// </summary>
        public void GoToBlacklist()
            => NavigateTo(btnNavBlacklist, "Blacklist", "Danh sách tài khoản bị chặn");

        public void GoToHistory()
            => NavigateTo(btnNavHistory, "Lịch sử quét", "Danh sách các lần kiểm tra trước đây");
    }
}