using eshop.Entities;

namespace eshop.Application.Services
{
    public interface IProductService
    {
        public IList<Product> GetProducts();
        public Task<IList<Product>> GetProductsAsync();
    }
}
