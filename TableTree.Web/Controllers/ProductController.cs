using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TableTree.Data.Models;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Product;
using TableTree.Web.ViewModels.Store;

namespace TableTree.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;
        private readonly IAvailabilityService availabilityService;
        private readonly UserManager<ApplicationUser> userManager;

		public ProductController(ILogger<ProductController> logger, IProductService productService,
            IAvailabilityService availabilityService, UserManager<ApplicationUser> userManager)
        {
            this.logger = logger;
            this.productService = productService;
            this.availabilityService = availabilityService;
            this.userManager = userManager;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var guid = Guid.Parse(id);
            await this.productService.SoftDelete(guid);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var guid = Guid.Parse(id);
            var model = await this.productService.GetProductDetailsByIdAsync(guid);

            return this.View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProductToStore(string productId)
        {
            var userIdentiticator = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await this.availabilityService
                .GetAddProductToStoreAsync(productId.ToString(), userIdentiticator);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToStore(AddProductToStoreViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.availabilityService
                .AddProductToStoreAsync(model);

            //TODO: Check what have to do when the data is ready.
            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentToProduct(Guid productId, string text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			ApplicationUser user = await userManager.FindByIdAsync(userId);

            Product product = await this.productService.GetProductByIdAsync(productId);

			CommentInputModel model = new CommentInputModel()
			{
				ApplicationUserId = Guid.Parse(userId),
				ApplicationUser = user,
				CommentDescription = text,
				ProductId = productId,
				Product = product,
			};

			await this.productService.AddCommentToProduct(model);

			return this.RedirectToAction("Details", new { id = product.Id });
		}
	}
}
