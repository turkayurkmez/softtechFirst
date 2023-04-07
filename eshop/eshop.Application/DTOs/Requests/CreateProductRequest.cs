using System.ComponentModel.DataAnnotations;

namespace eshop.Application.DTOs.Requests
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "Ürün adını belirtmeyi unuttunuz!")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Stocks { get; set; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
    }
}
