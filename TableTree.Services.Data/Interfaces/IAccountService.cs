using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TableTree.Services.Data.Interfaces
{
    public interface IAccountService
    {
        Task MakeUserAdmin(ClaimsPrincipal user);
        Task MakeUserGlobalAdmin(ClaimsPrincipal user);
    }
}
