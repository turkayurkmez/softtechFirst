using eshop.Entities;

namespace eshop.Application.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        Task<IList<Product>> GetProductsAsync();
        IList<Product> GetProductsByCategory(int value);
        Task<IList<Product>> GetProductsByCategoryAsync(int categoryId);

        Product GetProduct(int productId);
        Task<Product> GetProductAsync(int productId);
        void CreateProduct(Product product);
        Task CreateProductAsync(Product product);

        void Update(Product product);
        Task UpdateAsync(Product product);

        void DeleteProduct(int productId);
        Task DeleteProductAsync(int productId);
    }
}
