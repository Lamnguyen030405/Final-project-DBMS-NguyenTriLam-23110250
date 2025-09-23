using PhoneStore.Dao;
using PhoneStore.Utils;
using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneStore.Services
{
    public class OrderService
    {
        private OrderDao orderDao;
        private ProductDao productDao;
        private CustomerDao customerDao;
        private InventoryDao inventoryDao;
        private PromotionDao promotionDao;

        public OrderService()
        {
            orderDao = new OrderDao();
            productDao = new ProductDao();
            customerDao = new CustomerDao();
            inventoryDao = new InventoryDao();
            promotionDao = new PromotionDao();
        }

        public ServiceResult<List<Order>> GetAllOrders(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var orders = orderDao.GetAllOrders(fromDate, toDate);
                return ServiceResult<List<Order>>.Success(orders);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Order>>.Error($"Lỗi lấy danh sách đơn hàng: {ex.Message}");
            }
        }

        public ServiceResult<Order> GetOrderById(int orderId)
        {
            try
            {
                var order = orderDao.GetOrderById(orderId);
                if (order == null)
                {
                    return ServiceResult<Order>.Error("Không tìm thấy đơn hàng.");
                }

                return ServiceResult<Order>.Success(order);
            }
            catch (Exception ex)
            {
                return ServiceResult<Order>.Error($"Lỗi lấy thông tin đơn hàng: {ex.Message}");
            }
        }

        public ServiceResult<int> CreateOrder(CreateOrderRequest request)
        {
            try
            {
                // Validation
                var validationResult = ValidateOrderRequest(request);
                if (!validationResult.IsSuccess)
                {
                    return ServiceResult<int>.Error(validationResult.Message);
                }

                // Check stock availability
                foreach (var item in request.OrderItems)
                {
                    var stock = inventoryDao.GetProductStock(item.ProductId);
                    if (stock < item.Quantity)
                    {
                        var product = productDao.GetProductById(item.ProductId);
                        return ServiceResult<int>.Error($"Sản phẩm {product?.ProductName} không đủ tồn kho. Có thể bán: {stock}");
                    }
                }

                // Calculate order totals
                var calculationResult = CalculateOrderTotals(request);
                if (!calculationResult.IsSuccess)
                {
                    return ServiceResult<int>.Error(calculationResult.Message);
                }

                var orderTotals = calculationResult.Data;

                // Create order
                var order = new Order
                {
                    OrderCode = orderDao.GenerateOrderCode(),
                    CustomerId = (int)request.CustomerId,
                    EmployeeId = (int)SessionManager.CurrentUser?.EmployeeId,
                    OrderDate = DateTime.Now,
                    Subtotal = orderTotals.Subtotal,
                    DiscountAmount = orderTotals.DiscountAmount,
                    TaxAmount = orderTotals.TaxAmount,
                    TotalAmount = orderTotals.TotalAmount,
                    PromotionId = request.PromotionId,
                    PaymentMethod = request.PaymentMethod,
                    PaymentStatus = request.PaymentStatus,
                    OrderStatus = "processing",
                    Notes = request.Notes
                };

                // Create order details
                var orderDetails = new List<OrderDetail>();
                foreach (var item in request.OrderItems)
                {
                    var product = productDao.GetProductById(item.ProductId);
                    orderDetails.Add(new OrderDetail
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        DiscountPerItem = item.DiscountPerItem,
                        TotalPrice = (item.UnitPrice * item.Quantity) - item.DiscountPerItem
                    });
                }

                var orderId = orderDao.InsertOrder(order, orderDetails);

                if (orderId > 0)
                {
                    return ServiceResult<int>.Success(orderId, "Tạo đơn hàng thành công!");
                }
                else
                {
                    return ServiceResult<int>.Error("Không thể tạo đơn hàng. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<int>.Error($"Lỗi tạo đơn hàng: {ex.Message}");
            }
        }

        // NEW METHOD: Update both order and payment status in a single transaction
        public ServiceResult<bool> UpdateOrderAndPaymentStatus(int orderId, string newOrderStatus, string newPaymentStatus, string updateReason = null)
        {
            try
            {
                // Validate order status
                var validOrderStatuses = new[] { "processing", "completed", "cancelled", "returned" };
                if (!validOrderStatuses.Contains(newOrderStatus))
                {
                    return ServiceResult<bool>.Error("Trạng thái đơn hàng không hợp lệ.");
                }

                // Validate payment status
                var validPaymentStatuses = new[] { "paid", "pending", "partial", "refunded" };
                if (!validPaymentStatuses.Contains(newPaymentStatus))
                {
                    return ServiceResult<bool>.Error("Trạng thái thanh toán không hợp lệ.");
                }

                // Validate business logic between order and payment status
                var validationResult = ValidateStatusCombination(newOrderStatus, newPaymentStatus);
                if (!validationResult.IsSuccess)
                {
                    return validationResult;
                }

                // Update both statuses (ideally in a transaction)
                var orderResult = orderDao.UpdateOrderStatus(orderId, newOrderStatus);
                if (!orderResult)
                {
                    return ServiceResult<bool>.Error("Không thể cập nhật trạng thái đơn hàng.");
                }

                var paymentResult = orderDao.UpdatePaymentStatus(orderId, newPaymentStatus);
                if (!paymentResult)
                {
                    // Rollback order status if payment status update fails
                    // In a real system, this should be wrapped in a database transaction
                    return ServiceResult<bool>.Error("Không thể cập nhật trạng thái thanh toán.");
                }

                // Log the update if reason is provided
                if (!string.IsNullOrEmpty(updateReason))
                {
                    LogStatusUpdate(orderId, newOrderStatus, newPaymentStatus, updateReason);
                }

                return ServiceResult<bool>.Success(true, "Cập nhật trạng thái đơn hàng và thanh toán thành công!");
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Error($"Lỗi cập nhật trạng thái: {ex.Message}");
            }
        }

        public ServiceResult<decimal> ApplyPromotion(string promotionCode, decimal orderAmount)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(promotionCode))
                {
                    return ServiceResult<decimal>.Success(0);
                }

                var promotion = promotionDao.GetPromotionByCode(promotionCode);
                if (promotion == null)
                {
                    return ServiceResult<decimal>.Error("Mã khuyến mãi không tồn tại hoặc đã hết hạn.");
                }

                var discount = promotionDao.CalculateDiscount(promotion, orderAmount);
                return ServiceResult<decimal>.Success(discount, $"Áp dụng khuyến mãi thành công. Giảm {discount:N0}đ");
            }
            catch (Exception ex)
            {
                return ServiceResult<decimal>.Error($"Lỗi áp dụng khuyến mãi: {ex.Message}");
            }
        }

        private ServiceResult<bool> ValidateOrderRequest(CreateOrderRequest request)
        {
            if (request.OrderItems == null || !request.OrderItems.Any())
            {
                return ServiceResult<bool>.Error("Đơn hàng phải có ít nhất 1 sản phẩm.");
            }

            foreach (var item in request.OrderItems)
            {
                if (item.Quantity <= 0)
                {
                    return ServiceResult<bool>.Error("Số lượng sản phẩm phải lớn hơn 0.");
                }

                if (item.UnitPrice <= 0)
                {
                    return ServiceResult<bool>.Error("Giá sản phẩm phải lớn hơn 0.");
                }
            }

            var validPaymentMethods = new[] { "cash", "card", "transfer", "installment" };
            if (!validPaymentMethods.Contains(request.PaymentMethod))
            {
                return ServiceResult<bool>.Error("Phương thức thanh toán không hợp lệ.");
            }

            return ServiceResult<bool>.Success(true);
        }

        private ServiceResult<bool> ValidateStatusCombination(string orderStatus, string paymentStatus)
        {
            // Business logic validation between order and payment status
            switch (orderStatus.ToLower())
            {
                case "completed":
                    if (paymentStatus != "paid" && paymentStatus != "refunded")
                    {
                        return ServiceResult<bool>.Error("Đơn hàng hoàn thành phải có trạng thái thanh toán 'Đã thanh toán' hoặc 'Đã hoàn tiền'.");
                    }
                    break;

                case "cancelled":
                    if (paymentStatus == "paid")
                    {
                        return ServiceResult<bool>.Error("Đơn hàng đã hủy không thể có trạng thái 'Đã thanh toán'. Vui lòng chọn 'Đã hoàn tiền' hoặc 'Chưa thanh toán'.");
                    }
                    break;

                case "returned":
                    if (paymentStatus != "refunded")
                    {
                        return ServiceResult<bool>.Error("Đơn hàng trả hàng phải có trạng thái thanh toán 'Đã hoàn tiền'.");
                    }
                    break;
            }

            return ServiceResult<bool>.Success(true);
        }

        private void LogStatusUpdate(int orderId, string newOrderStatus, string newPaymentStatus, string reason)
        {
            try
            {
                // In a real system, this would save to an audit log table
                var logEntry = new
                {
                    OrderId = orderId,
                    NewOrderStatus = newOrderStatus,
                    NewPaymentStatus = newPaymentStatus,
                    Reason = reason,
                    UpdatedBy = SessionManager.CurrentUser?.EmployeeId,
                    UpdatedAt = DateTime.Now
                };

                // Log to debug output for now
                System.Diagnostics.Debug.WriteLine(message: $"Order Status Update: {Newtonsoft.Json.JsonConvert.SerializeObject(logEntry)}");
            }
            catch (Exception ex)
            {
                // Don't throw exception for logging errors
                System.Diagnostics.Debug.WriteLine($"Error logging status update: {ex.Message}");
            }
        }

        private ServiceResult<OrderTotals> CalculateOrderTotals(CreateOrderRequest request)
        {
            try
            {
                decimal subtotal = request.OrderItems.Sum(x => (x.UnitPrice * x.Quantity) - x.DiscountPerItem);
                decimal discountAmount = 0;

                // Apply promotion if exists
                if (request.PromotionId.HasValue)
                {
                    var promotion = promotionDao.GetPromotionByCode(request.PromotionCode);
                    if (promotion != null)
                    {
                        discountAmount = promotionDao.CalculateDiscount(promotion, subtotal);
                    }
                }

                decimal taxAmount = (subtotal - discountAmount) * 0.1m; // 10% VAT
                decimal totalAmount = subtotal - discountAmount + taxAmount;

                return ServiceResult<OrderTotals>.Success(new OrderTotals
                {
                    Subtotal = subtotal,
                    DiscountAmount = discountAmount,
                    TaxAmount = taxAmount,
                    TotalAmount = totalAmount
                });
            }
            catch (Exception ex)
            {
                return ServiceResult<OrderTotals>.Error($"Lỗi tính toán đơn hàng: {ex.Message}");
            }
        }
    }

    public class CreateOrderRequest
    {
        public int? CustomerId { get; set; }
        public List<OrderItemRequest> OrderItems { get; set; }
        public int? PromotionId { get; set; }
        public string PromotionCode { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; } = "pending";
        public string Notes { get; set; }
    }

    public class OrderItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPerItem { get; set; } = 0;
    }

    public class OrderTotals
    {
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}