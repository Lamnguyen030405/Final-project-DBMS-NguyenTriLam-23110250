using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Configs
{
    public static class DBConnection
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        public static string GetConnectionString()
        {
            return $"Data Source=.;Initial Catalog=phone_store_db;User ID={Username};Password={Password}";
        }

        private static string defaultConnStr = "Data Source=.;Initial Catalog=phone_store_db;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public static SqlConnection GetDefaultConnection()
        {
            return new SqlConnection(defaultConnStr);
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool TestDefaultConnection()
        {
            try
            {
                using (var conn = GetDefaultConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }

}
