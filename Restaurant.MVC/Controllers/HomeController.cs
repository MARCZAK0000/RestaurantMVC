using Microsoft.AspNetCore.Mvc;
using Restaurant.MVC.Models;
using System.Diagnostics;

namespace Restaurant.MVC.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NoAccess() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string queryString)
        {
            if(queryString == null) 
            {
                return View();
            }
            return RedirectToAction("Index", "Restaurant", new
            {
                pageNumber = 1,
                querySearch = queryString
            });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}