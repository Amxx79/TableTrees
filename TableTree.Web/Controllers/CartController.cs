﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
            var model = await this.cartService
                .GetAllProductsInCartAsync();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            this.cartService
                .AddProductAsync(id.ToString(), userId);

            return RedirectToAction(nameof(Index));
        }
    }
}