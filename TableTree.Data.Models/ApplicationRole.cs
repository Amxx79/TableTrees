using Microsoft.AspNetCore.Identity;

namespace TableTree.Data.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
            
        }

        public ApplicationRole(string roleName)
            : base(roleName)
        {
                
        }

    }
}
