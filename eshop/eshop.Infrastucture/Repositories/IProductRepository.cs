using eshop.Entities;

namespace eshop.Infrastucture.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IList<Product> GetProductsByCategoryId(int categoryId);
        Task<IList<Product>> GetProductsByCategoryIdAsync(int categoryId);
        IEnumerable<Product> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}
