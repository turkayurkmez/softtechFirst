using eshop.Entities;

namespace eshop.Application.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>()
            {
                new(){ Id=1, Name="Klavye", Price=2000, Description="Ergonomik bluetooth klavye", Stocks=100, ImageUrl="https://cdn.dsmcdn.com/ty740/product/media/images/20230220/15/285115501/31980046/1/1_org.jpg", CategoryId=1},
                new(){ Id=2, Name="Mouse", Price=500, Description="Ergonomik bluetooth mouse", Stocks=100, ImageUrl="https://cdn.dsmcdn.com/ty740/product/media/images/20230220/15/285115501/31980046/1/1_org.jpg", CategoryId=1},
                new(){ Id=3, Name="Kulaklık", Price=1000, Description="Ergonomik bluetooth kulaklık", Stocks=100, ImageUrl = "https://cdn.dsmcdn.com/ty740/product/media/images/20230220/15/285115501/31980046/1/1_org.jpg", CategoryId = 2},

            };
        }

        public Product GetProduct(int productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        public Task<Product> GetProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProducts()
        {
            return _products;
        }

        public Task<IList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProductsByCategory(int value)
        {
            return _products.Where(pr => pr.CategoryId == value).ToList();
        }

        public Task<IList<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
