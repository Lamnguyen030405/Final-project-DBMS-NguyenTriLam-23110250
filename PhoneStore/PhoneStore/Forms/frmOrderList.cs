using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhoneStore.Services;
using PhoneStore.Utils;
using PhoneStoreManagement.Models;

namespace PhoneStore.Forms
{
    public partial class frmOrderList : Form
    {
        private OrderService orderService;
        private List<Order> currentOrders;
        private Order selectedOrder;
        private PrintDocument printDocument;

        public frmOrderList()
        {
            InitializeComponent();
            orderService = new OrderService();
            currentOrders = new List<Order>();
            InitializePrint();
        }

        private void InitializePrint()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void InitializeForm()
        {
            // Set date filter defaults
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;

            // Set default selections
            cboOrderStatus.SelectedIndex = 0; // Tất cả
            cboPaymentStatus.SelectedIndex = 0; // Tất cả

            // Setup DataGridView columns
            SetupOrdersDataGridView();
            SetupOrderDetailsDataGridView();

        }

        private void SetupOrdersDataGridView()
        {
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add("OrderCode", "Mã đơn hàng");
            dgvOrders.Columns.Add("OrderDate", "Ngày đặt");
            dgvOrders.Columns.Add("CustomerName", "Khách hàng");
            dgvOrders.Columns.Add("EmployeeName", "Nhân viên");
            dgvOrders.Columns.Add("TotalAmount", "Tổng tiền");
            dgvOrders.Columns.Add("PaymentMethod", "PT Thanh toán");
            dgvOrders.Columns.Add("PaymentStatus", "TT Thanh toán");
            dgvOrders.Columns.Add("OrderStatus", "TT Đơn hàng");

            // Set column widths
            dgvOrders.Columns["OrderCode"].Width = 120;
            dgvOrders.Columns["OrderDate"].Width = 100;
            dgvOrders.Columns["CustomerName"].Width = 150;
            dgvOrders.Columns["EmployeeName"].Width = 120;
            dgvOrders.Columns["TotalAmount"].Width = 120;
            dgvOrders.Columns["PaymentMethod"].Width = 100;
            dgvOrders.Columns["PaymentStatus"].Width = 120;
            dgvOrders.Columns["OrderStatus"].Width = 120;

            // Format columns
            dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
            dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private void SetupOrderDetailsDataGridView()
        {
            dgvOrderDetails.Columns.Clear();
            dgvOrderDetails.Columns.Add("ProductCode", "Mã SP");
            dgvOrderDetails.Columns.Add("ProductName", "Tên sản phẩm");
            dgvOrderDetails.Columns.Add("Quantity", "SL");
            dgvOrderDetails.Columns.Add("UnitPrice", "Đơn giá");
            dgvOrderDetails.Columns.Add("DiscountPerItem", "Giảm giá");
            dgvOrderDetails.Columns.Add("TotalPrice", "Thành tiền");
            dgvOrderDetails.Columns.Add("WarrantyEndDate", "Hết BH");

            // Set column widths
            dgvOrderDetails.Columns["ProductCode"].Width = 100;
            dgvOrderDetails.Columns["ProductName"].Width = 300;
            dgvOrderDetails.Columns["Quantity"].Width = 60;
            dgvOrderDetails.Columns["UnitPrice"].Width = 100;
            dgvOrderDetails.Columns["DiscountPerItem"].Width = 100;
            dgvOrderDetails.Columns["TotalPrice"].Width = 120;
            dgvOrderDetails.Columns["WarrantyEndDate"].Width = 100;

            // Format columns
            dgvOrderDetails.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderDetails.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrderDetails.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            dgvOrderDetails.Columns["DiscountPerItem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrderDetails.Columns["DiscountPerItem"].DefaultCellStyle.Format = "N0";
            dgvOrderDetails.Columns["TotalPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrderDetails.Columns["TotalPrice"].DefaultCellStyle.Format = "N0";
            dgvOrderDetails.Columns["WarrantyEndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void LoadOrders()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);

                var result = orderService.GetAllOrders(fromDate, toDate);

                if (result.IsSuccess)
                {
                    currentOrders = result.Data;
                    ApplyFiltersAndDisplayOrders();
                }
                else
                {
                    ExceptionHandler.ShowValidationError(result.Message);
                    currentOrders = new List<Order>();
                    DisplayOrders(currentOrders);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tải danh sách đơn hàng");
                currentOrders = new List<Order>();
                DisplayOrders(currentOrders);
            }
        }

        private void ApplyFiltersAndDisplayOrders()
        {
            try
            {
                var filteredOrders = currentOrders.AsEnumerable();

                // Filter by order status
                if (cboOrderStatus.SelectedIndex > 0)
                {
                    string orderStatus = GetOrderStatusValue(cboOrderStatus.Text);
                    filteredOrders = filteredOrders.Where(o => o.OrderStatus == orderStatus);
                }

                // Filter by payment status
                if (cboPaymentStatus.SelectedIndex > 0)
                {
                    string paymentStatus = GetPaymentStatusValue(cboPaymentStatus.Text);
                    filteredOrders = filteredOrders.Where(o => o.PaymentStatus == paymentStatus);
                }

                //Filter by employee
                if (cboEmployee.SelectedIndex > 0)
                {
                    string employee = GetEmployeeByName(cboEmployee.Text);
                    if (employee != "")
                    {
                        filteredOrders = filteredOrders.Where(o => o.EmployeeName == employee);
                    }
                }

                DisplayOrders(filteredOrders.ToList());
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi lọc danh sách đơn hàng");
            }
        }

        private void SetRowStatusColor(DataGridViewRow row, string orderStatus, string paymentStatus)
        {
            // Set background color based on order status
            switch (orderStatus?.ToLower())
            {
                case "completed":
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    break;
                case "cancelled":
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                    break;
                case "returned":
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                    break;
                default: // processing
                    if (paymentStatus == "paid")
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    break;
            }
        }

        private void LoadOrderDetails(Order order)
        {
            try
            {
                if (order == null) return;

                var result = orderService.GetOrderById(order.OrderId);

                if (result.IsSuccess)
                {
                    selectedOrder = result.Data;
                    DisplayOrderDetails(selectedOrder);
                    DisplayOrderInfo(selectedOrder);
                }
                else
                {
                    ExceptionHandler.ShowValidationError("Không thể tải chi tiết đơn hàng: " + result.Message);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tải chi tiết đơn hàng");
            }
        }

        private void DisplayOrderDetails(Order order)
        {
            try
            {
                dgvOrderDetails.Rows.Clear();

                if (order.OrderDetails == null) return;

                foreach (var detail in order.OrderDetails)
                {
                    var row = dgvOrderDetails.Rows.Add();

                    dgvOrderDetails.Rows[row].Cells["ProductCode"].Value = detail.ProductCode;
                    dgvOrderDetails.Rows[row].Cells["ProductName"].Value = detail.ProductName;
                    dgvOrderDetails.Rows[row].Cells["Quantity"].Value = detail.Quantity;
                    dgvOrderDetails.Rows[row].Cells["UnitPrice"].Value = detail.UnitPrice;
                    dgvOrderDetails.Rows[row].Cells["DiscountPerItem"].Value = detail.DiscountPerItem;
                    dgvOrderDetails.Rows[row].Cells["TotalPrice"].Value = detail.TotalPrice;
                    dgvOrderDetails.Rows[row].Cells["WarrantyEndDate"].Value = detail.WarrantyEndDate?.ToString("dd/MM/yyyy") ?? "";
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hiển thị chi tiết đơn hàng");
            }
        }

        private void DisplayOrderInfo(Order order)
        {
            try
            {
                if (order == null)
                {
                    txtOrderInfo.Text = "";
                    return;
                }

                var info = $@"MÃ ĐƠN HÀNG: {order.OrderCode}
NGÀY ĐẶT: {order.OrderDate:dd/MM/yyyy HH:mm}
KHÁCH HÀNG: {order.CustomerName ?? "Khách lẻ"}
NHÂN VIÊN: {order.EmployeeName ?? ""}

CHI TIẾT THANH TOÁN:
- Tạm tính: {ValidationHelper.FormatCurrency(order.Subtotal)}
- Giảm giá: {ValidationHelper.FormatCurrency(order.DiscountAmount)}
- Thuế VAT: {ValidationHelper.FormatCurrency(order.TaxAmount)}
- TỔNG TIỀN: {ValidationHelper.FormatCurrency(order.TotalAmount)}

PHƯƠNG THỨC TT: {GetPaymentMethodText(order.PaymentMethod)}
TRẠNG THÁI TT: {GetPaymentStatusText(order.PaymentStatus)}
TRẠNG THÁI ĐH: {GetOrderStatusText(order.OrderStatus)}

GHI CHÚ: {order.Notes ?? "Không có"}

NGÀY TẠO: {order.CreatedAt:dd/MM/yyyy HH:mm}";

                txtOrderInfo.Text = info;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hiển thị thông tin đơn hàng");
            }
        }

        // =====================================================
        // EVENT HANDLERS
        // =====================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count > 0)
                {
                    var order = dgvOrders.SelectedRows[0].Tag as Order;
                    LoadOrderDetails(order);
                }
                else
                {
                    dgvOrderDetails.Rows.Clear();
                    txtOrderInfo.Text = "";
                    selectedOrder = null;
                }

                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi chọn đơn hàng");
            }
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnViewOrder_Click(sender, e);
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedOrder == null)
                {
                    ExceptionHandler.ShowValidationError("Vui lòng chọn đơn hàng cần xem chi tiết.");
                    return;
                }

                var orderDetailForm = new frmOrderDetail(selectedOrder);
                orderDetailForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi xem chi tiết đơn hàng");
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedOrder == null)
                {
                    ExceptionHandler.ShowValidationError("Vui lòng chọn đơn hàng cần cập nhật trạng thái.");
                    return;
                }

                // Check permission
                if (!SessionManager.IsManager && !SessionManager.IsCashier)
                {
                    ExceptionHandler.ShowValidationError("Bạn không có quyền cập nhật trạng thái đơn hàng.");
                    return;
                }

                // Check if order can be updated
                if (!CanUpdateOrderStatus(selectedOrder))
                {
                    ExceptionHandler.ShowValidationError("Đơn hàng này không thể cập nhật trạng thái.");
                    return;
                }

                using (var form = new frmUpdateOrder(selectedOrder))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrders(); // Refresh the list
                        ExceptionHandler.ShowSuccessMessage("Cập nhật trạng thái đơn hàng thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi cập nhật trạng thái đơn hàng");
            }
        }

        // Add new helper methods to frmOrderList.cs:

        private bool CanUpdateOrderStatus(Order order)
        {
            if (order == null) return false;

            // Cannot update completed or returned orders
            if (order.OrderStatus == "completed" || order.OrderStatus == "returned")
            {
                return false;
            }

            // Can update cancelled orders only to revert cancellation (if admin/manager)
            if (order.OrderStatus == "cancelled" && !SessionManager.IsManager)
            {
                return false;
            }

            return true;
        }

        // =====================================================
        // Enhanced frmOrderList with additional features
        // =====================================================

        // Add these new methods to frmOrderList.cs:

        private void AddOrderStatusSummary()
        {
            try
            {
                if (currentOrders == null || currentOrders.Count == 0)
                    return;

                var summary = currentOrders
                    .GroupBy(o => o.OrderStatus)
                    .Select(g => $"{GetOrderStatusText(g.Key)}: {g.Count()}")
                    .ToArray();

                var summaryText = "Tổng quan: " + string.Join(" | ", summary);

                // Update status bar or add a summary label
                // For now, we'll show it in a tooltip or status
                this.Text = $"Danh sách đơn hàng - {summaryText}";
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tạo tóm tắt đơn hàng", false);
            }
        }

        private void ExportOrdersToCSV()
        {
            try
            {
                if (currentOrders == null || currentOrders.Count == 0)
                {
                    ExceptionHandler.ShowValidationError("Không có dữ liệu để xuất.");
                    return;
                }

                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveDialog.FileName = $"DanhSachDonHang_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        var csv = GenerateCSVContent(currentOrders);
                        System.IO.File.WriteAllText(saveDialog.FileName, csv, System.Text.Encoding.UTF8);

                        ExceptionHandler.ShowSuccessMessage("Xuất file CSV thành công!");

                        // Ask if want to open file
                        if (ExceptionHandler.ShowConfirmDialog("Bạn có muốn mở file vừa xuất không?"))
                        {
                            System.Diagnostics.Process.Start(saveDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi xuất file CSV");
            }
        }

        private string GenerateCSVContent(List<Order> orders)
        {
            var csv = new System.Text.StringBuilder();

            // Header
            csv.AppendLine("Mã đơn hàng,Ngày đặt,Khách hàng,Nhân viên,Tổng tiền,PT Thanh toán,TT Thanh toán,TT Đơn hàng,Ghi chú");

            // Data
            foreach (var order in orders)
            {
                csv.AppendLine($"\"{order.OrderCode}\",\"{order.OrderDate:dd/MM/yyyy HH:mm}\",\"{order.CustomerName ?? "Khách lẻ"}\",\"{order.EmployeeName ?? ""}\",\"{order.TotalAmount:N0}\",\"{GetPaymentMethodText(order.PaymentMethod)}\",\"{GetPaymentStatusText(order.PaymentStatus)}\",\"{GetOrderStatusText(order.OrderStatus)}\",\"{order.Notes ?? ""}\"");
            }

            return csv.ToString();
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            ExportOrdersToCSV();
        }

        // Add context menu for right-click options
        private void SetupContextMenu()
        {
            var contextMenu = new ContextMenuStrip();

            var viewItem = new ToolStripMenuItem("Xem chi tiết", null, (s, e) => btnViewOrder_Click(s, e));
            var updateItem = new ToolStripMenuItem("Cập nhật trạng thái", null, (s, e) => btnUpdateStatus_Click(s, e));
            var printItem = new ToolStripMenuItem("In đơn hàng", null, (s, e) => btnPrintOrder_Click(s, e));
            var separator = new ToolStripSeparator();
            var exportItem = new ToolStripMenuItem("Xuất CSV", null, (s, e) => ExportOrdersToCSV());

            contextMenu.Items.AddRange(new ToolStripItem[]
            {
        viewItem, updateItem, printItem, separator, exportItem
            });

            dgvOrders.ContextMenuStrip = contextMenu;

            // Update context menu when selection changes
            contextMenu.Opening += (s, e) =>
            {
                bool hasSelection = selectedOrder != null;
                viewItem.Enabled = hasSelection;
                updateItem.Enabled = hasSelection && CanUpdateStatus();
                printItem.Enabled = hasSelection;
            };
        }

        // Add keyboard shortcuts
        private void SetupKeyboardShortcuts()
        {
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                try
                {
                    switch (e.KeyCode)
                    {
                        case Keys.F5:
                            btnRefresh_Click(s, e);
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            if (selectedOrder != null)
                            {
                                btnViewOrder_Click(s, e);
                                e.Handled = true;
                            }
                            break;
                        case Keys.F2:
                            if (selectedOrder != null && CanUpdateStatus())
                            {
                                btnUpdateStatus_Click(s, e);
                                e.Handled = true;
                            }
                            break;
                        case Keys.Escape:
                            this.Close();
                            e.Handled = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex, "Lỗi xử lý phím tắt", false);
                }
            };
        }

        // Update the frmOrderList_Load method to include new features:
        private void frmOrderList_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeForm();
                SetupContextMenu();
                SetupKeyboardShortcuts();
                LoadOrders();
                selectedOrder = dgvOrders.SelectedRows[0].Tag as Order;
                LoadOrderDetails(selectedOrder);
                LoadEmployeeList();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi khởi tạo form danh sách đơn hàng");
            }
        }

