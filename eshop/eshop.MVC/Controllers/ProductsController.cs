using eshop.Application.Services;
using eshop.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eshop.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }

        public IActionResult Create()
        {
            // var selectList = categoryService.GetCategories().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            ViewBag.Categories = getCategories();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.CreateProduct(product);
                return RedirectToAction(nameof(Index));

            }
            ViewBag.Categories = getCategories();
            return View();
        }


        public IActionResult Edit(int id)
        {
            var product = productService.GetProduct(id);
            if (product == null)
            {
                return NotFound(new { message = $"{id} id'li bir ürün yok!" });
            }

            ViewBag.Categories = getCategories();

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Update(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = getCategories();
            return View();
        }

        private IEnumerable<SelectListItem> getCategories()
        {
            var selectList = categoryService.GetCategories().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            return selectList;
        }

    }
}
