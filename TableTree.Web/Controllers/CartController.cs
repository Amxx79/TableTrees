using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TableTree.Data.Models;
using TableTree.Services.Data.Interfaces;

namespace TableTree.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private readonly ICartService cartService;

        public CartController(ILogger<ProductController> logger, ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.cartService
                .GetAllProductsInCartAsync();

            return View(model);
        }
    }
}
