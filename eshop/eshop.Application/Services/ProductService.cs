using eshop.Entities;
using eshop.Infrastucture.Repositories;

namespace eshop.Application.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }



        public void CreateProduct(Product product)
        {
            productRepository.Add(product);
        }

        public Product GetProduct(int productId)
        {
            return productRepository.GetItemById(productId);
        }

        public Task<Product> GetProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProducts()
        {
            return productRepository.GetAllItems(); ;
        }

        public Task<IList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProductsByCategory(int value)
        {
            return productRepository.GetProductsByCategoryId(value);
        }

        public Task<IList<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
        }
    }
}
