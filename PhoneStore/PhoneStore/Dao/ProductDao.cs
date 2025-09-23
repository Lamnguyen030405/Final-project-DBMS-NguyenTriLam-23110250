using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Dao
{
    public class ProductDao : BaseDao
    {
        public List<Product> GetAllProducts()
        {
            const string query = "SELECT * FROM v_AllActiveProducts";

            var dataTable = ExecuteQuery(query);
            var products = new List<Product>();

            foreach (DataRow row in dataTable.Rows)
            {
                products.Add(MapRowToProduct(row));
            }

            return products;
        }

        public Product GetProductById(int productId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@productId", productId)
            };

            var dataTable = ExecuteQuery("sp_GetProductById", parameters, isStoredProcedure: true);

            if (dataTable.Rows.Count > 0)
            {
                return MapRowToProduct(dataTable.Rows[0]);
            }

            return null;
        }

        public bool InsertProduct(Product product)
        {
            string query = @"
                INSERT INTO products (product_code, product_name, category_id, brand_id, 
                                    supplier_id, description, cost_price, selling_price, 
                                    warranty_period, image_url, status)
                VALUES (@code, @name, @categoryId, @brandId, @supplierId, @description, 
                        @costPrice, @sellingPrice, @warranty, @imageUrl, @status)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@code", product.ProductCode),
                new SqlParameter("@name", product.ProductName),
                new SqlParameter("@categoryId", (object)product.CategoryId ?? DBNull.Value),
                new SqlParameter("@brandId", (object)product.BrandId ?? DBNull.Value),
                new SqlParameter("@supplierId", (object)product.SupplierId ?? DBNull.Value),
                new SqlParameter("@description", product.Description ?? ""),
                new SqlParameter("@costPrice", (object)product.CostPrice ?? DBNull.Value),
                new SqlParameter("@sellingPrice", (object)product.SellingPrice ?? DBNull.Value),
                new SqlParameter("@warranty", (object)product.WarrantyPeriod ?? DBNull.Value),
                new SqlParameter("@imageUrl", product.ImageUrl ?? ""),
                new SqlParameter("@status", product.Status ?? "active")
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateProduct(Product product)
        {
            string query = @"
                UPDATE products 
                SET product_name = @name, category_id = @categoryId, brand_id = @brandId,
                    supplier_id = @supplierId, description = @description, 
                    cost_price = @costPrice, selling_price = @sellingPrice,
                    warranty_period = @warranty, image_url = @imageUrl, status = @status
                WHERE product_id = @productId";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@name", product.ProductName),
                new SqlParameter("@categoryId", (object)product.CategoryId ?? DBNull.Value),
                new SqlParameter("@brandId", (object)product.BrandId ?? DBNull.Value),
                new SqlParameter("@supplierId", (object)product.SupplierId ?? DBNull.Value),
                new SqlParameter("@description", product.Description ?? ""),
                new SqlParameter("@costPrice", (object)product.CostPrice ?? DBNull.Value),
                new SqlParameter("@sellingPrice", (object)product.SellingPrice ?? DBNull.Value),
                new SqlParameter("@warranty", (object)product.WarrantyPeriod ?? DBNull.Value),
                new SqlParameter("@imageUrl", product.ImageUrl ?? ""),
                new SqlParameter("@status", product.Status ?? "active"),
                new SqlParameter("@productId", product.ProductId)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        private Product MapRowToProduct(DataRow row)
        {
            return new Product
            {
                ProductId = Convert.ToInt32(row["product_id"]),
                ProductCode = row["product_code"].ToString(),
                ProductName = row["product_name"].ToString(),
                CategoryId = (int)(row["category_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["category_id"])),
                BrandId = (int)(row["brand_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["brand_id"])),
                SupplierId = (int)(row["supplier_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["supplier_id"])),
                Description = row["description"].ToString(),
                CostPrice = (decimal)(row["cost_price"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["cost_price"])),
                SellingPrice = (decimal)(row["selling_price"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["selling_price"])),
                WarrantyPeriod = (int)(row["warranty_period"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["warranty_period"])),
                ImageUrl = row["image_url"].ToString(),
                Status = row["status"].ToString(),
                CategoryName = row["category_name"].ToString(),
                BrandName = row["brand_name"].ToString(),
                QuantityOnHand = Convert.ToInt32(row["quantity_on_hand"]),
                CreatedAt = Convert.ToDateTime(row["created_at"])
            };
        }
       
        public List<Product> SearchProducts(string keyword, int? categoryId = null, int? brandId = null)
        {
            string query = @"
        SELECT p.*, c.category_name, b.brand_name, 
               COALESCE(i.quantity_on_hand, 0) as quantity_on_hand
        FROM products p
        LEFT JOIN categories c ON p.category_id = c.category_id
        LEFT JOIN brands b ON p.brand_id = b.brand_id
        LEFT JOIN inventory i ON p.product_id = i.product_id
        WHERE p.status = 'active'
        AND (@keyword IS NULL OR p.product_name LIKE '%' + @keyword + '%' 
             OR p.product_code LIKE '%' + @keyword + '%')
        AND (@categoryId IS NULL OR p.category_id = @categoryId)
        AND (@brandId IS NULL OR p.brand_id = @brandId)
        ORDER BY p.product_name";

            var parameters = new SqlParameter[]
            {
        new SqlParameter("@keyword", (object)keyword ?? DBNull.Value),
        new SqlParameter("@categoryId", (object)categoryId ?? DBNull.Value),
        new SqlParameter("@brandId", (object)brandId ?? DBNull.Value)
            };

            var dataTable = ExecuteQuery(query, parameters);
            var products = new List<Product>();

            foreach (DataRow row in dataTable.Rows)
            {
                products.Add(MapRowToProduct(row));
            }

            return products;
        }

        public string GenerateProductCode(int categoryId)
        {
            string query = @"
        SELECT c.category_name 
        FROM categories c 
        WHERE c.category_id = @categoryId";

            var parameters = new SqlParameter[]
            {
        new SqlParameter("@categoryId", categoryId)
            };

            var categoryResult = ExecuteQuery(query, parameters);

            if (categoryResult.Rows.Count == 0)
                return "PRD001";

            string categoryName = categoryResult.Rows[0]["category_name"].ToString();
            string prefix = categoryName.Length >= 3 ? categoryName.Substring(0, 3).ToUpper() : "PRD";

            string countQuery = @"
        SELECT 'P' + RIGHT('000' + CAST(COALESCE(MAX(CAST(RIGHT(product_code, 3) AS INT)), 0) + 1 AS NVARCHAR(3)), 3)
        FROM products 
        WHERE product_code LIKE @prefix + '%'";

            var countParams = new SqlParameter[]
            {
        new SqlParameter("@prefix", prefix)
            };

            var result = ExecuteScalar(countQuery, countParams);
            return $"{prefix}{result?.ToString() ?? "001"}";
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            string query = @"
        SELECT p.*, c.category_name, b.brand_name, 
               COALESCE(i.quantity_on_hand, 0) as quantity_on_hand
        FROM products p
        LEFT JOIN categories c ON p.category_id = c.category_id
        LEFT JOIN brands b ON p.brand_id = b.brand_id
        LEFT JOIN inventory i ON p.product_id = i.product_id
        WHERE p.category_id = @categoryId AND p.status = 'active'
        ORDER BY p.product_name";

            var parameters = new SqlParameter[]
            {
        new SqlParameter("@categoryId", categoryId)
            };

            var dataTable = ExecuteQuery(query, parameters);
            var products = new List<Product>();

            foreach (DataRow row in dataTable.Rows)
            {
                products.Add(MapRowToProduct(row));
            }

            return products;
        }
    }
}
