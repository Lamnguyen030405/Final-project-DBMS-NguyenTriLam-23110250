using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Configs
{
    public class DBConnection
    {
        private static string sqlStr = "Data Source=.;Initial Catalog=phone_store_db;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(sqlStr);
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
    }
}
