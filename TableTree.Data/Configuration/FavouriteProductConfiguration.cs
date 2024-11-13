using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TableTree.Data.Models;

namespace TableTree.Data.Configuration
{
    public class FavouriteProductConfiguration : IEntityTypeConfiguration<FavouriteProduct>
    {
        public void Configure(EntityTypeBuilder<FavouriteProduct> builder)
        {
            builder
                .HasKey(fp => new { fp.ProductId, fp.ApplicationUserId });

            builder
                .HasOne(fp => fp.ApplicationUser)
                .WithMany(au => au.ClientsFavouriteProducts)
                .HasForeignKey(fp => fp.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(fp => fp.Product)
                .WithMany(p => p.FavouriteProductsClients)
                .HasForeignKey(fp => fp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
