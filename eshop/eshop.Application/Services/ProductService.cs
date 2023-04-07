using eshop.Application.DTOs.Requests;
using eshop.Application.DTOs.Responses;
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

        public async Task<int> CreateProductAsync(CreateProductRequest createProductRequest)
        {
            var product = new Product
            {
                CategoryId = createProductRequest.CategoryId,
                Name = createProductRequest.Name,
                Description = createProductRequest.Description,
                ImageUrl = createProductRequest.ImageUrl,
                Price = createProductRequest.Price,
                Stocks = createProductRequest.Stocks,
            };
            await productRepository.AddAsync(product);
            return product.Id;

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

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await productRepository.GetProductsByNameAsync(name);
        }

        public async Task<IList<ProductListDisplayResponse>> GetProductsForDisplayAsync()
        {
            var list = await productRepository.GetAllItemsAsync();
            var responses = list.Select(x => new ProductListDisplayResponse
            {
                CategoryId = x.CategoryId,
                CategoryName = x.Category?.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stocks = x.Stocks
            }).ToList();

            return responses;
        }

        public async Task<bool> IsProductExistsAsync(int id)
        {
            return await productRepository.IsItemExistsAsync(id);
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
        }

        public async Task UpdateAsync(Product product)
        {
            await productRepository.UpdateAsync(product);
        }

        public async Task<int> UpdateAsync(UpdateProductRequest updateProductRequest)
        {
            var product = new Product
            {
                CategoryId = updateProductRequest.CategoryId,
                Description = updateProductRequest.Description,
                ImageUrl = updateProductRequest.ImageUrl,
                Id = updateProductRequest.Id,
                Name = updateProductRequest.Name,
                Price = updateProductRequest.Price,
                Stocks = updateProductRequest.Stocks


            };

            await productRepository.UpdateAsync(product);
            return product.Id;
        }
    }
}
