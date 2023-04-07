namespace eshop.Application.DTOs.Responses
{
    public class ProductListDisplayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Stocks { get; set; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
