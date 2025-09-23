using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Dao
{
    public class CustomerDao : BaseDao
    {
        public List<Customer> GetAllCustomers()
        {
            string query = @"
                SELECT c.*, 
                       COUNT(o.order_id) as total_orders,
                       COALESCE(MAX(o.order_date), c.created_at) as last_order_date
                FROM customers c
                LEFT JOIN orders o ON c.customer_id = o.customer_id AND o.order_status = 'completed'
                WHERE c.customer_code IS NOT NULL
                GROUP BY c.customer_id, c.customer_code, c.full_name, c.phone, c.email, 
                         c.address, c.date_of_birth, c.gender, c.customer_type, 
                         c.total_spent, c.created_at, c.updated_at
                ORDER BY c.total_spent DESC";

            var dataTable = ExecuteQuery(query);
            var customers = new List<Customer>();

            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(MapRowToCustomer(row));
            }

            return customers;
        }

        public List<Customer> SearchCustomers(string keyword)
        {
            string query = @"
                SELECT c.*, 
                       COUNT(o.order_id) as total_orders,
                       COALESCE(MAX(o.order_date), c.created_at) as last_order_date
                FROM customers c
                LEFT JOIN orders o ON c.customer_id = o.customer_id AND o.order_status = 'completed'
                WHERE (c.full_name LIKE '%' + @keyword + '%' 
                      OR c.phone LIKE '%' + @keyword + '%'
                      OR c.customer_code LIKE '%' + @keyword + '%'
                      OR c.email LIKE '%' + @keyword + '%')
                GROUP BY c.customer_id, c.customer_code, c.full_name, c.phone, c.email, 
                         c.address, c.date_of_birth, c.gender, c.customer_type, 
                         c.total_spent, c.created_at, c.updated_at
                ORDER BY c.total_spent DESC";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@keyword", keyword ?? "")
            };

            var dataTable = ExecuteQuery(query, parameters);
            var customers = new List<Customer>();

            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(MapRowToCustomer(row));
            }

            return customers;
        }

        public Customer GetCustomerByPhone(string phone)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@phone", phone)
            };

            var dataTable = ExecuteQuery("sp_GetCustomerByPhone", parameters, isStoredProcedure: true);

            if (dataTable.Rows.Count > 0)
            {
                return MapRowToCustomer(dataTable.Rows[0]);
            }

            return null;
        }

        public string GenerateCustomerCode()
        {
            const string query = "SELECT dbo.fn_GenerateCustomerCode()";
            var result = ExecuteScalar(query);
            return result?.ToString() ?? "CUS" + DateTime.Now.ToString("yyyyMMdd") + "0001";
        }

        public bool InsertCustomer(Customer customer)
        {
            customer.CustomerCode = GenerateCustomerCode();

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@customer_code", customer.CustomerCode),
                new SqlParameter("@full_name", customer.FullName),
                new SqlParameter("@phone", customer.Phone ?? ""),
                new SqlParameter("@email", customer.Email ?? ""),
                new SqlParameter("@address", customer.Address ?? ""),
                new SqlParameter("@date_of_birth", (object)customer.DateOfBirth ?? DBNull.Value),
                new SqlParameter("@gender", customer.Gender ?? ""),
                new SqlParameter("@customer_type", customer.CustomerType ?? "regular")
            };

            return ExecuteNonQuery("sp_InsertCustomer", parameters, isStoredProcedure: true) > 0;
        }

        public List<Customer> GetVIPCustomers()
        {
            string query = @"
                SELECT c.*, 
                       COUNT(o.order_id) as total_orders,
                       COALESCE(MAX(o.order_date), c.created_at) as last_order_date
                FROM customers c
                LEFT JOIN orders o ON c.customer_id = o.customer_id AND o.order_status = 'completed'
                WHERE c.customer_type = 'vip' OR c.total_spent >= 10000000
                GROUP BY c.customer_id, c.customer_code, c.full_name, c.phone, c.email, 
                         c.address, c.date_of_birth, c.gender, c.customer_type, 
                         c.total_spent, c.created_at, c.updated_at
                ORDER BY c.total_spent DESC";

            var dataTable = ExecuteQuery(query);
            var customers = new List<Customer>();

            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(MapRowToCustomer(row));
            }

            return customers;
        }

        private Customer MapRowToCustomer(DataRow row)
        {
            return new Customer
            {
                CustomerId = Convert.ToInt32(row["customer_id"]),
                CustomerCode = row["customer_code"].ToString(),
                FullName = row["full_name"].ToString(),
                Phone = row["phone"].ToString(),
                Email = row["email"].ToString(),
                Address = row["address"].ToString(),
                DateOfBirth = row["date_of_birth"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["date_of_birth"]),
                Gender = row["gender"].ToString(),
                CustomerType = row["customer_type"].ToString(),
                TotalSpent = Convert.ToDecimal(row["total_spent"]),
                CreatedAt = Convert.ToDateTime(row["created_at"])
            };
        }
    }
}
