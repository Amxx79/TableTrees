using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TableTree.Data.Models;

namespace TableTree.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> MakeUserAdmin()
        {
            string role = "Admin";

            IdentityResult? result = null;

            if (await roleManager.RoleExistsAsync(role) == false)
            {
                result = await roleManager.CreateAsync(new ApplicationRole(role));
            }

            if (User.IsInRole(role) == false && (result == null || result.Succeeded))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (user != null)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            return RedirectToAction(nameof(Index), "Product");
        }

        [Authorize]
        public async Task<IActionResult> MakeUserGlobalAdmin()
        {
            string role = "GlobalAdmin";

            IdentityResult? result = null;

            if (await roleManager.RoleExistsAsync(role) == false)
            {
                result = await roleManager.CreateAsync(new ApplicationRole(role));
            }

            if (User.IsInRole(role) == false && (result == null || result.Succeeded))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (user != null)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            return RedirectToAction(nameof(Index), "Product");
        }

    }
}
