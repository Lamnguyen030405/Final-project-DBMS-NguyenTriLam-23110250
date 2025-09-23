using PhoneStore.Dao;
using PhoneStore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class ReportService
    {
        private ReportDao reportDao;

        public ReportService()
        {
            reportDao = new ReportDao();
        }

        public ServiceResult<List<ReportDao.DailySalesReport>> GetDailySalesReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (fromDate > toDate)
                {
                    return ServiceResult<List<ReportDao.DailySalesReport>>.Error("Ngày bắt đầu không thể lớn hơn ngày kết thúc.");
                }

                if ((toDate - fromDate).TotalDays > 365)
                {
                    return ServiceResult<List<ReportDao.DailySalesReport>>.Error("Khoảng thời gian báo cáo không được vượt quá 1 năm.");
                }

                var reports = reportDao.GetDailySalesReport(fromDate, toDate);
                return ServiceResult<List<ReportDao.DailySalesReport>>.Success(reports);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<ReportDao.DailySalesReport>>.Error($"Lỗi tạo báo cáo doanh thu: {ex.Message}");
            }
        }

        public ServiceResult<List<ReportDao.ProductSalesReport>> GetTopSellingProducts(DateTime fromDate, DateTime toDate, int topCount = 10)
        {
            try
            {
                if (topCount <= 0 || topCount > 100)
                {
                    return ServiceResult<List<ReportDao.ProductSalesReport>>.Error("Số lượng sản phẩm phải từ 1 đến 100.");
                }

                var reports = reportDao.GetTopSellingProducts(fromDate, toDate, topCount);
                return ServiceResult<List<ReportDao.ProductSalesReport>>.Success(reports);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<ReportDao.ProductSalesReport>>.Error($"Lỗi tạo báo cáo sản phẩm bán chạy: {ex.Message}");
            }
        }

        public ServiceResult<List<ReportDao.EmployeePerformanceReport>> GetEmployeePerformanceReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var reports = reportDao.GetEmployeePerformanceReport(fromDate, toDate);
                return ServiceResult<List<ReportDao.EmployeePerformanceReport>>.Success(reports);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<ReportDao.EmployeePerformanceReport>>.Error($"Lỗi tạo báo cáo hiệu suất nhân viên: {ex.Message}");
            }
        }

        public ServiceResult<ReportDao.DashboardStats> GetDashboardStats()
        {
            try
            {
                var stats = reportDao.GetDashboardStats();
                return ServiceResult<ReportDao.DashboardStats>.Success(stats);
            }
            catch (Exception ex)
            {
                return ServiceResult<ReportDao.DashboardStats>.Error($"Lỗi lấy thống kê dashboard: {ex.Message}");
            }
        }
    }
}
