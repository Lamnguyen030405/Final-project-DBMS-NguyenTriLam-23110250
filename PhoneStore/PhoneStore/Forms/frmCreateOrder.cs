using PhoneStore.Dao;
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
    public partial class frmCreateOrder : Form
    {
        #region Fields
        private ProductDao productDao;
        private CustomerDao customerDao;
        private OrderDao orderDao;
        private PromotionDao promotionDao;
        private InventoryDao inventoryDao;
        private PaymentService paymentService;
        private OrderService orderService;


        private Customer selectedCustomer;
        private Promotion currentPromotion;
        private List<OrderDetailItem> orderItems;

        private decimal subtotal = 0;
        private decimal discountAmount = 0;
        private decimal taxAmount = 0;
        private decimal totalAmount = 0;
        private const decimal TAX_RATE = 0.08m; // VAT 8%
        #endregion

        #region Inner Classes
        public class OrderDetailItem
        {
            public int ProductId { get; set; }
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal DiscountPerItem { get; set; }
            public decimal TotalPrice { get; set; }

            public void CalculateTotal()
            {
                TotalPrice = (UnitPrice * Quantity) - DiscountPerItem;
            }
        }
        #endregion

        #region Constructor
        public frmCreateOrder()
        {
            InitializeComponent();
            InitializeDao();
            InitializeData();
        }
        #endregion

        #region Initialization
        private void InitializeDao()
        {
            productDao = new ProductDao();
            customerDao = new CustomerDao();
            orderDao = new OrderDao();
            promotionDao = new PromotionDao();
            inventoryDao = new InventoryDao();
            paymentService = new PaymentService();
            orderService = new OrderService();

        }

        private void InitializeData()
        {
            orderItems = new List<OrderDetailItem>();
            cboPaymentMethod.SelectedIndex = 0; // Default to cash
            SetupDataGridViews();
            LoadProducts();
            LoadPromotions();
        }

        private void SetupDataGridViews()
        {
            // Setup Products DataGridView
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductCode",
                HeaderText = "Mã SP",
                Name = "ProductCode",
                Width = 80
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên sản phẩm",
                Name = "ProductName",
                Width = 200
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BrandName",
                HeaderText = "Thương hiệu",
                Name = "BrandName",
                Width = 100
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SellingPrice",
                HeaderText = "Giá bán",
                Name = "SellingPrice",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "QuantityOnHand",
                HeaderText = "Tồn kho",
                Name = "QuantityOnHand",
                Width = 80
            });

            // Setup Order Details DataGridView
            dgvOrderDetails.AutoGenerateColumns = false;
            dgvOrderDetails.Columns.Clear();

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductCode",
                HeaderText = "Mã SP",
                Name = "ProductCode",
                Width = 80
            });

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên sản phẩm",
                Name = "ProductName",
                Width = 200
            });

            var quantityColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số lượng",
                Name = "Quantity",
                Width = 80
            };
            dgvOrderDetails.Columns.Add(quantityColumn);

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Đơn giá",
                Name = "UnitPrice",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPrice",
                HeaderText = "Thành tiền",
                Name = "TotalPrice",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // Make quantity column editable
            dgvOrderDetails.CellEndEdit += dgvOrderDetails_CellEndEdit;
        }
        #endregion

        #region Form Events
        private void frmCreateOrder_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtCustomerSearch;
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại để tìm kiếm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var customer = customerDao.GetCustomerByPhone(txtCustomerSearch.Text.Trim());

                if (customer != null)
                {
                    selectedCustomer = customer;
                    txtCustomerName.Text = customer.FullName;
                    txtCustomerPhone.Text = customer.Phone;

                    MessageBox.Show($"Đã tìm thấy khách hàng: {customer.FullName}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearCustomerInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm khách hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            using (var frmCustomer = new frmCustomerAdd())
            {
                if (frmCustomer.ShowDialog() == DialogResult.OK)
                {
                    // Reload customer info if new customer was created
                    var newCustomer = frmCustomer.NewCustomer;
                    if (newCustomer != null)
                    {
                        selectedCustomer = newCustomer;
                        txtCustomerName.Text = newCustomer.FullName;
                        txtCustomerPhone.Text = newCustomer.Phone;
                        txtCustomerSearch.Text = newCustomer.Phone;
                    }
                }
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            LoadProducts(txtProductSearch.Text.Trim());
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AddProductToOrder();
            }
        }

        private void dgvOrderDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOrderDetails.Columns["Quantity"].Index && e.RowIndex >= 0)
            {
                UpdateOrderItemQuantity(e.RowIndex);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvOrderDetails.SelectedRows[0].Index;

                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này khỏi đơn hàng?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    orderItems.RemoveAt(selectedIndex);
                    RefreshOrderDetails();
                    CalculateOrderTotal();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnApplyPromotion_Click(object sender, EventArgs e)
        {
            ApplyPromotionCode();
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            SaveOrder();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (orderItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn hủy đơn hàng này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Business Logic
        private void LoadProducts(string searchKeyword = "")
        {
            try
            {
                List<Product> products;

                if (string.IsNullOrWhiteSpace(searchKeyword))
                {
                    products = productDao.GetAllProducts();
                }
                else
                {
                    products = productDao.SearchProducts(searchKeyword);
                }

                dgvProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sản phẩm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddProductToOrder()
        {
            if (dgvProducts.SelectedRows.Count == 0)
                return;

            var selectedRow = dgvProducts.SelectedRows[0];
            var product = selectedRow.DataBoundItem as Product;

            if (product == null)
                return;

            // Check stock
            if (product.QuantityOnHand <= 0)
            {
                MessageBox.Show("Sản phẩm này hiện đã hết hàng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if product already exists in order
            var existingItem = orderItems.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (existingItem != null)
            {
                // Increase quantity
                if (existingItem.Quantity < product.QuantityOnHand)
                {
                    existingItem.Quantity++;
                    existingItem.CalculateTotal();
                }
                else
                {
                    MessageBox.Show("Số lượng đã đạt tối đa tồn kho.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                // Add new item
                var orderItem = new OrderDetailItem
                {
                    ProductId = product.ProductId,
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName,
                    Quantity = 1,
                    UnitPrice = product.SellingPrice,
                    DiscountPerItem = 0
                };
                orderItem.CalculateTotal();

                orderItems.Add(orderItem);
            }

            RefreshOrderDetails();
            CalculateOrderTotal();
        }

        private void UpdateOrderItemQuantity(int rowIndex)
        {
            try
            {
                var cell = dgvOrderDetails.Rows[rowIndex].Cells["Quantity"];
                if (int.TryParse(cell.Value?.ToString(), out int newQuantity) && newQuantity > 0)
                {
                    var orderItem = orderItems[rowIndex];

                    // Get current stock for this product
                    int currentStock = inventoryDao.GetProductStock(orderItem.ProductId);

                    if (newQuantity <= currentStock)
                    {
                        orderItem.Quantity = newQuantity;
                        orderItem.CalculateTotal();

                        RefreshOrderDetails();
                        CalculateOrderTotal();
                    }
                    else
                    {
                        MessageBox.Show($"Số lượng không được vượt quá tồn kho ({currentStock})", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cell.Value = orderItem.Quantity;
                    }
                }
                else
                {
                    // Invalid quantity, reset to original
                    cell.Value = orderItems[rowIndex].Quantity;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật số lượng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshOrderDetails()
        {
            dgvOrderDetails.DataSource = null;
            dgvOrderDetails.DataSource = orderItems.ToList();
        }

        private void CalculateOrderTotal()
        {
            subtotal = orderItems.Sum(x => x.TotalPrice);

            // Recalculate discount if promotion is applied
            if (currentPromotion != null)
            {
                discountAmount = promotionDao.CalculateDiscount(currentPromotion, subtotal);
            }

            taxAmount = (subtotal - discountAmount) * TAX_RATE;
            totalAmount = subtotal - discountAmount + taxAmount;

            // Update UI
            lblSubtotalValue.Text = subtotal.ToString("N0") + "đ";
            lblDiscountValue.Text = "-" + discountAmount.ToString("N0") + "đ";
            lblTaxValue.Text = taxAmount.ToString("N0") + "đ";
            lblTotalValue.Text = totalAmount.ToString("N0") + "đ";
        }

        private void ApplyPromotionCode()
        {
            string promotionCode = cboPromotionCode.Text.Trim();

            if (string.IsNullOrEmpty(promotionCode))
            {
                currentPromotion = null;
                CalculateOrderTotal();
                return;
            }

            try
            {
                var promotion = promotionDao.GetPromotionByCode(promotionCode);

                if (promotion != null)
                {
                    if (subtotal >= promotion.MinOrderAmount)
                    {
                        currentPromotion = promotion;
                        CalculateOrderTotal();

                        MessageBox.Show($"Đã áp dụng khuyến mãi: {promotion.PromotionName}", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Đơn hàng phải có giá trị tối thiểu {promotion.MinOrderAmount:N0}đ để áp dụng khuyến mãi này.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Mã khuyến mãi không hợp lệ hoặc đã hết hạn.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi áp dụng khuyến mãi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveOrder()
        {
            if (!ValidateOrder())
                return;

            try
            {
                var createRequest = new CreateOrderRequest
                {
                    CustomerId = selectedCustomer?.CustomerId,
                    PromotionId = currentPromotion?.PromotionId,
                    PromotionCode = cboPromotionCode.Text.Trim(),
                    PaymentMethod = GetPaymentMethodCode(),
                    PaymentStatus = "pending",
                    Notes = "",
                    OrderItems = orderItems.Select(item => new OrderItemRequest
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        DiscountPerItem = item.DiscountPerItem
                    }).ToList()
                };

                var result = orderService.CreateOrder(createRequest);

                if (result.IsSuccess)
                {
                    CreateInitialPaymentRecord(result.Data, createRequest.PaymentMethod);

                    MessageBox.Show($"Đơn hàng đã được tạo thành công! Mã đơn hàng ID: {result.Data}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Lỗi: {result.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu đơn hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ===== NEW METHOD: Create initial payment record =====
        private void CreateInitialPaymentRecord(int orderId, string paymentMethod)
        {
            try
            {
                // Create initial payment record with 0 amount (pending payment)
                var paymentRequest = new PaymentRequest
                {
                    OrderId = orderId,
                    Amount = 0m, // Initially 0 - will be updated when payment is made
                    PaymentMethod = paymentMethod,
                    ReferenceNumber = GenerateInitialReference(paymentMethod),
                    Notes = "Tạo đơn hàng mới - chưa thanh toán"
                };

                var result = paymentService.ProcessPayment(paymentRequest);
                if (!result.IsSuccess)
                {
                    // Log error but don't fail the whole operation
                    System.Diagnostics.Debug.WriteLine($"Failed to create initial payment record: {result.Message}");
                }
            }
            catch (Exception ex)
            {
                // Log error but don't fail the whole operation
                System.Diagnostics.Debug.WriteLine($"Error creating initial payment record: {ex.Message}");
            }
        }

        private string GenerateInitialReference(string paymentMethod)
        {
            // For pending payments, create a placeholder reference
            var referenceResult = paymentService.GenerateReferenceNumber(paymentMethod);
            if (referenceResult.IsSuccess)
            {
                return "PENDING-" + referenceResult.Data;
            }
            else
            {
                return $"PENDING-{paymentMethod.ToUpper()}{DateTime.Now:yyyyMMddHHmmss}";
            }
        }

        private bool ValidateOrder()
        {
            if (orderItems.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm vào đơn hàng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboPaymentMethod.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string GetPaymentMethodCode()
        {
            switch (cboPaymentMethod.SelectedIndex)
            {
                case 0: return "cash";
                case 1: return "card";
                case 2: return "transfer";
                case 3: return "installment";
                default: return "cash";
            }
        }

        private void ClearCustomerInfo()
        {
            selectedCustomer = null;
            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
        }


        private void btnNewPromotion_Click(object sender, EventArgs e)
        {
            using (var frmPromotion = new frmPromotionAdd())
            {
                if (frmPromotion.ShowDialog() == DialogResult.OK)
                {
                    // Reload promotions after adding a new one
                    LoadPromotions();

                    // Select the newly created promotion
                    if (frmPromotion.NewPromotion != null)
                    {
                        cboPromotionCode.Text = frmPromotion.NewPromotion.PromotionCode;
                        ApplyPromotionCode();

                        MessageBox.Show($"Khuyến mãi '{frmPromotion.NewPromotion.PromotionName}' đã được tạo và áp dụng!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void LoadPromotions()
        {
            try
            {
                var promotions = promotionDao.GetActivePromotions();

                cboPromotionCode.Items.Clear();
                cboPromotionCode.Items.Add(""); // Empty option

                foreach (var promotion in promotions)
                {
                    cboPromotionCode.Items.Add(promotion.PromotionCode);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading promotions: {ex.Message}");
            }
        }

        #endregion
    }
}