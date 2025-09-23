using System;
using System.Windows.Forms;
using PhoneStore.Services;
using PhoneStore.Utils;

namespace PhoneStore.Forms
{
    public partial class frmMain : Form
    {
        private ReportService reportService;

        public frmMain()
        {
            InitializeComponent();
            reportService = new ReportService();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Set user info
                lblUser.Text = $"Người dùng: {SessionManager.GetUserDisplayName()}";

                // Load dashboard stats
                LoadDashboardStats();

                // Set up role-based menu access
                SetupRoleBasedAccess();

                // Start datetime timer
                timerDateTime.Start();

                lblStatus.Text = "Hệ thống sẵn sàng";
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi khởi tạo form chính");
            }
        }

        private void LoadDashboardStats()
        {
            try
            {
                var statsResult = reportService.GetDashboardStats();

                if (statsResult.IsSuccess)
                {
                    var stats = statsResult.Data;

                    lblTodayRevenue.Text = $"Doanh thu: {ValidationHelper.FormatCurrency(stats.TodayRevenue)}";
                    lblTodayOrders.Text = $"Đơn hàng: {stats.TodayOrders}";

                    lblMonthRevenue.Text = $"Doanh thu: {ValidationHelper.FormatCurrency(stats.MonthRevenue)}";
                    lblMonthOrders.Text = $"Đơn hàng: {stats.MonthOrders}";
                }
                else
                {
                    // Set default values if can't load stats
                    lblTodayRevenue.Text = "Doanh thu: 0đ";
                    lblTodayOrders.Text = "Đơn hàng: 0";
                    lblMonthRevenue.Text = "Doanh thu: 0đ";
                    lblMonthOrders.Text = "Đơn hàng: 0";
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tải thống kê dashboard", false);

                // Set default values on error
                lblTodayRevenue.Text = "Doanh thu: 0đ";
                lblTodayOrders.Text = "Đơn hàng: 0";
                lblMonthRevenue.Text = "Doanh thu: 0đ";
                lblMonthOrders.Text = "Đơn hàng: 0";
            }
        }

        private void SetupRoleBasedAccess()
        {
            try
            {
                // Admin có full quyền
                if (SessionManager.IsAdmin)
                {
                    return; // Có tất cả quyền
                }

                // Manager có hầu hết quyền
                if (SessionManager.IsManager)
                {
                    return; // Có hầu hết quyền
                }

                // Cashier chỉ có quyền tạo đơn hàng và xem khách hàng
                if (SessionManager.IsCashier)
                {
                    mnuProducts.Enabled = false;
                    mnuReports.Enabled = false;
                    return;
                }

                // Salesperson có quyền bán hàng và quản lý khách hàng
                if (SessionManager.IsSalesperson)
                {
                    mnuReports.Enabled = false;
                    return;
                }

                // Staff có quyền hạn chế
                mnuProducts.Enabled = false;
                mnuReports.Enabled = false;
                mnuCustomers.Enabled = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi thiết lập phân quyền", false);
            }
        }

        // =====================================================
        // TIMER EVENT
        // =====================================================

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch
            {
                // Ignore timer errors
            }
        }

