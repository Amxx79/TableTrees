using Microsoft.AspNetCore.Identity;

namespace TableTree.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }
        public IEnumerable<ProductClient> ClientsProducts { get; set; } = new HashSet<ProductClient>();
    }
}
