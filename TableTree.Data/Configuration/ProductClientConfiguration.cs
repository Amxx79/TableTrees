using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TableTree.Data.Models;

namespace TableTree.Data.Configuration
{
    public class ProductClientConfiguration : IEntityTypeConfiguration<ProductClient>
    {
        public void Configure(EntityTypeBuilder<ProductClient> builder)
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
