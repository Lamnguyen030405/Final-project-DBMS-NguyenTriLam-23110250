using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Models/Product.cs
namespace PhoneStoreManagement.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int BrandId { get; set; }
        public int SupplierId { get; set; }
        public string Description { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int WarrantyPeriod { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; internal set; }

        // Navigation properties
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
