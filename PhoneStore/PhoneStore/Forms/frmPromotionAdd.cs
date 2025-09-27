using PhoneStore.Dao;
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
    public partial class frmPromotionAdd : Form
    {
        #region Fields
        private PromotionDao promotionDao;
        private PromotionService promotionService;
        public Promotion NewPromotion { get; private set; }
        #endregion

        #region Constructor
        public frmPromotionAdd()
        {
            InitializeComponent();
            InitializeDao();
            InitializeForm();
        }
        #endregion

        #region Initialization
        private void InitializeDao()
        {
            promotionDao = new PromotionDao();
            promotionService = new PromotionService();
        }

        private void InitializeForm()
        {
            // Set default values
            cboDiscountType.SelectedIndex = 0; // Default to percentage
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(30); // Default to 30 days
            nudUsageLimit.Value = 100;

            // Generate default promotion code
            txtPromotionCode.Text = GeneratePromotionCode();

            // Set focus
            this.ActiveControl = txtPromotionCode;
        }

        private string GeneratePromotionCode()
        {
            return "KM" + DateTime.Now.ToString("yyMMddHHmm");
        }
        #endregion

        #region Form Events
        private void frmPromotionAdd_Load(object sender, EventArgs e)
        {
            UpdateDiscountValueLabel();
        }

        private void cboDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDiscountValueLabel();
        }

        private void chkUnlimitedUsage_CheckedChanged(object sender, EventArgs e)
        {
            nudUsageLimit.Enabled = !chkUnlimitedUsage.Checked;
            if (chkUnlimitedUsage.Checked)
            {
                nudUsageLimit.Value = 0;
            }
            else
            {
                nudUsageLimit.Value = 100;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePromotion();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Business Logic
        private void UpdateDiscountValueLabel()
        {
            if (cboDiscountType.SelectedIndex == 0) // Percentage
            {
                lblPercentageSign.Visible = true;
                nudDiscountValue.Maximum = 100;
                nudDiscountValue.DecimalPlaces = 2;
            }
            else // Fixed amount
            {
                lblPercentageSign.Visible = false;
                nudDiscountValue.Maximum = 99999999;
                nudDiscountValue.DecimalPlaces = 0;
            }
        }

        private void SavePromotion()
        {
            if (!ValidateInput())
                return;

            try
            {
                var promotion = CreatePromotionFromInput();

                if (promotionDao.InsertPromotion(promotion))
                {
                    NewPromotion = promotion;
                    MessageBox.Show("Khuyến mãi đã được tạo thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu khuyến mãi. Vui lòng thử lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu khuyến mãi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // Validate promotion code
            if (string.IsNullOrWhiteSpace(txtPromotionCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPromotionCode.Focus();
                return false;
            }

            // Check if promotion code already exists
            try
            {
                var existingPromotion = promotionDao.GetPromotionByCode(txtPromotionCode.Text.Trim());
                if (existingPromotion != null)
                {
                    MessageBox.Show("Mã khuyến mãi đã tồn tại. Vui lòng chọn mã khác.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPromotionCode.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra mã khuyến mãi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate promotion name
            if (string.IsNullOrWhiteSpace(txtPromotionName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khuyến mãi.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPromotionName.Focus();
                return false;
            }

            // Validate discount type selection
            if (cboDiscountType.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại giảm giá.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDiscountType.Focus();
                return false;
            }

            // Validate discount value
            if (nudDiscountValue.Value <= 0)
            {
                MessageBox.Show("Giá trị giảm giá phải lớn hơn 0.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudDiscountValue.Focus();
                return false;
            }

            // Validate percentage discount
            if (cboDiscountType.SelectedIndex == 0 && nudDiscountValue.Value > 100)
            {
                MessageBox.Show("Giảm giá theo phần trăm không được vượt quá 100%.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudDiscountValue.Focus();
                return false;
            }

            // Validate date range
            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return false;
            }

            // Validate start date (should not be in the past)
            if (dtpStartDate.Value.Date < DateTime.Today)
            {
                if (MessageBox.Show("Ngày bắt đầu đã qua. Bạn có muốn tiếp tục?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    dtpStartDate.Focus();
                    return false;
                }
            }

            // Validate minimum order amount
            if (nudMinOrderAmount.Value < 0)
            {
                MessageBox.Show("Giá trị đơn hàng tối thiểu không được âm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMinOrderAmount.Focus();
                return false;
            }

            // Validate max discount amount
            if (nudMaxDiscountAmount.Value < 0)
            {
                MessageBox.Show("Giá trị giảm giá tối đa không được âm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMaxDiscountAmount.Focus();
                return false;
            }

            // Validate usage limit
            if (!chkUnlimitedUsage.Checked && nudUsageLimit.Value <= 0)
            {
                MessageBox.Show("Giới hạn sử dụng phải lớn hơn 0 hoặc chọn 'Không giới hạn'.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudUsageLimit.Focus();
                return false;
            }

            return true;
        }

        private Promotion CreatePromotionFromInput()
        {
            return new Promotion
            {
                PromotionCode = txtPromotionCode.Text.Trim().ToUpper(),
                PromotionName = txtPromotionName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                DiscountType = cboDiscountType.SelectedIndex == 0 ? "percentage" : "fixed_amount",
                DiscountValue = nudDiscountValue.Value,
                StartDate = dtpStartDate.Value.Date,
                EndDate = dtpEndDate.Value.Date,
                MinOrderAmount = nudMinOrderAmount.Value,
                MaxDiscountAmount = nudMaxDiscountAmount.Value,
                UsageLimit = chkUnlimitedUsage.Checked ? 0 : (int)nudUsageLimit.Value,
                UsedCount = 0,
                Status = "active",
                CreatedAt = DateTime.Now
            };
        }

        // Method to populate combo box with existing promotions (if needed for editing)
        private void LoadActivePromotions()
        {
            try
            {
                var promotions = promotionDao.GetActivePromotions();
                // This can be used if you want to show existing promotions for reference
            }
            catch (Exception ex)
            {
                // Handle silently for now
                System.Diagnostics.Debug.WriteLine($"Error loading promotions: {ex.Message}");
            }
        }
        #endregion
    }
}