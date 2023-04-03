using introduceNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace introduceNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ad = "Türkay Ürkmez";
            ViewBag.Tarih = DateTime.Now;
            ViewBag.Urunler = new string[] { "Ürün X", "Ürün Y", "Ürün Z" };
            return View();
        }

        public IActionResult Register()
        {
            //UserModel userModel = new UserModel() { FirstName = "Hüsamettin", LastName = "Cindoruk", BirthDate = new DateTime(1940, 1, 1) };
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View();
        }
    }
}
