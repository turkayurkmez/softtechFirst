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

        public async Task CreateProductAsync(Product product)
        {
            await productRepository.AddAsync(product);
        }

        public void DeleteProduct(int productId)
        {
            productRepository.Delete(productId);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await productRepository.DeleteAsync(productId);
        }

        public Product GetProduct(int productId)
        {
            return productRepository.GetItemById(productId);
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await productRepository.GetItemByIdAsync(productId);
        }

        public IList<Product> GetProducts()
        {
            return productRepository.GetAllItems(); ;
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            return await productRepository.GetAllItemsAsync();
        }

        public IList<Product> GetProductsByCategory(int value)
        {
            return productRepository.GetProductsByCategoryId(value);
        }

        public async Task<IList<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await productRepository.GetProductsByCategoryIdAsync(categoryId);
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
        }

        public async Task UpdateAsync(Product product)
        {
            await productRepository.UpdateAsync(product);
        }
    }
}
