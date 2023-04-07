using eshop.API.Filters;
using eshop.Application.DTOs.Requests;
using eshop.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetProductsForDisplayAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await productService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound(new { message = $"{id} id'li ürün yok!" });
            }
            return Ok(product);
        }
        [HttpGet("kategori/{id}")]
        public async Task<IActionResult> GetProductsByCategoryId(int id)
        {
            var products = await productService.GetProductsByCategoryAsync(id);
            return Ok(products);
        }
        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> SearchProductsByName(string name)
        {
            var products = await productService.GetProductsByName(name);
            return Ok(products);
        }
        [HttpPost]
        [RangeExc(Min = 1, Max = 10)]
        [Authorize]
        public async Task<IActionResult> CreateProduct(CreateProductRequest product)
        {
            if (product.Stocks > 10)
            {
                throw new ArgumentOutOfRangeException("Stock", product.Stocks, "too much!");
            }
            if (ModelState.IsValid)
            {
                var lastProductId = await productService.CreateProductAsync(product);
                return CreatedAtAction(nameof(GetProduct), new { id = lastProductId }, null);
            }

            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProduct(int id, UpdateProductRequest updateProductRequest)
        {
            //1. Koşula bak: bu id'li eleman  var mı?
            if (await productService.IsProductExistsAsync(id))
            {
                if (ModelState.IsValid)
                {
                    int lastProduct = await productService.UpdateAsync(updateProductRequest);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.IsProductExistsAsync(id))
            {
                await productService.DeleteProductAsync(id);
                return Ok();
            }
            return NotFound();
        }


    }
}
