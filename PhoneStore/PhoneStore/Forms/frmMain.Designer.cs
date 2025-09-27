using System;
using System.Windows.Forms;

namespace PhoneStore.Forms
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuProducts;
        private System.Windows.Forms.ToolStripMenuItem mnuProductList;
        private System.Windows.Forms.ToolStripMenuItem mnuProductCategories;
        private System.Windows.Forms.ToolStripMenuItem mnuProductBrands;
        private System.Windows.Forms.ToolStripMenuItem mnuInventory;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomers;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomerList;
        private System.Windows.Forms.ToolStripMenuItem mnuVIPCustomers;
        private System.Windows.Forms.ToolStripMenuItem mnuOrders;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateOrder;
        private System.Windows.Forms.ToolStripMenuItem mnuOrderList;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuSalesReport;
        private System.Windows.Forms.ToolStripMenuItem mnuInventoryReport;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomerReport;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblDateTime;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.GroupBox gbTodayStats;
        private System.Windows.Forms.Label lblTodayRevenue;
        private System.Windows.Forms.Label lblTodayOrders;
        private System.Windows.Forms.GroupBox gbMonthStats;
        private System.Windows.Forms.Label lblMonthRevenue;
        private System.Windows.Forms.Label lblMonthOrders;
        private GroupBox gbQuickActions;
        private Button btnCreateOrder;
        private Button btnViewProducts;
        private Button btnViewCustomers;
        private Timer timerDateTime;

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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProductList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProductCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProductBrands = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomerList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVIPCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrderList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalesReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInventoryReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomerReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.btnRefreshStats = new System.Windows.Forms.Button();
            this.gbQuickActions = new System.Windows.Forms.GroupBox();
            this.btnViewCustomers = new System.Windows.Forms.Button();
            this.btnViewProducts = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.gbMonthStats = new System.Windows.Forms.GroupBox();
            this.lblMonthOrders = new System.Windows.Forms.Label();
            this.lblMonthRevenue = new System.Windows.Forms.Label();
            this.gbTodayStats = new System.Windows.Forms.GroupBox();
            this.lblTodayOrders = new System.Windows.Forms.Label();
            this.lblTodayRevenue = new System.Windows.Forms.Label();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.mnuPromotion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPromotionList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.gbQuickActions.SuspendLayout();
            this.gbMonthStats.SuspendLayout();
            this.gbTodayStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuProducts,
            this.mnuCustomers,
            this.mnuPromotion,
            this.mnuOrders,
            this.mnuReports,
            this.mnuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1371, 31);
            this.menuStrip.TabIndex = 0;
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChangePassword,
            this.mnuLogout,
            this.mnuExit});
            this.mnuSystem.ForeColor = System.Drawing.Color.White;
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(96, 27);
            this.mnuSystem.Text = "Hệ thống";
            // 
            // mnuChangePassword
            // 
            this.mnuChangePassword.Name = "mnuChangePassword";
            this.mnuChangePassword.Size = new System.Drawing.Size(197, 28);
            this.mnuChangePassword.Text = "Đổi mật khẩu";
            this.mnuChangePassword.Click += new System.EventHandler(this.mnuChangePassword_Click);
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(197, 28);
            this.mnuLogout.Text = "Đăng xuất";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(197, 28);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuProducts
            // 
            this.mnuProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProductList,
            this.mnuProductCategories,
            this.mnuProductBrands,
            this.mnuInventory});
            this.mnuProducts.ForeColor = System.Drawing.Color.White;
            this.mnuProducts.Name = "mnuProducts";
            this.mnuProducts.Size = new System.Drawing.Size(101, 27);
            this.mnuProducts.Text = "Sản phẩm";
            // 
            // mnuProductList
            // 
            this.mnuProductList.Name = "mnuProductList";
            this.mnuProductList.Size = new System.Drawing.Size(254, 28);
            this.mnuProductList.Text = "Danh sách sản phẩm";
            this.mnuProductList.Click += new System.EventHandler(this.mnuProductList_Click);
            // 
            // mnuProductCategories
            // 
            this.mnuProductCategories.Name = "mnuProductCategories";
            this.mnuProductCategories.Size = new System.Drawing.Size(254, 28);
            this.mnuProductCategories.Text = "Danh mục";
            this.mnuProductCategories.Click += new System.EventHandler(this.mnuProductCategories_Click);
            // 
            // mnuProductBrands
            // 
            this.mnuProductBrands.Name = "mnuProductBrands";
            this.mnuProductBrands.Size = new System.Drawing.Size(254, 28);
            this.mnuProductBrands.Text = "Thương hiệu";
            this.mnuProductBrands.Click += new System.EventHandler(this.mnuProductBrands_Click);
            // 
            // mnuInventory
            // 
            this.mnuInventory.Name = "mnuInventory";
            this.mnuInventory.Size = new System.Drawing.Size(254, 28);
            this.mnuInventory.Text = "Quản lý tồn kho";
            this.mnuInventory.Click += new System.EventHandler(this.mnuInventory_Click);
            // 
            // mnuCustomers
            // 
            this.mnuCustomers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCustomerList,
            this.mnuVIPCustomers});
            this.mnuCustomers.ForeColor = System.Drawing.Color.White;
            this.mnuCustomers.Name = "mnuCustomers";
            this.mnuCustomers.Size = new System.Drawing.Size(115, 27);
            this.mnuCustomers.Text = "Khách hàng";
            // 
            // mnuCustomerList
            // 
            this.mnuCustomerList.Name = "mnuCustomerList";
            this.mnuCustomerList.Size = new System.Drawing.Size(268, 28);
            this.mnuCustomerList.Text = "Danh sách khách hàng";
            this.mnuCustomerList.Click += new System.EventHandler(this.mnuCustomerList_Click);
            // 
            // mnuVIPCustomers
            // 
            this.mnuVIPCustomers.Name = "mnuVIPCustomers";
            this.mnuVIPCustomers.Size = new System.Drawing.Size(268, 28);
            this.mnuVIPCustomers.Text = "Khách hàng VIP";
            this.mnuVIPCustomers.Click += new System.EventHandler(this.mnuVIPCustomers_Click);
            // 
            // mnuOrders
            // 
            this.mnuOrders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateOrder,
            this.mnuOrderList});
            this.mnuOrders.ForeColor = System.Drawing.Color.White;
            this.mnuOrders.Name = "mnuOrders";
            this.mnuOrders.Size = new System.Drawing.Size(100, 27);
            this.mnuOrders.Text = "Đơn hàng";
            // 
            // mnuCreateOrder
            // 
            this.mnuCreateOrder.Name = "mnuCreateOrder";
            this.mnuCreateOrder.Size = new System.Drawing.Size(253, 28);
            this.mnuCreateOrder.Text = "Tạo đơn hàng";
            this.mnuCreateOrder.Click += new System.EventHandler(this.mnuCreateOrder_Click);
            // 
            // mnuOrderList
            // 
            this.mnuOrderList.Name = "mnuOrderList";
            this.mnuOrderList.Size = new System.Drawing.Size(253, 28);
            this.mnuOrderList.Text = "Danh sách đơn hàng";
            this.mnuOrderList.Click += new System.EventHandler(this.mnuOrderList_Click);
            // 
            // mnuReports
            // 
            this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalesReport,
            this.mnuInventoryReport,
            this.mnuCustomerReport});
            this.mnuReports.ForeColor = System.Drawing.Color.White;
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(85, 27);
            this.mnuReports.Text = "Báo cáo";
            // 
            // mnuSalesReport
            // 
            this.mnuSalesReport.Name = "mnuSalesReport";
            this.mnuSalesReport.Size = new System.Drawing.Size(249, 28);
            this.mnuSalesReport.Text = "Báo cáo bán hàng";
            this.mnuSalesReport.Click += new System.EventHandler(this.mnuSalesReport_Click);
            // 
            // mnuInventoryReport
            // 
            this.mnuInventoryReport.Name = "mnuInventoryReport";
            this.mnuInventoryReport.Size = new System.Drawing.Size(249, 28);
            this.mnuInventoryReport.Text = "Báo cáo tồn kho";
            this.mnuInventoryReport.Click += new System.EventHandler(this.mnuInventoryReport_Click);
            // 
            // mnuCustomerReport
            // 
            this.mnuCustomerReport.Name = "mnuCustomerReport";
            this.mnuCustomerReport.Size = new System.Drawing.Size(249, 28);
            this.mnuCustomerReport.Text = "Báo cáo khách hàng";
            this.mnuCustomerReport.Click += new System.EventHandler(this.mnuCustomerReport_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.ForeColor = System.Drawing.Color.White;
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(87, 27);
            this.mnuHelp.Text = "Trợ giúp";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(224, 28);
            this.mnuAbout.Text = "Giới thiệu";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser,
            this.lblDateTime,
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 797);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1371, 26);
            this.statusStrip.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(45, 20);
            this.lblUser.Text = "User: ";
            // 
            // lblDateTime
            // 
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(1241, 20);
            this.lblDateTime.Spring = true;
            this.lblDateTime.Text = "DateTime";
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(68, 20);
            this.lblStatus.Text = "Sẵn sàng";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlMain.Controls.Add(this.pnlDashboard);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 31);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(11);
            this.pnlMain.Size = new System.Drawing.Size(1371, 766);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.btnRefreshStats);
            this.pnlDashboard.Controls.Add(this.gbQuickActions);
            this.pnlDashboard.Controls.Add(this.gbMonthStats);
            this.pnlDashboard.Controls.Add(this.gbTodayStats);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(11, 11);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(1349, 744);
            this.pnlDashboard.TabIndex = 0;
            // 
            // btnRefreshStats
            // 
            this.btnRefreshStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRefreshStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshStats.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRefreshStats.ForeColor = System.Drawing.Color.White;
            this.btnRefreshStats.Location = new System.Drawing.Point(770, 353);
            this.btnRefreshStats.Name = "btnRefreshStats";
            this.btnRefreshStats.Size = new System.Drawing.Size(156, 37);
            this.btnRefreshStats.TabIndex = 3;
            this.btnRefreshStats.Text = "Làm mới";
            this.btnRefreshStats.UseVisualStyleBackColor = false;
            this.btnRefreshStats.Click += new System.EventHandler(this.btnRefreshStats_Click);
            // 
            // gbQuickActions
            // 
            this.gbQuickActions.Controls.Add(this.btnViewCustomers);
            this.gbQuickActions.Controls.Add(this.btnViewProducts);
            this.gbQuickActions.Controls.Add(this.btnCreateOrder);
            this.gbQuickActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbQuickActions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gbQuickActions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.gbQuickActions.Location = new System.Drawing.Point(949, 0);
            this.gbQuickActions.Name = "gbQuickActions";
            this.gbQuickActions.Size = new System.Drawing.Size(400, 744);
            this.gbQuickActions.TabIndex = 2;
            this.gbQuickActions.TabStop = false;
            this.gbQuickActions.Text = "Thao tác nhanh";
            // 
            // btnViewCustomers
            // 
            this.btnViewCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnViewCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCustomers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnViewCustomers.ForeColor = System.Drawing.Color.White;
            this.btnViewCustomers.Location = new System.Drawing.Point(210, 80);
            this.btnViewCustomers.Name = "btnViewCustomers";
            this.btnViewCustomers.Size = new System.Drawing.Size(156, 37);
            this.btnViewCustomers.TabIndex = 2;
            this.btnViewCustomers.Text = "Quản lý khách hàng";
            this.btnViewCustomers.UseVisualStyleBackColor = false;
            this.btnViewCustomers.Click += new System.EventHandler(this.btnViewCustomers_Click);
            // 
            // btnViewProducts
            // 
            this.btnViewProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnViewProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewProducts.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnViewProducts.ForeColor = System.Drawing.Color.White;
            this.btnViewProducts.Location = new System.Drawing.Point(23, 80);
            this.btnViewProducts.Name = "btnViewProducts";
            this.btnViewProducts.Size = new System.Drawing.Size(181, 37);
            this.btnViewProducts.TabIndex = 1;
            this.btnViewProducts.Text = "Quản lý sản phẩm";
            this.btnViewProducts.UseVisualStyleBackColor = false;
            this.btnViewProducts.Click += new System.EventHandler(this.btnViewProducts_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCreateOrder.ForeColor = System.Drawing.Color.White;
            this.btnCreateOrder.Location = new System.Drawing.Point(23, 32);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(343, 37);
            this.btnCreateOrder.TabIndex = 0;
            this.btnCreateOrder.Text = "Tạo đơn hàng mới";
            this.btnCreateOrder.UseVisualStyleBackColor = false;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // gbMonthStats
            // 
            this.gbMonthStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMonthStats.Controls.Add(this.lblMonthOrders);
            this.gbMonthStats.Controls.Add(this.lblMonthRevenue);
            this.gbMonthStats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gbMonthStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.gbMonthStats.Location = new System.Drawing.Point(23, 187);
            this.gbMonthStats.Name = "gbMonthStats";
            this.gbMonthStats.Size = new System.Drawing.Size(903, 160);
            this.gbMonthStats.TabIndex = 1;
            this.gbMonthStats.TabStop = false;
            this.gbMonthStats.Text = "Thống kê tháng này";
            // 
            // lblMonthOrders
            // 
            this.lblMonthOrders.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblMonthOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMonthOrders.Location = new System.Drawing.Point(23, 85);
            this.lblMonthOrders.Name = "lblMonthOrders";
            this.lblMonthOrders.Size = new System.Drawing.Size(343, 27);
            this.lblMonthOrders.TabIndex = 1;
            this.lblMonthOrders.Text = "Đơn hàng: 0";
            // 
            // lblMonthRevenue
            // 
            this.lblMonthRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonthRevenue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblMonthRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblMonthRevenue.Location = new System.Drawing.Point(23, 43);
            this.lblMonthRevenue.Name = "lblMonthRevenue";
            this.lblMonthRevenue.Size = new System.Drawing.Size(846, 32);
            this.lblMonthRevenue.TabIndex = 0;
            this.lblMonthRevenue.Text = "Doanh thu: 0đ";
            // 
            // gbTodayStats
            // 
            this.gbTodayStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTodayStats.Controls.Add(this.lblTodayOrders);
            this.gbTodayStats.Controls.Add(this.lblTodayRevenue);
            this.gbTodayStats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gbTodayStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.gbTodayStats.Location = new System.Drawing.Point(23, 21);
            this.gbTodayStats.Name = "gbTodayStats";
            this.gbTodayStats.Size = new System.Drawing.Size(903, 160);
            this.gbTodayStats.TabIndex = 0;
            this.gbTodayStats.TabStop = false;
            this.gbTodayStats.Text = "Thống kê hôm nay";
            // 
            // lblTodayOrders
            // 
            this.lblTodayOrders.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTodayOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTodayOrders.Location = new System.Drawing.Point(23, 85);
            this.lblTodayOrders.Name = "lblTodayOrders";
            this.lblTodayOrders.Size = new System.Drawing.Size(343, 27);
            this.lblTodayOrders.TabIndex = 1;
            this.lblTodayOrders.Text = "Đơn hàng: 0";
            // 
            // lblTodayRevenue
            // 
            this.lblTodayRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTodayRevenue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTodayRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTodayRevenue.Location = new System.Drawing.Point(23, 43);
            this.lblTodayRevenue.Name = "lblTodayRevenue";
            this.lblTodayRevenue.Size = new System.Drawing.Size(846, 32);
            this.lblTodayRevenue.TabIndex = 0;
            this.lblTodayRevenue.Text = "Doanh thu: 0đ";
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // mnuPromotion
            // 
            this.mnuPromotion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPromotionList});
            this.mnuPromotion.ForeColor = System.Drawing.Color.White;
            this.mnuPromotion.Name = "mnuPromotion";
            this.mnuPromotion.Size = new System.Drawing.Size(114, 27);
            this.mnuPromotion.Text = "Khuyến mãi";
            // 
            // mnuPromotionList
            // 
            this.mnuPromotionList.Name = "mnuPromotionList";
            this.mnuPromotionList.Size = new System.Drawing.Size(267, 28);
            this.mnuPromotionList.Text = "Danh sách khuyến mãi";
            this.mnuPromotionList.Click += new System.EventHandler(this.mnuPromotionList_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 823);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1140, 637);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý cửa hàng điện thoại";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.gbQuickActions.ResumeLayout(false);
            this.gbMonthStats.ResumeLayout(false);
            this.gbTodayStats.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnRefreshStats;
        private ToolStripMenuItem mnuPromotion;
        private ToolStripMenuItem mnuPromotionList;
    }
}