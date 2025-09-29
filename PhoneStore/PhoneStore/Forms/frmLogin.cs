using PhoneStore.Configs;
using PhoneStore.Services;
using PhoneStore.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStore.Forms
{
    public partial class frmLogin : Form
    {
        private AuthenticationService authService;

        public frmLogin()
        {
            InitializeComponent();
            authService = new AuthenticationService();
            this.KeyPreview = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                // Test database connection
                if (!Configs.DBConnection.TestDefaultConnection())
                {
                    ExceptionHandler.ShowValidationError("Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra lại cấu hình kết nối.");
                    return;
                }

                // Load saved username if exists
                LoadSavedCredentials();

                // Set focus to appropriate control
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                    txtUsername.Focus();
                else
                    txtPassword.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi khởi tạo form đăng nhập");
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            btnLogin.Enabled = false;
            btnLogin.Text = "Đang đăng nhập...";

            try
            {
                DBConnection.Username = txtUsername.Text.Trim();
                DBConnection.Password = txtPassword.Text.Trim();

                var result = authService.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                if (result.Success)
                {
                    SessionManager.SetCurrentUser(result.User);

                    //// Save credentials if remember is checked
                    //if (chkRemember.Checked)
                    //{
                    //    SaveCredentials();
                    //}

                    ExceptionHandler.ShowSuccessMessage($"Chào mừng {result.User.Position}: {SessionManager.GetUserDisplayName()}!");

                    this.Hide();
                    var mainForm = new frmMain();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    ExceptionHandler.ShowValidationError(result.Message);
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi trong quá trình đăng nhập");
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ExceptionHandler.ShowConfirmDialog("Bạn có chắc chắn muốn thoát ứng dụng?"))
            {
                Application.Exit();
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ExceptionHandler.ShowValidationError("Vui lòng nhập tên đăng nhập.");
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ExceptionHandler.ShowValidationError("Vui lòng nhập mật khẩu.");
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void LoadSavedCredentials()
        {
            try
            {
                var savedUsername = Properties.Settings.Default.SavedUsername;
                if (!string.IsNullOrEmpty(savedUsername))
                {
                    txtUsername.Text = savedUsername;
                    //chkRemember.Checked = true;
                }
            }
            catch
            {
                // Ignore errors when loading saved credentials
            }
        }

        //private void SaveCredentials()
        //{
        //    try
        //    {
        //        Properties.Settings.Default.SavedUsername = txtUsername.Text.Trim();
        //        Properties.Settings.Default.Save();
        //    }
        //    catch
        //    {
        //        // Ignore errors when saving credentials
        //    }
        //}
    }
}
