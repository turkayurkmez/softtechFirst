using eshop.MVC.ExtensionMerhods;
using eshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshop.MVC.Components
{
    public class NoticationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cardCollection = HttpContext.Session.GetJson<ShoppingCardCollection>("basket");
            var totalItemsCount = cardCollection != null ? cardCollection.GetTotalProductsCount() : 0;
            return View(totalItemsCount);
        }
    }
}
