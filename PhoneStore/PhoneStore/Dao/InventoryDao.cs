using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Models;

namespace PhoneStore.Dao
{
    public class InventoryDao : BaseDao
    {
        public List<Inventory> GetAllInventory()
        {
            string query = @"
                SELECT p.product_id, p.product_name, p.product_code, p.selling_price,
                       b.brand_name, c.category_name,
                       COALESCE(i.quantity_on_hand, 0) as quantity_on_hand,
                       COALESCE(i.quantity_reserved, 0) as quantity_reserved,
                       COALESCE(i.min_stock_level, 0) as min_stock_level,
                       COALESCE(i.max_stock_level, 0) as max_stock_level,
                       COALESCE(i.last_updated, p.created_at) as last_updated
                FROM products p
                LEFT JOIN inventory i ON p.product_id = i.product_id
                LEFT JOIN brands b ON p.brand_id = b.brand_id
                LEFT JOIN categories c ON p.category_id = c.category_id
                WHERE p.status = 'active'
                ORDER BY p.product_name";

            var dataTable = ExecuteQuery(query);
            var inventory = new List<Inventory>();

            foreach (DataRow row in dataTable.Rows)
            {
                inventory.Add(MapRowToInventory(row));
            }

            return inventory;
        }

        public List<Inventory> GetLowStockItems()
        {
            string query = @"
                SELECT p.product_id, p.product_name, p.product_code, p.selling_price,
                       b.brand_name, c.category_name,
                       COALESCE(i.quantity_on_hand, 0) as quantity_on_hand,
                       COALESCE(i.quantity_reserved, 0) as quantity_reserved,
                       COALESCE(i.min_stock_level, 0) as min_stock_level,
                       COALESCE(i.max_stock_level, 0) as max_stock_level,
                       COALESCE(i.last_updated, p.created_at) as last_updated
                FROM products p
                LEFT JOIN inventory i ON p.product_id = i.product_id
                LEFT JOIN brands b ON p.brand_id = b.brand_id
                LEFT JOIN categories c ON p.category_id = c.category_id
                WHERE p.status = 'active' 
                AND COALESCE(i.quantity_on_hand, 0) <= COALESCE(i.min_stock_level, 0)
                ORDER BY (COALESCE(i.min_stock_level, 0) - COALESCE(i.quantity_on_hand, 0)) DESC";

            var dataTable = ExecuteQuery(query);
            var inventory = new List<Inventory>();

            foreach (DataRow row in dataTable.Rows)
            {
                inventory.Add(MapRowToInventory(row));
            }

            return inventory;
        }

        public bool UpdateStock(int productId, int newQuantity, int minLevel = 0, int maxLevel = 0)
        {
            string query = @"
                MERGE inventory AS target
                USING (SELECT @productId as product_id) AS source
                ON target.product_id = source.product_id
                WHEN MATCHED THEN
                    UPDATE SET quantity_on_hand = @quantity, 
                              min_stock_level = @minLevel,
                              max_stock_level = @maxLevel,
                              last_updated = GETDATE()
                WHEN NOT MATCHED THEN
                    INSERT (product_id, quantity_on_hand, min_stock_level, max_stock_level, last_updated)
                    VALUES (@productId, @quantity, @minLevel, @maxLevel, GETDATE());";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@productId", productId),
                new SqlParameter("@quantity", newQuantity),
                new SqlParameter("@minLevel", minLevel),
                new SqlParameter("@maxLevel", maxLevel)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public int GetProductStock(int productId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@productId", productId)
            };

            var result = ExecuteScalar("sp_GetProductStock", parameters, isStoredProcedure: true);
            return result != null ? Convert.ToInt32(result) : 0;
        }


        private Inventory MapRowToInventory(DataRow row)
        {
            return new Inventory
            {
                ProductId = Convert.ToInt32(row["product_id"]),
                ProductName = row["product_name"].ToString(),
                ProductCode = row["product_code"].ToString(),
                BrandName = row["brand_name"].ToString(),
                CategoryName = row["category_name"].ToString(),
                QuantityOnHand = Convert.ToInt32(row["quantity_on_hand"]),
                QuantityReserved = Convert.ToInt32(row["quantity_reserved"]),
                MinStockLevel = Convert.ToInt32(row["min_stock_level"]),
                MaxStockLevel = Convert.ToInt32(row["max_stock_level"]),
                SellingPrice = row["selling_price"] == DBNull.Value ? 0 : Convert.ToDecimal(row["selling_price"]),
                LastUpdated = Convert.ToDateTime(row["last_updated"])
            };
        }
    }
}
