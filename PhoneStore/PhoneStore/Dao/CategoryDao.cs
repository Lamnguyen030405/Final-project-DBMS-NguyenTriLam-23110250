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
    public class CategoryDao : BaseDao
    {
        public List<Category> GetAllCategories()
        {
            string query = @"
                SELECT c.*, COUNT(p.product_id) as product_count
                FROM categories c
                LEFT JOIN products p ON c.category_id = p.category_id AND p.status = 'active'
                WHERE c.status = 'active'
                GROUP BY c.category_id, c.category_name, c.description, c.status
                ORDER BY c.category_name";

            var dataTable = ExecuteQuery(query);
            var categories = new List<Category>();

            foreach (DataRow row in dataTable.Rows)
            {
                categories.Add(MapRowToCategory(row));
            }

            return categories;
        }

        public bool InsertCategory(Category category)
        {
            string query = @"
                INSERT INTO categories (category_name, description, status)
                VALUES (@name, @description, @status)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@name", category.CategoryName),
                new SqlParameter("@description", category.Description ?? ""),
                new SqlParameter("@status", category.Status ?? "active")
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        private Category MapRowToCategory(DataRow row)
        {
            return new Category
            {
                CategoryId = Convert.ToInt32(row["category_id"]),
                CategoryName = row["category_name"].ToString(),
                Description = row["description"].ToString(),
                Status = row["status"].ToString()
            };
        }
    }
}
