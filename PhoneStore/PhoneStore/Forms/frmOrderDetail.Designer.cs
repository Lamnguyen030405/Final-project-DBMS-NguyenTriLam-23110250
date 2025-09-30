namespace PhoneStore.Forms
{
    partial class frmOrderDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabOrderDetail = new System.Windows.Forms.TabControl();
            this.tabPageOrderInfo = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTaxAmount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDiscountAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCreatedAt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPaymentMethod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPaymentStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrderStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscountPerItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarrantyEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageCustomerInfo = new System.Windows.Forms.TabPage();
            this.btnViewCustomerHistory = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTotalSpent = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCustomerType = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPagePaymentHistory = new System.Windows.Forms.TabPage();
            this.btnDeletePayment = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblPaymentProgress = new System.Windows.Forms.Label();
            this.progressPayment = new System.Windows.Forms.ProgressBar();
            this.txtLastPaymentDate = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtRemainingAmount = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtTotalPaid = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblPaymentCount = new System.Windows.Forms.Label();
            this.dgvPaymentHistory = new System.Windows.Forms.DataGridView();
            this.colPaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferenceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.tabOrderDetail.SuspendLayout();
            this.tabPageOrderInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.tabPageCustomerInfo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPagePaymentHistory.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOrderDetail
            // 
            this.tabOrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOrderDetail.Controls.Add(this.tabPageOrderInfo);
            this.tabOrderDetail.Controls.Add(this.tabPageCustomerInfo);
            this.tabOrderDetail.Controls.Add(this.tabPagePaymentHistory);
            this.tabOrderDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOrderDetail.Location = new System.Drawing.Point(16, 15);
            this.tabOrderDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tabOrderDetail.Name = "tabOrderDetail";
            this.tabOrderDetail.SelectedIndex = 0;
            this.tabOrderDetail.Size = new System.Drawing.Size(1280, 800);
            this.tabOrderDetail.TabIndex = 0;
            // 
            // tabPageOrderInfo
            // 
            this.tabPageOrderInfo.Controls.Add(this.groupBox3);
            this.tabPageOrderInfo.Controls.Add(this.groupBox2);
            this.tabPageOrderInfo.Controls.Add(this.groupBox1);
            this.tabPageOrderInfo.Controls.Add(this.lblItemCount);
            this.tabPageOrderInfo.Controls.Add(this.dgvOrderItems);
            this.tabPageOrderInfo.Location = new System.Drawing.Point(4, 27);
            this.tabPageOrderInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageOrderInfo.Name = "tabPageOrderInfo";
            this.tabPageOrderInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageOrderInfo.Size = new System.Drawing.Size(1272, 769);
            this.tabPageOrderInfo.TabIndex = 0;
            this.tabPageOrderInfo.Text = "Thông tin đơn hàng";
            this.tabPageOrderInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtNotes);
            this.groupBox3.Location = new System.Drawing.Point(8, 640);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1253, 118);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ghi chú";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(8, 27);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(1236, 83);
            this.txtNotes.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTotalAmount);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtTaxAmount);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtDiscountAmount);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtSubtotal);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(928, 480);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(333, 153);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết thanh toán";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.ForeColor = System.Drawing.Color.Red;
            this.txtTotalAmount.Location = new System.Drawing.Point(133, 117);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(191, 24);
            this.txtTotalAmount.TabIndex = 7;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 121);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 18);
            this.label15.TabIndex = 6;
            this.label15.Text = "Tổng tiền:";
            // 
            // txtTaxAmount
            // 
            this.txtTaxAmount.Location = new System.Drawing.Point(133, 87);
            this.txtTaxAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTaxAmount.Name = "txtTaxAmount";
            this.txtTaxAmount.ReadOnly = true;
            this.txtTaxAmount.Size = new System.Drawing.Size(191, 24);
            this.txtTaxAmount.TabIndex = 5;
            this.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 91);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 18);
            this.label14.TabIndex = 4;
            this.label14.Text = "Thuế VAT:";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Location = new System.Drawing.Point(133, 58);
            this.txtDiscountAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.ReadOnly = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(191, 24);
            this.txtDiscountAmount.TabIndex = 3;
            this.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 62);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 18);
            this.label13.TabIndex = 2;
            this.label13.Text = "Giảm giá:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(133, 28);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(191, 24);
            this.txtSubtotal.TabIndex = 1;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 32);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tạm tính:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCreatedAt);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPaymentMethod);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPaymentStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtOrderStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEmployeeName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOrderDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOrderCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1253, 133);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // txtCreatedAt
            // 
            this.txtCreatedAt.Location = new System.Drawing.Point(797, 92);
            this.txtCreatedAt.Margin = new System.Windows.Forms.Padding(4);
            this.txtCreatedAt.Name = "txtCreatedAt";
            this.txtCreatedAt.ReadOnly = true;
            this.txtCreatedAt.Size = new System.Drawing.Size(199, 24);
            this.txtCreatedAt.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(693, 96);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 18);
            this.label11.TabIndex = 12;
            this.label11.Text = "Ngày tạo:";
            // 
            // txtPaymentMethod
            // 
            this.txtPaymentMethod.Location = new System.Drawing.Point(480, 92);
            this.txtPaymentMethod.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentMethod.Name = "txtPaymentMethod";
            this.txtPaymentMethod.ReadOnly = true;
            this.txtPaymentMethod.Size = new System.Drawing.Size(199, 24);
            this.txtPaymentMethod.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(347, 96);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "PT Thanh toán:";
            // 
            // txtPaymentStatus
            // 
            this.txtPaymentStatus.Location = new System.Drawing.Point(160, 92);
            this.txtPaymentStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentStatus.Name = "txtPaymentStatus";
            this.txtPaymentStatus.ReadOnly = true;
            this.txtPaymentStatus.Size = new System.Drawing.Size(159, 24);
            this.txtPaymentStatus.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Trạng thái TT:";
            // 
            // txtOrderStatus
            // 
            this.txtOrderStatus.Location = new System.Drawing.Point(797, 60);
            this.txtOrderStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderStatus.Name = "txtOrderStatus";
            this.txtOrderStatus.ReadOnly = true;
            this.txtOrderStatus.Size = new System.Drawing.Size(199, 24);
            this.txtOrderStatus.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(693, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Trạng thái:";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(480, 60);
            this.txtEmployeeName.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(199, 24);
            this.txtEmployeeName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhân viên:";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(160, 60);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(159, 24);
            this.txtOrderDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày đặt:";
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderCode.ForeColor = System.Drawing.Color.Blue;
            this.txtOrderCode.Location = new System.Drawing.Point(160, 28);
            this.txtOrderCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.ReadOnly = true;
            this.txtOrderCode.Size = new System.Drawing.Size(199, 24);
            this.txtOrderCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đơn hàng:";
            // 
            // lblItemCount
            // 
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCount.Location = new System.Drawing.Point(8, 154);
            this.lblItemCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(166, 18);
            this.lblItemCount.TabIndex = 1;
            this.lblItemCount.Text = "Danh sách sản phẩm";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductCode,
            this.colProductName,
            this.colQuantity,
            this.colUnitPrice,
            this.colDiscountPerItem,
            this.colTotalPrice,
            this.colWarrantyEnd});
            this.dgvOrderItems.Location = new System.Drawing.Point(8, 176);
            this.dgvOrderItems.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOrderItems.MultiSelect = false;
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.RowHeadersVisible = false;
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderItems.Size = new System.Drawing.Size(1256, 297);
            this.dgvOrderItems.TabIndex = 0;
            // 
            // colProductCode
            // 
            this.colProductCode.FillWeight = 80F;
            this.colProductCode.HeaderText = "Mã SP";
            this.colProductCode.MinimumWidth = 6;
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.FillWeight = 200F;
            this.colProductName.HeaderText = "Tên sản phẩm";
            this.colProductName.MinimumWidth = 6;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colQuantity
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle16;
            this.colQuantity.FillWeight = 60F;
            this.colQuantity.HeaderText = "SL";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N0";
            this.colUnitPrice.DefaultCellStyle = dataGridViewCellStyle17;
            this.colUnitPrice.HeaderText = "Đơn giá";
            this.colUnitPrice.MinimumWidth = 6;
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colDiscountPerItem
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N0";
            this.colDiscountPerItem.DefaultCellStyle = dataGridViewCellStyle18;
            this.colDiscountPerItem.FillWeight = 80F;
            this.colDiscountPerItem.HeaderText = "Giảm giá";
            this.colDiscountPerItem.MinimumWidth = 6;
            this.colDiscountPerItem.Name = "colDiscountPerItem";
            this.colDiscountPerItem.ReadOnly = true;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.FillWeight = 120F;
            this.colTotalPrice.HeaderText = "Thành tiền";
            this.colTotalPrice.MinimumWidth = 6;
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.ReadOnly = true;
            // 
            // colWarrantyEnd
            // 
            this.colWarrantyEnd.FillWeight = 90F;
            this.colWarrantyEnd.HeaderText = "Hết BH";
            this.colWarrantyEnd.MinimumWidth = 6;
            this.colWarrantyEnd.Name = "colWarrantyEnd";
            this.colWarrantyEnd.ReadOnly = true;
            // 
            // tabPageCustomerInfo
            // 
            this.tabPageCustomerInfo.Controls.Add(this.btnViewCustomerHistory);
            this.tabPageCustomerInfo.Controls.Add(this.groupBox4);
            this.tabPageCustomerInfo.Location = new System.Drawing.Point(4, 27);
            this.tabPageCustomerInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageCustomerInfo.Name = "tabPageCustomerInfo";
            this.tabPageCustomerInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageCustomerInfo.Size = new System.Drawing.Size(1272, 769);
            this.tabPageCustomerInfo.TabIndex = 1;
            this.tabPageCustomerInfo.Text = "Thông tin khách hàng";
            this.tabPageCustomerInfo.UseVisualStyleBackColor = true;
            // 
            // btnViewCustomerHistory
            // 
            this.btnViewCustomerHistory.BackColor = System.Drawing.Color.Blue;
            this.btnViewCustomerHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCustomerHistory.Location = new System.Drawing.Point(8, 308);
            this.btnViewCustomerHistory.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewCustomerHistory.Name = "btnViewCustomerHistory";
            this.btnViewCustomerHistory.Size = new System.Drawing.Size(200, 37);
            this.btnViewCustomerHistory.TabIndex = 1;
            this.btnViewCustomerHistory.Text = "Xem lịch sử mua hàng";
            this.btnViewCustomerHistory.UseVisualStyleBackColor = false;
            this.btnViewCustomerHistory.Click += new System.EventHandler(this.btnViewCustomerHistory_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtTotalSpent);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.txtCustomerType);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.txtCustomerAddress);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtCustomerEmail);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtCustomerPhone);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtCustomerName);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(8, 7);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1253, 293);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin khách hàng";
            // 
            // txtTotalSpent
            // 
            this.txtTotalSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSpent.ForeColor = System.Drawing.Color.Green;
            this.txtTotalSpent.Location = new System.Drawing.Point(160, 252);
            this.txtTotalSpent.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalSpent.Name = "txtTotalSpent";
            this.txtTotalSpent.ReadOnly = true;
            this.txtTotalSpent.Size = new System.Drawing.Size(265, 24);
            this.txtTotalSpent.TabIndex = 11;
            this.txtTotalSpent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 256);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 18);
            this.label21.TabIndex = 10;
            this.label21.Text = "Tổng chi tiêu:";
            // 
            // txtCustomerType
            // 
            this.txtCustomerType.Location = new System.Drawing.Point(160, 220);
            this.txtCustomerType.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerType.Name = "txtCustomerType";
            this.txtCustomerType.ReadOnly = true;
            this.txtCustomerType.Size = new System.Drawing.Size(265, 24);
            this.txtCustomerType.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 224);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(120, 18);
            this.label20.TabIndex = 8;
            this.label20.Text = "Loại khách hàng:";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerAddress.Location = new System.Drawing.Point(160, 156);
            this.txtCustomerAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerAddress.Multiline = true;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.ReadOnly = true;
            this.txtCustomerAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCustomerAddress.Size = new System.Drawing.Size(1084, 56);
            this.txtCustomerAddress.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 160);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 18);
            this.label19.TabIndex = 6;
            this.label19.Text = "Địa chỉ:";
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerEmail.Location = new System.Drawing.Point(160, 124);
            this.txtCustomerEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.ReadOnly = true;
            this.txtCustomerEmail.Size = new System.Drawing.Size(1084, 24);
            this.txtCustomerEmail.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 128);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 18);
            this.label18.TabIndex = 4;
            this.label18.Text = "Email:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(160, 92);
            this.txtCustomerPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.ReadOnly = true;
            this.txtCustomerPhone.Size = new System.Drawing.Size(265, 24);
            this.txtCustomerPhone.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 96);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 18);
            this.label17.TabIndex = 2;
            this.label17.Text = "Số điện thoại:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.ForeColor = System.Drawing.Color.Blue;
            this.txtCustomerName.Location = new System.Drawing.Point(160, 60);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(1084, 24);
            this.txtCustomerName.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 64);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 18);
            this.label16.TabIndex = 0;
            this.label16.Text = "Tên khách hàng:";
            // 
            // tabPagePaymentHistory
            // 
            this.tabPagePaymentHistory.Controls.Add(this.btnDeletePayment);
            this.tabPagePaymentHistory.Controls.Add(this.groupBox6);
            this.tabPagePaymentHistory.Controls.Add(this.groupBox5);
            this.tabPagePaymentHistory.Controls.Add(this.btnAddPayment);
            this.tabPagePaymentHistory.Location = new System.Drawing.Point(4, 27);
            this.tabPagePaymentHistory.Margin = new System.Windows.Forms.Padding(4);
            this.tabPagePaymentHistory.Name = "tabPagePaymentHistory";
            this.tabPagePaymentHistory.Padding = new System.Windows.Forms.Padding(4);
            this.tabPagePaymentHistory.Size = new System.Drawing.Size(1272, 769);
            this.tabPagePaymentHistory.TabIndex = 2;
            this.tabPagePaymentHistory.Text = "Lịch sử thanh toán";
            this.tabPagePaymentHistory.UseVisualStyleBackColor = true;
            // 
            // btnDeletePayment
            // 
            this.btnDeletePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeletePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePayment.Location = new System.Drawing.Point(218, 147);
            this.btnDeletePayment.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletePayment.Name = "btnDeletePayment";
            this.btnDeletePayment.Size = new System.Drawing.Size(195, 42);
            this.btnDeletePayment.TabIndex = 3;
            this.btnDeletePayment.Text = "Xóa thanh toán";
            this.btnDeletePayment.UseVisualStyleBackColor = false;
            this.btnDeletePayment.Click += new System.EventHandler(this.btnDeletePayment_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.lblPaymentProgress);
            this.groupBox6.Controls.Add(this.progressPayment);
            this.groupBox6.Controls.Add(this.txtLastPaymentDate);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.txtRemainingAmount);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.txtTotalPaid);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Location = new System.Drawing.Point(8, 7);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(1253, 133);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tóm tắt thanh toán";
            // 
            // lblPaymentProgress
            // 
            this.lblPaymentProgress.AutoSize = true;
            this.lblPaymentProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentProgress.Location = new System.Drawing.Point(8, 96);
            this.lblPaymentProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentProgress.Name = "lblPaymentProgress";
            this.lblPaymentProgress.Size = new System.Drawing.Size(138, 18);
            this.lblPaymentProgress.TabIndex = 7;
            this.lblPaymentProgress.Text = "0% đã thanh toán";
            // 
            // progressPayment
            // 
            this.progressPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressPayment.Location = new System.Drawing.Point(200, 92);
            this.progressPayment.Margin = new System.Windows.Forms.Padding(4);
            this.progressPayment.Name = "progressPayment";
            this.progressPayment.Size = new System.Drawing.Size(1045, 28);
            this.progressPayment.TabIndex = 6;
            // 
            // txtLastPaymentDate
            // 
            this.txtLastPaymentDate.Location = new System.Drawing.Point(797, 60);
            this.txtLastPaymentDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastPaymentDate.Name = "txtLastPaymentDate";
            this.txtLastPaymentDate.ReadOnly = true;
            this.txtLastPaymentDate.Size = new System.Drawing.Size(199, 24);
            this.txtLastPaymentDate.TabIndex = 5;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(693, 64);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(90, 18);
            this.label26.TabIndex = 4;
            this.label26.Text = "TT gần nhất:";
            // 
            // txtRemainingAmount
            // 
            this.txtRemainingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemainingAmount.ForeColor = System.Drawing.Color.Red;
            this.txtRemainingAmount.Location = new System.Drawing.Point(480, 60);
            this.txtRemainingAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemainingAmount.Name = "txtRemainingAmount";
            this.txtRemainingAmount.ReadOnly = true;
            this.txtRemainingAmount.Size = new System.Drawing.Size(199, 24);
            this.txtRemainingAmount.TabIndex = 3;
            this.txtRemainingAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(347, 64);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 18);
            this.label25.TabIndex = 2;
            this.label25.Text = "Còn lại:";
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPaid.ForeColor = System.Drawing.Color.Green;
            this.txtTotalPaid.Location = new System.Drawing.Point(160, 60);
            this.txtTotalPaid.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.ReadOnly = true;
            this.txtTotalPaid.Size = new System.Drawing.Size(159, 24);
            this.txtTotalPaid.TabIndex = 1;
            this.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 64);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 18);
            this.label24.TabIndex = 0;
            this.label24.Text = "Đã thanh toán:";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.lblPaymentCount);
            this.groupBox5.Controls.Add(this.dgvPaymentHistory);
            this.groupBox5.Location = new System.Drawing.Point(8, 197);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(1253, 561);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lịch sử giao dịch";
            // 
            // lblPaymentCount
            // 
            this.lblPaymentCount.AutoSize = true;
            this.lblPaymentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentCount.Location = new System.Drawing.Point(8, 27);
            this.lblPaymentCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentCount.Name = "lblPaymentCount";
            this.lblPaymentCount.Size = new System.Drawing.Size(188, 18);
            this.lblPaymentCount.TabIndex = 1;
            this.lblPaymentCount.Text = "Chưa có thanh toán nào";
            // 
            // dgvPaymentHistory
            // 
            this.dgvPaymentHistory.AllowUserToAddRows = false;
            this.dgvPaymentHistory.AllowUserToDeleteRows = false;
            this.dgvPaymentHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaymentHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPaymentDate,
            this.colPaymentMethod,
            this.colAmount,
            this.colReferenceNumber,
            this.colPaymentStatus,
            this.colPaymentNotes});
            this.dgvPaymentHistory.Location = new System.Drawing.Point(8, 49);
            this.dgvPaymentHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPaymentHistory.MultiSelect = false;
            this.dgvPaymentHistory.Name = "dgvPaymentHistory";
            this.dgvPaymentHistory.ReadOnly = true;
            this.dgvPaymentHistory.RowHeadersVisible = false;
            this.dgvPaymentHistory.RowHeadersWidth = 51;
            this.dgvPaymentHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentHistory.Size = new System.Drawing.Size(1237, 505);
            this.dgvPaymentHistory.TabIndex = 0;
            this.dgvPaymentHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaymentHistory_CellDoubleClick);
            // 
            // colPaymentDate
            // 
            this.colPaymentDate.FillWeight = 120F;
            this.colPaymentDate.HeaderText = "Ngày thanh toán";
            this.colPaymentDate.MinimumWidth = 6;
            this.colPaymentDate.Name = "colPaymentDate";
            this.colPaymentDate.ReadOnly = true;
            // 
            // colPaymentMethod
            // 
            this.colPaymentMethod.HeaderText = "Phương thức";
            this.colPaymentMethod.MinimumWidth = 6;
            this.colPaymentMethod.Name = "colPaymentMethod";
            this.colPaymentMethod.ReadOnly = true;
            // 
            // colAmount
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N0";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle19;
            this.colAmount.HeaderText = "Số tiền";
            this.colAmount.MinimumWidth = 6;
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colReferenceNumber
            // 
            this.colReferenceNumber.FillWeight = 120F;
            this.colReferenceNumber.HeaderText = "Mã tham chiếu";
            this.colReferenceNumber.MinimumWidth = 6;
            this.colReferenceNumber.Name = "colReferenceNumber";
            this.colReferenceNumber.ReadOnly = true;
            // 
            // colPaymentStatus
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPaymentStatus.DefaultCellStyle = dataGridViewCellStyle20;
            this.colPaymentStatus.FillWeight = 80F;
            this.colPaymentStatus.HeaderText = "Trạng thái";
            this.colPaymentStatus.MinimumWidth = 6;
            this.colPaymentStatus.Name = "colPaymentStatus";
            this.colPaymentStatus.ReadOnly = true;
            // 
            // colPaymentNotes
            // 
            this.colPaymentNotes.FillWeight = 180F;
            this.colPaymentNotes.HeaderText = "Ghi chú";
            this.colPaymentNotes.MinimumWidth = 6;
            this.colPaymentNotes.Name = "colPaymentNotes";
            this.colPaymentNotes.ReadOnly = true;
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPayment.Location = new System.Drawing.Point(8, 148);
            this.btnAddPayment.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(202, 42);
            this.btnAddPayment.TabIndex = 0;
            this.btnAddPayment.Text = "Thêm thanh toán";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnPrintPreview);
            this.panel1.Controls.Add(this.btnPrintInvoice);
            this.panel1.Controls.Add(this.btnUpdateStatus);
            this.panel1.Location = new System.Drawing.Point(16, 822);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 62);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1167, 10);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 42);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1047, 10);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 42);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPreview.Location = new System.Drawing.Point(187, 10);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(160, 42);
            this.btnPrintPreview.TabIndex = 2;
            this.btnPrintPreview.Text = "Xem trước in";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintInvoice.Location = new System.Drawing.Point(20, 10);
            this.btnPrintInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(159, 42);
            this.btnPrintInvoice.TabIndex = 1;
            this.btnPrintInvoice.Text = "In hóa đơn";
            this.btnPrintInvoice.UseVisualStyleBackColor = true;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.Blue;
            this.btnUpdateStatus.Location = new System.Drawing.Point(360, 10);
            this.btnUpdateStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(208, 42);
            this.btnUpdateStatus.TabIndex = 0;
            this.btnUpdateStatus.Text = "Cập nhật trạng thái";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // frmOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 898);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabOrderDetail);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1327, 936);
            this.Name = "frmOrderDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết đơn hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabOrderDetail.ResumeLayout(false);
            this.tabPageOrderInfo.ResumeLayout(false);
            this.tabPageOrderInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.tabPageCustomerInfo.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPagePaymentHistory.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Các tab chính
        private System.Windows.Forms.TabControl tabOrderDetail;
        private System.Windows.Forms.TabPage tabPageOrderInfo;
        private System.Windows.Forms.TabPage tabPageCustomerInfo;
        private System.Windows.Forms.TabPage tabPagePaymentHistory;

        // Tab 1 - Thông tin đơn hàng
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Label lblItemCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;

        private System.Windows.Forms.TextBox txtOrderCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrderStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPaymentStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPaymentMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCreatedAt;
        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDiscountAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTaxAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label15;

        private System.Windows.Forms.TextBox txtNotes;

        // Các cột của dgvOrderItems
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountPerItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarrantyEnd;

        // Tab 2 - Thông tin khách hàng
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCustomerType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTotalSpent;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnViewCustomerHistory;

        // Tab 3 - Lịch sử thanh toán
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvPaymentHistory;
        private System.Windows.Forms.Label lblPaymentCount;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtTotalPaid;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtRemainingAmount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtLastPaymentDate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ProgressBar progressPayment;
        private System.Windows.Forms.Label lblPaymentProgress;
        private System.Windows.Forms.Button btnAddPayment;

        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferenceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentNotes;

        // Thanh công cụ dưới cùng
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnDeletePayment;
    }
}