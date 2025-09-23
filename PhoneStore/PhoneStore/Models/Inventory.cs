using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Models/InventoryModel.cs
namespace PhoneStore.Models
{
    public class Inventory
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public int QuantityOnHand { get; set; }
        public int QuantityReserved { get; set; }
        public int MinStockLevel { get; set; }
        public int MaxStockLevel { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsLowStock => QuantityOnHand <= MinStockLevel;
    }
}
