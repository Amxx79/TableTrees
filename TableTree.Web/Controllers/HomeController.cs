using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TableTree.Services.Data;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.Models;
using TableTree.Web.ViewModels.Product;

namespace TableTree.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<ProductController> logger, IProductService productService)
        {
            this._logger = logger;
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await productService.GetAllProductsAsync(new AllProductsSearchFilterViewModel());
            return View(model);
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

        [Route("/StatusCodeError/{statusCode}")]  
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("404");
            }

            else if (statusCode == 500)
            {
                return View("500");
            }

            // Handle other status codes or render a generic error view
            return View("404");
        }
    }
}
