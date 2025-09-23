using PhoneStore.Configs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Dao
{
    public abstract class BaseDao
    {
        protected SqlConnection GetConnection()
        {
            return DBConnection.GetConnection();
        }

        protected int ExecuteNonQuery(string commandText, SqlParameter[] parameters = null, bool isStoredProcedure = false)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteNonQuery();
                }
            }
        }


        protected object ExecuteScalar(string commandText, SqlParameter[] parameters = null, bool isStoredProcedure = false)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteScalar();
                }
            }
        }

        protected DataTable ExecuteQuery(string name, SqlParameter[] parameters = null, bool isStoredProcedure = false)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(name, conn))
                {
                    cmd.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected T ExecuteStoredProcedure<T>(string procedureName, SqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    var result = cmd.ExecuteScalar();
                    return (T)Convert.ChangeType(result, typeof(T));
                }
            }
        }
    }
}
