using PhoneStore.Dao;
using PhoneStore.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhoneStore.Forms
{
    public partial class frmPromotionEdit : Form
    {
        #region Fields
        private PromotionDao promotionDao;
        private Promotion originalPromotion;
        #endregion

        #region Constructor
        public frmPromotionEdit(Promotion promotion)
        {
            InitializeComponent();
            InitializeDao();
            originalPromotion = promotion;
            LoadPromotionData();
        }
        #endregion

        #region Initialization
        private void InitializeDao()
        {
            promotionDao = new PromotionDao();
        }

        private void LoadPromotionData()
        {
            if (originalPromotion == null) return;

            txtPromotionCode.Text = originalPromotion.PromotionCode;
            txtPromotionName.Text = originalPromotion.PromotionName;
            txtDescription.Text = originalPromotion.Description;

            cboDiscountType.SelectedIndex = originalPromotion.DiscountType == "percentage" ? 0 : 1;
            nudDiscountValue.Value = originalPromotion.DiscountValue;

            dtpStartDate.Value = originalPromotion.StartDate;
            dtpEndDate.Value = originalPromotion.EndDate;

            nudMinOrderAmount.Value = originalPromotion.MinOrderAmount;
            nudMaxDiscountAmount.Value = originalPromotion.MaxDiscountAmount;

            if (originalPromotion.UsageLimit == 0)
            {
                chkUnlimitedUsage.Checked = true;
                nudUsageLimit.Value = 0;
                nudUsageLimit.Enabled = false;
            }
            else
            {
                chkUnlimitedUsage.Checked = false;
                nudUsageLimit.Value = originalPromotion.UsageLimit;
                nudUsageLimit.Enabled = true;
            }

            lblUsedCountValue.Text = originalPromotion.UsedCount.ToString();

            cboStatus.SelectedIndex = originalPromotion.Status == "active" ? 0 : 1;

            // Disable promotion code editing (it should be unique and not changed)
            txtPromotionCode.ReadOnly = true;
            txtPromotionCode.BackColor = Color.LightGray;

            UpdateDiscountValueLabel();
        }
        #endregion

        #region Form Events
        private void frmPromotionEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtPromotionName;
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
            else if (nudUsageLimit.Value == 0)
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
                var updatedPromotion = CreatePromotionFromInput();

                if (promotionDao.UpdatePromotion(updatedPromotion))
                {
                    MessageBox.Show("Khuyến mãi đã được cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật khuyến mãi. Vui lòng thử lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật khuyến mãi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
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

            // Validate usage limit (should not be less than already used)
            if (!chkUnlimitedUsage.Checked)
            {
                if (nudUsageLimit.Value <= 0)
                {
                    MessageBox.Show("Giới hạn sử dụng phải lớn hơn 0 hoặc chọn 'Không giới hạn'.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudUsageLimit.Focus();
                    return false;
                }

                if (nudUsageLimit.Value < originalPromotion.UsedCount)
                {
                    MessageBox.Show($"Giới hạn sử dụng không được nhỏ hơn số lần đã sử dụng ({originalPromotion.UsedCount}).",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudUsageLimit.Focus();
                    return false;
                }
            }

            // Validate status selection
            if (cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStatus.Focus();
                return false;
            }

            return true;
        }

        private Promotion CreatePromotionFromInput()
        {
            return new Promotion
            {
                PromotionId = originalPromotion.PromotionId,
                PromotionCode = originalPromotion.PromotionCode, // Keep original code
                PromotionName = txtPromotionName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                DiscountType = cboDiscountType.SelectedIndex == 0 ? "percentage" : "fixed_amount",
                DiscountValue = nudDiscountValue.Value,
                StartDate = dtpStartDate.Value.Date,
                EndDate = dtpEndDate.Value.Date,
                MinOrderAmount = nudMinOrderAmount.Value,
                MaxDiscountAmount = nudMaxDiscountAmount.Value,
                UsageLimit = chkUnlimitedUsage.Checked ? 0 : (int)nudUsageLimit.Value,
                UsedCount = originalPromotion.UsedCount, // Keep original used count
                Status = cboStatus.SelectedIndex == 0 ? "active" : "inactive",
                CreatedAt = originalPromotion.CreatedAt // Keep original creation time
            };
        }
        #endregion
    }
}