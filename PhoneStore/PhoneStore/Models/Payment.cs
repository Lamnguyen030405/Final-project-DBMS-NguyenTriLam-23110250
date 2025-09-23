using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // cash, card, transfer, installment
        public decimal Amount { get; set; }
        public string ReferenceNumber { get; set; }
        public string Status { get; set; } // successful, failed, pending
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public string OrderCode { get; set; }
        public string CustomerName { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public string PaymentMethodText { get; set; }
        public string StatusText { get; set; }
    }

    public class PaymentSummary
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public decimal TotalOrderAmount { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string PaymentStatus { get; set; }
        public int PaymentCount { get; set; }
        public DateTime? LastPaymentDate { get; set; }
    }

    public class PaymentRequest
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; }
        public string Notes { get; set; }
    }
}
