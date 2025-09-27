namespace PhoneStore.Forms
{
    partial class frmCreateOrder
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.Label lblCustomerSearch;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerPhone;

        private System.Windows.Forms.GroupBox gbProducts;
        private System.Windows.Forms.Label lblProductSearch;
        private System.Windows.Forms.TextBox txtProductSearch;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.DataGridView dgvProducts;

        private System.Windows.Forms.GroupBox gbOrderDetails;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Button btnRemoveItem;

        private System.Windows.Forms.GroupBox gbOrderSummary;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Button btnApplyPromotion;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label lblPaymentMethod;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.gbOrderSummary = new System.Windows.Forms.GroupBox();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.btnApplyPromotion = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.gbOrderDetails = new System.Windows.Forms.GroupBox();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.gbProducts = new System.Windows.Forms.GroupBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.txtProductSearch = new System.Windows.Forms.TextBox();
            this.lblProductSearch = new System.Windows.Forms.Label();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.lblCustomerSearch = new System.Windows.Forms.Label();
            this.cboPromotionCode = new System.Windows.Forms.ComboBox();
            this.btnNewPromotion = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.gbOrderSummary.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.gbOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.gbProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.gbCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(11);
            this.pnlMain.Size = new System.Drawing.Size(1371, 853);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlButtons);
            this.pnlRight.Controls.Add(this.gbOrderSummary);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(868, 11);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(492, 831);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSaveOrder);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 778);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(492, 53);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(171, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 37);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSaveOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveOrder.ForeColor = System.Drawing.Color.White;
            this.btnSaveOrder.Location = new System.Drawing.Point(23, 11);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(137, 37);
            this.btnSaveOrder.TabIndex = 0;
            this.btnSaveOrder.Text = "Lưu đơn hàng";
            this.btnSaveOrder.UseVisualStyleBackColor = false;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // gbOrderSummary
            // 
            this.gbOrderSummary.Controls.Add(this.btnNewPromotion);
            this.gbOrderSummary.Controls.Add(this.cboPromotionCode);
            this.gbOrderSummary.Controls.Add(this.cboPaymentMethod);
            this.gbOrderSummary.Controls.Add(this.lblPaymentMethod);
            this.gbOrderSummary.Controls.Add(this.lblTotalValue);
            this.gbOrderSummary.Controls.Add(this.lblTotal);
            this.gbOrderSummary.Controls.Add(this.lblTaxValue);
            this.gbOrderSummary.Controls.Add(this.lblTax);
            this.gbOrderSummary.Controls.Add(this.lblDiscountValue);
            this.gbOrderSummary.Controls.Add(this.btnApplyPromotion);
            this.gbOrderSummary.Controls.Add(this.lblDiscount);
            this.gbOrderSummary.Controls.Add(this.lblSubtotalValue);
            this.gbOrderSummary.Controls.Add(this.lblSubtotal);
            this.gbOrderSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOrderSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbOrderSummary.Location = new System.Drawing.Point(0, 0);
            this.gbOrderSummary.Name = "gbOrderSummary";
            this.gbOrderSummary.Size = new System.Drawing.Size(492, 373);
            this.gbOrderSummary.TabIndex = 0;
            this.gbOrderSummary.TabStop = false;
            this.gbOrderSummary.Text = "Tổng kết đơn hàng";
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Items.AddRange(new object[] {
            "Tiền mặt",
            "Thẻ tín dụng",
            "Chuyển khoản",
            "Trả góp"});
            this.cboPaymentMethod.Location = new System.Drawing.Point(23, 304);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(228, 28);
            this.cboPaymentMethod.TabIndex = 11;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaymentMethod.Location = new System.Drawing.Point(23, 277);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(136, 23);
            this.lblPaymentMethod.TabIndex = 10;
            this.lblPaymentMethod.Text = "Phương thức TT:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.Red;
            this.lblTotalValue.Location = new System.Drawing.Point(229, 224);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(229, 32);
            this.lblTotalValue.TabIndex = 9;
            this.lblTotalValue.Text = "0đ";
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(23, 224);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(131, 32);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Tổng tiền:";
            // 
            // lblTaxValue
            // 
            this.lblTaxValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaxValue.Location = new System.Drawing.Point(286, 181);
            this.lblTaxValue.Name = "lblTaxValue";
            this.lblTaxValue.Size = new System.Drawing.Size(171, 20);
            this.lblTaxValue.TabIndex = 7;
            this.lblTaxValue.Text = "0đ";
            this.lblTaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTax.Location = new System.Drawing.Point(23, 181);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(86, 23);
            this.lblTax.TabIndex = 6;
            this.lblTax.Text = "Thuế VAT:";
            // 
            // lblDiscountValue
            // 
            this.lblDiscountValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiscountValue.ForeColor = System.Drawing.Color.Green;
            this.lblDiscountValue.Location = new System.Drawing.Point(286, 139);
            this.lblDiscountValue.Name = "lblDiscountValue";
            this.lblDiscountValue.Size = new System.Drawing.Size(171, 21);
            this.lblDiscountValue.TabIndex = 5;
            this.lblDiscountValue.Text = "-0đ";
            this.lblDiscountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnApplyPromotion
            // 
            this.btnApplyPromotion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnApplyPromotion.Location = new System.Drawing.Point(200, 114);
            this.btnApplyPromotion.Name = "btnApplyPromotion";
            this.btnApplyPromotion.Size = new System.Drawing.Size(80, 25);
            this.btnApplyPromotion.TabIndex = 4;
            this.btnApplyPromotion.Text = "Áp dụng";
            this.btnApplyPromotion.UseVisualStyleBackColor = true;
            this.btnApplyPromotion.Click += new System.EventHandler(this.btnApplyPromotion_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiscount.Location = new System.Drawing.Point(23, 85);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(112, 20);
            this.lblDiscount.TabIndex = 2;
            this.lblDiscount.Text = "Mã khuyến mãi:";
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalValue.Location = new System.Drawing.Point(286, 43);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.Size = new System.Drawing.Size(171, 21);
            this.lblSubtotalValue.TabIndex = 1;
            this.lblSubtotalValue.Text = "0đ";
            this.lblSubtotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtotal.Location = new System.Drawing.Point(23, 43);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(90, 25);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Tạm tính:";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.gbOrderDetails);
            this.pnlLeft.Controls.Add(this.gbProducts);
            this.pnlLeft.Controls.Add(this.gbCustomer);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(11, 11);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(857, 831);
            this.pnlLeft.TabIndex = 0;
            // 
            // gbOrderDetails
            // 
            this.gbOrderDetails.Controls.Add(this.btnRemoveItem);
            this.gbOrderDetails.Controls.Add(this.dgvOrderDetails);
            this.gbOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOrderDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbOrderDetails.Location = new System.Drawing.Point(0, 459);
            this.gbOrderDetails.Name = "gbOrderDetails";
            this.gbOrderDetails.Size = new System.Drawing.Size(857, 372);
            this.gbOrderDetails.TabIndex = 2;
            this.gbOrderDetails.TabStop = false;
            this.gbOrderDetails.Text = "Chi tiết đơn hàng";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveItem.Location = new System.Drawing.Point(743, 336);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(97, 32);
            this.btnRemoveItem.TabIndex = 1;
            this.btnRemoveItem.Text = "Xóa item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.AllowUserToDeleteRows = false;
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetails.ColumnHeadersHeight = 29;
            this.dgvOrderDetails.Location = new System.Drawing.Point(17, 27);
            this.dgvOrderDetails.MultiSelect = false;
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.RowHeadersWidth = 51;
            this.dgvOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderDetails.Size = new System.Drawing.Size(823, 299);
            this.dgvOrderDetails.TabIndex = 0;
            // 
            // gbProducts
            // 
            this.gbProducts.Controls.Add(this.dgvProducts);
            this.gbProducts.Controls.Add(this.btnSearchProduct);
            this.gbProducts.Controls.Add(this.txtProductSearch);
            this.gbProducts.Controls.Add(this.lblProductSearch);
            this.gbProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProducts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbProducts.Location = new System.Drawing.Point(0, 160);
            this.gbProducts.Name = "gbProducts";
            this.gbProducts.Size = new System.Drawing.Size(857, 299);
            this.gbProducts.TabIndex = 1;
            this.gbProducts.TabStop = false;
            this.gbProducts.Text = "Danh sách sản phẩm";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeight = 29;
            this.dgvProducts.Location = new System.Drawing.Point(17, 91);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(823, 192);
            this.dgvProducts.TabIndex = 3;
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearchProduct.Location = new System.Drawing.Point(371, 53);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(86, 25);
            this.btnSearchProduct.TabIndex = 2;
            this.btnSearchProduct.Text = "Tìm kiếm";
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProductSearch.Location = new System.Drawing.Point(17, 53);
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.Size = new System.Drawing.Size(342, 27);
            this.txtProductSearch.TabIndex = 1;
            // 
            // lblProductSearch
            // 
            this.lblProductSearch.AutoSize = true;
            this.lblProductSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductSearch.Location = new System.Drawing.Point(17, 32);
            this.lblProductSearch.Name = "lblProductSearch";
            this.lblProductSearch.Size = new System.Drawing.Size(141, 20);
            this.lblProductSearch.TabIndex = 0;
            this.lblProductSearch.Text = "Tìm kiếm sản phẩm:";
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.txtCustomerPhone);
            this.gbCustomer.Controls.Add(this.lblCustomerPhone);
            this.gbCustomer.Controls.Add(this.txtCustomerName);
            this.gbCustomer.Controls.Add(this.lblCustomerName);
            this.gbCustomer.Controls.Add(this.btnNewCustomer);
            this.gbCustomer.Controls.Add(this.btnSearchCustomer);
            this.gbCustomer.Controls.Add(this.txtCustomerSearch);
            this.gbCustomer.Controls.Add(this.lblCustomerSearch);
            this.gbCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCustomer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbCustomer.Location = new System.Drawing.Point(0, 0);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(857, 160);
            this.gbCustomer.TabIndex = 0;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Thông tin khách hàng";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(257, 112);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.ReadOnly = true;
            this.txtCustomerPhone.Size = new System.Drawing.Size(171, 27);
            this.txtCustomerPhone.TabIndex = 7;
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerPhone.Location = new System.Drawing.Point(257, 91);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(100, 20);
            this.lblCustomerPhone.TabIndex = 6;
            this.lblCustomerPhone.Text = "Số điện thoại:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerName.Location = new System.Drawing.Point(17, 112);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(228, 27);
            this.txtCustomerName.TabIndex = 5;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerName.Location = new System.Drawing.Point(17, 91);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(57, 20);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "Họ tên:";
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNewCustomer.Location = new System.Drawing.Point(354, 53);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(114, 25);
            this.btnNewCustomer.TabIndex = 3;
            this.btnNewCustomer.Text = "Khách hàng mới";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearchCustomer.Location = new System.Drawing.Point(257, 53);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(86, 25);
            this.btnSearchCustomer.TabIndex = 2;
            this.btnSearchCustomer.Text = "Tìm kiếm";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerSearch.Location = new System.Drawing.Point(17, 53);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(228, 27);
            this.txtCustomerSearch.TabIndex = 1;
            // 
            // lblCustomerSearch
            // 
            this.lblCustomerSearch.AutoSize = true;
            this.lblCustomerSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerSearch.Location = new System.Drawing.Point(17, 32);
            this.lblCustomerSearch.Name = "lblCustomerSearch";
            this.lblCustomerSearch.Size = new System.Drawing.Size(114, 20);
            this.lblCustomerSearch.TabIndex = 0;
            this.lblCustomerSearch.Text = "Tìm kiếm (SĐT):";
            // 
            // cboPromotionCode
            // 
            this.cboPromotionCode.FormattingEnabled = true;
            this.cboPromotionCode.Location = new System.Drawing.Point(23, 110);
            this.cboPromotionCode.Name = "cboPromotionCode";
            this.cboPromotionCode.Size = new System.Drawing.Size(164, 31);
            this.cboPromotionCode.TabIndex = 12;
            // 
            // btnNewPromotion
            // 
            this.btnNewPromotion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNewPromotion.Location = new System.Drawing.Point(286, 114);
            this.btnNewPromotion.Name = "btnNewPromotion";
            this.btnNewPromotion.Size = new System.Drawing.Size(115, 25);
            this.btnNewPromotion.TabIndex = 13;
            this.btnNewPromotion.Text = "Khuyến mãi";
            this.btnNewPromotion.UseVisualStyleBackColor = true;
            this.btnNewPromotion.Click += new System.EventHandler(this.btnNewPromotion_Click);
            // 
            // frmCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 853);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo đơn hàng mới";
            this.Load += new System.EventHandler(this.frmCreateOrder_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.gbOrderSummary.ResumeLayout(false);
            this.gbOrderSummary.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.gbOrderDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.gbProducts.ResumeLayout(false);
            this.gbProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ComboBox cboPromotionCode;
        private System.Windows.Forms.Button btnNewPromotion;
    }
}