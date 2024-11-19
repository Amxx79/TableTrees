using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;
using TableTree.Data.Models;
using TableTree.Services.Data.Interfaces;

namespace TableTree.Services.Data
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public AccountService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task MakeUserAdmin(ClaimsPrincipal user)
        {
            string role = "Admin";
            IdentityResult? result = null;

            if (await roleManager.RoleExistsAsync(role) == false)
            {
                result = await roleManager.CreateAsync(new ApplicationRole(role));
            }

            if (user.IsInRole(role) == false && (result == null || result.Succeeded))
            {
                var currentUser = await userManager.FindByNameAsync(user.Identity.Name);

                if (currentUser != null)
                {
                    await userManager.AddToRoleAsync(currentUser, role);
                }
            }

            return;
        }

        public async Task MakeUserGlobalAdmin(ClaimsPrincipal user)
        {
            string role = "GlobalAdmin";

            IdentityResult? result = null;

            if (await roleManager.RoleExistsAsync(role) == false)
            {
                result = await roleManager.CreateAsync(new ApplicationRole(role));
            }

            if (user.IsInRole(role) == false && (result == null || result.Succeeded))
            {
                var currentUser = await userManager.FindByNameAsync(user.Identity.Name);

                if (user != null)
                {
                    await userManager.AddToRoleAsync(currentUser, role);
                }
            }

            return;
        }
    }
}
