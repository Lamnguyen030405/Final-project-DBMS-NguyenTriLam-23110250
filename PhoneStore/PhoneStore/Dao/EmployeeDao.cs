using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStoreManagement.Models;

namespace PhoneStore.Dao
{
    public class EmployeeDao : BaseDao
    {
        public class EmployeeListItem
        {
            public int Value { get; set; }
            public string Text { get; set; }
            public string Position { get; set; }
            public string Status { get; set; }
        }

        public List<Employee> GetAllEmployees()
        {
            string query = @"
                SELECT e.*, 
                       CASE WHEN u.user_id IS NOT NULL THEN 1 ELSE 0 END as has_user,
                       u.username,
                       u.last_login
                FROM employees e
                LEFT JOIN users u ON e.employee_id = u.employee_id
                ORDER BY e.full_name";

            var dataTable = ExecuteQuery(query);
            var employees = new List<Employee>();

            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(MapRowToEmployee(row));
            }

            return employees;
        }

        public List<Employee> GetActiveEmployees()
        {
            string query = @"
                SELECT e.*, 
                       CASE WHEN u.user_id IS NOT NULL THEN 1 ELSE 0 END as has_user,
                       u.username,
                       u.last_login
                FROM employees e
                LEFT JOIN users u ON e.employee_id = u.employee_id
                WHERE e.status = 'active'
                ORDER BY e.full_name";

            var dataTable = ExecuteQuery(query);
            var employees = new List<Employee>();

            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(MapRowToEmployee(row));
            }

