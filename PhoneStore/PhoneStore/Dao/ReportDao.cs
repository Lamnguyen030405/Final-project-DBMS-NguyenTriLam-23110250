using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStoreManagement.Models;
using System.Security.Cryptography;

namespace PhoneStore.Dao
{
    public class ReportDao : BaseDao
    {
        public class DailySalesReport
        {
            public DateTime Date { get; set; }
            public int TotalOrders { get; set; }
            public decimal TotalRevenue { get; set; }
            public decimal AverageOrderValue { get; set; }
        }

        public class ProductSalesReport
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string BrandName { get; set; }
            public int QuantitySold { get; set; }
            public decimal TotalRevenue { get; set; }
            public decimal AveragePrice { get; set; }
            public int TotalOrders { get; set; }
        }

        public class EmployeePerformanceReport
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public string Position { get; set; }
            public int TotalOrders { get; set; }
            public decimal TotalSales { get; set; }
            public decimal AverageOrderValue { get; set; }
            public DateTime LastSaleDate { get; set; }
        }

        public class CustomerSalesReport
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerType { get; set; }
            public int TotalOrders { get; set; }
            public decimal TotalSpent { get; set; }
            public decimal AverageOrderValue { get; set; }
            public DateTime LastOrderDate { get; set; }
        }

        public List<DailySalesReport> GetDailySalesReport(DateTime fromDate, DateTime toDate)
        {
            string query = "SELECT * FROM fn_GetDailySalesReport(@fromDate, @toDate)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@fromDate", fromDate.Date),
                new SqlParameter("@toDate", toDate.Date)
            };

            var dataTable = ExecuteQuery(query, parameters);
            var reports = new List<DailySalesReport>();

            foreach (DataRow row in dataTable.Rows)
            {
                reports.Add(new DailySalesReport
                {
                    Date = Convert.ToDateTime(row["report_date"]),
                    TotalOrders = Convert.ToInt32(row["total_orders"]),
                    TotalRevenue = Convert.ToDecimal(row["total_revenue"]),
                    AverageOrderValue = Convert.ToDecimal(row["avg_order_value"])
                });
            }

            return reports;
        }

        public List<ProductSalesReport> GetTopSellingProducts(DateTime fromDate, DateTime toDate, int topCount = 10)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@topCount", topCount),
                new SqlParameter("@fromDate", fromDate.Date),
                new SqlParameter("@toDate", toDate.Date)
            };

            var dataTable = ExecuteQuery("sp_GetTopSellingProducts", parameters, isStoredProcedure: true);
            var reports = new List<ProductSalesReport>();

            foreach (DataRow row in dataTable.Rows)
            {
                reports.Add(new ProductSalesReport
                {
                    ProductId = Convert.ToInt32(row["product_id"]),
                    ProductName = row["product_name"].ToString(),
                    BrandName = row["brand_name"].ToString(),
                    QuantitySold = Convert.ToInt32(row["quantity_sold"]),
                    TotalRevenue = Convert.ToDecimal(row["total_revenue"]),
                    AveragePrice = Convert.ToDecimal(row["avg_price"]),
                    TotalOrders = Convert.ToInt32(row["total_orders"])
                });
            }

            return reports;
        }

        public List<EmployeePerformanceReport> GetEmployeePerformanceReport(DateTime fromDate, DateTime toDate)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@fromDate", fromDate.Date),
                new SqlParameter("@toDate", toDate.Date)
            };

            var dataTable = ExecuteQuery("sp_GetEmployeePerformanceReport", parameters, isStoredProcedure: true);
            var reports = new List<EmployeePerformanceReport>();

            foreach (DataRow row in dataTable.Rows)
            {
                reports.Add(new EmployeePerformanceReport
                {
                    EmployeeId = Convert.ToInt32(row["employee_id"]),
                    EmployeeName = row["full_name"].ToString(),
                    Position = row["position"].ToString(),
                    TotalOrders = Convert.ToInt32(row["total_orders"]),
                    TotalSales = Convert.ToDecimal(row["total_sales"]),
                    AverageOrderValue = Convert.ToDecimal(row["avg_order_value"]),
                    LastSaleDate = Convert.ToDateTime(row["last_sale_date"])
                });
            }

            return reports;
        }

        public List<CustomerSalesReport> GetCustomerSalesReport(DateTime fromDate, DateTime toDate, int topCount = 20)
        {
            string query = @"
                SELECT TOP (@topCount)
                    c.customer_id,
                    c.full_name,
                    c.customer_type,
                    COUNT(o.order_id) AS total_orders,
                    COALESCE(SUM(o.total_amount), 0) AS total_spent,
                    COALESCE(AVG(o.total_amount), 0) AS avg_order_value,
                    COALESCE(MAX(o.order_date), c.created_at) AS last_order_date
                FROM customers c
                LEFT JOIN orders o ON c.customer_id = o.customer_id 
                    AND o.order_status = 'completed'
                    AND CAST(o.order_date AS DATE) BETWEEN @fromDate AND @toDate
                GROUP BY c.customer_id, c.full_name, c.customer_type, c.created_at
                HAVING COUNT(o.order_id) > 0
                ORDER BY total_spent DESC";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@topCount", topCount),
                new SqlParameter("@fromDate", fromDate.Date),
                new SqlParameter("@toDate", toDate.Date)
            };

            var dataTable = ExecuteQuery(query, parameters);
            var reports = new List<CustomerSalesReport>();

            foreach (DataRow row in dataTable.Rows)
            {
                reports.Add(new CustomerSalesReport
                {
                    CustomerId = Convert.ToInt32(row["customer_id"]),
                    CustomerName = row["full_name"].ToString(),
                    CustomerType = row["customer_type"].ToString(),
                    TotalOrders = Convert.ToInt32(row["total_orders"]),
                    TotalSpent = Convert.ToDecimal(row["total_spent"]),
                    AverageOrderValue = Convert.ToDecimal(row["avg_order_value"]),
                    LastOrderDate = Convert.ToDateTime(row["last_order_date"])
                });
            }

            return reports;
        }

        public Dictionary<string, decimal> GetMonthlyRevenueComparison(int currentYear, int previousYear)
        {
            string query = @"
                SELECT 
                    MONTH(order_date) AS month_number,
                    SUM(CASE WHEN YEAR(order_date) = @currentYear THEN total_amount ELSE 0 END) AS current_year,
                    SUM(CASE WHEN YEAR(order_date) = @previousYear THEN total_amount ELSE 0 END) AS previous_year
                FROM orders
                WHERE order_status = 'completed'
                AND YEAR(order_date) IN (@currentYear, @previousYear)
                GROUP BY MONTH(order_date)
                ORDER BY month_number";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@currentYear", currentYear),
                new SqlParameter("@previousYear", previousYear)
            };

            var dataTable = ExecuteQuery(query, parameters);
            var result = new Dictionary<string, decimal>();

            foreach (DataRow row in dataTable.Rows)
            {
                int month = Convert.ToInt32(row["month_number"]);
                string monthName = new DateTime(2000, month, 1).ToString("MMMM");

                result[$"{monthName} {currentYear}"] = Convert.ToDecimal(row["current_year"]);
                result[$"{monthName} {previousYear}"] = Convert.ToDecimal(row["previous_year"]);
            }

            return result;
        }

        public class DashboardStats
        {
            public decimal TodayRevenue { get; set; }
            public decimal MonthRevenue { get; set; }
            public int TodayOrders { get; set; }
            public int MonthOrders { get; set; }
            public int LowStockProducts { get; set; }
            public int TotalCustomers { get; set; }
            public decimal AverageOrderValue { get; set; }
        }

        public DashboardStats GetDashboardStats()
        {
            string procedureName = "sp_GetDashboardStats";
            var dataTable = ExecuteQuery(procedureName, null, isStoredProcedure: true);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new DashboardStats
                {
                    TodayRevenue = Convert.ToDecimal(row["today_revenue"]),
                    TodayOrders = Convert.ToInt32(row["today_orders"]),
                    MonthRevenue = Convert.ToDecimal(row["month_revenue"]),
                    MonthOrders = Convert.ToInt32(row["month_orders"]),
                    AverageOrderValue = Convert.ToDecimal(row["avg_order_value"]),
                    TotalCustomers = Convert.ToInt32(row["total_customers"]),
                    LowStockProducts = Convert.ToInt32(row["low_stock_products"])
                };
            }

            return new DashboardStats();
        }

    }
}
