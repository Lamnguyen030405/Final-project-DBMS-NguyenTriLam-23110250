using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Dao
{
    public class UserDao : BaseDao
    {
        public User LoginUser(string username, string password)
        {
            try
            {
                int result = 0, userId = 0;

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password),
                    new SqlParameter("@result", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@user_id", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };

                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("LoginUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();

                        result = (int)cmd.Parameters["@result"].Value;
                        userId = cmd.Parameters["@user_id"].Value != DBNull.Value ?
                                (int)cmd.Parameters["@user_id"].Value : 0;
                    }
                }

                if (result == 1 && userId > 0)
                {
                    return GetUserById(userId);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đăng nhập: {ex.Message}");
            }
        }

        public User GetUserById(int userId)
        {
            string query = @"
                SELECT u.*, e.full_name as employee_name, e.position
                FROM users u
                LEFT JOIN employees e ON u.employee_id = e.employee_id
                WHERE u.user_id = @userId";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@userId", userId)
            };

            var dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                var user = new User
                {
                    UserId = Convert.ToInt32(row["user_id"]),
                    Username = row["username"].ToString(),
                    EmployeeId = row["employee_id"] == DBNull.Value ? null :
                               (int?)Convert.ToInt32(row["employee_id"]),
                    Status = row["status"].ToString(),
                    LastLogin = row["last_login"] == DBNull.Value ? null :
                              (DateTime?)Convert.ToDateTime(row["last_login"]),
                    CreatedAt = Convert.ToDateTime(row["created_at"]),
                    EmployeeName = row["employee_name"].ToString(),
                    Position = row["position"].ToString()
                };

                // Lấy vai trò của user
                user.Roles = GetUserRoles(userId);

                return user;
            }

            return null;
        }

        public List<string> GetUserRoles(int userId)
        {
            var roles = new List<string>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("CheckUserRoles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(reader["role_name"].ToString());
                        }
                    }
                }
            }

            return roles;
        }

        public bool ChangePassword(int userId, string newPassword)
        {
            try
            {
                string query = "UPDATE users SET password_hash = @password WHERE user_id = @userId";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@password", HashPassword(newPassword)),
                    new SqlParameter("@userId", userId)
                };

                return ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
