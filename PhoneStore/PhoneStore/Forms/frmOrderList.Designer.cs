namespace PhoneStore.Forms
{
    partial class frmOrderList
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;

        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.ComboBox cboOrderStatus;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.ComboBox cboPaymentStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.GroupBox gbOrderList;
        private System.Windows.Forms.DataGridView dgvOrders;

        private System.Windows.Forms.GroupBox gbOrderDetails;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Label lblOrderInfo;
        private System.Windows.Forms.TextBox txtOrderInfo;

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnViewOrder;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnPrintOrder;
        private System.Windows.Forms.Button btnClose;

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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrintOrder = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.gbOrderDetails = new System.Windows.Forms.GroupBox();
            this.txtOrderInfo = new System.Windows.Forms.TextBox();
            this.lblOrderInfo = new System.Windows.Forms.Label();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.gbOrderList = new System.Windows.Forms.GroupBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboPaymentStatus = new System.Windows.Forms.ComboBox();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.cboOrderStatus = new System.Windows.Forms.ComboBox();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.gbOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.gbOrderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(11);
            this.pnlMain.Size = new System.Drawing.Size(1600, 853);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlButtons);
            this.pnlBottom.Controls.Add(this.gbOrderDetails);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(11, 491);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1578, 351);
            this.pnlBottom.TabIndex = 1;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnExportCSV);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnPrintOrder);
            this.pnlButtons.Controls.Add(this.btnUpdateStatus);
            this.pnlButtons.Controls.Add(this.btnViewOrder);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 298);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1578, 53);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.BackColor = System.Drawing.Color.Red;
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExportCSV.ForeColor = System.Drawing.Color.White;
            this.btnExportCSV.Location = new System.Drawing.Point(441, 11);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(114, 37);
            this.btnExportCSV.TabIndex = 4;
            this.btnExportCSV.Text = "Xuất CSV";
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1440, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 37);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrintOrder
            // 
            this.btnPrintOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnPrintOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintOrder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPrintOrder.ForeColor = System.Drawing.Color.White;
            this.btnPrintOrder.Location = new System.Drawing.Point(321, 11);
            this.btnPrintOrder.Name = "btnPrintOrder";
            this.btnPrintOrder.Size = new System.Drawing.Size(114, 37);
            this.btnPrintOrder.TabIndex = 2;
            this.btnPrintOrder.Text = "In đơn hàng";
            this.btnPrintOrder.UseVisualStyleBackColor = false;
            this.btnPrintOrder.Click += new System.EventHandler(this.btnPrintOrder_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(166, 11);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(149, 37);
            this.btnUpdateStatus.TabIndex = 1;
            this.btnUpdateStatus.Text = "Cập nhật TT";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnViewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewOrder.ForeColor = System.Drawing.Color.White;
            this.btnViewOrder.Location = new System.Drawing.Point(23, 11);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(137, 37);
            this.btnViewOrder.TabIndex = 0;
            this.btnViewOrder.Text = "Xem chi tiết";
            this.btnViewOrder.UseVisualStyleBackColor = false;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            // 
            // gbOrderDetails
            // 
            this.gbOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrderDetails.Controls.Add(this.txtOrderInfo);
            this.gbOrderDetails.Controls.Add(this.lblOrderInfo);
            this.gbOrderDetails.Controls.Add(this.dgvOrderDetails);
            this.gbOrderDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbOrderDetails.Location = new System.Drawing.Point(0, 0);
            this.gbOrderDetails.Name = "gbOrderDetails";
            this.gbOrderDetails.Size = new System.Drawing.Size(1578, 288);
            this.gbOrderDetails.TabIndex = 0;
            this.gbOrderDetails.TabStop = false;
            this.gbOrderDetails.Text = "Chi tiết đơn hàng";
            // 
            // txtOrderInfo
            // 
            this.txtOrderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtOrderInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOrderInfo.Location = new System.Drawing.Point(1063, 48);
            this.txtOrderInfo.Multiline = true;
            this.txtOrderInfo.Name = "txtOrderInfo";
            this.txtOrderInfo.ReadOnly = true;
            this.txtOrderInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOrderInfo.Size = new System.Drawing.Size(491, 224);
            this.txtOrderInfo.TabIndex = 2;
            // 
            // lblOrderInfo
            // 
            this.lblOrderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderInfo.AutoSize = true;
            this.lblOrderInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrderInfo.Location = new System.Drawing.Point(1063, 27);
            this.lblOrderInfo.Name = "lblOrderInfo";
            this.lblOrderInfo.Size = new System.Drawing.Size(142, 20);
            this.lblOrderInfo.TabIndex = 1;
            this.lblOrderInfo.Text = "Thông tin đơn hàng:";
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.AllowUserToDeleteRows = false;
            this.dgvOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(11, 27);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.RowHeadersWidth = 51;
            this.dgvOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderDetails.Size = new System.Drawing.Size(1029, 245);
            this.dgvOrderDetails.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.gbOrderList);
            this.pnlTop.Controls.Add(this.gbFilters);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(11, 11);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1578, 480);
            this.pnlTop.TabIndex = 0;
            // 
            // gbOrderList
            // 
            this.gbOrderList.Controls.Add(this.dgvOrders);
            this.gbOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOrderList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbOrderList.Location = new System.Drawing.Point(0, 107);
            this.gbOrderList.Name = "gbOrderList";
            this.gbOrderList.Size = new System.Drawing.Size(1578, 373);
            this.gbOrderList.TabIndex = 1;
            this.gbOrderList.TabStop = false;
            this.gbOrderList.Text = "Danh sách đơn hàng";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(3, 26);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1572, 344);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.cboEmployee);
            this.gbFilters.Controls.Add(this.lblEmployee);
            this.gbFilters.Controls.Add(this.btnRefresh);
            this.gbFilters.Controls.Add(this.btnSearch);
            this.gbFilters.Controls.Add(this.cboPaymentStatus);
            this.gbFilters.Controls.Add(this.lblPaymentStatus);
            this.gbFilters.Controls.Add(this.cboOrderStatus);
            this.gbFilters.Controls.Add(this.lblOrderStatus);
            this.gbFilters.Controls.Add(this.dtpToDate);
            this.gbFilters.Controls.Add(this.lblToDate);
            this.gbFilters.Controls.Add(this.dtpFromDate);
            this.gbFilters.Controls.Add(this.lblFromDate);
            this.gbFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFilters.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbFilters.Location = new System.Drawing.Point(0, 0);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(1578, 107);
            this.gbFilters.TabIndex = 0;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Bộ lọc tìm kiếm";
            // 
            // cboEmployee
            // 
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Location = new System.Drawing.Point(733, 53);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(228, 28);
            this.cboEmployee.TabIndex = 11;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmployee.Location = new System.Drawing.Point(733, 31);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(78, 20);
            this.lblEmployee.TabIndex = 10;
            this.lblEmployee.Text = "Nhân viên:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1104, 54);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(91, 29);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1001, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 29);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboPaymentStatus
            // 
            this.cboPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboPaymentStatus.FormattingEnabled = true;
            this.cboPaymentStatus.Items.AddRange(new object[] {
            "Tất cả",
            "Chưa thanh toán",
            "Đã thanh toán",
            "Thanh toán một phần",
            "Đã hoàn tiền"});
            this.cboPaymentStatus.Location = new System.Drawing.Point(537, 53);
            this.cboPaymentStatus.Name = "cboPaymentStatus";
            this.cboPaymentStatus.Size = new System.Drawing.Size(171, 28);
            this.cboPaymentStatus.TabIndex = 7;
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentStatus.Location = new System.Drawing.Point(537, 32);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(153, 20);
            this.lblPaymentStatus.TabIndex = 6;
            this.lblPaymentStatus.Text = "Trạng thái thanh toán:";
            // 
            // cboOrderStatus
            // 
            this.cboOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboOrderStatus.FormattingEnabled = true;
            this.cboOrderStatus.Items.AddRange(new object[] {
            "Tất cả",
            "Đang xử lý",
            "Hoàn thành",
            "Đã hủy",
            "Đã trả hàng"});
            this.cboOrderStatus.Location = new System.Drawing.Point(343, 53);
            this.cboOrderStatus.Name = "cboOrderStatus";
            this.cboOrderStatus.Size = new System.Drawing.Size(171, 28);
            this.cboOrderStatus.TabIndex = 5;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrderStatus.Location = new System.Drawing.Point(343, 32);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(145, 20);
            this.lblOrderStatus.TabIndex = 4;
            this.lblOrderStatus.Text = "Trạng thái đơn hàng:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(183, 53);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(137, 27);
            this.dtpToDate.TabIndex = 3;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblToDate.Location = new System.Drawing.Point(183, 32);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(75, 20);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(23, 53);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(137, 27);
            this.dtpFromDate.TabIndex = 1;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFromDate.Location = new System.Drawing.Point(23, 32);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(65, 20);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // frmOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 853);
            this.Controls.Add(this.pnlMain);
            this.MinimumSize = new System.Drawing.Size(1140, 637);
            this.Name = "frmOrderList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách đơn hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOrderList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.gbOrderDetails.ResumeLayout(false);
            this.gbOrderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.gbOrderList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.Label lblEmployee;
    }
}