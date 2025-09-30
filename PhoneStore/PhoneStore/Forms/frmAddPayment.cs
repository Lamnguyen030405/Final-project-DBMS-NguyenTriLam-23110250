using PhoneStore.Models;
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
    public partial class frmAddPayment : Form
    {
        private PaymentService paymentService;
        private PaymentRequest paymentRequest;
        private PaymentSummary paymentSummary;
        private bool isProcessing = false;

        public frmAddPayment(PaymentRequest request)
        {
            InitializeComponent();
            paymentService = new PaymentService();
            paymentRequest = request;

            InitializeForm();
            LoadPaymentSummary();
            //LoadPaymentForEdit(paymentId);
        }

        private void InitializeForm()
        {
            try
            {
                // Setup payment method dropdown
                cboPaymentMethod.Items.Clear();
                cboPaymentMethod.Items.Add(new ComboBoxItem("cash", "Tiền mặt"));
                cboPaymentMethod.Items.Add(new ComboBoxItem("card", "Thẻ tín dụng"));
                cboPaymentMethod.Items.Add(new ComboBoxItem("transfer", "Chuyển khoản"));
                cboPaymentMethod.Items.Add(new ComboBoxItem("installment", "Trả góp"));

                // Set default payment method
                if (!string.IsNullOrEmpty(paymentRequest.PaymentMethod))
                {
                    SelectPaymentMethod(paymentRequest.PaymentMethod);
                }
                else
                {
                    cboPaymentMethod.SelectedIndex = 0;
                }

                // Setup numeric input
                numAmount.DecimalPlaces = 0;
                numAmount.Maximum = 999999999;
                numAmount.Minimum = 0;
                numAmount.Value = paymentRequest.Amount;
                numAmount.ThousandsSeparator = true;

                // Setup date picker
                dtpPaymentDate.Value = DateTime.Now;
                dtpPaymentDate.MaxDate = DateTime.Now;

                // Event handlers
                cboPaymentMethod.SelectedIndexChanged += CboPaymentMethod_SelectedIndexChanged;
                numAmount.ValueChanged += NumAmount_ValueChanged;
                btnGenerateReference.Click += BtnGenerateReference_Click;
                btnPayFull.Click += BtnPayFull_Click;
                btnProcess.Click += BtnProcess_Click;
                btnCancel.Click += BtnCancel_Click;

                // Initial state
                UpdateReferenceNumberState();
                UpdatePaymentInfo();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi khởi tạo form thanh toán");
            }
        }

        private void LoadPaymentSummary()
        {
            try
            {
                var summaryResult = paymentService.GetPaymentSummary(paymentRequest.OrderId);
                if (summaryResult.IsSuccess)
                {
                    paymentSummary = summaryResult.Data;
                    DisplayPaymentSummary();
                }
                else
                {
                    ExceptionHandler.ShowValidationError($"Không thể tải thông tin thanh toán: {summaryResult.Message}");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tải thông tin thanh toán");
                this.Close();
            }
        }

        private void LoadPaymentForEdit(int paymentId)
        {

        }

        private void DisplayPaymentSummary()
        {
            try
            {
                if (paymentSummary == null) return;

                lblOrderCode.Text = paymentSummary.OrderCode;
                lblTotalAmount.Text = ValidationHelper.FormatCurrency(paymentSummary.TotalOrderAmount);
                lblPaidAmount.Text = ValidationHelper.FormatCurrency(paymentSummary.TotalPaidAmount);
                lblRemainingAmount.Text = ValidationHelper.FormatCurrency(paymentSummary.RemainingAmount);

                // Set remaining amount color
                if (paymentSummary.RemainingAmount > 0)
                {
                    lblRemainingAmount.ForeColor = Color.Red;
                    lblRemainingAmount.Font = new Font(lblRemainingAmount.Font, FontStyle.Bold);
                }

                // Update payment count
                lblPaymentCount.Text = $"Đã có {paymentSummary.PaymentCount} giao dịch";

                // Set maximum payment amount
                numAmount.Maximum = paymentSummary.RemainingAmount;
                if (numAmount.Value > paymentSummary.RemainingAmount)
                {
                    numAmount.Value = paymentSummary.RemainingAmount;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi hiển thị thông tin thanh toán", false);
            }
        }

        private void SelectPaymentMethod(string method)
        {
            try
            {
                for (int i = 0; i < cboPaymentMethod.Items.Count; i++)
                {
                    var item = cboPaymentMethod.Items[i] as ComboBoxItem;
                    if (item != null && item.Value.Equals(method, StringComparison.OrdinalIgnoreCase))
                    {
                        cboPaymentMethod.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi chọn phương thức thanh toán", false);
            }
        }

        private void UpdateReferenceNumberState()
        {
            try
            {
                var selectedItem = cboPaymentMethod.SelectedItem as ComboBoxItem;
                if (selectedItem == null) return;

                bool isCash = selectedItem.Value.Equals("cash", StringComparison.OrdinalIgnoreCase);

                txtReferenceNumber.Enabled = !isCash;
                btnGenerateReference.Enabled = !isCash;

                if (isCash)
                {
                    txtReferenceNumber.Text = "";
                    lblReferenceRequired.Visible = false;
                }
                else
                {
                    lblReferenceRequired.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi cập nhật trạng thái mã tham chiếu", false);
            }
        }

        private void UpdatePaymentInfo()
        {
            try
            {
                if (paymentSummary == null) return;

                decimal amount = numAmount.Value;
                decimal remaining = paymentSummary.RemainingAmount - amount;

                lblAmountInfo.Text = $"Số tiền: {ValidationHelper.FormatCurrency(amount)}";
                lblAfterPayment.Text = $"Còn lại sau thanh toán: {ValidationHelper.FormatCurrency(remaining)}";

                if (remaining <= 0)
                {
                    lblAfterPayment.ForeColor = Color.Green;
                    lblAfterPayment.Font = new Font(lblAfterPayment.Font, FontStyle.Bold);
                }
                else
                {
                    lblAfterPayment.ForeColor = Color.Orange;
                    lblAfterPayment.Font = new Font(lblAfterPayment.Font, FontStyle.Regular);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi cập nhật thông tin thanh toán", false);
            }
        }

        private bool ValidateInput()
        {
            try
            {
                // Validate amount
                if (numAmount.Value <= 0)
                {
                    ExceptionHandler.ShowValidationError("Vui lòng nhập số tiền thanh toán.");
                    numAmount.Focus();
                    return false;
                }

                if (numAmount.Value > paymentSummary.RemainingAmount)
                {
                    ExceptionHandler.ShowValidationError($"Số tiền thanh toán không được vượt quá số tiền còn lại ({ValidationHelper.FormatCurrency(paymentSummary.RemainingAmount)}).");
                    numAmount.Focus();
                    return false;
                }

                // Validate payment method
                var selectedItem = cboPaymentMethod.SelectedItem as ComboBoxItem;
                if (selectedItem == null)
                {
                    ExceptionHandler.ShowValidationError("Vui lòng chọn phương thức thanh toán.");
                    cboPaymentMethod.Focus();
                    return false;
                }

                // Validate reference number for non-cash payments
                if (!selectedItem.Value.Equals("cash", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrWhiteSpace(txtReferenceNumber.Text))
                    {
                        ExceptionHandler.ShowValidationError("Vui lòng nhập mã tham chiếu cho phương thức thanh toán này.");
                        txtReferenceNumber.Focus();
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi kiểm tra dữ liệu", false);
                return false;
            }
        }

        private void ProcessPayment()
        {
            try
            {
                if (isProcessing) return;

                if (!ValidateInput()) return;

                // Confirm payment
                var selectedItem = cboPaymentMethod.SelectedItem as ComboBoxItem;
                var confirmMsg = $"Xác nhận thanh toán?\n\n" +
                                $"Số tiền: {ValidationHelper.FormatCurrency(numAmount.Value)}\n" +
                                $"Phương thức: {selectedItem.Text}\n" +
                                $"Mã tham chiếu: {txtReferenceNumber.Text}";

                if (MessageBox.Show(confirmMsg, "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                isProcessing = true;
                btnProcess.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Create payment request
                var request = new PaymentRequest
                {
                    OrderId = paymentRequest.OrderId,
                    Amount = numAmount.Value,
                    PaymentMethod = selectedItem.Value,
                    ReferenceNumber = txtReferenceNumber.Text.Trim(),
                    Notes = txtNotes.Text.Trim()
                };

                // Process payment
                var result = paymentService.ProcessPayment(request);

                if (result.IsSuccess)
                {
                    ExceptionHandler.ShowSuccessMessage(result.Message);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ExceptionHandler.ShowValidationError(result.Message);
                    isProcessing = false;
                    btnProcess.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi xử lý thanh toán");
                isProcessing = false;
                btnProcess.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GenerateReferenceNumber()
        {
            try
            {
                var selectedItem = cboPaymentMethod.SelectedItem as ComboBoxItem;
                if (selectedItem == null) return;

                var result = paymentService.GenerateReferenceNumber(selectedItem.Value);
                if (result.IsSuccess)
                {
                    txtReferenceNumber.Text = result.Data;
                }
                else
                {
                    ExceptionHandler.ShowValidationError($"Không thể tạo mã tham chiếu: {result.Message}");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tạo mã tham chiếu");
            }
        }

        // =====================================================
        // EVENT HANDLERS
        // =====================================================

        private void CboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateReferenceNumberState();
        }

        private void NumAmount_ValueChanged(object sender, EventArgs e)
        {
            UpdatePaymentInfo();
        }

        private void BtnGenerateReference_Click(object sender, EventArgs e)
        {
            GenerateReferenceNumber();
        }

        private void BtnPayFull_Click(object sender, EventArgs e)
        {
            try
            {
                if (paymentSummary != null)
                {
                    numAmount.Value = paymentSummary.RemainingAmount;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi thiết lập thanh toán đủ");
            }
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            ProcessPayment();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    // Helper class for ComboBox items
    public class ComboBoxItem
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public ComboBoxItem(string value, string text)
        {
            Value = value;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}