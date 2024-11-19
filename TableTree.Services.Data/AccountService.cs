using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;
using TableTree.Data.Models;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Account;

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

        public async Task<List<UserRoleViewModel>> GetlAllUsers()
        {
            List<UserRoleViewModel> model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var roles = await userManager.GetRolesAsync(user);

                var isInRole = await userManager.IsInRoleAsync(user, "Admin");

                UserRoleViewModel userRole = new UserRoleViewModel()
                {
                    Id = user.Id.ToString(),
                    Username = user.UserName,
                    IsAdmin = isInRole,
                };

                model.Add(userRole);
            }

            return model;
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

            else if (user.IsInRole("Admin"))
            {
                var currentUser = await userManager.FindByNameAsync(user.Identity.Name);

                await userManager.RemoveFromRoleAsync(currentUser, role);
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
