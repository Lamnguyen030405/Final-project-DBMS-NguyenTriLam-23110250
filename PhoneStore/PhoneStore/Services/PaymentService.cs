using PhoneStore.Dao;
using PhoneStore.Models;
using PhoneStore.Services;
using PhoneStore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class PaymentService
    {
        private PaymentDao paymentDao;
        private OrderDao orderDao;

        public PaymentService()
        {
            paymentDao = new PaymentDao();
            orderDao = new OrderDao();
        }

        public ServiceResult<List<Payment>> GetPaymentsByOrderId(int orderId)
        {
            try
            {
                var payments = paymentDao.GetPaymentsByOrderId(orderId);
                return ServiceResult<List<Payment>>.Success(payments);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Payment>>.Error($"Lỗi lấy danh sách thanh toán: {ex.Message}");
            }
        }

        public ServiceResult<PaymentSummary> GetPaymentSummary(int orderId)
        {
            try
            {
                var summary = paymentDao.GetPaymentSummaryByOrderId(orderId);
                if (summary == null)
                {
                    return ServiceResult<PaymentSummary>.Error("Không tìm thấy thông tin đơn hàng.");
                }

                return ServiceResult<PaymentSummary>.Success(summary);
            }
            catch (Exception ex)
            {
                return ServiceResult<PaymentSummary>.Error($"Lỗi lấy tóm tắt thanh toán: {ex.Message}");
            }
        }

        public ServiceResult<int> ProcessPayment(PaymentRequest request)
        {
            try
            {
                // Validation
                var validationResult = ValidatePaymentRequest(request);
                if (!validationResult.IsSuccess)
                {
                    return ServiceResult<int>.Error(validationResult.Message);
                }

                // Check order exists and can accept payment
                var order = orderDao.GetOrderById(request.OrderId);
                if (order == null)
                {
                    return ServiceResult<int>.Error("Không tìm thấy đơn hàng.");
                }

                if (order.OrderStatus == "cancelled")
                {
                    return ServiceResult<int>.Error("Không thể thanh toán cho đơn hàng đã hủy.");
                }

                // Check payment amount
                var summaryResult = GetPaymentSummary(request.OrderId);
                if (!summaryResult.IsSuccess)
                {
                    return ServiceResult<int>.Error(summaryResult.Message);
                }

                var summary = summaryResult.Data;
                if (request.Amount > summary.RemainingAmount)
                {
                    return ServiceResult<int>.Error($"Số tiền thanh toán vượt quá số tiền còn lại ({ValidationHelper.FormatCurrency(summary.RemainingAmount)}).");
                }

                // Create payment
                var payment = new Payment
                {
                    OrderId = request.OrderId,
                    PaymentDate = DateTime.Now,
                    PaymentMethod = request.PaymentMethod,
                    Amount = request.Amount,
                    ReferenceNumber = request.ReferenceNumber,
                    Status = "successful", // In real system, this might be "pending" initially
                    Notes = request.Notes
                };

                var paymentId = paymentDao.InsertPayment(payment);

                if (paymentId > 0)
                {
                    return ServiceResult<int>.Success(paymentId, "Thanh toán thành công!");
                }
                else
                {
                    return ServiceResult<int>.Error("Không thể xử lý thanh toán. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<int>.Error($"Lỗi xử lý thanh toán: {ex.Message}");
            }
        }

        public ServiceResult<bool> UpdatePayment(Payment payment)
        {
            try
            {
                if (payment.Amount <= 0)
                {
                    return ServiceResult<bool>.Error("Số tiền thanh toán phải lớn hơn 0.");
                }

                var result = paymentDao.UpdatePayment(payment);

                if (result)
                {
                    return ServiceResult<bool>.Success(true, "Cập nhật thanh toán thành công!");
                }
                else
                {
                    return ServiceResult<bool>.Error("Không thể cập nhật thanh toán.");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Error($"Lỗi cập nhật thanh toán: {ex.Message}");
            }
        }

        public ServiceResult<bool> CancelPayment(int paymentId, string reason)
        {
            try
            {
                var payment = paymentDao.GetPaymentById(paymentId);
                if (payment == null)
                {
                    return ServiceResult<bool>.Error("Không tìm thấy thông tin thanh toán.");
                }

                if (payment.Status == "failed")
                {
                    return ServiceResult<bool>.Error("Thanh toán đã bị hủy trước đó.");
                }

                // Update payment status to failed
                payment.Status = "failed";
                payment.Notes = (payment.Notes ?? "") + $" [Hủy: {reason}]";

                var result = paymentDao.UpdatePayment(payment);

                if (result)
                {
                    return ServiceResult<bool>.Success(true, "Hủy thanh toán thành công!");
                }
                else
                {
                    return ServiceResult<bool>.Error("Không thể hủy thanh toán.");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Error($"Lỗi hủy thanh toán: {ex.Message}");
            }
        }

        public ServiceResult<List<Payment>> GetPaymentsByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (fromDate > toDate)
                {
                    return ServiceResult<List<Payment>>.Error("Ngày bắt đầu không thể lớn hơn ngày kết thúc.");
                }

                var payments = paymentDao.GetPaymentsByDateRange(fromDate, toDate);
                return ServiceResult<List<Payment>>.Success(payments);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Payment>>.Error($"Lỗi lấy danh sách thanh toán: {ex.Message}");
            }
        }

        public ServiceResult<Dictionary<string, decimal>> GetPaymentSummaryByMethod(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var methods = new[] { "cash", "card", "transfer", "installment" };
                var summary = new Dictionary<string, decimal>();

                foreach (var method in methods)
                {
                    var total = paymentDao.GetTotalPaymentsByMethod(method, fromDate, toDate);
                    summary[method] = total;
                }

                return ServiceResult<Dictionary<string, decimal>>.Success(summary);
            }
            catch (Exception ex)
            {
                return ServiceResult<Dictionary<string, decimal>>.Error($"Lỗi tạo tóm tắt thanh toán: {ex.Message}");
            }
        }

        public ServiceResult<string> GenerateReferenceNumber(string paymentMethod)
        {
            try
            {
                var prefix = paymentMethod.ToUpper().Substring(0, Math.Min(3, paymentMethod.Length));
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var random = new Random().Next(100, 999);

                var referenceNumber = $"{prefix}{timestamp}{random}";

                return ServiceResult<string>.Success(referenceNumber);
            }
            catch (Exception ex)
            {
                return ServiceResult<string>.Error($"Lỗi tạo mã tham chiếu: {ex.Message}");
            }
        }

        private ServiceResult<bool> ValidatePaymentRequest(PaymentRequest request)
        {
            if (request.OrderId <= 0)
            {
                return ServiceResult<bool>.Error("Mã đơn hàng không hợp lệ.");
            }

            if (request.Amount <= 0)
            {
                return ServiceResult<bool>.Error("Số tiền thanh toán phải lớn hơn 0.");
            }

            var validMethods = new[] { "cash", "card", "transfer", "installment" };
            if (!validMethods.Contains(request.PaymentMethod))
            {
                return ServiceResult<bool>.Error("Phương thức thanh toán không hợp lệ.");
            }

            if (request.PaymentMethod != "cash" && string.IsNullOrWhiteSpace(request.ReferenceNumber))
            {
                return ServiceResult<bool>.Error("Vui lòng nhập mã tham chiếu cho phương thức thanh toán này.");
            }

            return ServiceResult<bool>.Success(true);
        }
    }
}
