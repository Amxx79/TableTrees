﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var model = await this.cartService
                .GetAllProductsInCartAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid id, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.cartService
                .AddProductAsync(id.ToString(), userId, quantity);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(string productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.cartService.RemoveProduct(productId, userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
