using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TableTree.Data.Models;
using static TableTree.Common.ApplicationConstants;

namespace TableTree.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

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

            builder
                .Property(p => p.ImageUrl)
                .HasDefaultValue(NoImageUrl);

            //builder
            //    .HasData(this.GenerateProducts());
        }

        /*private IEnumerable<Product> GenerateProducts()
        {
            IEnumerable<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Round Epoxy Table Moss Stones",
                    Description = "Round Epoxy Tables have gradually shifted from designer fads to sought out and indispensable home decor for those who want to keep it stylish",
                    Price = 526.50m,
                    ImageUrl = "https://i.etsystatic.com/21622583/r/il/745996/5104378769/il_794xN.5104378769_dck9.jpg",
                    IsDeleted = false,
                    TreeTypeId = Guid.Parse("401DD5CD-C271-4960-84CE-0B364C96F039"),
                    CategoryId = Guid.Parse("61BC3294-73CA-441B-9B53-0D4F26B673F3"),
                },

                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rustic Tree Trunk Coffee Table",
                    Description = "Resin Cast Rustic Tree Trunk Side Table, Such a unique and beautiful Side Table fit for any room around your home. We custom make these Rustic Tree Trunk Side Tables to any style,size and colour of Epoxy Resin. We also manufacture our own legs and can accommodate a number of styles to suit your needs",
                    Price = 999.90m,
                    ImageUrl = "https://theindustrialfurniture.co.uk/cdn/shop/files/EkranResmi2023-04-3011.47-PhotoRoom_grande.png?v=1692620377",
                    IsDeleted = false,
                    TreeTypeId = Guid.Parse("133A6AF3-1B7D-4D6E-AA41-33BE63184766"),
                    CategoryId = Guid.Parse("A1042FEE-F95A-4BF3-A758-49B13CFF3E79"),
                },

                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Waterproof natural wood bathroom cabinet with natural towel opening.",
                    Description = "Custom double tree stump vanity design features western cedar tree stumps. It also features a redwood live-edge wood countertop. Water bridge bathroom faucets spill into hammered copper vessel sinks. Custom forged chains add to the rustic ambiance. Our double tree stump vanities are built to order, thus allowing for a complete bespoke design experience.",
                    Price = 599.99m,
                    ImageUrl = "https://masivno.com/wp-content/uploads/2023/07/IMG_2392-1612x1655.jpeg",
                    IsDeleted = false,
                    TreeTypeId = Guid.Parse("632BFA2F-AA06-4C1B-913D-33EF43A44D34"),
                    CategoryId = Guid.Parse("6ACD5822-A59E-4427-B8AC-FBCA0751CD98"),
                },
            };

            return products;
        }*/
    }
}
