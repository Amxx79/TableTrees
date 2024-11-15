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
            model.Categories = await this.productService.GetAllCategoriesAsync();
            model.TreeTypes = await this.productService.GetAllTreeTypesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this
                .productService.AddProductAsync(model);
            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var guid = Guid.Parse(id);
            await this.productService.SoftDelete(guid);

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            var guid = Guid.Parse(id);
            var model = await this.productService.GetProductDetailsByIdAsync(guid);

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var guid = Guid.Parse(id);
            var model = this.productService
                .GetProductForEditById(guid);


            model.Categories = this.productService.GetAllCategories();
            model.TreeTypes = this.productService.GetAllTreeTypes();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Categories = this.productService.GetAllCategories();
            model.TreeTypes = this.productService.GetAllTreeTypes();

            bool isUpdated = this.productService
                .EditProduct(model);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddProductToStore(string id)
        {


            return this.RedirectToAction(nameof(Index));
        }


    }
}
