using eshop.Application.Services;
using eshop.MVC.ExtensionMerhods;
using eshop.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eshop.MVC.Controllers
{
    [Authorize]
    public class ProductCardController : Controller
    {


        private readonly IProductService productService;

        public ProductCardController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var collection = getCollectionFromSession();
            return View(collection);
        }

        public IActionResult AddProduct(int id)
        {

            // TODO 2: Sepete eklenen ürünü db'den çek ve sepet koleksiyonuna ekle, bu koleksiyonu da Session içerisinde sakla.
            var product = productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            ShoppingCardCollection cardCollection = getCollectionFromSession();
            ProductItem productItem = new ProductItem { Product = product, Quantity = 1 };
            cardCollection.AddProduct(productItem);
            saveCollectionToSession(cardCollection);

            return Json(new { message = $"{product.Name} ürünü, sepete eklendi" });
        }



        private ShoppingCardCollection getCollectionFromSession()
        {
            //var serializedString = HttpContext.Session.GetString("basket");
            //if (string.IsNullOrEmpty(serializedString))
            //{
            //    return new ShoppingCardCollection();
            //}
            //return JsonSerializer.Deserialize<ShoppingCardCollection>(serializedString);
            var result = HttpContext.Request.Cookies["SepetOlusturuldu"] == null ? "Yok" : HttpContext.Request.Cookies["SepetOlusturuldu"];
            return HttpContext.Session.GetJson<ShoppingCardCollection>("basket") ?? new ShoppingCardCollection();

        }
        private void saveCollectionToSession(ShoppingCardCollection cardCollection)
        {
            //var serialized = JsonSerializer.Serialize(cardCollection);
            //HttpContext.Session.SetString("basket", serialized);

            HttpContext.Session.SetJson("basket", cardCollection);
            HttpContext.Response.Cookies.Append("SepetOlusturuldu", "evet");


        }
    }
}
