using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using TableTree.Data.Models;
using TableTree.Services.Data.Interfaces;

namespace TableTree.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IAccountService accountService;

        public AccountController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
            IAccountService accountService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.accountService = accountService;
            this.signInManager = signInManager;
        }

        [Authorize(Roles = "GlobalAdmin")]
        public async Task<IActionResult> Index()
        {
            var model = await this.accountService.GetlAllUsers();

            return this.View(model);
        }


        [Authorize(Roles = "GlobalAdmin")]
        public async Task<IActionResult> MakeUserAdmin(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var claimsPrincipalUser = await signInManager.CreateUserPrincipalAsync(user);

            await this.accountService.MakeUserAdmin(claimsPrincipalUser);

            return RedirectToAction(nameof(Index), "Product");
        }

        [Authorize]
        public async Task<IActionResult> MakeUserGlobalAdmin()
        {
            var user = User;

            await this.accountService.MakeUserGlobalAdmin(user);

            return RedirectToAction(nameof(Index), "Product");
        }

    }
}