        // Update the DisplayOrders method to include summary:
        private void DisplayOrders(List<Order> orders)
        {
            try
            {
                dgvOrders.Rows.Clear();

                foreach (var order in orders)
                {
                    var row = dgvOrders.Rows.Add();
                    dgvOrders.Rows[row].Tag = order;

                    dgvOrders.Rows[row].Cells["OrderCode"].Value = order.OrderCode;
                    dgvOrders.Rows[row].Cells["OrderDate"].Value = order.OrderDate;
                    dgvOrders.Rows[row].Cells["CustomerName"].Value = order.CustomerName ?? "Khách lẻ";
                    dgvOrders.Rows[row].Cells["EmployeeName"].Value = order.EmployeeName ?? "";
                    dgvOrders.Rows[row].Cells["TotalAmount"].Value = order.TotalAmount;
                    dgvOrders.Rows[row].Cells["PaymentMethod"].Value = GetPaymentMethodText(order.PaymentMethod);
                    dgvOrders.Rows[row].Cells["PaymentStatus"].Value = GetPaymentStatusText(order.PaymentStatus);
                    dgvOrders.Rows[row].Cells["OrderStatus"].Value = GetOrderStatusText(order.OrderStatus);

                    // Color coding for status
                    SetRowStatusColor(dgvOrders.Rows[row], order.OrderStatus, order.PaymentStatus);
                }

                // Clear order details when orders are refreshed
                dgvOrderDetails.Rows.Clear();
                txtOrderInfo.Text = "";
                selectedOrder = null;

                UpdateButtonStates();
                AddOrderStatusSummary(); // Add this line
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hiển thị danh sách đơn hàng");
            }
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedOrder == null)
                {
                    ExceptionHandler.ShowValidationError("Vui lòng chọn đơn hàng cần in.");
                    return;
                }

