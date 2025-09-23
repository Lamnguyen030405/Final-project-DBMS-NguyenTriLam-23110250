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
    public class InventoryService
    {
        private InventoryDao inventoryDao;

        public InventoryService()
        {
            inventoryDao = new InventoryDao();
        }

        public ServiceResult<List<Inventory>> GetAllInventory()
        {
            try
            {
                var inventory = inventoryDao.GetAllInventory();
                return ServiceResult<List<Inventory>>.Success(inventory);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Inventory>>.Error($"Lỗi lấy danh sách tồn kho: {ex.Message}");
            }
        }

        public ServiceResult<List<Inventory>> GetLowStockItems()
        {
            try
            {
                var lowStockItems = inventoryDao.GetLowStockItems();
                return ServiceResult<List<Inventory>>.Success(lowStockItems);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Inventory>>.Error($"Lỗi lấy danh sách hàng sắp hết: {ex.Message}");
            }
        }

        public ServiceResult<bool> UpdateStock(int productId, int newQuantity, int minLevel = 0, int maxLevel = 0)
        {
            try
            {
                if (newQuantity < 0)
                {
                    return ServiceResult<bool>.Error("Số lượng tồn kho không thể âm.");
                }

                if (minLevel < 0 || maxLevel < 0)
                {
                    return ServiceResult<bool>.Error("Mức tồn kho không thể âm.");
                }

                if (maxLevel > 0 && minLevel > maxLevel)
                {
                    return ServiceResult<bool>.Error("Mức tồn kho tối thiểu không thể lớn hơn mức tối đa.");
                }

                var result = inventoryDao.UpdateStock(productId, newQuantity, minLevel, maxLevel);

                if (result)
                {
                    return ServiceResult<bool>.Success(true, "Cập nhật tồn kho thành công!");
                }
                else
                {
                    return ServiceResult<bool>.Error("Không thể cập nhật tồn kho.");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Error($"Lỗi cập nhật tồn kho: {ex.Message}");
            }
        }

        public ServiceResult<int> GetProductStock(int productId)
        {
            try
            {
                var stock = inventoryDao.GetProductStock(productId);
                return ServiceResult<int>.Success(stock);
            }
            catch (Exception ex)
            {
                return ServiceResult<int>.Error($"Lỗi lấy tồn kho: {ex.Message}");
            }
        }
    }
}
