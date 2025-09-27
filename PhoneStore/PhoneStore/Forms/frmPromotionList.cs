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
    public partial class frmPromotionList : Form
    {
        #region Fields
        private PromotionDao promotionDao;
        private PromotionService promotionService;
        private List<Promotion> allPromotions;
        private List<Promotion> filteredPromotions;
        private Promotion selectedPromotion;
        #endregion

        #region Constructor
        public frmPromotionList()
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
            cboStatus.SelectedIndex = 0; // Default to "Tất cả"
            SetupDataGridView();
            UpdateButtonStates();
        }

        private void SetupDataGridView()
        {
            dgvPromotions.AutoGenerateColumns = false;
            dgvPromotions.Columns.Clear();

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PromotionCode",
                HeaderText = "Mã khuyến mãi",
                Name = "PromotionCode",
                Width = 120,
                ReadOnly = true
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PromotionName",
                HeaderText = "Tên khuyến mãi",
                Name = "PromotionName",
                Width = 200,
                ReadOnly = true
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DiscountType",
                HeaderText = "Loại giảm giá",
                Name = "DiscountType",
                Width = 100,
                ReadOnly = true
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DiscountValue",
                HeaderText = "Giá trị",
                Name = "DiscountValue",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                ReadOnly = true
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StartDate",
                HeaderText = "Ngày bắt đầu",
                Name = "StartDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                ReadOnly = true
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EndDate",
                HeaderText = "Ngày kết thúc",
                Name = "EndDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                ReadOnly = true
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MinOrderAmount",
                HeaderText = "ĐH tối thiểu",
                Name = "MinOrderAmount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                ReadOnly = true
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UsageLimit",
                HeaderText = "Giới hạn SD",
                Name = "UsageLimit",
                Width = 100,
                ReadOnly = true
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UsedCount",
                HeaderText = "Đã sử dụng",
                Name = "UsedCount",
                Width = 100,
                ReadOnly = true
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                Name = "Status",
                Width = 100,
                ReadOnly = true
            });

            // Set alternating row colors for better readability
            dgvPromotions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvPromotions.RowHeadersVisible = false;
        }
        #endregion

        #region Form Events
        private void frmPromotionList_Load(object sender, EventArgs e)
        {
            LoadPromotions();
            dgvPromotions.SelectionChanged += dgvPromotions_SelectionChanged;
        }

        private void txtSearchKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPromotions();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearchKeyword.Clear();
            cboStatus.SelectedIndex = 0;
            LoadPromotions();
        }

        private void dgvPromotions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPromotions.SelectedRows.Count > 0)
            {
                var promotionDisplay = dgvPromotions.SelectedRows[0].DataBoundItem as PromotionDisplay;
                selectedPromotion = promotionDisplay?.OriginalPromotion;
            }
            else
            {
                selectedPromotion = null;
            }

            UpdateButtonStates();
        }

        private void dgvPromotions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPromotion();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPromotion();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePromotion();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            ChangePromotionStatus("active");
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            ChangePromotionStatus("inactive");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPromotions();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Business Logic
        private void LoadPromotions()
        {
            try
            {
                // Get all promotions, not just active ones
                allPromotions = promotionDao.GetAllPromotions();
                filteredPromotions = new List<Promotion>(allPromotions);

                UpdateDataGridView();
                UpdatePromotionCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách khuyến mãi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchPromotions()
        {
            try
            {
                if (allPromotions == null)
                {
                    LoadPromotions();
                    return;
                }

                var searchKeyword = txtSearchKeyword.Text.Trim().ToLower();
                var selectedStatus = GetSelectedStatus();

                filteredPromotions = allPromotions.Where(p =>
                    (string.IsNullOrEmpty(searchKeyword) ||
                     p.PromotionCode.ToLower().Contains(searchKeyword) ||
                     p.PromotionName.ToLower().Contains(searchKeyword)) &&
                    (selectedStatus == "all" || GetPromotionStatusDisplay(p) == selectedStatus)
                ).ToList();

                UpdateDataGridView();
                UpdatePromotionCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm khuyến mãi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGridView()
        {
            // Transform data for display using concrete class
            var displayData = filteredPromotions.Select(p => new PromotionDisplay
            {
                PromotionId = p.PromotionId,
                PromotionCode = p.PromotionCode,
                PromotionName = p.PromotionName,
                DiscountType = p.DiscountType == "percentage" ? "Phần trăm" : "Số tiền",
                DiscountValue = p.DiscountValue,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                MinOrderAmount = p.MinOrderAmount,
                UsageLimit = p.UsageLimit == 0 ? "Không giới hạn" : p.UsageLimit.ToString(),
                UsedCount = p.UsedCount,
                Status = GetPromotionStatusDisplay(p),
                OriginalPromotion = p // Lưu reference đến object gốc
            }).ToList();

            dgvPromotions.DataSource = displayData;

            // Update display columns
            foreach (DataGridViewRow row in dgvPromotions.Rows)
            {
                var promotionDisplay = row.DataBoundItem as PromotionDisplay;
                var promotion = promotionDisplay?.OriginalPromotion;

                if (promotion != null)
                {
                    // Color code rows based on status
                    if (!promotion.IsActive)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                    }
                    else if (promotion.EndDate < DateTime.Today)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (promotion.StartDate > DateTime.Today)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }
            }
        }

        private void AddPromotion()
        {
            try
            {
                using (var frmAdd = new frmPromotionAdd())
                {
                    if (frmAdd.ShowDialog() == DialogResult.OK)
                    {
                        LoadPromotions();
                        MessageBox.Show("Khuyến mãi đã được thêm thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm khuyến mãi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditPromotion()
        {
            if (selectedPromotion == null)
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var frmEdit = new frmPromotionEdit(selectedPromotion))
                {
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        LoadPromotions();
                        MessageBox.Show("Khuyến mãi đã được cập nhật thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa khuyến mãi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletePromotion()
        {
            if (selectedPromotion == null)
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedPromotion.UsedCount > 0)
            {
                MessageBox.Show("Không thể xóa khuyến mãi đã được sử dụng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khuyến mãi '{selectedPromotion.PromotionName}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                if (promotionDao.DeletePromotion(selectedPromotion.PromotionId))
                {
                    LoadPromotions();
                    MessageBox.Show("Khuyến mãi đã được xóa thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa khuyến mãi. Vui lòng thử lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa khuyến mãi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangePromotionStatus(string newStatus)
        {
            if (selectedPromotion == null)
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần thay đổi trạng thái.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusText = newStatus == "active" ? "kích hoạt" : "tạm dừng";
            string confirmMessage = $"Bạn có chắc chắn muốn {statusText} khuyến mãi '{selectedPromotion.PromotionName}'?";

            if (MessageBox.Show(confirmMessage, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                if (promotionDao.UpdatePromotionStatus(selectedPromotion.PromotionId, newStatus))
                {
                    LoadPromotions();
                    MessageBox.Show($"Khuyến mãi đã được {statusText} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi {statusText} khuyến mãi. Vui lòng thử lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi {statusText} khuyến mãi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = selectedPromotion != null;

            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection && (selectedPromotion?.UsedCount == 0);
            btnActivate.Enabled = hasSelection && selectedPromotion?.Status != "active";
            btnDeactivate.Enabled = hasSelection && selectedPromotion?.Status == "active";
        }

        private void UpdatePromotionCount()
        {
            int totalCount = allPromotions?.Count ?? 0;
            int filteredCount = filteredPromotions?.Count ?? 0;

            string countText = filteredCount == totalCount
                ? $"Tổng số: {totalCount} khuyến mãi"
                : $"Hiển thị: {filteredCount}/{totalCount} khuyến mãi";

            this.Text = $"Danh sách khuyến mãi - {countText}";
        }

        private string GetSelectedStatus()
        {
            switch (cboStatus.SelectedIndex)
            {
                case 0: return "all"; // Tất cả
                case 1: return "Đang hoạt động";
                case 2: return "Tạm dừng";
                case 3: return "Hết hạn";
                default: return "all";
            }
        }

        private string GetPromotionStatusDisplay(Promotion promotion)
        {
            if (promotion.Status != "active")
            {
                return "Tạm dừng";
            }

            if (promotion.EndDate < DateTime.Today)
            {
                return "Hết hạn";
            }

            if (promotion.StartDate > DateTime.Today)
            {
                return "Chưa bắt đầu";
            }

            if (promotion.UsageLimit > 0 && promotion.UsedCount >= promotion.UsageLimit)
            {
                return "Đã hết lượt";
            }

            return "Đang hoạt động";
        }

        public class PromotionDisplay
        {
            public int PromotionId { get; set; }
            public string PromotionCode { get; set; }
            public string PromotionName { get; set; }
            public string DiscountType { get; set; }
            public decimal DiscountValue { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal MinOrderAmount { get; set; }
            public string UsageLimit { get; set; }
            public int UsedCount { get; set; }
            public string Status { get; set; }

            // Lưu reference đến Promotion gốc
            public Promotion OriginalPromotion { get; set; }
        }

        #endregion

    }
}