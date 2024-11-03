using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TableTree.Web.Models;

namespace TableTree.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
