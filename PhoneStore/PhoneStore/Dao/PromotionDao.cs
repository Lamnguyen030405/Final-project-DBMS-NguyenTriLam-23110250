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
    public class PromotionDao : BaseDao
    {
        public List<Promotion> GetActivePromotions()
        {
            string query = @"
                SELECT *
                FROM promotions
                WHERE status = 'active'
                AND CAST(GETDATE() AS DATE) BETWEEN start_date AND end_date
                AND (usage_limit IS NULL OR used_count < usage_limit)
                ORDER BY created_at DESC";

            var dataTable = ExecuteQuery(query);
            var promotions = new List<Promotion>();

            foreach (DataRow row in dataTable.Rows)
            {
                promotions.Add(MapRowToPromotion(row));
            }

            return promotions;
        }

        public Promotion GetPromotionByCode(string promotionCode)
        {
            string query = @"
                SELECT *
                FROM promotions
                WHERE promotion_code = @code
                AND status = 'active'
                AND CAST(GETDATE() AS DATE) BETWEEN start_date AND end_date
                AND (usage_limit IS NULL OR used_count < usage_limit)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@code", promotionCode)
            };

            var dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return MapRowToPromotion(dataTable.Rows[0]);
            }

            return null;
        }

        public decimal CalculateDiscount(Promotion promotion, decimal orderAmount)
        {
            if (promotion == null || orderAmount < promotion.MinOrderAmount)
                return 0;

            decimal discount = 0;

            if (promotion.DiscountType == "percentage")
            {
                discount = orderAmount * (promotion.DiscountValue / 100);
            }
            else if (promotion.DiscountType == "fixed_amount")
            {
                discount = promotion.DiscountValue;
            }

            // Apply maximum discount limit
            if (promotion.MaxDiscountAmount > 0 && discount > promotion.MaxDiscountAmount)
            {
                discount = promotion.MaxDiscountAmount;
            }

            return discount;
        }

        public bool InsertPromotion(Promotion promotion)
        {
            string query = @"
                INSERT INTO promotions (promotion_code, promotion_name, description, discount_type,
                                      discount_value, start_date, end_date, min_order_amount,
                                      max_discount_amount, usage_limit, status)
                VALUES (@code, @name, @description, @discountType, @discountValue,
                       @startDate, @endDate, @minOrderAmount, @maxDiscountAmount, @usageLimit, @status)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@code", promotion.PromotionCode),
                new SqlParameter("@name", promotion.PromotionName),
                new SqlParameter("@description", promotion.Description ?? ""),
                new SqlParameter("@discountType", promotion.DiscountType),
                new SqlParameter("@discountValue", promotion.DiscountValue),
                new SqlParameter("@startDate", promotion.StartDate.Date),
                new SqlParameter("@endDate", promotion.EndDate.Date),
                new SqlParameter("@minOrderAmount", promotion.MinOrderAmount),
                new SqlParameter("@maxDiscountAmount", promotion.MaxDiscountAmount),
                new SqlParameter("@usageLimit", promotion.UsageLimit > 0 ? (object)promotion.UsageLimit : DBNull.Value),
                new SqlParameter("@status", promotion.Status ?? "active")
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        private Promotion MapRowToPromotion(DataRow row)
        {
            return new Promotion
            {
                PromotionId = Convert.ToInt32(row["promotion_id"]),
                PromotionCode = row["promotion_code"].ToString(),
                PromotionName = row["promotion_name"].ToString(),
                Description = row["description"].ToString(),
                DiscountType = row["discount_type"].ToString(),
                DiscountValue = Convert.ToDecimal(row["discount_value"]),
                StartDate = Convert.ToDateTime(row["start_date"]),
                EndDate = Convert.ToDateTime(row["end_date"]),
                MinOrderAmount = row["min_order_amount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["min_order_amount"]),
                MaxDiscountAmount = row["max_discount_amount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["max_discount_amount"]),
                UsageLimit = row["usage_limit"] == DBNull.Value ? 0 : Convert.ToInt32(row["usage_limit"]),
                UsedCount = Convert.ToInt32(row["used_count"]),
                Status = row["status"].ToString(),
                CreatedAt = Convert.ToDateTime(row["created_at"])
            };
        }
    }
}
