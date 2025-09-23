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
    public class OrderDao : BaseDao
    {
        public List<Order> GetAllOrders(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@fromDate", (object)fromDate ?? DBNull.Value),
                new SqlParameter("@toDate", (object)toDate ?? DBNull.Value)
            };

            string query = "SELECT * FROM fn_GetAllOrders(@fromDate, @toDate)";
            var dataTable = ExecuteQuery(query, parameters.ToArray());

            var orders = new List<Order>();
            foreach (DataRow row in dataTable.Rows)
            {
                orders.Add(MapRowToOrder(row));
            }

            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@orderId", orderId)
            };

            var dataTable = ExecuteQuery("sp_GetOrderById", parameters, isStoredProcedure: true);

            if (dataTable.Rows.Count > 0)
            {
                var order = MapRowToOrder(dataTable.Rows[0]);
                order.OrderDetails = GetOrderDetails(orderId);
                return order;
            }

            return null;
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@orderId", orderId)
            };

            var dataTable = ExecuteQuery("sp_GetOrderDetails", parameters, isStoredProcedure: true);
            var details = new List<OrderDetail>();

            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(MapRowToOrderDetail(row));
            }

            return details;
        }

        public string GenerateOrderCode()
        {
            const string query = "SELECT dbo.fn_GenerateOrderCode()";
            var result = ExecuteScalar(query);
            return result?.ToString() ?? "ORD" + DateTime.Now.ToString("yyyyMMdd") + "0001";
        }

        public int InsertOrder(Order order, List<OrderDetail> orderDetails)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert Order using stored procedure
                        using (var cmd = new SqlCommand("sp_InsertOrder", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            var orderIdParam = new SqlParameter("@order_id", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };

                            cmd.Parameters.AddRange(new SqlParameter[]
                            {
                                new SqlParameter("@order_code", order.OrderCode),
                                new SqlParameter("@customer_id", (object)order.CustomerId ?? DBNull.Value),
                                new SqlParameter("@employee_id", (object)order.EmployeeId ?? DBNull.Value),
                                new SqlParameter("@order_date", order.OrderDate),
                                new SqlParameter("@subtotal", order.Subtotal),
                                new SqlParameter("@discount_amount", order.DiscountAmount),
                                new SqlParameter("@tax_amount", order.TaxAmount),
                                new SqlParameter("@total_amount", order.TotalAmount),
                                new SqlParameter("@promotion_id", (object)order.PromotionId ?? DBNull.Value),
                                new SqlParameter("@payment_method", order.PaymentMethod),
                                new SqlParameter("@payment_status", order.PaymentStatus),
                                new SqlParameter("@order_status", order.OrderStatus),
                                new SqlParameter("@notes", order.Notes ?? ""),
                                orderIdParam
                            });

                            cmd.ExecuteNonQuery();
                            int orderId = Convert.ToInt32(orderIdParam.Value);

                            // 2. Insert Order Details
                            foreach (var detail in orderDetails)
                            {
                                using (var detailCmd = new SqlCommand("sp_InsertOrderDetail", conn, transaction))
                                {
                                    detailCmd.CommandType = CommandType.StoredProcedure;

                                    detailCmd.Parameters.AddRange(new SqlParameter[]
                                    {
                                        new SqlParameter("@order_id", orderId),
                                        new SqlParameter("@product_id", detail.ProductId),
                                        new SqlParameter("@quantity", detail.Quantity),
                                        new SqlParameter("@unit_price", detail.UnitPrice),
                                        new SqlParameter("@discount_per_item", detail.DiscountPerItem),
                                        new SqlParameter("@total_price", detail.TotalPrice)
                                    });

                                    detailCmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            return orderId;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool UpdateOrderStatus(int orderId, string newStatus)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@orderId", orderId),
                new SqlParameter("@newStatus", newStatus)
            };

            return ExecuteNonQuery("sp_UpdateOrderStatus", parameters, isStoredProcedure: true) > 0;
        }

        public bool UpdatePaymentStatus(int orderId, string newStatus)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@orderId", orderId),
                new SqlParameter("@newStatus", newStatus)
            };

            return ExecuteNonQuery("sp_UpdatePaymentStatus", parameters, isStoredProcedure: true) > 0;
        }

        public decimal GetTotalRevenue(DateTime? fromDate = null, DateTime? toDate = null)
        {
            string query = @"
                SELECT COALESCE(SUM(total_amount), 0) 
                FROM orders 
                WHERE order_status = 'completed'";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (fromDate.HasValue)
            {
                query += " AND CAST(order_date AS DATE) >= @fromDate";
                parameters.Add(new SqlParameter("@fromDate", fromDate.Value.Date));
            }

            if (toDate.HasValue)
            {
                query += " AND CAST(order_date AS DATE) <= @toDate";
                parameters.Add(new SqlParameter("@toDate", toDate.Value.Date));
            }

            var result = ExecuteScalar(query, parameters.ToArray());
            return Convert.ToDecimal(result);
        }

        private Order MapRowToOrder(DataRow row)
        {
            return new Order
            {
                OrderId = Convert.ToInt32(row["order_id"]),
                OrderCode = row["order_code"].ToString(),
                CustomerId = (int)(row["customer_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["customer_id"])),
                EmployeeId = (int)(row["employee_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["employee_id"])),
                OrderDate = Convert.ToDateTime(row["order_date"]),
                Subtotal = Convert.ToDecimal(row["subtotal"]),
                DiscountAmount = Convert.ToDecimal(row["discount_amount"]),
                TaxAmount = Convert.ToDecimal(row["tax_amount"]),
                TotalAmount = Convert.ToDecimal(row["total_amount"]),
                PromotionId = row["promotion_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["promotion_id"]),
                PaymentMethod = row["payment_method"].ToString(),
                PaymentStatus = row["payment_status"].ToString(),
                OrderStatus = row["order_status"].ToString(),
                Notes = row["notes"].ToString(),
                CustomerName = row["customer_name"].ToString(),
                EmployeeName = row["employee_name"].ToString(),
                CreatedAt = Convert.ToDateTime(row["created_at"])
            };
        }

        private OrderDetail MapRowToOrderDetail(DataRow row)
        {
            return new OrderDetail
            {
                DetailId = Convert.ToInt32(row["detail_id"]),
                OrderId = Convert.ToInt32(row["order_id"]),
                ProductId = Convert.ToInt32(row["product_id"]),
                Quantity = Convert.ToInt32(row["quantity"]),
                UnitPrice = Convert.ToDecimal(row["unit_price"]),
                DiscountPerItem = Convert.ToDecimal(row["discount_per_item"]),
                TotalPrice = Convert.ToDecimal(row["total_price"]),
                ProductName = row["product_name"].ToString(),
                ProductCode = row["product_code"].ToString(),
                WarrantyStartDate = row["warranty_start_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["warranty_start_date"]),
                WarrantyEndDate = row["warranty_end_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["warranty_end_date"])
            };
        }
    }
}
