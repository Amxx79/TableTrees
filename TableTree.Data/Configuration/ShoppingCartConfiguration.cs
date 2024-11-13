using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TableTree.Data.Models;

namespace TableTree.Data.Configuration
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder
                .HasKey(pc => new { pc.ProductId, pc.ApplicationUserId });

            builder
                .HasOne(pc => pc.ApplicationUser)
                .WithMany(u => u.ClientsProducts)
                .HasForeignKey(c => c.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductsClients)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
