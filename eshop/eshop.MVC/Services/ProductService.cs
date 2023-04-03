namespace eshop.MVC.Services
{
    public class InsideProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set; }


    }
    public class InsideProductService
    {
        public List<InsideProduct> GetProducts()
        {
            return new()
            {
                new(){ Id=1, Name="Klavye", Price=2000, Description="Ergonomik bluetooth klavye", StockCount=100},
                new(){ Id=2, Name="Mouse", Price=500, Description="Ergonomik bluetooth mouse", StockCount=100},
                new(){ Id=3, Name="Kulaklık", Price=1000, Description="Ergonomik bluetooth kulaklık", StockCount=100},

            };
        }
    }
}
