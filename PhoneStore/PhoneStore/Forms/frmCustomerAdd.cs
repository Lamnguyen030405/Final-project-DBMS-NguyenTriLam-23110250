using PhoneStore.Dao;
using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStore.Forms
{
    public partial class frmCustomerAdd : Form
    {
        #region Fields
        private CustomerDao customerDao;
        public Customer NewCustomer { get; private set; }
        #endregion

        #region Constructor
        public frmCustomerAdd()
        {
            InitializeComponent();
            customerDao = new CustomerDao();
        }
        #endregion

        #region Form Events
        private void frmCustomerAdd_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCustomer();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Private Methods
        private void InitializeForm()
        {
            // Set default values
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-25);
            cboGender.SelectedIndex = 0; // Default to "Nam"
            rbRegular.Checked = true;

            // Set focus to first input
            txtFullName.Focus();

            // Add event handlers for validation
            txtPhone.Leave += TxtPhone_Leave;
            txtEmail.Leave += TxtEmail_Leave;
        }

        private void TxtPhone_Leave(object sender, EventArgs e)
        {
            ValidatePhoneNumber();
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private bool ValidateForm()
        {
            // Reset error states
            ResetErrorStates();

            bool isValid = true;
            string errorMessage = "";

            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                HighlightError(txtFullName);
                errorMessage += "- Họ và tên là bắt buộc\n";
                isValid = false;
            }
            else if (txtFullName.Text.Trim().Length < 2)
            {
                HighlightError(txtFullName);
                errorMessage += "- Họ và tên phải có ít nhất 2 ký tự\n";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                HighlightError(txtPhone);
                errorMessage += "- Số điện thoại là bắt buộc\n";
                isValid = false;
            }
            else if (!IsValidPhoneNumber(txtPhone.Text))
            {
                HighlightError(txtPhone);
                errorMessage += "- Số điện thoại không hợp lệ (10-11 số, bắt đầu bằng 0)\n";
                isValid = false;
            }

            // Validate email if provided
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                HighlightError(txtEmail);
                errorMessage += "- Email không hợp lệ\n";
                isValid = false;
            }

            // Validate age
            var age = CalculateAge(dtpDateOfBirth.Value);
            if (age < 16 || age > 100)
            {
                HighlightError(dtpDateOfBirth);
                errorMessage += "- Tuổi phải từ 16 đến 100\n";
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show($"Vui lòng kiểm tra lại thông tin:\n\n{errorMessage}",
                    "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private bool ValidatePhoneNumber()
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
                return true; // Will be handled by required field validation

            if (!IsValidPhoneNumber(txtPhone.Text))
            {
                HighlightError(txtPhone);
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10-11 số, bắt đầu bằng 0.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if phone number already exists
            try
            {
                var existingCustomer = customerDao.GetCustomerByPhone(txtPhone.Text.Trim());
                if (existingCustomer != null)
                {
                    HighlightError(txtPhone);
                    MessageBox.Show($"Số điện thoại này đã được sử dụng bởi khách hàng: {existingCustomer.FullName}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra số điện thoại: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ResetErrorState(txtPhone);
            return true;
        }

        private bool ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ResetErrorState(txtEmail);
                return true; // Email is optional
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                HighlightError(txtEmail);
                MessageBox.Show("Email không hợp lệ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            ResetErrorState(txtEmail);
            return true;
        }

        private bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Remove spaces and special characters
            string cleanPhone = Regex.Replace(phone, @"[\s\-\(\)]", "");

            // Vietnamese phone number pattern: starts with 0, 10-11 digits total
            return Regex.IsMatch(cleanPhone, @"^0[0-9]{9,10}$");
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age;
        }

        private void HighlightError(Control control)
        {
            control.BackColor = System.Drawing.Color.FromArgb(255, 235, 235);
            control.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void ResetErrorState(Control control)
        {
            control.BackColor = System.Drawing.SystemColors.Window;
            control.ForeColor = System.Drawing.SystemColors.WindowText;
        }

        private void ResetErrorStates()
        {
            ResetErrorState(txtFullName);
            ResetErrorState(txtPhone);
            ResetErrorState(txtEmail);
            dtpDateOfBirth.BackColor = System.Drawing.SystemColors.Window;
        }

        private void SaveCustomer()
        {
            if (!ValidateForm())
                return;

            try
            {
                // Create customer object
                var customer = new Customer
                {
                    FullName = txtFullName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                    DateOfBirth = dtpDateOfBirth.Value.Date,
                    Gender = GetSelectedGender(),
                    CustomerType = rbVIP.Checked ? "vip" : "regular"
                };

                // Save to database
                bool success = customerDao.InsertCustomer(customer);

                if (success)
                {
                    // Get the saved customer (with generated customer code and ID)
                    NewCustomer = customerDao.GetCustomerByPhone(customer.Phone);

                    MessageBox.Show($"Đã thêm khách hàng thành công!\nMã khách hàng: {NewCustomer?.CustomerCode}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi lưu thông tin khách hàng. Vui lòng thử lại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu khách hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedGender()
        {
            switch (cboGender.SelectedIndex)
            {
                case 0: return "male";
                case 1: return "female";
                case 2: return "other";
                default: return "male";
            }
        }
        #endregion
    }
}
