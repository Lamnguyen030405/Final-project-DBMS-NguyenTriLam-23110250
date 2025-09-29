using PhoneStore.Models;
using PhoneStore.Services;
using PhoneStore.Utils;
using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStore.Forms
{
    public partial class frmOrderDetail : Form
    {
        private Order order;
        private OrderService orderService;
        private PaymentService paymentService;
        private CustomerService customerService;
        private List<Payment> orderPayments;
        private PaymentSummary paymentSummary;
        private PrintDocument printDocument;

        public frmOrderDetail(Order orderData)
        {
            InitializeComponent();

            order = orderData;
            orderService = new OrderService();
            paymentService = new PaymentService();
            customerService = new CustomerService();
            orderPayments = new List<Payment>();

            LoadOrderData(order.OrderId);
            InitializePrint();
        }

        private void InitializePrint()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void LoadOrderData(int orderId)
        {
            try
            {
                // Load order details
                var orderResult = orderService.GetOrderById(orderId);
                if (orderResult.IsSuccess)
                {
                    order = orderResult.Data;
                    LoadOrderInfo();
                    LoadOrderItems();
                    LoadCustomerInfo();
                    LoadPaymentHistory();
                    LoadPaymentSummary();
                    SetupFormBehavior();
                }
                else
                {
                    ExceptionHandler.ShowValidationError($"Không thể tải thông tin đơn hàng: {orderResult.Message}");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tải dữ liệu đơn hàng");
                this.Close();
            }
        }

        private void LoadOrderInfo()
        {
            try
            {
                if (order == null) return;

                // Basic order information
                txtOrderCode.Text = order.OrderCode;
                txtOrderDate.Text = order.OrderDate.ToString("dd/MM/yyyy HH:mm");
                txtEmployeeName.Text = order.EmployeeName ?? "";
                txtOrderStatus.Text = GetOrderStatusText(order.OrderStatus);
                txtPaymentStatus.Text = GetPaymentStatusText(order.PaymentStatus);
                txtPaymentMethod.Text = GetPaymentMethodText(order.PaymentMethod);

                // Set status colors
                SetStatusColors();

                // Financial summary
                txtSubtotal.Text = ValidationHelper.FormatCurrency(order.Subtotal);
                txtDiscountAmount.Text = ValidationHelper.FormatCurrency(order.DiscountAmount);
                txtTaxAmount.Text = ValidationHelper.FormatCurrency(order.TaxAmount);
                txtTotalAmount.Text = ValidationHelper.FormatCurrency(order.TotalAmount);

                // Notes
                txtNotes.Text = order.Notes ?? "";

                // Timestamps
                txtCreatedAt.Text = order.CreatedAt.ToString("dd/MM/yyyy HH:mm");

                // Update form title
                this.Text = $"Chi tiết đơn hàng - {order.OrderCode}";
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hiển thị thông tin đơn hàng", false);
            }
        }

        private void LoadOrderItems()
        {
            try
            {
                dgvOrderItems.Rows.Clear();

                if (order.OrderDetails == null || order.OrderDetails.Count == 0)
                {
                    return;
                }

                foreach (var item in order.OrderDetails)
                {
                    var row = dgvOrderItems.Rows.Add();

                    dgvOrderItems.Rows[row].Cells["colProductCode"].Value = item.ProductCode;
                    dgvOrderItems.Rows[row].Cells["colProductName"].Value = item.ProductName;
                    dgvOrderItems.Rows[row].Cells["colQuantity"].Value = item.Quantity;
                    dgvOrderItems.Rows[row].Cells["colUnitPrice"].Value = item.UnitPrice;
                    dgvOrderItems.Rows[row].Cells["colDiscountPerItem"].Value = item.DiscountPerItem;
                    dgvOrderItems.Rows[row].Cells["colTotalPrice"].Value = item.TotalPrice;
                    dgvOrderItems.Rows[row].Cells["colWarrantyEnd"].Value = item.WarrantyEndDate?.ToString("dd/MM/yyyy") ?? "";
                }

                // Update summary
                lblItemCount.Text = $"Tổng số sản phẩm: {order.OrderDetails.Sum(x => x.Quantity)}";
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hiển thị danh sách sản phẩm", false);
            }
        }

        private void LoadCustomerInfo()
        {
            try
            {
                if (order.CustomerId <= 0)
                {
                    // Guest customer
                    txtCustomerName.Text = order.CustomerName ?? "Khách lẻ";
                    txtCustomerPhone.Text = "";
                    txtCustomerEmail.Text = "";
                    txtCustomerAddress.Text = "";
                    txtCustomerType.Text = "Khách lẻ";
                    txtTotalSpent.Text = ValidationHelper.FormatCurrency(0);
                    btnViewCustomerHistory.Enabled = false;
                    return;
                }

                // Load customer details from service
                var customerResult = customerService.GetAllCustomers();
                if (customerResult.IsSuccess)
                {
                    var customer = customerResult.Data.FirstOrDefault(c => c.CustomerId == order.CustomerId);
                    if (customer != null)
                    {
                        txtCustomerName.Text = customer.FullName;
                        txtCustomerPhone.Text = customer.Phone ?? "";
                        txtCustomerEmail.Text = customer.Email ?? "";
                        txtCustomerAddress.Text = customer.Address ?? "";
                        txtCustomerType.Text = GetCustomerTypeText(customer.CustomerType);
                        txtTotalSpent.Text = ValidationHelper.FormatCurrency(customer.TotalSpent);
                        btnViewCustomerHistory.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tải thông tin khách hàng", false);
            }
        }

        private void LoadPaymentHistory()
        {
            try
            {
                var paymentsResult = paymentService.GetPaymentsByOrderId(order.OrderId);
                if (paymentsResult.IsSuccess)
                {
                    orderPayments = paymentsResult.Data ?? new List<Payment>();
                    DisplayPaymentHistory();
                }
                else
                {
                    orderPayments = new List<Payment>();
                    dgvPaymentHistory.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tải lịch sử thanh toán", false);
                orderPayments = new List<Payment>();
            }
        }

        private void DisplayPaymentHistory()
        {
            try
            {
                dgvPaymentHistory.Rows.Clear();

                if (orderPayments == null || orderPayments.Count == 0)
                {
                    lblPaymentCount.Text = "Chưa có thanh toán nào";
                    return;
                }

                foreach (var payment in orderPayments.OrderByDescending(p => p.PaymentDate))
                {
                    var row = dgvPaymentHistory.Rows.Add();

                    dgvPaymentHistory.Rows[row].Cells["colPaymentDate"].Value = payment.PaymentDate;
                    dgvPaymentHistory.Rows[row].Cells["colPaymentMethod"].Value = GetPaymentMethodText(payment.PaymentMethod);
                    dgvPaymentHistory.Rows[row].Cells["colAmount"].Value = payment.Amount;
                    dgvPaymentHistory.Rows[row].Cells["colReferenceNumber"].Value = payment.ReferenceNumber ?? "";
                    dgvPaymentHistory.Rows[row].Cells["colPaymentStatus"].Value = GetPaymentStatusText(payment.Status);
                    dgvPaymentHistory.Rows[row].Cells["colPaymentNotes"].Value = payment.Notes ?? "";

                    // Color code payment status
                    SetPaymentRowColor(dgvPaymentHistory.Rows[row], payment.Status);
                }

                lblPaymentCount.Text = $"Tổng số giao dịch: {orderPayments.Count}";
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hiển thị lịch sử thanh toán", false);
            }
        }

        private void LoadPaymentSummary()
        {
            try
            {
                var summaryResult = paymentService.GetPaymentSummary(order.OrderId);
                if (summaryResult.IsSuccess)
                {
                    paymentSummary = summaryResult.Data;
                    DisplayPaymentSummary();
                }
                else
                {
                    // Create default summary
                    paymentSummary = new PaymentSummary
                    {
                        OrderId = order.OrderId,
                        TotalOrderAmount = order.TotalAmount,
                        TotalPaidAmount = 0,
                        RemainingAmount = order.TotalAmount
                    };
                    DisplayPaymentSummary();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tải tóm tắt thanh toán", false);
            }
        }

        private void DisplayPaymentSummary()
        {
            try
            {
                if (paymentSummary == null) return;

                txtTotalPaid.Text = ValidationHelper.FormatCurrency(paymentSummary.TotalPaidAmount);
                txtRemainingAmount.Text = ValidationHelper.FormatCurrency(paymentSummary.RemainingAmount);
                txtLastPaymentDate.Text = paymentSummary.LastPaymentDate?.ToString("dd/MM/yyyy HH:mm") ?? "Chưa có";

                // Color code remaining amount
                if (paymentSummary.RemainingAmount <= 0)
                {
                    txtRemainingAmount.ForeColor = Color.Green;
                    txtRemainingAmount.Font = new Font(txtRemainingAmount.Font, FontStyle.Bold);
                }
                else if (paymentSummary.RemainingAmount < paymentSummary.TotalOrderAmount)
                {
                    txtRemainingAmount.ForeColor = Color.Orange;
                }
                else
                {
                    txtRemainingAmount.ForeColor = Color.Red;
                }

                // Update progress bar
                var paidPercentage = paymentSummary.TotalOrderAmount > 0
                    ? (int)((paymentSummary.TotalPaidAmount / paymentSummary.TotalOrderAmount) * 100)
                    : 0;
                progressPayment.Value = Math.Min(100, Math.Max(0, paidPercentage));
                lblPaymentProgress.Text = $"{paidPercentage}% đã thanh toán";
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hiển thị tóm tắt thanh toán", false);
            }
        }

        private void SetupFormBehavior()
        {
            try
            {
                // Enable/disable action buttons based on order status
                btnUpdateStatus.Enabled = CanUpdateOrder();
                btnAddPayment.Enabled = CanAddPayment();
                btnPrintInvoice.Enabled = true;

                // Setup tab behavior
                tabOrderDetail.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi thiết lập form", false);
            }
        }

        // =====================================================
        // EVENT HANDLERS
        // =====================================================

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (order == null || !CanUpdateOrder())
                {
                    ExceptionHandler.ShowValidationError("Không thể cập nhật trạng thái đơn hàng này.");
                    return;
                }

                using (var form = new frmUpdateOrder(order))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Reload order data
                        LoadOrderData(order.OrderId);
                        ExceptionHandler.ShowSuccessMessage("Cập nhật trạng thái thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi cập nhật trạng thái đơn hàng");
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (order == null || !CanAddPayment())
                {
                    ExceptionHandler.ShowValidationError("Không thể thêm thanh toán cho đơn hàng này.");
                    return;
                }

                // TODO: Open payment form
                var paymentRequest = new PaymentRequest
                {
                    OrderId = order.OrderId,
                    PaymentMethod = order.PaymentMethod,
                    Amount = paymentSummary?.RemainingAmount ?? 0
                };

                using (var form = new frmAddPayment(paymentRequest))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Reload payment data
                        LoadPaymentHistory();
                        LoadPaymentSummary();
                        ExceptionHandler.ShowSuccessMessage("Thêm thanh toán thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi thêm thanh toán");
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (order == null)
                {
                    ExceptionHandler.ShowValidationError("Không có thông tin đơn hàng để in.");
                    return;
                }

                using (var printDialog = new PrintDialog())
                {
                    printDialog.Document = printDocument;

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.Print();
                        ExceptionHandler.ShowSuccessMessage("In hóa đơn thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi in hóa đơn");
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (var printPreview = new PrintPreviewDialog())
                {
                    printPreview.Document = printDocument;
                    printPreview.WindowState = FormWindowState.Maximized;
                    printPreview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi xem trước in");
            }
        }

        private void btnViewCustomerHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (order.CustomerId <= 0)
                {
                    ExceptionHandler.ShowValidationError("Khách lẻ không có lịch sử mua hàng.");
                    return;
                }

                // TODO: Open customer history form
                MessageBox.Show($"Lịch sử mua hàng của khách hàng: {order.CustomerName}\n\nForm lịch sử khách hàng sẽ được cập nhật trong phiên bản tiếp theo.",
                    "Lịch sử khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi xem lịch sử khách hàng");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadOrderData(order.OrderId);
                ExceptionHandler.ShowSuccessMessage("Làm mới dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi làm mới dữ liệu");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPaymentHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= orderPayments.Count) return;

                var payment = orderPayments.OrderByDescending(p => p.PaymentDate).ToList()[e.RowIndex];
                ShowPaymentDetail(payment);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi xem chi tiết thanh toán");
            }
        }

        // =====================================================
        // PRINT HANDLERS
        // =====================================================

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                if (order == null) return;

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
                g.DrawString("HÓA ĐƠN CHI TIẾT", boldFont, Brushes.Black, 330, y);
                y += boldFont.GetHeight() + 20;

                // Order Info
                g.DrawString($"Mã đơn hàng: {order.OrderCode}", font, Brushes.Black, 50, y);
                g.DrawString($"Ngày đặt: {order.OrderDate:dd/MM/yyyy HH:mm}", font, Brushes.Black, 400, y);
                y += lineHeight;
                g.DrawString($"Khách hàng: {order.CustomerName ?? "Khách lẻ"}", font, Brushes.Black, 50, y);
                g.DrawString($"Nhân viên: {order.EmployeeName ?? ""}", font, Brushes.Black, 400, y);
                y += lineHeight;
                g.DrawString($"Trạng thái: {GetOrderStatusText(order.OrderStatus)}", font, Brushes.Black, 50, y);
                g.DrawString($"Thanh toán: {GetPaymentStatusText(order.PaymentStatus)}", font, Brushes.Black, 400, y);
                y += lineHeight + 20;

                // Products Header
                g.DrawString("STT", boldFont, Brushes.Black, 50, y);
                g.DrawString("Tên sản phẩm", boldFont, Brushes.Black, 100, y);
                g.DrawString("SL", boldFont, Brushes.Black, 400, y);
                g.DrawString("Đơn giá", boldFont, Brushes.Black, 430, y);
                g.DrawString("Giảm giá", boldFont, Brushes.Black, 520, y);
                g.DrawString("Thành tiền", boldFont, Brushes.Black, 600, y);
                y += boldFont.GetHeight() + 5;

                // Draw line
                g.DrawLine(Pens.Black, 50, y, 750, y);
                y += 10;

                // Products
                if (order.OrderDetails != null)
                {
                    int stt = 1;
                    foreach (var item in order.OrderDetails)
                    {
                        g.DrawString(stt.ToString(), font, Brushes.Black, 55, y);
                        g.DrawString(item.ProductName ?? item.ProductCode, font, Brushes.Black, 100, y);
                        g.DrawString(item.Quantity.ToString(), font, Brushes.Black, 405, y);
                        g.DrawString(ValidationHelper.FormatCurrency(item.UnitPrice), font, Brushes.Black, 430, y);
                        g.DrawString(ValidationHelper.FormatCurrency(item.DiscountPerItem), font, Brushes.Black, 520, y);
                        g.DrawString(ValidationHelper.FormatCurrency(item.TotalPrice), font, Brushes.Black, 600, y);
                        y += lineHeight;
                        stt++;
                    }
                }

                y += 20;
                g.DrawLine(Pens.Black, 50, y, 750, y);
                y += 15;

                // Financial Summary
                g.DrawString($"Tạm tính: {ValidationHelper.FormatCurrency(order.Subtotal)}", font, Brushes.Black, 550, y);
                y += lineHeight;
                g.DrawString($"Giảm giá: {ValidationHelper.FormatCurrency(order.DiscountAmount)}", font, Brushes.Black, 550, y);
                y += lineHeight;
                g.DrawString($"Thuế VAT: {ValidationHelper.FormatCurrency(order.TaxAmount)}", font, Brushes.Black, 550, y);
                y += lineHeight;
                g.DrawString($"TỔNG TIỀN: {ValidationHelper.FormatCurrency(order.TotalAmount)}", boldFont, Brushes.Black, 550, y);
                y += boldFont.GetHeight() + 20;

                // Payment Summary
                if (paymentSummary != null)
                {
                    g.DrawString($"Đã thanh toán: {ValidationHelper.FormatCurrency(paymentSummary.TotalPaidAmount)}", font, Brushes.Black, 50, y);
                    y += lineHeight;
                    g.DrawString($"Còn lại: {ValidationHelper.FormatCurrency(paymentSummary.RemainingAmount)}", font, Brushes.Black, 50, y);
                    y += lineHeight + 20;
                }

                // Payment History
                if (orderPayments != null && orderPayments.Count > 0)
                {
                    g.DrawString("LỊCH SỬ THANH TOÁN:", boldFont, Brushes.Black, 50, y);
                    y += boldFont.GetHeight() + 10;

                    foreach (var payment in orderPayments.OrderBy(p => p.PaymentDate))
                    {
                        g.DrawString($"- {payment.PaymentDate:dd/MM/yyyy HH:mm}: {ValidationHelper.FormatCurrency(payment.Amount)} ({GetPaymentMethodText(payment.PaymentMethod)})", font, Brushes.Black, 70, y);
                        y += lineHeight;
                    }
                    y += 10;
                }

                // Footer
                g.DrawString("Cảm ơn quý khách đã mua hàng!", font, Brushes.Black, 310, y);
                y += lineHeight;
                g.DrawString($"In lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", font, Brushes.Black, 330, y);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi in hóa đơn", false);
            }
        }

        // =====================================================
        // HELPER METHODS
        // =====================================================

        private void ShowPaymentDetail(Payment payment)
        {
            try
            {
                var detail = $@"CHI TIẾT GIAO DỊCH THANH TOÁN

Ngày thanh toán: {payment.PaymentDate:dd/MM/yyyy HH:mm}
Phương thức: {GetPaymentMethodText(payment.PaymentMethod)}
Số tiền: {ValidationHelper.FormatCurrency(payment.Amount)}
Mã tham chiếu: {payment.ReferenceNumber ?? "Không có"}
Trạng thái: {GetPaymentStatusText(payment.Status)}
Ghi chú: {payment.Notes ?? "Không có"}

Ngày tạo: {payment.CreatedAt:dd/MM/yyyy HH:mm}";

                MessageBox.Show(detail, "Chi tiết thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hiển thị chi tiết thanh toán", false);
            }
        }

        private void SetStatusColors()
        {
            try
            {
                // Order status color
                switch (order.OrderStatus?.ToLower())
                {
                    case "completed":
                        txtOrderStatus.ForeColor = Color.Green;
                        break;
                    case "cancelled":
                        txtOrderStatus.ForeColor = Color.Red;
                        break;
                    case "returned":
                        txtOrderStatus.ForeColor = Color.Blue;
                        break;
                    default: // processing
                        txtOrderStatus.ForeColor = Color.Orange;
                        break;
                }

                // Payment status color
                switch (order.PaymentStatus?.ToLower())
                {
                    case "paid":
                        txtPaymentStatus.ForeColor = Color.Green;
                        break;
                    case "pending":
                        txtPaymentStatus.ForeColor = Color.Red;
                        break;
                    case "partial":
                        txtPaymentStatus.ForeColor = Color.Orange;
                        break;
                    case "refunded":
                        txtPaymentStatus.ForeColor = Color.Blue;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi đặt màu trạng thái", false);
            }
        }

        private void SetPaymentRowColor(DataGridViewRow row, string status)
        {
            try
            {
                switch (status?.ToLower())
                {
                    case "successful":
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "failed":
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                    case "pending":
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi đặt màu hàng thanh toán", false);
            }
        }

        private bool CanUpdateOrder()
        {
            if (order == null) return false;

            // Cannot update completed or returned orders
            if (order.OrderStatus == "completed" || order.OrderStatus == "returned") return false;

            // Can update cancelled orders only if manager
            if (order.OrderStatus == "cancelled" && !SessionManager.IsManager) return false;

            return SessionManager.IsManager || SessionManager.IsCashier;
        }

        private bool CanAddPayment()
        {
            if (order == null || paymentSummary == null) return false;

            // Cannot add payment to cancelled orders
            if (order.OrderStatus == "cancelled") return false;

            // Cannot add payment if fully paid
            if (paymentSummary.RemainingAmount <= 0) return false;

            return SessionManager.IsManager || SessionManager.IsCashier;
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
                case "successful": return "Thành công";
                case "failed": return "Thất bại";
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

        private string GetCustomerTypeText(string type)
        {
            switch (type?.ToLower())
            {
                case "vip": return "VIP";
                case "regular": return "Thường";
                case "premium": return "Cao cấp";
                default: return type ?? "Thường";
            }
        }
    }
}