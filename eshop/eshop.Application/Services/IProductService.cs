using eshop.Application.DTOs.Requests;
using eshop.Application.DTOs.Responses;
using eshop.Entities;

namespace eshop.Application.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        Task<IList<Product>> GetProductsAsync();
        Task<IList<ProductListDisplayResponse>> GetProductsForDisplayAsync();

        IList<Product> GetProductsByCategory(int value);
        Task<IList<Product>> GetProductsByCategoryAsync(int categoryId);

        Product GetProduct(int productId);
        Task<Product> GetProductAsync(int productId);
        void CreateProduct(Product product);
        Task CreateProductAsync(Product product);

        /// <summary>
        /// Bu overload, direkt DTO ile çalışır
        /// </summary>
        /// <param name="createProductRequest">Bir ürün ekleme ihtiyacı için gereken tüm ürün özellikleri...</param>
        /// <returns></returns>
        Task<int> CreateProductAsync(CreateProductRequest createProductRequest);

        void Update(Product product);
        Task UpdateAsync(Product product);

        Task<int> UpdateAsync(UpdateProductRequest updateProductRequest);
        void DeleteProduct(int productId);
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<bool> IsProductExistsAsync(int id);
    }
}
