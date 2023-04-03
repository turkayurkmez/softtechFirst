﻿using eshop.MVC.Models;
using eshop.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Bu controller, ürün verisiyle çalışmak zorunda.
            //Ürün verisi olmadan bu controller olmaz.
            //Ürün verisini sağlayan nesne, controller nesnesinin bağımlılığıdır.

            InsideProductService productService = new InsideProductService();
            var products = productService.GetProducts();

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