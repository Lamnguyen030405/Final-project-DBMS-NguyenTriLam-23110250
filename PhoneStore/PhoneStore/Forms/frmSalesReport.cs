using PhoneStore.Dao;
using PhoneStore.Services;
using PhoneStore.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PhoneStore.Forms
{
    public partial class frmSalesReport : Form
    {
        private readonly ReportService reportService;
        private List<ReportDao.DailySalesReport> dailyReports;
        private List<ReportDao.ProductSalesReport> productReports;
        private List<ReportDao.EmployeePerformanceReport> employeeReports;

        public frmSalesReport()
        {
            InitializeComponent();
            reportService = new ReportService();
            dailyReports = new List<ReportDao.DailySalesReport>();
            productReports = new List<ReportDao.ProductSalesReport>();
            employeeReports = new List<ReportDao.EmployeePerformanceReport>();
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeForm();
                SetDefaultDateRange();
                SetupDataGridViews();
                CreateChartPlaceholder();
                SetupKeyboardShortcuts();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi khởi tạo form báo cáo bán hàng");
            }
        }

        #region Form Setup

        private void InitializeForm()
        {
            cboReportType.SelectedIndex = 0; // Default to daily report
        }

        private void SetDefaultDateRange()
        {
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now;
        }

        private void SetupKeyboardShortcuts()
        {
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.G:
                            btnGenerate_Click(s, e);
                            break;
                        case Keys.E:
                            btnExport_Click(s, e);
                            break;
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                    e.Handled = true;
                }
            };
        }

        #endregion

        #region DataGridView Setup

        private void SetupDataGridViews()
        {
            SetupDailySalesGrid();
            SetupProductSalesGrid();
            SetupEmployeeSalesGrid();
        }

        private void SetupDailySalesGrid()
        {
            dgvDailySales.Columns.Clear();

            var columns = new[]
            {
                new { Name = "Date", Header = "Ngày", Width = 120, Format = "dd/MM/yyyy", Align = DataGridViewContentAlignment.MiddleLeft },
                new { Name = "TotalOrders", Header = "Số đơn", Width = 100, Format = "", Align = DataGridViewContentAlignment.MiddleCenter },
                new { Name = "TotalRevenue", Header = "Doanh thu", Width = 150, Format = "N0", Align = DataGridViewContentAlignment.MiddleRight },
                new { Name = "AverageOrderValue", Header = "ĐH TB", Width = 150, Format = "N0", Align = DataGridViewContentAlignment.MiddleRight }
            };

            foreach (var col in columns)
            {
                var column = new DataGridViewTextBoxColumn
                {
                    Name = col.Name,
                    HeaderText = col.Header,
                    Width = col.Width,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = col.Align,
                        Format = col.Format
                    }
                };
                dgvDailySales.Columns.Add(column);
            }
        }

        private void SetupProductSalesGrid()
        {
            dgvProductSales.Columns.Clear();

            var columns = new[]
            {
                new { Name = "ProductName", Header = "Tên sản phẩm", Width = 300, Format = "", Align = DataGridViewContentAlignment.MiddleLeft },
                new { Name = "BrandName", Header = "Thương hiệu", Width = 120, Format = "", Align = DataGridViewContentAlignment.MiddleLeft },
                new { Name = "QuantitySold", Header = "SL bán", Width = 80, Format = "", Align = DataGridViewContentAlignment.MiddleCenter },
                new { Name = "TotalRevenue", Header = "Doanh thu", Width = 120, Format = "N0", Align = DataGridViewContentAlignment.MiddleRight }
            };

            foreach (var col in columns)
            {
                var column = new DataGridViewTextBoxColumn
                {
                    Name = col.Name,
                    HeaderText = col.Header,
                    Width = col.Width,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = col.Align,
                        Format = col.Format
                    }
                };
                dgvProductSales.Columns.Add(column);
            }
        }

        private void SetupEmployeeSalesGrid()
        {
            dgvEmployeeSales.Columns.Clear();

            var columns = new[]
            {
                new { Name = "EmployeeName", Header = "Tên nhân viên", Width = 200, Format = "", Align = DataGridViewContentAlignment.MiddleLeft },
                new { Name = "Position", Header = "Chức vụ", Width = 120, Format = "", Align = DataGridViewContentAlignment.MiddleLeft },
                new { Name = "TotalOrders", Header = "Số đơn", Width = 100, Format = "", Align = DataGridViewContentAlignment.MiddleCenter },
                new { Name = "TotalSales", Header = "Tổng bán", Width = 150, Format = "N0", Align = DataGridViewContentAlignment.MiddleRight }
            };

            foreach (var col in columns)
            {
                var column = new DataGridViewTextBoxColumn
                {
                    Name = col.Name,
                    HeaderText = col.Header,
                    Width = col.Width,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = col.Align,
                        Format = col.Format
                    }
                };
                dgvEmployeeSales.Columns.Add(column);
            }
        }

        #endregion

        #region Event Handlers

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboReportType.SelectedIndex)
                {
                    case 0: // Daily
                        dtpFromDate.Value = DateTime.Today;
                        dtpToDate.Value = DateTime.Today;
                        break;
                    case 1: // Weekly
                        var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                        dtpFromDate.Value = startOfWeek;
                        dtpToDate.Value = startOfWeek.AddDays(6);
                        break;
                    case 2: // Monthly
                        dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi thay đổi loại báo cáo");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateDateRange()) return;

                btnGenerate.Enabled = false;
                btnGenerate.Text = "Đang tạo...";

                GenerateReports();
                UpdateSummary();
                UpdateChart();

                ExceptionHandler.ShowSuccessMessage("Tạo báo cáo thành công!");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tạo báo cáo");
            }
            finally
            {
                btnGenerate.Enabled = true;
                btnGenerate.Text = "Tạo báo cáo";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HasReportData())
                {
                    ExceptionHandler.ShowValidationError("Vui lòng tạo báo cáo trước khi xuất file.");
                    return;
                }

                ExportToCSV();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi xuất file");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HasReportData())
                {
                    ExceptionHandler.ShowValidationError("Vui lòng tạo báo cáo trước khi in.");
                    return;
                }

                var result = MessageBox.Show("Bạn có muốn xem trước bản in không?",
                    "Tùy chọn in ấn",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                    return;
                else if (result == DialogResult.Yes)
                    ShowPrintPreview();
                else
                    PrintDirectly();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi in báo cáo");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Report Generation

        private bool ValidateDateRange()
        {
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                ExceptionHandler.ShowValidationError("Ngày bắt đầu không thể lớn hơn ngày kết thúc.");
                dtpFromDate.Focus();
                return false;
            }

            if ((dtpToDate.Value - dtpFromDate.Value).TotalDays > 365)
            {
                ExceptionHandler.ShowValidationError("Khoảng thời gian báo cáo không được vượt quá 1 năm.");
                dtpFromDate.Focus();
                return false;
            }

            return true;
        }

        private void GenerateReports()
        {
            var fromDate = dtpFromDate.Value.Date;
            var toDate = dtpToDate.Value.Date;

            // Clear existing data
            dailyReports?.Clear();
            productReports?.Clear();
            employeeReports?.Clear();

            // Generate reports
            GenerateDailyReport(fromDate, toDate);
            GenerateProductReport(fromDate, toDate);
            GenerateEmployeeReport(fromDate, toDate);
        }

        private void GenerateDailyReport(DateTime fromDate, DateTime toDate)
        {
            var result = reportService.GetDailySalesReport(fromDate, toDate);
            if (result.IsSuccess)
            {
                dailyReports = result.Data ?? new List<ReportDao.DailySalesReport>();
                DisplayDailyReport();
            }
            else
            {
                ExceptionHandler.ShowValidationError($"Lỗi tải báo cáo theo ngày: {result.Message}");
            }
        }

        private void GenerateProductReport(DateTime fromDate, DateTime toDate)
        {
            var result = reportService.GetTopSellingProducts(fromDate, toDate, 20);
            if (result.IsSuccess)
            {
                productReports = result.Data ?? new List<ReportDao.ProductSalesReport>();
                DisplayProductReport();
            }
            else
            {
                ExceptionHandler.ShowValidationError($"Lỗi tải báo cáo sản phẩm: {result.Message}");
            }
        }

        private void GenerateEmployeeReport(DateTime fromDate, DateTime toDate)
        {
            var result = reportService.GetEmployeePerformanceReport(fromDate, toDate);
            if (result.IsSuccess)
            {
                employeeReports = result.Data ?? new List<ReportDao.EmployeePerformanceReport>();
                DisplayEmployeeReport();
            }
            else
            {
                ExceptionHandler.ShowValidationError($"Lỗi tải báo cáo nhân viên: {result.Message}");
            }
        }

        #endregion

        #region Display Methods

        private void DisplayDailyReport()
        {
            dgvDailySales.Rows.Clear();

            foreach (var report in dailyReports.OrderBy(r => r.Date))
            {
                var row = dgvDailySales.Rows.Add();
                dgvDailySales.Rows[row].Cells["Date"].Value = report.Date;
                dgvDailySales.Rows[row].Cells["TotalOrders"].Value = report.TotalOrders;
                dgvDailySales.Rows[row].Cells["TotalRevenue"].Value = report.TotalRevenue;
                dgvDailySales.Rows[row].Cells["AverageOrderValue"].Value = report.AverageOrderValue;

                // Highlight weekends
                if (report.Date.DayOfWeek == DayOfWeek.Saturday || report.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    dgvDailySales.Rows[row].DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
        }

        private void DisplayProductReport()
        {
            dgvProductSales.Rows.Clear();

            foreach (var report in productReports.OrderByDescending(r => r.QuantitySold))
            {
                var row = dgvProductSales.Rows.Add();
                dgvProductSales.Rows[row].Cells["ProductName"].Value = report.ProductName;
                dgvProductSales.Rows[row].Cells["BrandName"].Value = report.BrandName ?? "";
                dgvProductSales.Rows[row].Cells["QuantitySold"].Value = report.QuantitySold;
                dgvProductSales.Rows[row].Cells["TotalRevenue"].Value = report.TotalRevenue;

                // Highlight top 3 products
                if (row < 3)
                {
                    dgvProductSales.Rows[row].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void DisplayEmployeeReport()
        {
            dgvEmployeeSales.Rows.Clear();

            foreach (var report in employeeReports.OrderByDescending(r => r.TotalSales))
            {
                var row = dgvEmployeeSales.Rows.Add();
                dgvEmployeeSales.Rows[row].Cells["EmployeeName"].Value = report.EmployeeName;
                dgvEmployeeSales.Rows[row].Cells["Position"].Value = report.Position;
                dgvEmployeeSales.Rows[row].Cells["TotalOrders"].Value = report.TotalOrders;
                dgvEmployeeSales.Rows[row].Cells["TotalSales"].Value = report.TotalSales;

                // Highlight top performer
                if (row == 0 && report.TotalSales > 0)
                {
                    dgvEmployeeSales.Rows[row].DefaultCellStyle.BackColor = Color.Gold;
                }
            }
        }

        #endregion

        #region Summary and Chart

        private void UpdateSummary()
        {
            if (!HasReportData())
            {
                ResetSummary();
                return;
            }

            var totalRevenue = dailyReports.Sum(r => r.TotalRevenue);
            var totalOrders = dailyReports.Sum(r => r.TotalOrders);
            var averageOrderValue = totalOrders > 0 ? totalRevenue / totalOrders : 0;
            var topProduct = productReports?.OrderByDescending(p => p.QuantitySold)?.FirstOrDefault();

            lblTotalRevenueValue.Text = ValidationHelper.FormatCurrency(totalRevenue);
            lblTotalOrdersValue.Text = totalOrders.ToString("N0");
            lblAverageOrderValueValue.Text = ValidationHelper.FormatCurrency(averageOrderValue);
            lblTopProductValue.Text = topProduct?.ProductName ?? "Chưa có dữ liệu";
        }

        private void ResetSummary()
        {
            lblTotalRevenueValue.Text = "0đ";
            lblTotalOrdersValue.Text = "0";
            lblAverageOrderValueValue.Text = "0đ";
            lblTopProductValue.Text = "Chưa có dữ liệu";
        }

        private void UpdateChart()
        {
            pnlChart.Controls.Clear();

            if (!HasReportData())
            {
                CreateChartPlaceholder();
                return;
            }

            // Tạo layout để chứa nhiều biểu đồ
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoScroll = true,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(10),
            };

            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Add từng biểu đồ
            layout.Controls.Add(CreateRevenueChart(), 0, 0);
            layout.Controls.Add(CreateMultiTypeChart(), 0, 1);
            layout.Controls.Add(CreatePieChart(), 0, 2);

            pnlChart.Controls.Add(layout);
        }
        private void CreateChartPlaceholder()
        {
            var lblPlaceholder = new Label
            {
                Text = "Biểu đồ doanh thu sẽ được hiển thị ở đây\n\nVui lòng tạo báo cáo để xem biểu đồ",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            pnlChart.Controls.Add(lblPlaceholder);
        }

        private Chart CreateRevenueChart()
        {
            try
            {
                // Create Chart control
                var chart = new Chart();
                chart.Dock = DockStyle.Fill;
                chart.BackColor = Color.White;

                // Create ChartArea
                var chartArea = new ChartArea("RevenueArea");
                chartArea.AxisX.Title = "Ngày";
                chartArea.AxisY.Title = "Doanh thu (VNĐ)";
                chartArea.AxisX.LabelStyle.Format = "dd/MM";
                chartArea.AxisY.LabelStyle.Format = "N0";
                chartArea.BackColor = Color.AliceBlue;
                chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
                chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                chart.ChartAreas.Add(chartArea);

                // Create Series
                var series = new Series("Revenue");
                series.ChartType = SeriesChartType.Column;
                series.Color = Color.SteelBlue;
                series.BorderWidth = 2;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N0";

                // Add data points
                if (dailyReports != null && dailyReports.Any())
                {
                    var sortedReports = dailyReports.OrderBy(r => r.Date).ToList();

                    foreach (var report in sortedReports)
                    {
                        var point = series.Points.AddXY(report.Date.ToString("dd/MM"), (double)report.TotalRevenue);
                        series.Points[point].ToolTip = $"Ngày: {report.Date:dd/MM/yyyy}\nDoanh thu: {ValidationHelper.FormatCurrency(report.TotalRevenue)}";
                    }
                }
                else
                {
                    // Add sample data if no reports available
                    series.Points.AddXY("Không có dữ liệu", 0);
                }

                chart.Series.Add(series);

                // Add title
                var title = new Title("BIỂU ĐỒ DOANH THU THEO NGÀY");
                title.Font = new Font("Arial", 12, FontStyle.Bold);
                title.ForeColor = Color.DarkBlue;
                chart.Titles.Add(title);

                // Add legend
                var legend = new Legend("RevenueLegend");
                legend.Docking = Docking.Top;
                legend.Alignment = StringAlignment.Center;
                chart.Legends.Add(legend);

                return chart;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tạo biểu đồ", false);
                return null;
            }
        }

        // Alternative method using different chart types
        private Chart CreateMultiTypeChart()
        {
            try
            {
                var chart = new Chart();
                chart.Dock = DockStyle.Fill;
                chart.BackColor = Color.White;

                // Create ChartArea
                var chartArea = new ChartArea("MainArea");
                chartArea.AxisX.Title = "Ngày";
                chartArea.AxisY.Title = "Giá trị (VNĐ)";
                chartArea.AxisX.LabelStyle.Format = "dd/MM";
                chartArea.AxisY.LabelStyle.Format = "N0";
                chart.ChartAreas.Add(chartArea);

                if (dailyReports != null && dailyReports.Any())
                {
                    var sortedReports = dailyReports.OrderBy(r => r.Date).ToList();

                    // Revenue series (Column)
                    var revenueSeries = new Series("Doanh thu");
                    revenueSeries.ChartType = SeriesChartType.Column;
                    revenueSeries.Color = Color.SteelBlue;
                    revenueSeries.YAxisType = AxisType.Primary;

                    // Order count series (Line)
                    var orderSeries = new Series("Số đơn hàng");
                    orderSeries.ChartType = SeriesChartType.Line;
                    orderSeries.Color = Color.Red;
                    orderSeries.BorderWidth = 3;
                    orderSeries.MarkerStyle = MarkerStyle.Circle;
                    orderSeries.MarkerSize = 6;
                    orderSeries.YAxisType = AxisType.Secondary;

                    foreach (var report in sortedReports)
                    {
                        revenueSeries.Points.AddXY(report.Date.ToString("dd/MM"), (double)report.TotalRevenue);
                        orderSeries.Points.AddXY(report.Date.ToString("dd/MM"), report.TotalOrders);
                    }

                    chart.Series.Add(revenueSeries);
                    chart.Series.Add(orderSeries);

                    // Configure secondary Y axis for order count
                    chartArea.AxisY2.Enabled = AxisEnabled.True;
                    chartArea.AxisY2.Title = "Số đơn hàng";
                    chartArea.AxisY2.LabelStyle.Format = "N0";
                }

                // Add title
                var title = new Title("DOANH THU VÀ SỐ ĐƠN HÀNG THEO NGÀY");
                title.Font = new Font("Arial", 12, FontStyle.Bold);
                title.ForeColor = Color.DarkBlue;
                chart.Titles.Add(title);

                // Add legend
                var legend = new Legend();
                legend.Docking = Docking.Top;
                legend.Alignment = StringAlignment.Center;
                chart.Legends.Add(legend);

                return chart;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tạo biểu đồ kết hợp", false);
                return null;
            }
        }

        // Method to create pie chart for revenue by category/method
        private Chart CreatePieChart()
        {
            try
            {
                var chart = new Chart();
                chart.Dock = DockStyle.Fill;
                chart.BackColor = Color.White;

                // Create ChartArea
                var chartArea = new ChartArea("PieArea");
                chartArea.BackColor = Color.Transparent;
                chart.ChartAreas.Add(chartArea);

                // Create pie series
                var pieSeries = new Series("PaymentMethods");
                pieSeries.ChartType = SeriesChartType.Pie;
                pieSeries.IsValueShownAsLabel = true;
                pieSeries.LabelFormat = "P1"; // Percentage format
                pieSeries["PieLabelStyle"] = "Outside";
                pieSeries["PieLineColor"] = "Black";
                pieSeries["PieDrawingStyle"] = "SoftEdge";

                //// Get date range for the chart (e.g., current month or selected period)
                //DateTime fromDate = DateTime.Now.AddDays(-30); // Last 30 days
                //DateTime toDate = DateTime.Now;

                // You might want to make this configurable based on user selection
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                // Get payment summary by method from PaymentService
                var paymentService = new PaymentService();
                var summaryResult = paymentService.GetPaymentSummaryByMethod(fromDate, toDate);

                if (!summaryResult.IsSuccess)
                {
                    // Handle error - show empty chart or error message
                    ExceptionHandler.HandleException(new Exception(summaryResult.Message), "Lỗi lấy dữ liệu thanh toán", false);
                    return CreateEmptyPieChart();
                }

                var paymentData = summaryResult.Data;

                // Define colors for each payment method
                var methodColors = new Dictionary<string, Color>
        {
            { "cash", Color.FromArgb(70, 130, 180) },      // SteelBlue - Tiền mặt
            { "card", Color.FromArgb(60, 179, 113) },      // MediumSeaGreen - Thẻ tín dụng  
            { "transfer", Color.FromArgb(255, 165, 0) },   // Orange - Chuyển khoản
            { "installment", Color.FromArgb(147, 112, 219) } // MediumPurple - Trả góp
        };

                // Method display names
                var methodDisplayNames = new Dictionary<string, string>
        {
            { "cash", "Tiền mặt" },
            { "card", "Thẻ tín dụng" },
            { "transfer", "Chuyển khoản" },
            { "installment", "Trả góp" }
        };

                // Calculate total for percentage
                decimal totalAmount = paymentData.Values.Sum();

                if (totalAmount <= 0)
                {
                    return CreateEmptyPieChart();
                }

                // Add data points for methods with payments
                foreach (var method in paymentData.Where(x => x.Value > 0).OrderByDescending(x => x.Value))
                {
                    string displayName = methodDisplayNames.ContainsKey(method.Key)
                        ? methodDisplayNames[method.Key]
                        : method.Key;

                    var pointIndex = pieSeries.Points.AddXY(displayName, (double)method.Value);

                    // Set color
                    if (methodColors.ContainsKey(method.Key))
                    {
                        pieSeries.Points[pointIndex].Color = methodColors[method.Key];
                    }

                    // Set tooltip with detailed information
                    decimal percentage = (method.Value / totalAmount) * 100;
                    pieSeries.Points[pointIndex].ToolTip =
                        $"{displayName}\n" +
                        $"Số tiền: {ValidationHelper.FormatCurrency(method.Value)}\n" +
                        $"Tỷ lệ: {percentage:F1}%";

                    // Set label
                    pieSeries.Points[pointIndex].Label = $"{percentage:F1}%";
                    pieSeries.Points[pointIndex].LegendText = displayName;
                }

                chart.Series.Add(pieSeries);

                // Add title with date range
                var title = new Title($"PHÂN BỔ DOANH THU THEO PHƯƠNG THỨC THANH TOÁN\n({fromDate:dd/MM/yyyy} - {toDate:dd/MM/yyyy})");
                title.Font = new Font("Arial", 11, FontStyle.Bold);
                title.ForeColor = Color.DarkBlue;
                chart.Titles.Add(title);

                // Add legend
                var legend = new Legend();
                legend.Docking = Docking.Right;
                legend.Alignment = StringAlignment.Center;
                legend.Font = new Font("Arial", 9);
                chart.Legends.Add(legend);

                // Add total amount as subtitle
                var subtitle = new Title($"Tổng doanh thu: {ValidationHelper.FormatCurrency(totalAmount)}");
                subtitle.Font = new Font("Arial", 10, FontStyle.Regular);
                subtitle.ForeColor = Color.DarkGreen;
                subtitle.Docking = Docking.Bottom;
                chart.Titles.Add(subtitle);

                return chart;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi tạo biểu đồ tròn", false);
                return CreateEmptyPieChart();
            }
        }

        private Chart CreateEmptyPieChart()
        {
            try
            {
                var chart = new Chart();
                chart.Dock = DockStyle.Fill;
                chart.BackColor = Color.White;

                var chartArea = new ChartArea("EmptyArea");
                chart.ChartAreas.Add(chartArea);

                // Add empty title
                var title = new Title("KHÔNG CÓ DỮ LIỆU THANH TOÁN");
                title.Font = new Font("Arial", 12, FontStyle.Bold);
                title.ForeColor = Color.Gray;
                chart.Titles.Add(title);

                var subtitle = new Title("Chọn khoảng thời gian khác hoặc kiểm tra dữ liệu thanh toán");
                subtitle.Font = new Font("Arial", 10, FontStyle.Regular);
                subtitle.ForeColor = Color.DarkGray;
                subtitle.Docking = Docking.Bottom;
                chart.Titles.Add(subtitle);

                return chart;
            }
            catch
            {
                return new Chart(); // Return basic empty chart if even this fails
            }
        }

        #endregion

        #region Export

        private bool HasReportData()
        {
            return dailyReports != null && dailyReports.Count > 0;
        }

        private void ExportToCSV()
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "CSV files (*.csv)|*.csv";
                saveDialog.FileName = $"BaoCaoBanHang_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    CreateCSVFile(saveDialog.FileName);
                    ExceptionHandler.ShowSuccessMessage("Xuất file thành công!");

                    if (ExceptionHandler.ShowConfirmDialog("Bạn có muốn mở file vừa xuất không?"))
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
            }
        }

        private void CreateCSVFile(string fileName)
        {
            var content = new System.Text.StringBuilder();

            // Header
            content.AppendLine("BÁO CÁO BÁN HÀNG");
            content.AppendLine($"Từ ngày: {dtpFromDate.Value:dd/MM/yyyy} đến {dtpToDate.Value:dd/MM/yyyy}");
            content.AppendLine($"Thời gian tạo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            content.AppendLine();

            // Summary
            content.AppendLine("TỔNG QUAN");
            content.AppendLine($"Tổng doanh thu,{lblTotalRevenueValue.Text.Replace("đ", "").Replace(",", ".")}");
            content.AppendLine($"Tổng đơn hàng,{lblTotalOrdersValue.Text}");
            content.AppendLine($"Giá trị đơn TB,{lblAverageOrderValueValue.Text.Replace("đ", "").Replace(",", ".")}");
            content.AppendLine($"SP bán chạy,\"{lblTopProductValue.Text}\"");
            content.AppendLine();

            // Daily report
            if (dailyReports?.Count > 0)
            {
                content.AppendLine("BÁO CÁO THEO NGÀY");
                content.AppendLine("Ngày,Số đơn hàng,Doanh thu,ĐH TB");
                foreach (var report in dailyReports.OrderBy(r => r.Date))
                {
                    content.AppendLine($"{report.Date:dd/MM/yyyy},{report.TotalOrders},{report.TotalRevenue.ToString("N0").Replace(",", ".")},{report.AverageOrderValue.ToString("N0").Replace(",", ".")}");
                }
                content.AppendLine();
            }

            // Product report
            if (productReports?.Count > 0)
            {
                content.AppendLine("TOP SẢN PHẨM BÁN CHẠY");
                content.AppendLine("STT,Tên sản phẩm,Thương hiệu,SL bán,Doanh thu");
                int index = 1;
                foreach (var report in productReports.OrderByDescending(r => r.QuantitySold).Take(10))
                {
                    content.AppendLine($"{index},\"{report.ProductName}\",\"{report.BrandName ?? ""}\",{report.QuantitySold},{report.TotalRevenue.ToString("N0").Replace(",", ".")}");
                    index++;
                }
                content.AppendLine();
            }

            // Employee report
            if (employeeReports?.Count > 0)
            {
                content.AppendLine("HIỆU SUẤT NHÂN VIÊN");
                content.AppendLine("STT,Tên nhân viên,Chức vụ,Số đơn,Doanh số");
                int index = 1;
                foreach (var report in employeeReports.OrderByDescending(r => r.TotalSales))
                {
                    content.AppendLine($"{index},\"{report.EmployeeName}\",\"{report.Position}\",{report.TotalOrders},{report.TotalSales.ToString("N0").Replace(",", ".")}");
                    index++;
                }
            }

            System.IO.File.WriteAllText(fileName, content.ToString(), System.Text.Encoding.UTF8);
        }


        #endregion

        #region Print Methods

        private void ShowPrintPreview()
        {
            try
            {
                using (var previewDialog = new PrintPreviewDialog())
                using (var printDocument = CreatePrintDocument())
                {
                    previewDialog.Document = printDocument;
                    previewDialog.Size = new Size(800, 600);
                    previewDialog.StartPosition = FormStartPosition.CenterParent;
                    previewDialog.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi xem trước bản in");
            }
        }

        private void PrintDirectly()
        {
            try
            {
                using (var printDialog = new PrintDialog())
                using (var printDocument = CreatePrintDocument())
                {
                    printDialog.Document = printDocument;

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.Print();
                        ExceptionHandler.ShowSuccessMessage("Đã gửi báo cáo đến máy in thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi in báo cáo");
            }
        }

        private System.Drawing.Printing.PrintDocument CreatePrintDocument()
        {
            var printDocument = new System.Drawing.Printing.PrintDocument();
            printDocument.DocumentName = $"BaoCaoBanHang_{DateTime.Now:yyyyMMdd_HHmmss}";
            printDocument.PrintPage += PrintDocument_PrintPage;
            return printDocument;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                var graphics = e.Graphics;
                var titleFont = new Font("Arial", 16, FontStyle.Bold);
                var headerFont = new Font("Arial", 12, FontStyle.Bold);
                var font = new Font("Arial", 10);
                var brush = new SolidBrush(Color.Black);

                float yPos = 50;
                float leftMargin = 50;

                // Print title
                graphics.DrawString("BÁO CÁO BÁN HÀNG", titleFont, brush, leftMargin, yPos);
                yPos += 40;

                // Print report info
                graphics.DrawString($"Từ ngày: {dtpFromDate.Value:dd/MM/yyyy} đến {dtpToDate.Value:dd/MM/yyyy}",
                    font, brush, leftMargin, yPos);
                yPos += 25;

                graphics.DrawString($"Thời gian tạo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}",
                    font, brush, leftMargin, yPos);
                yPos += 40;

                // Print summary
                graphics.DrawString("TỔNG QUAN", headerFont, brush, leftMargin, yPos);
                yPos += 30;

                var summaryData = new[]
                {
                    $"Tổng doanh thu: {lblTotalRevenueValue.Text}",
                    $"Tổng đơn hàng: {lblTotalOrdersValue.Text}",
                    $"Giá trị đơn TB: {lblAverageOrderValueValue.Text}",
                    $"SP bán chạy: {lblTopProductValue.Text}"
                };

                foreach (var item in summaryData)
                {
                    graphics.DrawString(item, font, brush, leftMargin, yPos);
                    yPos += 20;
                }

                yPos += 30;

                // Print daily report (top 10)
                if (dailyReports?.Count > 0)
                {
                    graphics.DrawString("BÁO CÁO THEO NGÀY (10 ngày gần nhất)", headerFont, brush, leftMargin, yPos);
                    yPos += 30;

                    // Headers
                    graphics.DrawString("Ngày", font, brush, leftMargin, yPos);
                    graphics.DrawString("Đơn hàng", font, brush, leftMargin + 100, yPos);
                    graphics.DrawString("Doanh thu", font, brush, leftMargin + 200, yPos);
                    yPos += 25;

                    // Data
                    var recentReports = dailyReports.OrderByDescending(r => r.Date).Take(10);
                    foreach (var report in recentReports)
                    {
                        if (yPos > e.PageBounds.Height - 100) break;

                        graphics.DrawString(report.Date.ToString("dd/MM/yyyy"), font, brush, leftMargin, yPos);
                        graphics.DrawString(report.TotalOrders.ToString(), font, brush, leftMargin + 100, yPos);
                        graphics.DrawString(report.TotalRevenue.ToString("N0"), font, brush, leftMargin + 200, yPos);
                        yPos += 20;
                    }
                }

                // Footer
                yPos = e.PageBounds.Height - 60;
                graphics.DrawString($"Người tạo: {SessionManager.GetUserDisplayName()}", font, brush, leftMargin, yPos);
                graphics.DrawString($"Trang 1", font, brush, e.PageBounds.Width - 100, yPos);

                // Clean up
                titleFont.Dispose();
                headerFont.Dispose();
                font.Dispose();
                brush.Dispose();

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "Lỗi in trang báo cáo", false);
            }
        }

        #endregion
    }
}