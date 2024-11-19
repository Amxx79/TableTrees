using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using TableTree.Data.Models;
using TableTree.Services.Data.Interfaces;

namespace TableTree.Services.Data
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IPrincipal currentUser;


        public AccountService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IPrincipal user)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.currentUser = user;
        }

        public async Task MakeUserAdmin()
        {
            string role = "Admin";
            IdentityResult? result = null;

            if (await roleManager.RoleExistsAsync(role) == false)
            {
                result = await roleManager.CreateAsync(new ApplicationRole(role));
            }

            if (currentUser.IsInRole(role) == false && (result == null || result.Succeeded))
            {
                var user = await userManager.FindByNameAsync(currentUser.Identity.Name);

                if (user != null)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            return;
        }

        public async Task MakeUserGlobalAdmin()
        {
            string role = "GlobalAdmin";

            IdentityResult? result = null;

            if (await roleManager.RoleExistsAsync(role) == false)
            {
                result = await roleManager.CreateAsync(new ApplicationRole(role));
            }

            if (currentUser.IsInRole(role) == false && (result == null || result.Succeeded))
            {
                var user = await userManager.FindByNameAsync(currentUser.Identity.Name);

                if (user != null)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            return;
        }
    }
}
