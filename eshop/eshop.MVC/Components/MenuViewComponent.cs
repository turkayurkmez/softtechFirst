﻿using eshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace eshop.MVC.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public MenuViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }
    }
}
