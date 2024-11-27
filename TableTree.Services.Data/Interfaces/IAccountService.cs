using System.Security.Claims;
using TableTree.Web.ViewModels.Account;

namespace TableTree.Services.Data.Interfaces
{
    public interface IAccountService
    {
        Task MakeUserAdmin(ClaimsPrincipal user);
        Task MakeUserGlobalAdmin(ClaimsPrincipal user);
        Task<List<UserRoleViewModel>> GetlAllUsers();
        Task<bool> DeleteUser(string userId);
    }
}
