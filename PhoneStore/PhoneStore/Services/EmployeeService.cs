using PhoneStore.Dao;
using PhoneStore.Utils;
using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class EmployeeService
    {
        private EmployeeDao employeeDao;

        public EmployeeService()
        {
            employeeDao = new EmployeeDao();
        }

        public ServiceResult<List<Employee>> GetAllEmployees()
        {
            try
            {
                var employees = employeeDao.GetAllEmployees();
                return ServiceResult<List<Employee>>.Success(employees);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Employee>>.Error($"Lỗi tải danh sách nhân viên: {ex.Message}");
            }
        }

        public ServiceResult<List<Employee>> GetActiveEmployees()
        {
            try
            {
                var employees = employeeDao.GetActiveEmployees();
                return ServiceResult<List<Employee>>.Success(employees);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Employee>>.Error($"Lỗi tải danh sách nhân viên hoạt động: {ex.Message}");
            }
        }

        public ServiceResult<List<EmployeeDao.EmployeeListItem>> GetEmployeesForComboBox(bool includeAll = true)
        {
            try
            {
                var items = employeeDao.GetEmployeesForComboBox(includeAll);
                return ServiceResult<List<EmployeeDao.EmployeeListItem>>.Success(items);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<EmployeeDao.EmployeeListItem>>.Error($"Lỗi tải danh sách nhân viên cho ComboBox: {ex.Message}");
            }
        }

        public ServiceResult<List<Employee>> GetEmployeesByPosition(string position)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(position))
                {
                    return ServiceResult<List<Employee>>.Error("Vị trí công việc không được để trống");
                }

                var employees = employeeDao.GetEmployeesByPosition(position);
                return ServiceResult<List<Employee>>.Success(employees);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Employee>>.Error($"Lỗi tải danh sách nhân viên theo vị trí: {ex.Message}");
            }
        }

        public ServiceResult<Employee> GetEmployeeById(int employeeId)
        {
            try
            {
                if (employeeId <= 0)
                {
                    return ServiceResult<Employee>.Error("ID nhân viên không hợp lệ");
                }

                var employee = employeeDao.GetEmployeeById(employeeId);

                if (employee == null)
                {
                    return ServiceResult<Employee>.Error("Không tìm thấy nhân viên");
                }

                return ServiceResult<Employee>.Success(employee);
            }
            catch (Exception ex)
            {
                return ServiceResult<Employee>.Error($"Lỗi tải thông tin nhân viên: {ex.Message}");
            }
        }

        public ServiceResult<Employee> GetEmployeeByCode(string employeeCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(employeeCode))
                {
                    return ServiceResult<Employee>.Error("Mã nhân viên không được để trống");
                }

                var employee = employeeDao.GetEmployeeByCode(employeeCode);

                if (employee == null)
                {
                    return ServiceResult<Employee>.Error("Không tìm thấy nhân viên");
                }

                return ServiceResult<Employee>.Success(employee);
            }
            catch (Exception ex)
            {
                return ServiceResult<Employee>.Error($"Lỗi tải thông tin nhân viên: {ex.Message}");
            }
        }

        public ServiceResult<List<Employee>> SearchEmployees(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    return GetActiveEmployees();
                }

                if (keyword.Length < 2)
                {
                    return ServiceResult<List<Employee>>.Error("Từ khóa tìm kiếm phải có ít nhất 2 ký tự");
                }

                var employees = employeeDao.SearchEmployees(keyword);
                return ServiceResult<List<Employee>>.Success(employees);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Employee>>.Error($"Lỗi tìm kiếm nhân viên: {ex.Message}");
            }
        }

        public ServiceResult<bool> CreateEmployee(Employee employee)
        {
            try
            {
                // Validate input
                var validationResult = ValidateEmployee(employee, isCreate: true);
                if (!validationResult.IsSuccess)
                {
                    return ServiceResult<bool>.Error(validationResult.Message);
                }

                // Generate employee code if not provided
                if (string.IsNullOrWhiteSpace(employee.EmployeeCode))
                {
                    employee.EmployeeCode = employeeDao.GenerateEmployeeCode();
                }

                // Check for duplicates
                if (employeeDao.IsEmployeeCodeExists(employee.EmployeeCode))
                {
                    return ServiceResult<bool>.Error("Mã nhân viên đã tồn tại");
                }

                if (!string.IsNullOrWhiteSpace(employee.Email) && employeeDao.IsEmailExists(employee.Email))
                {
                    return ServiceResult<bool>.Error("Email đã được sử dụng bởi nhân viên khác");
                }

                // Set default values
                employee.Status = "active";

                var success = employeeDao.InsertEmployee(employee);

                if (success)
                {
                    return ServiceResult<bool>.Success(true, "Thêm nhân viên thành công");
                }
                else
                {
                    return ServiceResult<bool>.Error("Có lỗi xảy ra khi thêm nhân viên");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Error($"Lỗi thêm nhân viên: {ex.Message}");
            }
        }

        public ServiceResult<bool> UpdateEmployee(Employee employee)
        {
            try
            {
                // Validate input
                var validationResult = ValidateEmployee(employee, isCreate: false);
                if (!validationResult.IsSuccess)
                {
                    return ServiceResult<bool>.Error(validationResult.Message);
                }

                // Check for duplicates (excluding current employee)
                if (employeeDao.IsEmployeeCodeExists(employee.EmployeeCode, employee.EmployeeId))
                {
                    return ServiceResult<bool>.Error("Mã nhân viên đã tồn tại");
                }

                if (!string.IsNullOrWhiteSpace(employee.Email) && employeeDao.IsEmailExists(employee.Email, employee.EmployeeId))
                {
                    return ServiceResult<bool>.Error("Email đã được sử dụng bởi nhân viên khác");
                }

                var success = employeeDao.UpdateEmployee(employee);

                if (success)
                {
                    return ServiceResult<bool>.Success(true, "Cập nhật nhân viên thành công");
                }
                else
                {
                    return ServiceResult<bool>.Error("Không tìm thấy nhân viên hoặc có lỗi xảy ra");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Error($"Lỗi cập nhật nhân viên: {ex.Message}");
            }
        }

        public ServiceResult<bool> DeleteEmployee(int employeeId)
        {
            try
            {
                if (employeeId <= 0)
                {
                    return ServiceResult<bool>.Error("ID nhân viên không hợp lệ");
                }

                // Check if employee exists
                var employee = employeeDao.GetEmployeeById(employeeId);
                if (employee == null)
                {
                    return ServiceResult<bool>.Error("Không tìm thấy nhân viên");
                }

                var success = employeeDao.DeleteEmployee(employeeId);

                if (success)
                {
                    return ServiceResult<bool>.Success(true, "Xóa nhân viên thành công");
                }
                else
                {
                    return ServiceResult<bool>.Error("Có lỗi xảy ra khi xóa nhân viên");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Error($"Lỗi xóa nhân viên: {ex.Message}");
            }
        }

        public ServiceResult<Dictionary<string, int>> GetEmployeeStatistics()
        {
            try
            {
                var stats = employeeDao.GetEmployeeCountByPosition();
                return ServiceResult<Dictionary<string, int>>.Success(stats);
            }
            catch (Exception ex)
            {
                return ServiceResult<Dictionary<string, int>>.Error($"Lỗi tải thống kê nhân viên: {ex.Message}");
            }
        }

        private ServiceResult<bool> ValidateEmployee(Employee employee, bool isCreate)
        {
            if (employee == null)
            {
                return ServiceResult<bool>.Error("Thông tin nhân viên không được để trống");
            }

            if (string.IsNullOrWhiteSpace(employee.FullName))
            {
                return ServiceResult<bool>.Error("Họ tên không được để trống");
            }

            if (employee.FullName.Length < 2 || employee.FullName.Length > 100)
            {
                return ServiceResult<bool>.Error("Họ tên phải từ 2 đến 100 ký tự");
            }

            if (!string.IsNullOrWhiteSpace(employee.Email) && !ValidationHelper.IsValidEmail(employee.Email))
            {
                return ServiceResult<bool>.Error("Email không hợp lệ");
            }

            if (!string.IsNullOrWhiteSpace(employee.Phone) && !ValidationHelper.IsValidPhoneNumber(employee.Phone))
            {
                return ServiceResult<bool>.Error("Số điện thoại không hợp lệ");
            }

            if (employee.HireDate > DateTime.Now.Date)
            {
                return ServiceResult<bool>.Error("Ngày vào làm không thể là ngày trong tương lai");
            }

            if (employee.Salary < 0)
            {
                return ServiceResult<bool>.Error("Lương không thể âm");
            }

            var validPositions = new[] { "Quản lý", "Thu ngân", "Bán hàng", "Kho", "Kỹ thuật" };
            if (!string.IsNullOrWhiteSpace(employee.Position) && !validPositions.Contains(employee.Position))
            {
                return ServiceResult<bool>.Error($"Vị trí công việc phải là một trong: {string.Join(", ", validPositions)}");
            }

            return ServiceResult<bool>.Success(true);
        }
    }
}