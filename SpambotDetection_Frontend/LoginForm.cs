using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace demo_AI
{
    public partial class LoginForm : Form
    {
        // ════════════════════════════════════════════════════════════
        //  Hằng số màu sắc
        // ════════════════════════════════════════════════════════════
        private static readonly System.Drawing.Color ColorError = System.Drawing.Color.FromArgb(248, 81, 73);
        private static readonly System.Drawing.Color ColorSuccess = System.Drawing.Color.FromArgb(0, 212, 170);
        private static readonly System.Drawing.Color ColorMuted = System.Drawing.Color.FromArgb(100, 110, 120);

        // HttpClient dùng chung cho toàn ứng dụng
        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        // ════════════════════════════════════════════════════════════
        //  Constructor
        // ════════════════════════════════════════════════════════════
        public LoginForm()
        {
            InitializeComponent();
            AttachEvents();
        }

        // ════════════════════════════════════════════════════════════
        //  Gắn events
        // ════════════════════════════════════════════════════════════
        private void AttachEvents()
        {
            this.Load += LoginForm_Load;
            this.btnLogin.Click += BtnLogin_Click;
            this.chkShowPass.CheckedChanged += ChkShowPass_CheckedChanged;

            this.txtUsername.KeyDown += TxtUsername_KeyDown;
            this.txtPassword.KeyDown += TxtPassword_KeyDown;

            this.txtUsername.TextChanged += (s, e) => ClearStatus();
            this.txtPassword.TextChanged += (s, e) => ClearStatus();
        }

        // ════════════════════════════════════════════════════════════
        //  Load
        // ════════════════════════════════════════════════════════════
        private void LoginForm_Load(object sender, EventArgs e)
        {
            picSpinner.Visible = false;
            lblStatus.Visible = false;
            txtUsername.Focus();
        }

        // ════════════════════════════════════════════════════════════
        //  Keyboard shortcuts
        // ════════════════════════════════════════════════════════════
        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnLogin_Click(sender, e);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Toggle hiện / ẩn mật khẩu
        // ════════════════════════════════════════════════════════════
        private void ChkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPass.Checked;
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = 0;
        }

        // ════════════════════════════════════════════════════════════
        //  Nút Đăng nhập
        // ════════════════════════════════════════════════════════════
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                ShowStatus("Vui lòng nhập tên đăng nhập và mật khẩu.", isError: true);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(username))
            {
                ShowStatus("Tên đăng nhập không được để trống.", isError: true);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ShowStatus("Mật khẩu không được để trống.", isError: true);
                txtPassword.Focus();
                return;
            }

            SetUiLoading(true);
            ClearStatus();

            try
            {
                bool ok = await LoginAsync(username, password);

                if (ok)
                {
                    ShowStatus($"Chào mừng, {AppSession.DisplayName}!", isError: false);
                    await Task.Delay(600);

                    var mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"Lỗi không xác định: {ex.Message}", isError: true);
            }
            finally
            {
                SetUiLoading(false);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Login — dùng localhost cố định, KHÔNG dùng Ngrok URL
        // ════════════════════════════════════════════════════════════
        private async Task<bool> LoginAsync(string username, string password)
        {
            // Login luôn trỏ về localhost — Ngrok URL chỉ dùng cho AI scan
            string localUrl = ConfigurationManager.AppSettings["LocalApiUrl"] ?? "http://localhost:5000";
            string url = $"{localUrl.TrimEnd('/')}/api/auth/login";

            var payload = new
            {
                Username = username,
                Password = password
            };

            string jsonBody = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response;
            try
            {
                response = await _http.PostAsync(url, content);
            }
            catch (HttpRequestException)
            {
                ShowStatus("Không thể kết nối đến máy chủ.\nKiểm tra lại URL API hoặc liên hệ Admin.", isError: true);
                return false;
            }
            catch (TaskCanceledException)
            {
                ShowStatus("Máy chủ không phản hồi (timeout 15s).\nVui lòng thử lại.", isError: true);
                return false;
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject json;

            try
            {
                json = JObject.Parse(responseBody);
            }
            catch
            {
                ShowStatus("Phản hồi từ máy chủ không hợp lệ.", isError: true);
                return false;
            }

            if (response.IsSuccessStatusCode)
            {
                JToken data = json["data"];
                if (data == null)
                {
                    ShowStatus("Phản hồi đăng nhập không hợp lệ.", isError: true);
                    return false;
                }

                string accessToken = data["accessToken"]?.ToString() ?? string.Empty;
                string refreshToken = data["refreshToken"]?.ToString() ?? string.Empty;
                JToken userNode = data["user"];

                Guid userId = Guid.TryParse(userNode?["id"]?.ToString(), out var g) ? g : Guid.Empty;
                string uname = userNode?["username"]?.ToString() ?? username;
                string displayName = userNode?["displayName"]?.ToString() ?? uname;
                string role = userNode?["role"]?.ToString() ?? "user";

                AppSession.SetSession(accessToken, refreshToken, userId, uname, displayName, role);

                _http.DefaultRequestHeaders.Remove("Authorization");
                _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                string errMsg = json["error"]?["message"]?.ToString() ?? "Sai tên đăng nhập hoặc mật khẩu.";
                ShowStatus(errMsg, isError: true);
                txtPassword.Clear();
                txtPassword.Focus();
                return false;
            }
            else
            {
                string errMsg = json["error"]?["message"]?.ToString()
                                ?? $"Lỗi máy chủ ({(int)response.StatusCode}).";
                ShowStatus(errMsg, isError: true);
                return false;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Helpers UI
        // ════════════════════════════════════════════════════════════
        private void SetUiLoading(bool loading)
        {
            btnLogin.Enabled = !loading;
            txtUsername.Enabled = !loading;
            txtPassword.Enabled = !loading;
            chkShowPass.Enabled = !loading;
            picSpinner.Visible = loading;
            btnLogin.Text = loading ? "Đang đăng nhập..." : "ĐĂNG NHẬP";
        }

        private void ShowStatus(string message, bool isError)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = isError ? ColorError : ColorSuccess;
            lblStatus.Visible = true;
        }

        private void ClearStatus()
        {
            lblStatus.Visible = false;
            lblStatus.Text = string.Empty;
        }
    }
}