                // Show print preview
                using (var printPreview = new PrintPreviewDialog())
                {
                    printPreview.Document = printDocument;
                    printPreview.WindowState = FormWindowState.Maximized;

                    if (printPreview.ShowDialog() == DialogResult.OK)
                    {
                        ExceptionHandler.ShowSuccessMessage("Xem trước hóa đơn hoàn tất!");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi in đơn hàng");
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (selectedOrder == null) return;

            var g = e.Graphics;
            var font = new Font("Arial", 10);
            var boldFont = new Font("Arial", 12, FontStyle.Bold);
            var titleFont = new Font("Arial", 16, FontStyle.Bold);

            float y = 50;
            float lineHeight = font.GetHeight();

            // Company Header
            g.DrawString("PHONE STORE MANAGEMENT", titleFont, Brushes.Black, 270, y);
            y += titleFont.GetHeight() + 10;
            g.DrawString("Địa chỉ: 123 Đường ABC, Quận 1, TP.HCM", font, Brushes.Black, 300, y);
            y += lineHeight;
            g.DrawString("Điện thoại: 028.1234.5678", font, Brushes.Black, 340, y);
            y += lineHeight + 20;

            // Invoice Title
            g.DrawString("HÓA ĐƠN BÁN HÀNG", boldFont, Brushes.Black, 340, y);
            y += boldFont.GetHeight() + 20;

            // Order Info
            g.DrawString($"Mã đơn hàng: {selectedOrder.OrderCode}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"Ngày đặt: {selectedOrder.OrderDate:dd/MM/yyyy HH:mm}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"Khách hàng: {selectedOrder.CustomerName ?? "Khách lẻ"}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"Nhân viên: {selectedOrder.EmployeeName ?? ""}", font, Brushes.Black, 50, y);
            y += lineHeight + 20;

            // Products Header
            g.DrawString("STT", boldFont, Brushes.Black, 70, y);
            g.DrawString("Tên sản phẩm", boldFont, Brushes.Black, 120, y);
            g.DrawString("SL", boldFont, Brushes.Black, 420, y);
            g.DrawString("Đơn giá", boldFont, Brushes.Black, 450, y);
            g.DrawString("Thành tiền", boldFont, Brushes.Black, 600, y);
            y += boldFont.GetHeight() + 5;

            // Draw line
            g.DrawLine(Pens.Black, 70, y, 750, y);
            y += 10;

            // Products
            if (selectedOrder.OrderDetails != null)
            {   
                int stt = 1;
                foreach (var item in selectedOrder.OrderDetails)
                {
                    g.DrawString(stt.ToString(), font, Brushes.Black, 75, y);
                    g.DrawString(item.ProductName ?? item.ProductCode, font, Brushes.Black, 120, y);
                    g.DrawString(item.Quantity.ToString(), font, Brushes.Black, 425, y);
                    g.DrawString(ValidationHelper.FormatCurrency(item.UnitPrice), font, Brushes.Black, 450, y);
                    g.DrawString(ValidationHelper.FormatCurrency(item.TotalPrice), font, Brushes.Black, 600, y);
                    y += lineHeight;
                    stt++;
                }
            }

            y += 20;
            g.DrawLine(Pens.Black, 70, y, 750, y);
            y += 15;

            // Payment Summary
            g.DrawString($"Tạm tính: {ValidationHelper.FormatCurrency(selectedOrder.Subtotal)}", font, Brushes.Black, 550, y);
            y += lineHeight;
            g.DrawString($"Giảm giá: {ValidationHelper.FormatCurrency(selectedOrder.DiscountAmount)}", font, Brushes.Black, 550, y);
            y += lineHeight;
            g.DrawString($"Thuế VAT: {ValidationHelper.FormatCurrency(selectedOrder.TaxAmount)}", font, Brushes.Black, 550, y);
            y += lineHeight;
            g.DrawString($"TỔNG TIỀN: {ValidationHelper.FormatCurrency(selectedOrder.TotalAmount)}", boldFont, Brushes.Black, 550, y);
            y += boldFont.GetHeight() + 20;

            // Payment Info
            g.DrawString($"Phương thức TT: {GetPaymentMethodText(selectedOrder.PaymentMethod)}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"Trạng thái: {GetPaymentStatusText(selectedOrder.PaymentStatus)}", font, Brushes.Black, 50, y);
            y += lineHeight + 30;

            // Footer
            g.DrawString("Cảm ơn quý khách đã mua hàng!", font, Brushes.Black, 310, y);
            y += lineHeight;
            g.DrawString($"In lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", font, Brushes.Black, 330, y);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =====================================================
        // HELPER METHODS
        // =====================================================

        private void UpdateButtonStates()
        {
            bool hasSelection = selectedOrder != null;

            btnViewOrder.Enabled = hasSelection;
            btnUpdateStatus.Enabled = hasSelection && CanUpdateStatus();
            btnPrintOrder.Enabled = hasSelection;
        }

        private bool CanUpdateStatus()
        {
            if (selectedOrder == null) return false;

            // Only allow status update for processing or pending payment orders
            return selectedOrder.OrderStatus == "processing" ||
                   selectedOrder.PaymentStatus == "pending";
        }

        private string GetOrderStatusValue(string displayText)
        {
            switch (displayText)
            {
                case "Đang xử lý": return "processing";
                case "Hoàn thành": return "completed";
                case "Đã hủy": return "cancelled";
                case "Đã trả hàng": return "returned";
                default: return "";
            }
        }

        private string GetPaymentStatusValue(string displayText)
        {
            switch (displayText)
            {
                case "Chưa thanh toán": return "pending";
                case "Đã thanh toán": return "paid";
                case "Thanh toán một phần": return "partial";
                case "Đã hoàn tiền": return "refunded";
                default: return "";
            }
        }

        private string GetEmployeeByName(string displayText)
        {
            if (displayText == "Tất cả nhân viên")
            {
                return "";
            }
            return displayText;
        }

        private string GetOrderStatusText(string status)
        {
            switch (status?.ToLower())
            {
                case "processing": return "Đang xử lý";
                case "completed": return "Hoàn thành";
                case "cancelled": return "Đã hủy";
                case "returned": return "Đã trả hàng";
                default: return status ?? "";
            }
        }

        private string GetPaymentStatusText(string status)
        {
            switch (status?.ToLower())
            {
                case "pending": return "Chưa thanh toán";
                case "paid": return "Đã thanh toán";
                case "partial": return "Thanh toán một phần";
                case "refunded": return "Đã hoàn tiền";
                default: return status ?? "";
            }
        }

        private string GetPaymentMethodText(string method)
        {
            switch (method?.ToLower())
            {
                case "cash": return "Tiền mặt";
                case "card": return "Thẻ tín dụng";
                case "transfer": return "Chuyển khoản";
                case "installment": return "Trả góp";
                default: return method ?? "";
            }
        }

        private void LoadEmployeeList()
        {
            try
            {
                cboEmployee.Items.Clear();

                var employeeService = new EmployeeService();
                var result = employeeService.GetEmployeesForComboBox(includeAll: true);

                if (result.IsSuccess)
                {
                    foreach (var item in result.Data)
                    {
                        cboEmployee.Items.Add(new
                        {
                            Text = item.Text,
                            Value = item.Value,
                            Position = item.Position,
                            Status = item.Status
                        });
                    }

                    cboEmployee.DisplayMember = "Text";
                    cboEmployee.ValueMember = "Value";
                    cboEmployee.SelectedIndex = 0;
                }
                else
                {
                    ExceptionHandler.ShowValidationError(result.Message);

                    // Fallback - add "Tất cả nhân viên" option
                    cboEmployee.Items.Add(new { Text = "Tất cả nhân viên", Value = -1 });
                    cboEmployee.DisplayMember = "Text";
                    cboEmployee.ValueMember = "Value";
                    cboEmployee.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tải danh sách nhân viên", false);

                // Fallback for extreme error cases
                cboEmployee.Items.Clear();
                cboEmployee.Items.Add(new { Text = "Tất cả nhân viên", Value = -1 });
                cboEmployee.DisplayMember = "Text";
                cboEmployee.ValueMember = "Value";
                cboEmployee.SelectedIndex = 0;
            }
        }

    }
}