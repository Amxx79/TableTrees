using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TableTree.Data.Models;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Cart;

namespace TableTree.Web.Controllers
{
    [Authorize]
    public class FavouritesController : Controller
    {
        private readonly IFavouriteService service;

        public FavouritesController(IFavouriteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await this.service
                .GetAllProductsInFavouritesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavourites(Guid id)
        {
            var userIdentiticator = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.service
                .AddProductAsync(id.ToString(), userIdentiticator);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavourites(Guid id)
        {
            var userIdentiticator = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.service
                .RemoveProduct(id.ToString() ,userIdentiticator);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
