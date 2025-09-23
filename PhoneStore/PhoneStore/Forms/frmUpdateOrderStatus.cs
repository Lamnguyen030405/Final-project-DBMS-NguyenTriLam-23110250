using PhoneStore.Models;
using PhoneStore.Services;
using PhoneStore.Utils;
using PhoneStoreManagement.Models;
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
    public partial class frmUpdateOrder : Form
    {
        private Order order;
        private OrderService orderService;
        private PaymentService paymentService;
        private decimal originalTotalAmount;
        private bool isFormLoading;

        public frmUpdateOrder(Order orderToUpdate)
        {
            order = orderToUpdate;
            orderService = new OrderService();
            paymentService = new PaymentService();
            var paymentSumary = paymentService.GetPaymentSummary(order.OrderId);
            originalTotalAmount = paymentSumary.Data.RemainingAmount;
            InitializeComponent();
        }

        private void frmUpdateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                isFormLoading = true;
                LoadOrderInfo();
                SetupStatusCombos();
                SetupFormBehavior();
                isFormLoading = false;

                UpdateRemainingAmount();
                ValidateForm();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi khởi tạo form cập nhật đơn hàng");
            }
        }

        private void LoadOrderInfo()
        {
            // Load basic order information
            txtOrderCode.Text = order.OrderCode;
            txtOrderDate.Text = order.OrderDate.ToString("dd/MM/yyyy HH:mm");
            txtCustomerName.Text = order.CustomerName ?? "Khách lẻ";
            txtTotalAmount.Text = ValidationHelper.FormatCurrency(order.TotalAmount);

            // Load current status
            txtCurrentOrderStatus.Text = GetOrderStatusText(order.OrderStatus);
            txtCurrentPaymentStatus.Text = GetPaymentStatusText(order.PaymentStatus);

            // Load payment info
            txtPaymentMethod.Text = GetPaymentMethodText(order.PaymentMethod);

            // Load actual payment summary from PaymentService
            //LoadPaymentSummary();

            // Load notes
            txtNotes.Text = order.Notes ?? "";
        }

        //private void LoadPaymentSummary()
        //{
        //    try
        //    {
        //        var summaryResult = paymentService.GetPaymentSummary(order.OrderId);
        //        if (summaryResult.IsSuccess && summaryResult.Data != null)
        //        {
        //            var summary = summaryResult.Data;
        //            numPaidAmount.Value = summary.TotalPaidAmount;
        //        }
        //        else
        //        {
        //            // Fallback: set based on current payment status
        //            SetPaidAmountBasedOnStatus(order.PaymentStatus);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler.HandleException(ex, "Lỗi tải thông tin thanh toán", false);
        //        SetPaidAmountBasedOnStatus(order.PaymentStatus);
        //    }
        //}

        private void SetPaidAmountBasedOnStatus(string paymentStatus)
        {
            switch (paymentStatus?.ToLower())
            {
                case "paid":
                    numPaidAmount.Value = order.TotalAmount;
                    break;
                case "partial":
                    numPaidAmount.Value = order.TotalAmount * 0.5m; // Example: 50% paid
                    break;
                case "pending":
                case "refunded":
                default:
                    numPaidAmount.Value = 0;
                    break;
            }
        }

        private void SetupStatusCombos()
        {
            // Setup order status combo
            SetComboBoxDisplayMember(cboNewOrderStatus);
            SelectComboBoxItem(cboNewOrderStatus, order.OrderStatus);

            // Setup payment status combo
            SetComboBoxDisplayMember(cboNewPaymentStatus);
            SelectComboBoxItem(cboNewPaymentStatus, order.PaymentStatus);

            // Set default reason
            cboUpdateReason.SelectedIndex = 0;
        }

        private void SetComboBoxDisplayMember(ComboBox combo)
        {
            combo.DisplayMember = "Display";
            combo.ValueMember = "Value";

            if (combo == cboNewOrderStatus)
            {
                combo.DataSource = new[]
                {
                    new { Value = "processing", Display = "Đang xử lý" },
                    new { Value = "completed", Display = "Hoàn thành" },
                    new { Value = "cancelled", Display = "Đã hủy" },
                    new { Value = "returned", Display = "Đã trả hàng" }
                };
            }
            else if (combo == cboNewPaymentStatus)
            {
                combo.DataSource = new[]
                {
                    new { Value = "pending", Display = "Chưa thanh toán" },
                    new { Value = "paid", Display = "Đã thanh toán" },
                    new { Value = "partial", Display = "Thanh toán một phần" },
                    new { Value = "refunded", Display = "Đã hoàn tiền" }
                };
            }
        }

        private void SelectComboBoxItem(ComboBox combo, string value)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                var item = combo.Items[i];
                var valueProperty = item.GetType().GetProperty("Value");
                if (valueProperty != null && valueProperty.GetValue(item).ToString() == value)
                {
                    combo.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SetupFormBehavior()
        {
            // Disable certain controls based on current status
            if (order.OrderStatus == "completed" || order.OrderStatus == "cancelled")
            {
                // Allow changing cancelled orders back to processing if needed
                if (order.OrderStatus == "completed")
                {
                    // Completed orders can only be returned or refunded
                    RemoveComboBoxItems(cboNewOrderStatus, new[] { "processing" });
                }
            }

            if (order.PaymentStatus == "refunded")
            {
                numPaidAmount.Enabled = false;
            }
        }

        private void RemoveComboBoxItems(ComboBox combo, string[] valuesToRemove)
        {
            var currentDataSource = (Array)combo.DataSource;
            var filteredList = new List<object>();

            foreach (var item in currentDataSource)
            {
                var valueProperty = item.GetType().GetProperty("Value");
                var value = valueProperty?.GetValue(item)?.ToString();

                if (!valuesToRemove.Contains(value))
                {
                    filteredList.Add(item);
                }
            }

            combo.DataSource = filteredList.ToArray();
        }

        // =====================================================
        // EVENT HANDLERS
        // =====================================================

        private void cboNewOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoading) return;

            try
            {
                var selectedValue = GetSelectedComboValue(cboNewOrderStatus);

                // Auto-update payment status based on order status
                switch (selectedValue?.ToLower())
                {
                    case "completed":
                        if (GetSelectedComboValue(cboNewPaymentStatus) != "refunded")
                        {
                            SelectComboBoxItem(cboNewPaymentStatus, "paid");
                            numPaidAmount.Value = originalTotalAmount;
                        }
                        break;

                    case "cancelled":
                        if (numPaidAmount.Value > 0)
                        {
                            if (ExceptionHandler.ShowConfirmDialog("Đơn hàng đã hủy và có thanh toán. Bạn có muốn chuyển sang trạng thái 'Đã hoàn tiền'?"))
                            {
                                SelectComboBoxItem(cboNewPaymentStatus, "refunded");
                            }
                        }
                        else
                        {
                            SelectComboBoxItem(cboNewPaymentStatus, "pending");
                        }
                        break;

                    case "returned":
                        SelectComboBoxItem(cboNewPaymentStatus, "refunded");
                        break;

                    case "processing":
                        // Keep current payment status for processing orders
                        break;
                }

                ValidateForm();
                //UpdateRemainingAmount();
                ShowStatusChangeWarning(selectedValue);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi xử lý thay đổi trạng thái đơn hàng");
            }
        }

        private void cboNewPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoading) return;

            try
            {
                var selectedValue = GetSelectedComboValue(cboNewPaymentStatus);

                // Auto-update paid amount based on payment status
                switch (selectedValue?.ToLower())
                {
                    case "paid":
                        numPaidAmount.Value = originalTotalAmount;
                        break;

                    case "pending":
                        numPaidAmount.Value = 0;
                        break;

                    case "partial":
                        if (numPaidAmount.Value == 0 || numPaidAmount.Value == originalTotalAmount)
                        {
                            // Set to 50% as default for partial payment
                            numPaidAmount.Value = originalTotalAmount * 0.5m;
                        }
                        break;

                    case "refunded":
                        // Keep current paid amount for refund calculation
                        break;
                }

                ValidateForm();
                //UpdateRemainingAmount();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi xử lý thay đổi trạng thái thanh toán");
            }
        }

        private void numPaidAmount_ValueChanged(object sender, EventArgs e)
        {
            if (isFormLoading) return;

            try
            {
                // Auto-adjust payment status based on paid amount
                var paidAmount = numPaidAmount.Value;
                var currentPaymentStatus = GetSelectedComboValue(cboNewPaymentStatus);

                if (paidAmount == 0 && currentPaymentStatus != "pending" && currentPaymentStatus != "refunded")
                {
                    SelectComboBoxItem(cboNewPaymentStatus, "pending");
                }
                else if (paidAmount == originalTotalAmount && currentPaymentStatus != "paid" && currentPaymentStatus != "refunded")
                {
                    SelectComboBoxItem(cboNewPaymentStatus, "paid");
                }
                else if (paidAmount > 0 && paidAmount < originalTotalAmount && currentPaymentStatus != "partial" && currentPaymentStatus != "refunded")
                {
                    SelectComboBoxItem(cboNewPaymentStatus, "partial");
                }

                //UpdateRemainingAmount();
                ValidateForm();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi cập nhật số tiền thanh toán");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateBeforeSave())
                    return;

                if (!ExceptionHandler.ShowConfirmDialog("Bạn có chắc chắn muốn cập nhật trạng thái đơn hàng này?"))
                    return;

                var newOrderStatus = GetSelectedComboValue(cboNewOrderStatus);
                var newPaymentStatus = GetSelectedComboValue(cboNewPaymentStatus);
                var updateReason = cboUpdateReason.Text;

                // Use the new combined update method
                var result = orderService.UpdateOrderAndPaymentStatus(
                    order.OrderId,
                    newOrderStatus,
                    newPaymentStatus,
                    updateReason
                );

                if (result.IsSuccess)
                {
                    // Create payment record if payment status changed to paid/partial
                    if (ShouldCreatePaymentRecord(newPaymentStatus))
                    {
                        CreatePaymentRecord(newPaymentStatus);
                    }

                    ExceptionHandler.ShowSuccessMessage(result.Message ?? "Cập nhật trạng thái đơn hàng thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ExceptionHandler.ShowValidationError("Lỗi cập nhật: " + result.Message);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi lưu thay đổi trạng thái");
            }
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement receipt printing
                var receiptInfo = GenerateReceiptInfo();

                MessageBox.Show($"Thông tin hóa đơn:\n\n{receiptInfo}\n\nChức năng in hóa đơn sẽ được cập nhật trong phiên bản tiếp theo.",
                    "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi in hóa đơn");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (HasChanges())
                {
                    if (!ExceptionHandler.ShowConfirmDialog("Bạn có thay đổi chưa được lưu. Bạn có chắc chắn muốn hủy?"))
                        return;
                }

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hủy form");
            }
        }

        // =====================================================
        // HELPER METHODS
        // =====================================================

        private void ShowStatusChangeWarning(string newOrderStatus)
        {
            if (newOrderStatus == "cancelled" && order.OrderStatus != "cancelled")
            {
                MessageBox.Show("Lưu ý: Đơn hàng đã hủy sẽ không thể chuyển về trạng thái khác. " +
                    "Vui lòng kiểm tra kỹ trước khi lưu.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (newOrderStatus == "completed" && order.OrderStatus != "completed")
            {
                MessageBox.Show("Lưu ý: Đơn hàng hoàn thành chỉ có thể chuyển sang trạng thái 'Đã trả hàng'.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ShouldCreatePaymentRecord(string newPaymentStatus)
        {
            // Create payment record if status changed from pending/partial to paid/partial
            // and there's an amount to record
            return (newPaymentStatus == "paid" || newPaymentStatus == "partial") &&
                   (order.PaymentStatus == "pending" || order.PaymentStatus == "partial") &&
                   numPaidAmount.Value > 0;
        }


        private void CreatePaymentRecord(string paymentStatus)
        {
            try
            {
                var paymentRequest = new PhoneStore.Models.PaymentRequest
                {
                    OrderId = order.OrderId,
                    Amount = numPaidAmount.Value,
                    PaymentMethod = order.PaymentMethod,
                    ReferenceNumber = GeneratePaymentReference(),
                    Notes = $"Cập nhật trạng thái thanh toán: {GetPaymentStatusText(paymentStatus)}"
                };

                var result = paymentService.ProcessPayment(paymentRequest);
                if (!result.IsSuccess)
                {
                    // Log error but don't fail the whole operation
                    System.Diagnostics.Debug.WriteLine($"Failed to create payment record: {result.Message}");
                }
            }
            catch (Exception ex)
            {
                // Log error but don't fail the whole operation
                System.Diagnostics.Debug.WriteLine($"Error creating payment record: {ex.Message}");
            }
        }

        private string GeneratePaymentReference()
        {
            var referenceResult = paymentService.GenerateReferenceNumber(order.PaymentMethod);
            return referenceResult.IsSuccess ? referenceResult.Data : $"UPD{DateTime.Now:yyyyMMddHHmmss}";
        }

        private void UpdateRemainingAmount()
        {
            try
            {
                decimal remaining = originalTotalAmount - numPaidAmount.Value;
                txtRemainingAmount.Text = ValidationHelper.FormatCurrency(remaining);

                // Color code the remaining amount
                if (remaining <= 0)
                {
                    txtRemainingAmount.ForeColor = System.Drawing.Color.Green;
                }
                else if (remaining < originalTotalAmount)
                {
                    txtRemainingAmount.ForeColor = System.Drawing.Color.Orange;
                }
                else
                {
                    txtRemainingAmount.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi cập nhật số tiền còn lại", false);
            }
        }

        private void ValidateForm()
        {
            try
            {
                bool isValid = true;
                var errorMessages = new List<string>();

                // Check if paid amount is reasonable
                if (numPaidAmount.Value > originalTotalAmount)
                {
                    errorMessages.Add("Số tiền thanh toán không thể lớn hơn tổng tiền đơn hàng");
                    isValid = false;
                }

                // Check if payment status matches paid amount
                var paymentStatus = GetSelectedComboValue(cboNewPaymentStatus);
                var orderStatus = GetSelectedComboValue(cboNewOrderStatus);

                if (paymentStatus == "paid" && numPaidAmount.Value < originalTotalAmount)
                {
                    errorMessages.Add("Trạng thái 'Đã thanh toán' yêu cầu số tiền thanh toán phải bằng tổng tiền đơn hàng");
                    isValid = false;
                }
                else if (paymentStatus == "pending" && numPaidAmount.Value > 0)
                {
                    errorMessages.Add("Trạng thái 'Chưa thanh toán' yêu cầu số tiền thanh toán phải bằng 0");
                    isValid = false;
                }
                else if (paymentStatus == "partial" && (numPaidAmount.Value <= 0 || numPaidAmount.Value >= originalTotalAmount))
                {
                    errorMessages.Add("Trạng thái 'Thanh toán một phần' yêu cầu số tiền thanh toán lớn hơn 0 và nhỏ hơn tổng tiền");
                    isValid = false;
                }

                // Business logic validation
                if (orderStatus == "completed" && paymentStatus != "paid" && paymentStatus != "refunded")
                {
                    errorMessages.Add("Đơn hàng hoàn thành phải có trạng thái thanh toán 'Đã thanh toán' hoặc 'Đã hoàn tiền'");
                    isValid = false;
                }

                if (orderStatus == "cancelled" && paymentStatus == "paid")
                {
                    errorMessages.Add("Đơn hàng đã hủy không thể có trạng thái 'Đã thanh toán'");
                    isValid = false;
                }

                if (orderStatus == "returned" && paymentStatus != "refunded")
                {
                    errorMessages.Add("Đơn hàng trả hàng phải có trạng thái thanh toán 'Đã hoàn tiền'");
                    isValid = false;
                }

                btnSave.Enabled = isValid;

                // Show validation messages
                if (errorMessages.Any())
                {
                    var combinedMessage = string.Join("\n", errorMessages);
                    // You could show this in a validation label if you have one
                    // lblValidation.Text = combinedMessage;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi validate form", false);
            }
        }

        private bool ValidateBeforeSave()
        {
            // Check if reason is selected
            if (cboUpdateReason.SelectedIndex < 0)
            {
                ExceptionHandler.ShowValidationError("Vui lòng chọn lý do cập nhật.");
                cboUpdateReason.Focus();
                return false;
            }

            // Check payment logic
            var paymentStatus = GetSelectedComboValue(cboNewPaymentStatus);
            var orderStatus = GetSelectedComboValue(cboNewOrderStatus);

            if (paymentStatus == "paid" && numPaidAmount.Value < originalTotalAmount)
            {
                ExceptionHandler.ShowValidationError("Trạng thái 'Đã thanh toán' yêu cầu số tiền thanh toán phải bằng tổng tiền đơn hàng.");
                numPaidAmount.Focus();
                return false;
            }

            if (numPaidAmount.Value > originalTotalAmount)
            {
                ExceptionHandler.ShowValidationError("Số tiền thanh toán không thể lớn hơn tổng tiền đơn hàng.");
                numPaidAmount.Focus();
                return false;
            }

            // Confirm dangerous operations
            if (orderStatus == "cancelled" && order.OrderStatus != "cancelled")
            {
                if (!ExceptionHandler.ShowConfirmDialog("Bạn có chắc chắn muốn hủy đơn hàng này? Thao tác này không thể hoàn tác."))
                    return false;
            }

            if (paymentStatus == "refunded" && order.PaymentStatus != "refunded" && numPaidAmount.Value > 0)
            {
                if (!ExceptionHandler.ShowConfirmDialog($"Bạn có chắc chắn muốn hoàn tiền {ValidationHelper.FormatCurrency(numPaidAmount.Value)}?"))
                    return false;
            }

            return true;
        }

        private bool HasChanges()
        {
            var newOrderStatus = GetSelectedComboValue(cboNewOrderStatus);
            var newPaymentStatus = GetSelectedComboValue(cboNewPaymentStatus);

            return newOrderStatus != order.OrderStatus ||
                   newPaymentStatus != order.PaymentStatus ||
                   txtNotes.Text.Trim() != (order.Notes ?? "").Trim();
        }

        private string GetSelectedComboValue(ComboBox combo)
        {
            var selectedItem = combo.SelectedItem;
            if (selectedItem == null) return "";

            var valueProperty = selectedItem.GetType().GetProperty("Value");
            return valueProperty?.GetValue(selectedItem)?.ToString() ?? "";
        }

        private string GenerateReceiptInfo()
        {
            return $@"HÓA ĐƠN BÁN HÀNG
Mã đơn hàng: {order.OrderCode}
Ngày: {order.OrderDate:dd/MM/yyyy HH:mm}
Khách hàng: {order.CustomerName ?? "Khách lẻ"}

Tổng tiền: {ValidationHelper.FormatCurrency(originalTotalAmount)}
Đã thanh toán: {ValidationHelper.FormatCurrency(numPaidAmount.Value)}
Còn lại: {ValidationHelper.FormatCurrency(originalTotalAmount - numPaidAmount.Value)}

Trạng thái đơn hàng: {GetSelectedComboDisplayText(cboNewOrderStatus)}
Trạng thái thanh toán: {GetSelectedComboDisplayText(cboNewPaymentStatus)}

Nhân viên: {SessionManager.GetUserDisplayName()}
Thời gian in: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private string GetSelectedComboDisplayText(ComboBox combo)
        {
            var selectedItem = combo.SelectedItem;
            if (selectedItem == null) return "";

            var displayProperty = selectedItem.GetType().GetProperty("Display");
            return displayProperty?.GetValue(selectedItem)?.ToString() ?? "";
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
    }
}