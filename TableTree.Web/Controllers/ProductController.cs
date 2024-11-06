using Microsoft.AspNetCore.Mvc;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Product;

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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddProductInputModel();
            model.Categories = await this.productService.GetAllCategories();
            model.TreeTypes = await this.productService.GetAllTreeTypes();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Categories = await this.productService.GetAllCategories();
            model.TreeTypes = await this.productService.GetAllTreeTypes();

            await this
                .productService.AddProductAsync(model);
            return this.RedirectToAction(nameof(Index));
        }
    }
}