            return employees;
        }

        public List<EmployeeListItem> GetEmployeesForComboBox(bool includeAll = true)
        {
            var items = new List<EmployeeListItem>();

            if (includeAll)
            {
                items.Add(new EmployeeListItem
                {
                    Value = -1,
                    Text = "Tất cả nhân viên",
                    Position = "",
                    Status = "all"
                });
            }

            string query = "SELECT * FROM v_ActiveEmployees ORDER BY position, full_name";
            var dataTable = ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                items.Add(new EmployeeListItem
                {
                    Value = Convert.ToInt32(row["employee_id"]),
                    Text = row["full_name"].ToString(),
                    Position = row["position"].ToString(),
                    Status = row["status"].ToString()
                });
            }

            return items;
        }

        public List<Employee> GetEmployeesByPosition(string position)
        {
            string query = @"
                SELECT e.*, 
                       CASE WHEN u.user_id IS NOT NULL THEN 1 ELSE 0 END as has_user,
                       u.username,
                       u.last_login
                FROM employees e
                LEFT JOIN users u ON e.employee_id = u.employee_id
                WHERE e.status = 'active' AND e.position = @position
                ORDER BY e.full_name";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@position", position)
            };

            var dataTable = ExecuteQuery(query, parameters);
            var employees = new List<Employee>();

            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(MapRowToEmployee(row));
            }

            return employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            string query = @"
                SELECT e.*, 
                       CASE WHEN u.user_id IS NOT NULL THEN 1 ELSE 0 END as has_user,
                       u.username,
                       u.last_login
                FROM employees e
                LEFT JOIN users u ON e.employee_id = u.employee_id
                WHERE e.employee_id = @employeeId";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeId", employeeId)
            };

            var dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return MapRowToEmployee(dataTable.Rows[0]);
            }

            return null;
        }

        public Employee GetEmployeeByCode(string employeeCode)
        {
            string query = @"
                SELECT e.*, 
                       CASE WHEN u.user_id IS NOT NULL THEN 1 ELSE 0 END as has_user,
                       u.username,
                       u.last_login
                FROM employees e
                LEFT JOIN users u ON e.employee_id = u.employee_id
                WHERE e.employee_code = @employeeCode";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeCode", employeeCode)
            };

            var dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return MapRowToEmployee(dataTable.Rows[0]);
            }

            return null;
        }

        public List<Employee> SearchEmployees(string keyword)
        {
            string query = @"
                SELECT e.*, 
                       CASE WHEN u.user_id IS NOT NULL THEN 1 ELSE 0 END as has_user,
                       u.username,
                       u.last_login
                FROM employees e
                LEFT JOIN users u ON e.employee_id = u.employee_id
                WHERE (e.full_name LIKE '%' + @keyword + '%' 
                      OR e.employee_code LIKE '%' + @keyword + '%'
                      OR e.phone LIKE '%' + @keyword + '%'
                      OR e.email LIKE '%' + @keyword + '%')
                AND e.status = 'active'
                ORDER BY e.full_name";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@keyword", keyword ?? "")
            };

            var dataTable = ExecuteQuery(query, parameters);
            var employees = new List<Employee>();

            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(MapRowToEmployee(row));
            }

            return employees;
        }

        public bool InsertEmployee(Employee employee)
        {
            string query = @"
                INSERT INTO employees (employee_code, full_name, phone, email, address, 
                                     position, hire_date, salary, status)
                VALUES (@code, @fullName, @phone, @email, @address, 
                       @position, @hireDate, @salary, @status)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@code", employee.EmployeeCode),
                new SqlParameter("@fullName", employee.FullName),
                new SqlParameter("@phone", employee.Phone ?? ""),
                new SqlParameter("@email", employee.Email ?? ""),
                new SqlParameter("@address", employee.Address ?? ""),
                new SqlParameter("@position", employee.Position ?? ""),
                new SqlParameter("@hireDate", employee.HireDate),
                new SqlParameter("@salary", employee.Salary),
                new SqlParameter("@status", employee.Status ?? "active")
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            string query = @"
                UPDATE employees 
                SET full_name = @fullName, phone = @phone, email = @email, 
                    address = @address, position = @position, hire_date = @hireDate,
                    salary = @salary, status = @status, updated_at = GETDATE()
                WHERE employee_id = @employeeId";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@fullName", employee.FullName),
                new SqlParameter("@phone", employee.Phone ?? ""),
                new SqlParameter("@email", employee.Email ?? ""),
                new SqlParameter("@address", employee.Address ?? ""),
                new SqlParameter("@position", employee.Position ?? ""),
                new SqlParameter("@hireDate", employee.HireDate),
                new SqlParameter("@salary", employee.Salary),
                new SqlParameter("@status", employee.Status ?? "active"),
                new SqlParameter("@employeeId", employee.EmployeeId)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteEmployee(int employeeId)
        {
            // Soft delete - just update status
            string query = @"
                UPDATE employees 
                SET status = 'inactive', updated_at = GETDATE()
                WHERE employee_id = @employeeId";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeId", employeeId)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public string GenerateEmployeeCode()
        {
            string query = @"
                SELECT 'EMP' + RIGHT('000' + CAST(COALESCE(MAX(CAST(RIGHT(employee_code, 3) AS INT)), 0) + 1 AS NVARCHAR(3)), 3)
                FROM employees 
                WHERE employee_code LIKE 'EMP%'";

            var result = ExecuteScalar(query);
            return result?.ToString() ?? "EMP001";
        }

        public bool IsEmployeeCodeExists(string employeeCode, int? excludeEmployeeId = null)
        {
            string query = "SELECT COUNT(1) FROM employees WHERE employee_code = @code";

            if (excludeEmployeeId.HasValue)
            {
                query += " AND employee_id != @excludeId";
            }

            var parameters = excludeEmployeeId.HasValue
                ? new SqlParameter[]
                  {
                      new SqlParameter("@code", employeeCode),
                      new SqlParameter("@excludeId", excludeEmployeeId.Value)
                  }
                : new SqlParameter[]
                  {
                      new SqlParameter("@code", employeeCode)
                  };

            var result = ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public bool IsEmailExists(string email, int? excludeEmployeeId = null)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string query = "SELECT COUNT(1) FROM employees WHERE email = @email AND email != ''";

            if (excludeEmployeeId.HasValue)
            {
                query += " AND employee_id != @excludeId";
            }

            var parameters = excludeEmployeeId.HasValue
                ? new SqlParameter[]
                  {
                      new SqlParameter("@email", email),
                      new SqlParameter("@excludeId", excludeEmployeeId.Value)
                  }
                : new SqlParameter[]
                  {
                      new SqlParameter("@email", email)
                  };

            var result = ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public Dictionary<string, int> GetEmployeeCountByPosition()
        {
            string query = @"
                SELECT position, COUNT(*) as count
                FROM employees
                WHERE status = 'active'
                GROUP BY position
                ORDER BY position";

            var dataTable = ExecuteQuery(query);
            var result = new Dictionary<string, int>();

            foreach (DataRow row in dataTable.Rows)
            {
                var position = row["position"].ToString();
                var count = Convert.ToInt32(row["count"]);
                result[position] = count;
            }

            return result;
        }

        private Employee MapRowToEmployee(DataRow row)
        {
            return new Employee
            {
                EmployeeId = Convert.ToInt32(row["employee_id"]),
                EmployeeCode = row["employee_code"].ToString(),
                FullName = row["full_name"].ToString(),
                Phone = row["phone"].ToString(),
                Email = row["email"].ToString(),
                Address = row["address"].ToString(),
                Position = row["position"].ToString(),
                HireDate = Convert.ToDateTime(row["hire_date"]),
                Salary = Convert.ToDecimal(row["salary"]),
                Status = row["status"].ToString()
            };
        }
    }
}