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
    public class BrandDao : BaseDao
    {
        public List<Brand> GetAllBrands()
        {
            string query = @"
                SELECT b.*, COUNT(p.product_id) as product_count
                FROM brands b
                LEFT JOIN products p ON b.brand_id = p.brand_id AND p.status = 'active'
                WHERE b.status = 'active'
                GROUP BY b.brand_id, b.brand_name, b.country_origin, b.description, b.status
                ORDER BY b.brand_name";

            var dataTable = ExecuteQuery(query);
            var brands = new List<Brand>();

            foreach (DataRow row in dataTable.Rows)
            {
                brands.Add(MapRowToBrand(row));
            }

            return brands;
        }

        public bool InsertBrand(Brand brand)
        {
            string query = @"
                INSERT INTO brands (brand_name, country_origin, description, status)
                VALUES (@name, @country, @description, @status)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@name", brand.BrandName),
                new SqlParameter("@country", brand.CountryOrigin ?? ""),
                new SqlParameter("@description", brand.Description ?? ""),
                new SqlParameter("@status", brand.Status ?? "active")
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        private Brand MapRowToBrand(DataRow row)
        {
            return new Brand
            {
                BrandId = Convert.ToInt32(row["brand_id"]),
                BrandName = row["brand_name"].ToString(),
                CountryOrigin = row["country_origin"].ToString(),
                Description = row["description"].ToString(),
                Status = row["status"].ToString()
            };
        }
    }
}
