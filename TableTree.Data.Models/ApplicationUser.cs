using Microsoft.AspNetCore.Identity;

namespace TableTree.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }
        public IEnumerable<ShoppingCart> ClientsProducts { get; set; } = new HashSet<ShoppingCart>();
        public IEnumerable<FavouriteProduct> ClientsFavouriteProducts { get; set; } = new HashSet<FavouriteProduct>();
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}
