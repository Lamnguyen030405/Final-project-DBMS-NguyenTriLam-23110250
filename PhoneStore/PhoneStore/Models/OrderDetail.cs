using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Models/OrderDetail.cs
namespace PhoneStoreManagement.Models
{
    public class OrderDetail
    {
        public int DetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPerItem { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation properties
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public DateTime? WarrantyStartDate { get; internal set; }
        public DateTime? WarrantyEndDate { get; internal set; }
    }
}
