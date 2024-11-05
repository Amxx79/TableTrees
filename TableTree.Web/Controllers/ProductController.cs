using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TableTree.Data.Models;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.Models;

namespace TableTree.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await productService.GetAllProductsAsync();
            return View(model);
        }
    }
}
