using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Models/Order.cs
namespace PhoneStoreManagement.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int? PromotionId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
        public string Notes { get; set; }

        // Navigation properties
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public DateTime CreatedAt { get; internal set; }
    }
}
