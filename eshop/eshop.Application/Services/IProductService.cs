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
        void Update(Product product);
    }
}
