namespace PhoneStore.Forms
{
    partial class frmSalesReport
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;

        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.ComboBox cboReportType;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.GroupBox gbSummary;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueValue;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblTotalOrdersValue;
        private System.Windows.Forms.Label lblAverageOrderValue;
        private System.Windows.Forms.Label lblAverageOrderValueValue;
        private System.Windows.Forms.Label lblTopProduct;
        private System.Windows.Forms.Label lblTopProductValue;

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDailyReport;
        private System.Windows.Forms.TabPage tabProductReport;
        private System.Windows.Forms.TabPage tabEmployeeReport;
        private System.Windows.Forms.TabPage tabCharts;

        private System.Windows.Forms.DataGridView dgvDailySales;
        private System.Windows.Forms.DataGridView dgvProductSales;
        private System.Windows.Forms.DataGridView dgvEmployeeSales;
        private System.Windows.Forms.Panel pnlChart;

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnPrint;
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDailyReport = new System.Windows.Forms.TabPage();
            this.dgvDailySales = new System.Windows.Forms.DataGridView();
            this.tabProductReport = new System.Windows.Forms.TabPage();
            this.dgvProductSales = new System.Windows.Forms.DataGridView();
            this.tabEmployeeReport = new System.Windows.Forms.TabPage();
            this.dgvEmployeeSales = new System.Windows.Forms.DataGridView();
            this.tabCharts = new System.Windows.Forms.TabPage();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.lblTopProductValue = new System.Windows.Forms.Label();
            this.lblTopProduct = new System.Windows.Forms.Label();
            this.lblAverageOrderValueValue = new System.Windows.Forms.Label();
            this.lblAverageOrderValue = new System.Windows.Forms.Label();
            this.lblTotalOrdersValue = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblTotalRevenueValue = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabDailyReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailySales)).BeginInit();
            this.tabProductReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSales)).BeginInit();
            this.tabEmployeeReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeSales)).BeginInit();
            this.tabCharts.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.gbSummary.SuspendLayout();
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
            this.pnlMain.Size = new System.Drawing.Size(1600, 960);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlButtons);
            this.pnlBottom.Controls.Add(this.tabMain);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(11, 224);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1578, 725);
            this.pnlBottom.TabIndex = 1;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnPrint);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 661);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1578, 64);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1417, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 37);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(23, 16);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(137, 37);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "In báo cáo";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabDailyReport);
            this.tabMain.Controls.Add(this.tabProductReport);
            this.tabMain.Controls.Add(this.tabEmployeeReport);
            this.tabMain.Controls.Add(this.tabCharts);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1578, 661);
            this.tabMain.TabIndex = 0;
            // 
            // tabDailyReport
            // 
            this.tabDailyReport.Controls.Add(this.dgvDailySales);
            this.tabDailyReport.Location = new System.Drawing.Point(4, 32);
            this.tabDailyReport.Name = "tabDailyReport";
            this.tabDailyReport.Padding = new System.Windows.Forms.Padding(11);
            this.tabDailyReport.Size = new System.Drawing.Size(1570, 625);
            this.tabDailyReport.TabIndex = 0;
            this.tabDailyReport.Text = "Báo cáo theo ngày";
            this.tabDailyReport.UseVisualStyleBackColor = true;
            // 
            // dgvDailySales
            // 
            this.dgvDailySales.AllowUserToAddRows = false;
            this.dgvDailySales.AllowUserToDeleteRows = false;
            this.dgvDailySales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDailySales.BackgroundColor = System.Drawing.Color.White;
            this.dgvDailySales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDailySales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailySales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDailySales.Location = new System.Drawing.Point(11, 11);
            this.dgvDailySales.Name = "dgvDailySales";
            this.dgvDailySales.ReadOnly = true;
            this.dgvDailySales.RowHeadersWidth = 51;
            this.dgvDailySales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDailySales.Size = new System.Drawing.Size(1548, 603);
            this.dgvDailySales.TabIndex = 0;
            // 
            // tabProductReport
            // 
            this.tabProductReport.Controls.Add(this.dgvProductSales);
            this.tabProductReport.Location = new System.Drawing.Point(4, 32);
            this.tabProductReport.Name = "tabProductReport";
            this.tabProductReport.Padding = new System.Windows.Forms.Padding(11);
            this.tabProductReport.Size = new System.Drawing.Size(1570, 625);
            this.tabProductReport.TabIndex = 1;
            this.tabProductReport.Text = "Báo cáo sản phẩm";
            this.tabProductReport.UseVisualStyleBackColor = true;
            // 
            // dgvProductSales
            // 
            this.dgvProductSales.AllowUserToAddRows = false;
            this.dgvProductSales.AllowUserToDeleteRows = false;
            this.dgvProductSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProductSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductSales.Location = new System.Drawing.Point(11, 11);
            this.dgvProductSales.Name = "dgvProductSales";
            this.dgvProductSales.ReadOnly = true;
            this.dgvProductSales.RowHeadersWidth = 51;
            this.dgvProductSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductSales.Size = new System.Drawing.Size(1548, 603);
            this.dgvProductSales.TabIndex = 0;
            // 
            // tabEmployeeReport
            // 
            this.tabEmployeeReport.Controls.Add(this.dgvEmployeeSales);
            this.tabEmployeeReport.Location = new System.Drawing.Point(4, 32);
            this.tabEmployeeReport.Name = "tabEmployeeReport";
            this.tabEmployeeReport.Padding = new System.Windows.Forms.Padding(11);
            this.tabEmployeeReport.Size = new System.Drawing.Size(1570, 625);
            this.tabEmployeeReport.TabIndex = 2;
            this.tabEmployeeReport.Text = "Báo cáo nhân viên";
            this.tabEmployeeReport.UseVisualStyleBackColor = true;
            // 
            // dgvEmployeeSales
            // 
            this.dgvEmployeeSales.AllowUserToAddRows = false;
            this.dgvEmployeeSales.AllowUserToDeleteRows = false;
            this.dgvEmployeeSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployeeSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployeeSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEmployeeSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployeeSales.Location = new System.Drawing.Point(11, 11);
            this.dgvEmployeeSales.Name = "dgvEmployeeSales";
            this.dgvEmployeeSales.ReadOnly = true;
            this.dgvEmployeeSales.RowHeadersWidth = 51;
            this.dgvEmployeeSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeSales.Size = new System.Drawing.Size(1548, 603);
            this.dgvEmployeeSales.TabIndex = 0;
            // 
            // tabCharts
            // 
            this.tabCharts.Controls.Add(this.pnlChart);
            this.tabCharts.Location = new System.Drawing.Point(4, 32);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.Padding = new System.Windows.Forms.Padding(11);
            this.tabCharts.Size = new System.Drawing.Size(1570, 625);
            this.tabCharts.TabIndex = 3;
            this.tabCharts.Text = "Biểu đồ";
            this.tabCharts.UseVisualStyleBackColor = true;
            // 
            // pnlChart
            // 
            this.pnlChart.AutoScroll = true;
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(11, 11);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(1548, 603);
            this.pnlChart.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.gbSummary);
            this.pnlTop.Controls.Add(this.gbFilters);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(11, 11);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1578, 213);
            this.pnlTop.TabIndex = 0;
            // 
            // gbSummary
            // 
            this.gbSummary.Controls.Add(this.lblTopProductValue);
            this.gbSummary.Controls.Add(this.lblTopProduct);
            this.gbSummary.Controls.Add(this.lblAverageOrderValueValue);
            this.gbSummary.Controls.Add(this.lblAverageOrderValue);
            this.gbSummary.Controls.Add(this.lblTotalOrdersValue);
            this.gbSummary.Controls.Add(this.lblTotalOrders);
            this.gbSummary.Controls.Add(this.lblTotalRevenueValue);
            this.gbSummary.Controls.Add(this.lblTotalRevenue);
            this.gbSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbSummary.Location = new System.Drawing.Point(686, 0);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(892, 213);
            this.gbSummary.TabIndex = 1;
            this.gbSummary.TabStop = false;
            this.gbSummary.Text = "Tổng quan";
            // 
            // lblTopProductValue
            // 
            this.lblTopProductValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTopProductValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTopProductValue.Location = new System.Drawing.Point(229, 177);
            this.lblTopProductValue.Name = "lblTopProductValue";
            this.lblTopProductValue.Size = new System.Drawing.Size(633, 22);
            this.lblTopProductValue.TabIndex = 7;
            this.lblTopProductValue.Text = "Chưa có dữ liệu";
            this.lblTopProductValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTopProduct
            // 
            this.lblTopProduct.AutoSize = true;
            this.lblTopProduct.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTopProduct.Location = new System.Drawing.Point(34, 171);
            this.lblTopProduct.Name = "lblTopProduct";
            this.lblTopProduct.Size = new System.Drawing.Size(186, 28);
            this.lblTopProduct.TabIndex = 6;
            this.lblTopProduct.Text = "Sản phẩm bán chạy:";
            // 
            // lblAverageOrderValueValue
            // 
            this.lblAverageOrderValueValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAverageOrderValueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.lblAverageOrderValueValue.Location = new System.Drawing.Point(246, 128);
            this.lblAverageOrderValueValue.Name = "lblAverageOrderValueValue";
            this.lblAverageOrderValueValue.Size = new System.Drawing.Size(628, 28);
            this.lblAverageOrderValueValue.TabIndex = 5;
            this.lblAverageOrderValueValue.Text = "0đ";
            this.lblAverageOrderValueValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAverageOrderValue
            // 
            this.lblAverageOrderValue.AutoSize = true;
            this.lblAverageOrderValue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAverageOrderValue.Location = new System.Drawing.Point(34, 128);
            this.lblAverageOrderValue.Name = "lblAverageOrderValue";
            this.lblAverageOrderValue.Size = new System.Drawing.Size(206, 28);
            this.lblAverageOrderValue.TabIndex = 4;
            this.lblAverageOrderValue.Text = "Giá trị đơn trung bình:";
            // 
            // lblTotalOrdersValue
            // 
            this.lblTotalOrdersValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalOrdersValue.Location = new System.Drawing.Point(229, 83);
            this.lblTotalOrdersValue.Name = "lblTotalOrdersValue";
            this.lblTotalOrdersValue.Size = new System.Drawing.Size(616, 27);
            this.lblTotalOrdersValue.TabIndex = 3;
            this.lblTotalOrdersValue.Text = "0";
            this.lblTotalOrdersValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalOrders.Location = new System.Drawing.Point(34, 85);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(150, 28);
            this.lblTotalOrders.TabIndex = 2;
            this.lblTotalOrders.Text = "Tổng đơn hàng:";
            // 
            // lblTotalRevenueValue
            // 
            this.lblTotalRevenueValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTotalRevenueValue.Location = new System.Drawing.Point(229, 37);
            this.lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            this.lblTotalRevenueValue.Size = new System.Drawing.Size(663, 32);
            this.lblTotalRevenueValue.TabIndex = 1;
            this.lblTotalRevenueValue.Text = "0đ";
            this.lblTotalRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalRevenue.Location = new System.Drawing.Point(34, 43);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(156, 28);
            this.lblTotalRevenue.TabIndex = 0;
            this.lblTotalRevenue.Text = "Tổng doanh thu:";
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnExport);
            this.gbFilters.Controls.Add(this.btnGenerate);
            this.gbFilters.Controls.Add(this.dtpToDate);
            this.gbFilters.Controls.Add(this.lblToDate);
            this.gbFilters.Controls.Add(this.dtpFromDate);
            this.gbFilters.Controls.Add(this.lblFromDate);
            this.gbFilters.Controls.Add(this.cboReportType);
            this.gbFilters.Controls.Add(this.lblReportType);
            this.gbFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbFilters.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbFilters.Location = new System.Drawing.Point(0, 0);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(686, 213);
            this.gbFilters.TabIndex = 0;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Bộ lọc báo cáo";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(171, 119);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(114, 37);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(23, 119);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(137, 37);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Tạo báo cáo";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(411, 59);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(137, 27);
            this.dtpToDate.TabIndex = 5;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblToDate.Location = new System.Drawing.Point(411, 37);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(75, 20);
            this.lblToDate.TabIndex = 4;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(251, 59);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(137, 27);
            this.dtpFromDate.TabIndex = 3;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFromDate.Location = new System.Drawing.Point(251, 37);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(65, 20);
            this.lblFromDate.TabIndex = 2;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // cboReportType
            // 
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "Báo cáo theo ngày",
            "Báo cáo theo tuần",
            "Báo cáo theo tháng",
            "Báo cáo tùy chỉnh"});
            this.cboReportType.Location = new System.Drawing.Point(23, 59);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(205, 28);
            this.cboReportType.TabIndex = 1;
            this.cboReportType.SelectedIndexChanged += new System.EventHandler(this.cboReportType_SelectedIndexChanged);
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReportType.Location = new System.Drawing.Point(23, 37);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(98, 20);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "Loại báo cáo:";
            // 
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 960);
            this.Controls.Add(this.pnlMain);
            this.MinimumSize = new System.Drawing.Size(1369, 744);
            this.Name = "frmSalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabDailyReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailySales)).EndInit();
            this.tabProductReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSales)).EndInit();
            this.tabEmployeeReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeSales)).EndInit();
            this.tabCharts.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.gbSummary.ResumeLayout(false);
            this.gbSummary.PerformLayout();
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}