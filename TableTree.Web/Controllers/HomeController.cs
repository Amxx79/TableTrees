using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TableTree.Web.Models;

namespace TableTree.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public HomeController(ILogger<ProductController> logger)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
