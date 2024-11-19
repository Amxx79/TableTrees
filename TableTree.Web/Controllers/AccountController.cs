﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using TableTree.Data.Models;
using TableTree.Services.Data.Interfaces;

namespace TableTree.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAccountService accountService;

        public AccountController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager
            , IAccountService accountService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.accountService = accountService;
        }

        [Authorize]
        public async Task<IActionResult> MakeUserAdmin()
        {
            await this.accountService.MakeUserAdmin();

            return RedirectToAction(nameof(Index), "Product");
        }

        [Authorize]
        public async Task<IActionResult> MakeUserGlobalAdmin()
        {
            await this.accountService.MakeUserGlobalAdmin();

            return RedirectToAction(nameof(Index), "Product");
        }

    }
}
