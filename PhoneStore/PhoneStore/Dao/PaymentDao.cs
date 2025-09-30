using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Dao
{
    public class PaymentDao : BaseDao
    {
        public List<Payment> GetPaymentsByOrderId(int orderId)
        {
            try
            {
                string query = @"
                    SELECT p.*, o.order_code, o.total_amount as order_total_amount, 
                           COALESCE(c.full_name, 'Khách lẻ') as customer_name
                    FROM payments p
                    INNER JOIN orders o ON p.order_id = o.order_id
                    LEFT JOIN customers c ON o.customer_id = c.customer_id
                    WHERE p.order_id = @orderId
                    ORDER BY p.payment_date DESC";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@orderId", orderId)
                };

                var dataTable = ExecuteQuery(query, parameters);
                var payments = new List<Payment>();

                foreach (DataRow row in dataTable.Rows)
                {
                    payments.Add(MapRowToPayment(row));
                }

                return payments;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách thanh toán: {ex.Message}");
            }
        }

        public Payment GetPaymentById(int paymentId)
        {
            try
            {
                string query = @"
                    SELECT p.*, o.order_code, o.total_amount as order_total_amount, 
                           COALESCE(c.full_name, 'Khách lẻ') as customer_name
                    FROM payments p
                    INNER JOIN orders o ON p.order_id = o.order_id
                    LEFT JOIN customers c ON o.customer_id = c.customer_id
                    WHERE p.payment_id = @paymentId";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@paymentId", paymentId)
                };

                var dataTable = ExecuteQuery(query, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    return MapRowToPayment(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thông tin thanh toán: {ex.Message}");
            }
        }

        public PaymentSummary GetPaymentSummaryByOrderId(int orderId)
        {
            try
            {
                string query = "SELECT * FROM fn_GetPaymentSummaryByOrderId(@orderId)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@orderId", orderId)
                };

                var dataTable = ExecuteQuery(query, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    return MapRowToPaymentSummary(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy tóm tắt thanh toán: {ex.Message}");
            }
        }

        public int InsertPayment(Payment payment)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@order_id", payment.OrderId),
                    new SqlParameter("@payment_date", payment.PaymentDate),
                    new SqlParameter("@payment_method", payment.PaymentMethod),
                    new SqlParameter("@amount", payment.Amount),
                    new SqlParameter("@reference_number", payment.ReferenceNumber ?? ""),
                    new SqlParameter("@status", payment.Status),
                    new SqlParameter("@notes", payment.Notes ?? ""),
                    new SqlParameter
                    {
                        ParameterName = "@payment_id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    }
                };

                ExecuteNonQuery("sp_InsertPayment", parameters, isStoredProcedure: true);

                return Convert.ToInt32(parameters.First(p => p.ParameterName == "@payment_id").Value);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thêm thanh toán: {ex.Message}");
            }
        }

        public bool UpdatePayment(Payment payment)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string updateQuery = @"
                                UPDATE payments 
                                SET payment_method = @paymentMethod, 
                                    amount = @amount,
                                    reference_number = @referenceNumber,
                                    status = @status,
                                    notes = @notes
                                WHERE order_id = @orderId";

                            using (var cmd = new SqlCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddRange(new SqlParameter[]
                                {
                                    new SqlParameter("@paymentMethod", payment.PaymentMethod),
                                    new SqlParameter("@amount", payment.Amount),
                                    new SqlParameter("@referenceNumber", payment.ReferenceNumber ?? ""),
                                    new SqlParameter("@status", payment.Status),
                                    new SqlParameter("@notes", payment.Notes ?? ""),
                                    new SqlParameter("@orderId", payment.OrderId)
                                });

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Update order payment status
                                    UpdateOrderPaymentStatus(payment.OrderId);
                                    transaction.Commit();
                                    return true;
                                }
                            }

                            transaction.Rollback();
                            return false;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật thanh toán: {ex.Message}");
            }
        }

        public bool DeletePayment(int paymentId)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@paymentId", paymentId)
                };

                ExecuteNonQuery("sp_DeletePayment", parameters, isStoredProcedure: true);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xóa thanh toán: {ex.Message}");
            }
        }

        public void UpdateOrderPaymentStatus(int orderId)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@orderId", orderId)
                };

                ExecuteNonQuery("sp_UpdateOrderPaymentStatus", parameters, isStoredProcedure: true);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật trạng thái thanh toán: {ex.Message}");
            }
        }

        public List<Payment> GetPaymentsByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string query = @"
                    SELECT p.*, o.order_code, o.total_amount as order_total_amount, 
                           COALESCE(c.full_name, 'Khách lẻ') as customer_name
                    FROM payments p
                    INNER JOIN orders o ON p.order_id = o.order_id
                    LEFT JOIN customers c ON o.customer_id = c.customer_id
                    WHERE CAST(p.payment_date AS DATE) BETWEEN @fromDate AND @toDate
                    AND p.status = 'successful'
                    ORDER BY p.payment_date DESC";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@fromDate", fromDate.Date),
                    new SqlParameter("@toDate", toDate.Date)
                };

                var dataTable = ExecuteQuery(query, parameters);
                var payments = new List<Payment>();

                foreach (DataRow row in dataTable.Rows)
                {
                    payments.Add(MapRowToPayment(row));
                }

                return payments;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách thanh toán theo khoảng thời gian: {ex.Message}");
            }
        }

        public decimal GetTotalPaymentsByMethod(string paymentMethod, DateTime fromDate, DateTime toDate)
        {
            try
            {
                string query = @"
                    SELECT COALESCE(SUM(amount), 0) as total_amount
                    FROM payments 
                    WHERE payment_method = @paymentMethod
                    AND CAST(payment_date AS DATE) BETWEEN @fromDate AND @toDate
                    AND status = 'successful'";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@paymentMethod", paymentMethod),
                    new SqlParameter("@fromDate", fromDate.Date),
                    new SqlParameter("@toDate", toDate.Date)
                };

                var result = ExecuteScalar(query, parameters);
                return Convert.ToDecimal(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tính tổng thanh toán theo phương thức: {ex.Message}");
            }
        }

        private Payment MapRowToPayment(DataRow row)
        {
            return new Payment
            {
                PaymentId = Convert.ToInt32(row["payment_id"]),
                OrderId = Convert.ToInt32(row["order_id"]),
                PaymentDate = Convert.ToDateTime(row["payment_date"]),
                PaymentMethod = row["payment_method"].ToString(),
                Amount = Convert.ToDecimal(row["amount"]),
                ReferenceNumber = row["reference_number"].ToString(),
                Status = row["status"].ToString(),
                Notes = row["notes"].ToString(),
                CreatedAt = Convert.ToDateTime(row["created_at"]),
                OrderCode = row["order_code"].ToString(),
                CustomerName = row["customer_name"].ToString(),
                OrderTotalAmount = Convert.ToDecimal(row["order_total_amount"])
            };
        }

        private PaymentSummary MapRowToPaymentSummary(DataRow row)
        {
            return new PaymentSummary
            {
                OrderId = Convert.ToInt32(row["order_id"]),
                OrderCode = row["order_code"].ToString(),
                TotalOrderAmount = Convert.ToDecimal(row["total_order_amount"]),
                TotalPaidAmount = Convert.ToDecimal(row["total_paid_amount"]),
                RemainingAmount = Convert.ToDecimal(row["remaining_amount"]),
                PaymentStatus = row["payment_status"].ToString(),
                PaymentCount = Convert.ToInt32(row["payment_count"]),
                LastPaymentDate = row["last_payment_date"] == DBNull.Value ?
                    (DateTime?)null : Convert.ToDateTime(row["last_payment_date"])
            };
        }
    }
}
