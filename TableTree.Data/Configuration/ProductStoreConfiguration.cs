using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TableTree.Data.Models;

namespace TableTree.Data.Configuration
{
    public class ProductStoreConfiguration : IEntityTypeConfiguration<ProductStore>
    {
        public void Configure(EntityTypeBuilder<ProductStore> builder)
        {
            builder
                .HasKey(ps => new { ps.ProductId, ps.StoreId });

            builder
                .HasOne(ps => ps.Product)
                .WithMany(ps => ps.ProductStores)
                .HasForeignKey(ps => ps.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ps => ps.Store)
                .WithMany(ps => ps.StoreProducts)
                .HasForeignKey(ps => ps.StoreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
