using PhoneStore.Dao;
using PhoneStore.Models;
using PhoneStore.Utils;
using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class ProductService
    {
        private ProductDao productDao;
        private CategoryDao categoryDao;
        private BrandDao brandDao;
        private InventoryDao inventoryDao;

        public ProductService()
        {
            productDao = new ProductDao();
            categoryDao = new CategoryDao();
            brandDao = new BrandDao();
            inventoryDao = new InventoryDao();
        }

        public ServiceResult<List<Product>> GetAllProducts()
        {
            try
            {
                var products = productDao.GetAllProducts();
                return ServiceResult<List<Product>>.Success(products);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Product>>.Error($"Lỗi lấy danh sách sản phẩm: {ex.Message}");
            }
        }

        public ServiceResult<List<Product>> SearchProducts(string keyword, int? categoryId = null, int? brandId = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword) && !categoryId.HasValue && !brandId.HasValue)
                {
                    return GetAllProducts();
                }

                var products = productDao.SearchProducts(keyword, categoryId, brandId);
                return ServiceResult<List<Product>>.Success(products);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Product>>.Error($"Lỗi tìm kiếm sản phẩm: {ex.Message}");
            }
        }

        public ServiceResult<Product> GetProductById(int productId)
        {
            try
            {
                var product = productDao.GetProductById(productId);
                if (product == null)
                {
                    return ServiceResult<Product>.Error("Không tìm thấy sản phẩm.");
                }

                return ServiceResult<Product>.Success(product);
            }
            catch (Exception ex)
            {
                return ServiceResult<Product>.Error($"Lỗi lấy thông tin sản phẩm: {ex.Message}");
            }
        }

        public ServiceResult<bool> AddProduct(Product product)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(product.ProductName))
                {
                    return ServiceResult<bool>.Error("Tên sản phẩm không được để trống.");
                }

                if (product.SellingPrice <= 0)
                {
                    return ServiceResult<bool>.Error("Giá bán phải lớn hơn 0.");
                }

                if (product.CostPrice.HasValue && product.CostPrice >= product.SellingPrice)
                {
                    return ServiceResult<bool>.Error("Giá vốn phải nhỏ hơn giá bán.");
                }

                // Generate product code if not provided
                if (string.IsNullOrWhiteSpace(product.ProductCode))
                {
                    product.ProductCode = GenerateProductCode(product.CategoryId ?? 1);
                }

                var result = productDao.InsertProduct(product);

                if (result)
                {
                    return ServiceResult<bool>.Success(true, "Thêm sản phẩm thành công!");
                }
                else
                {
                    return ServiceResult<bool>.Error("Không thể thêm sản phẩm. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Error($"Lỗi thêm sản phẩm: {ex.Message}");
            }
        }

        public ServiceResult<bool> UpdateProduct(Product product)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(product.ProductName))
                {
                    return ServiceResult<bool>.Error("Tên sản phẩm không được để trống.");
                }

                if (product.SellingPrice <= 0)
                {
                    return ServiceResult<bool>.Error("Giá bán phải lớn hơn 0.");
                }

                var result = productDao.UpdateProduct(product);

                if (result)
                {
                    return ServiceResult<bool>.Success(true, "Cập nhật sản phẩm thành công!");
                }
                else
                {
                    return ServiceResult<bool>.Error("Không thể cập nhật sản phẩm. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Error($"Lỗi cập nhật sản phẩm: {ex.Message}");
            }
        }

        public ServiceResult<List<Category>> GetAllCategories()
        {
            try
            {
                var categories = categoryDao.GetAllCategories();
                return ServiceResult<List<Category>>.Success(categories);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Category>>.Error($"Lỗi lấy danh sách danh mục: {ex.Message}");
            }
        }

        public ServiceResult<List<Brand>> GetAllBrands()
        {
            try
            {
                var brands = brandDao.GetAllBrands();
                return ServiceResult<List<Brand>>.Success(brands);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Brand>>.Error($"Lỗi lấy danh sách thương hiệu: {ex.Message}");
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

        private string GenerateProductCode(int categoryId)
        {
            try
            {
                return productDao.GenerateProductCode(categoryId);
            }
            catch
            {
                return "PRD" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2);
            }
        }
    }
}
