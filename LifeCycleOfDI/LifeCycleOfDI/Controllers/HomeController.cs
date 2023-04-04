using LifeCycleOfDI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LifeCycleOfDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingleton singleton;
        private readonly IScoped scoped;
        private readonly ITransient transient;
        private readonly GuidService guidService;

        public HomeController(ILogger<HomeController> logger, ISingleton singleton, IScoped scoped, ITransient transient, GuidService guidService)
        {
            _logger = logger;
            this.singleton = singleton;
            this.scoped = scoped;
            this.transient = transient;
            this.guidService = guidService;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = singleton.Guid.ToString();
            ViewBag.Scoped = scoped.Guid.ToString();
            ViewBag.Transient = transient.Guid.ToString();

            ViewBag.ObjSingleton = guidService.Singleton.Guid.ToString();
            ViewBag.ObjScoped = guidService.Scoped.Guid.ToString();
            ViewBag.ObjTransient = guidService.Transient.Guid.ToString();
            return View();
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