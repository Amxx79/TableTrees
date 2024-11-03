using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TableTree.Data.Models;

namespace TableTree.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne(t => t.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(t => t.CategoryId);

            builder
                .HasOne(p => p.TreeType)
                .WithMany(tt => tt.Products)
                .HasForeignKey(p => p.TreeTypeId);

            builder
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
