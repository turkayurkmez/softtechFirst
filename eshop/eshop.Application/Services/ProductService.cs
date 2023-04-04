using eshop.Entities;

namespace eshop.Application.Services
{
    public class ProductService : IProductService
    {

        public IList<Product> GetProducts()
        {
            return new List<Product>()
            {
                new(){ Id=1, Name="Klavye", Price=2000, Description="Ergonomik bluetooth klavye", Stocks=100, ImageUrl="https://cdn.dsmcdn.com/ty740/product/media/images/20230220/15/285115501/31980046/1/1_org.jpg"},
                new(){ Id=2, Name="Mouse", Price=500, Description="Ergonomik bluetooth mouse", Stocks=100, ImageUrl="https://cdn.dsmcdn.com/ty740/product/media/images/20230220/15/285115501/31980046/1/1_org.jpg"},
                new(){ Id=3, Name="Kulaklık", Price=1000, Description="Ergonomik bluetooth kulaklık", Stocks=100, ImageUrl = "https://cdn.dsmcdn.com/ty740/product/media/images/20230220/15/285115501/31980046/1/1_org.jpg"},

            };
        }

        public Task<IList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
