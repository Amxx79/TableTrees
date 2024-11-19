using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using TableTree.Data.Models;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Account;

namespace TableTree.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAccountService accountService;

        public AccountController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, 
            IAccountService accountService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            List<UserRoleViewModel> model = new List<UserRoleViewModel>();


            foreach (var user in userManager.Users)
            {
                var roles = await userManager.GetRolesAsync(user);

                UserRoleViewModel userRole = new UserRoleViewModel()
                {
                    Id = user.Id.ToString(),
                    Username = user.UserName,
                    IsAdmin = roles.Contains("Admin") ? true : false,
                };

                model.Add(userRole);
            }

            return this.View(model);
        }


        [Authorize]
        public async Task<IActionResult> MakeUserAdmin()
        {
            var user = User;

            await this.accountService.MakeUserAdmin(user);

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
