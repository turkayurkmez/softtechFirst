using eshop.Application.Services;
using eshop.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eshop.MVC.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IUserService userService;

        public KullaniciController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Giris(string nerelereGidem)
        {
            ViewBag.ReturnUrl = nerelereGidem;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Giris(UserLoginViewModel userLogin, string? nerelereGidem = null)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (!string.IsNullOrEmpty(nerelereGidem) && Url.IsLocalUrl(nerelereGidem))
                    {
                        return Redirect(nerelereGidem);
                    }
                    return Redirect("/");
                }

                ModelState.AddModelError("login", "Hatalıu kullanıcı adı veya şifre");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Yasak()
        {
            return View();
        }
    }
}
