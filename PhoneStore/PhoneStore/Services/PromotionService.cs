using PhoneStore.Dao;
using PhoneStore.Models;
using PhoneStore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class PromotionService
    {
        private PromotionDao promotionDao;

        public PromotionService()
        {
            promotionDao = new PromotionDao();
        }

        public ServiceResult<List<Promotion>> GetActivePromotions()
        {
            try
            {
                var promotions = promotionDao.GetActivePromotions();
                return ServiceResult<List<Promotion>>.Success(promotions);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Promotion>>.Error($"Lỗi lấy danh sách khuyến mãi: {ex.Message}");
            }
        }

        public ServiceResult<Promotion> GetPromotionByCode(string promotionCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(promotionCode))
                {
                    return ServiceResult<Promotion>.Error("Mã khuyến mãi không được để trống.");
                }

                var promotion = promotionDao.GetPromotionByCode(promotionCode.Trim());
                if (promotion == null)
                {
                    return ServiceResult<Promotion>.Error("Mã khuyến mãi không tồn tại hoặc đã hết hạn.");
                }

                return ServiceResult<Promotion>.Success(promotion);
            }
            catch (Exception ex)
            {
                return ServiceResult<Promotion>.Error($"Lỗi kiểm tra khuyến mãi: {ex.Message}");
            }
        }

        public ServiceResult<decimal> CalculateDiscount(string promotionCode, decimal orderAmount)
        {
            try
            {
                var promotionResult = GetPromotionByCode(promotionCode);
                if (!promotionResult.IsSuccess)
                {
                    return ServiceResult<decimal>.Error(promotionResult.Message);
                }

                var discount = promotionDao.CalculateDiscount(promotionResult.Data, orderAmount);
                return ServiceResult<decimal>.Success(discount);
            }
            catch (Exception ex)
            {
                return ServiceResult<decimal>.Error($"Lỗi tính toán giảm giá: {ex.Message}");
            }
        }
    }
}
