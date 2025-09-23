using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Models/Promotion.cs
namespace PhoneStore.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public string PromotionCode { get; set; }
        public string PromotionName { get; set; }
        public string Description { get; set; }
        public string DiscountType { get; set; } // percentage, fixed_amount
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MinOrderAmount { get; set; }
        public decimal MaxDiscountAmount { get; set; }
        public int UsageLimit { get; set; }
        public int UsedCount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive => Status == "active" && DateTime.Now.Date >= StartDate.Date && DateTime.Now.Date <= EndDate.Date;
    }
}
