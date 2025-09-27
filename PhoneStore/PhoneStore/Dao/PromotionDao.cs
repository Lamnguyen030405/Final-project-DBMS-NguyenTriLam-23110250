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
            string query = "SELECT * FROM v_ActivePromotions ORDER BY created_at DESC";

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
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@code", promotionCode)
            };

            var dataTable = ExecuteQuery("sp_GetPromotionByCode", parameters, isStoredProcedure: true);

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
            try
            {
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

                ExecuteNonQuery("sp_InsertPromotion", parameters, isStoredProcedure: true);

                // Nếu không có exception → thành công
                return true;
            }
            catch
            {
                return false;
            }
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

        public List<Promotion> GetAllPromotions()
        {
            var dataTable = ExecuteQuery("sp_GetAllPromotions", null, isStoredProcedure: true);
            var promotions = new List<Promotion>();

            foreach (DataRow row in dataTable.Rows)
            {
                promotions.Add(MapRowToPromotion(row));
            }

            return promotions;
        }


        public bool UpdatePromotionStatus(int promotionId, string status)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
            new SqlParameter("@status", status),
            new SqlParameter("@promotionId", promotionId)
                };

                ExecuteNonQuery("sp_UpdatePromotionStatus", parameters, isStoredProcedure: true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePromotion(int promotionId)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
            new SqlParameter("@promotionId", promotionId)
                };

                ExecuteNonQuery("sp_DeletePromotion", parameters, isStoredProcedure: true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePromotion(Promotion promotion)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
            new SqlParameter("@promotionId", promotion.PromotionId),
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

                ExecuteNonQuery("sp_UpdatePromotion", parameters, isStoredProcedure: true);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public Promotion GetPromotionById(int promotionId)
        {
            string query = @"
        SELECT *
        FROM promotions
        WHERE promotion_id = @promotionId";

            var parameters = new SqlParameter[]
            {
        new SqlParameter("@promotionId", promotionId)
            };

            var dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return MapRowToPromotion(dataTable.Rows[0]);
            }

            return null;
        }
    }
}