        // =====================================================
        // SYSTEM MENU EVENTS
        // =====================================================

        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement change password form
                MessageBox.Show("Chức năng đổi mật khẩu sẽ được cập nhật trong phiên bản tiếp theo.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở form đổi mật khẩu");
            }
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (ExceptionHandler.ShowConfirmDialog("Bạn có chắc chắn muốn đăng xuất?"))
                {
                    SessionManager.Logout();

                    this.Hide();
                    var loginForm = new frmLogin();
                    loginForm.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi đăng xuất");
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ExceptionHandler.ShowConfirmDialog("Bạn có chắc chắn muốn thoát ứng dụng?"))
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi thoát ứng dụng");
            }
        }

        // =====================================================
        // PRODUCT MENU EVENTS
        // =====================================================

        private void mnuProductList_Click(object sender, EventArgs e)
        {
            try
            {
                OpenForm("frmProductList", "Danh sách sản phẩm");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở form sản phẩm");
            }
        }

        private void mnuProductCategories_Click(object sender, EventArgs e)
        {
            try
            {
                OpenForm("frmCategories", "Quản lý danh mục");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở form danh mục");
            }
        }

        private void mnuProductBrands_Click(object sender, EventArgs e)
        {
            try
            {
                OpenForm("frmBrands", "Quản lý thương hiệu");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở form thương hiệu");
            }
        }

        private void mnuInventory_Click(object sender, EventArgs e)
        {
            try
            {
                OpenForm("frmInventory", "Quản lý tồn kho");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở form tồn kho");
            }
        }

        // =====================================================
        // CUSTOMER MENU EVENTS
        // =====================================================

        private void mnuCustomerList_Click(object sender, EventArgs e)
        {
            try
            {
                OpenForm("frmCustomerList", "Danh sách khách hàng");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở form khách hàng");
            }
        }

        private void mnuVIPCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                OpenForm("frmVIPCustomers", "Khách hàng VIP");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở form khách hàng VIP");
            }
        }

        // =====================================================
        // ORDER MENU EVENTS
        // =====================================================

        private void mnuCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var createOrderForm = new frmCreateOrder();
                createOrderForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở form tạo đơn hàng");
            }
        }

        private void mnuOrderList_Click(object sender, EventArgs e)
        {
            try
            {
                var orderListForm = new frmOrderList();
                orderListForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở form đơn hàng");
            }
        }

        // =====================================================
        // REPORT MENU EVENTS
        // =====================================================

        private void mnuSalesReport_Click(object sender, EventArgs e)
        {
            try
            {
                var salesReportForm = new frmSalesReport();
                salesReportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở báo cáo bán hàng");
            }
        }

        private void mnuInventoryReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenForm("frmInventoryReport", "Báo cáo tồn kho");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở báo cáo tồn kho");
            }
        }

        private void mnuCustomerReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenForm("frmCustomerReport", "Báo cáo khách hàng");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi mở báo cáo khách hàng");
            }
        }

        // =====================================================
        // HELP MENU EVENTS
        // =====================================================

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            try
            {
                string aboutText = $@"HỆ THỐNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI

Phiên bản: 1.0.0
Ngày phát hành: {DateTime.Now:dd/MM/yyyy}

Phát triển bởi: [Tên sinh viên]
MSSV: [Mã số sinh viên]
Lớp: [Tên lớp]

Môn học: Hệ quản trị cơ sở dữ liệu
Giảng viên: [Tên giảng viên]

© 2024 All rights reserved.";

                MessageBox.Show(aboutText, "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hiển thị thông tin");
            }
        }

        // =====================================================
        // QUICK ACTION BUTTON EVENTS
        // =====================================================

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            mnuCreateOrder_Click(sender, e);
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            mnuProductList_Click(sender, e);
        }

        private void btnViewCustomers_Click(object sender, EventArgs e)
        {
            mnuCustomerList_Click(sender, e);
        }

        // =====================================================
        // FORM CLOSING EVENT
        // =====================================================

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    if (!ExceptionHandler.ShowConfirmDialog("Bạn có chắc chắn muốn thoát ứng dụng?"))
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                // Stop timer
                if (timerDateTime != null)
                {
                    timerDateTime.Stop();
                }

                // Logout user
                SessionManager.Logout();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi đóng form chính", false);
            }
        }

        // =====================================================
        // HELPER METHODS
        // =====================================================

        private void OpenForm(string formName, string formTitle)
        {
            try
            {
                lblStatus.Text = $"Đang mở {formTitle}...";

                // Placeholder - sẽ implement các form cụ thể sau
                MessageBox.Show($"Form '{formTitle}' sẽ được cài đặt trong phiên bản tiếp theo.\n\nForm type: {formName}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblStatus.Text = "Sẵn sàng";
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, $"Lỗi mở form {formTitle}");
                lblStatus.Text = "Sẵn sàng";
            }
        }

        private void RefreshDashboard()
        {
            try
            {
                LoadDashboardStats();
                lblStatus.Text = "Đã làm mới thống kê";
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi làm mới dashboard", false);
            }
        }

        // =====================================================
        // PUBLIC METHODS FOR CHILD FORMS
        // =====================================================

        public void UpdateStatus(string message)
        {
            try
            {
                if (lblStatus != null)
                {
                    lblStatus.Text = message;
                }
            }
            catch
            {
                // Ignore status update errors
            }
        }

        public void RefreshStats()
        {
            RefreshDashboard();
        }

        private void btnRefreshStats_Click(object sender, EventArgs e)
        {
            RefreshStats();
        }
    }
}