using eshop.Application.Services;
using eshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index(int? categoryId = null)
        {
            //Bu controller, ürün verisiyle çalışmak zorunda.
            //Ürün verisi olmadan bu controller olmaz.
            //Ürün verisini sağlayan nesne, controller nesnesinin bağımlılığıdır.

            // InsideProductService productService = new InsideProductService();
            var products = categoryId.HasValue ? productService.GetProductsByCategory(categoryId.Value) :
                                                 productService.GetProducts();

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}