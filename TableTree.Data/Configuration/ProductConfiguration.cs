using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;
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
                .HasMany(p => p.Comments)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId);

            builder
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(p => p.ImageUrl)
                .HasDefaultValue(NoImageUrl);

            builder
                .HasData(this.GenerateProducts());
        }

        private IEnumerable<Product> GenerateProducts()
        {
            IEnumerable<Product> products = new List<Product>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Reclaimed Wood Counter Top",
                    Description = "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.",
                    Price = 450.00m,
                    ImageUrl = "/images/table-1.jpeg",
                    IsDeleted = false,
                    CategoryId = Guid.Parse("61BC3294-73CA-441B-9B53-0D4F26B673F3"),
                    TreeTypeId = Guid.Parse("401DD5CD-C271-4960-84CE-0B364C96F039"),
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Eris Hackberry Blue Epoxy Resin Table",
                    Description = "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.",
                    Price = 1599.00m,
                    ImageUrl = "/images/table-2.jpeg",
                    IsDeleted = false,
                    CategoryId = Guid.Parse("A1042FEE-F95A-4BF3-A758-49B13CFF3E79"),
                    TreeTypeId = Guid.Parse("133A6AF3-1B7D-4D6E-AA41-33BE63184766"),
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Epoxy resin table olive tree",
                    Description = "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.",
                    Price = 1200.00m,
                    ImageUrl = "/images/table-3.jpg",
                    IsDeleted = false,
                    CategoryId = Guid.Parse("A1042FEE-F95A-4BF3-A758-49B13CFF3E79"),
                    TreeTypeId = Guid.Parse("401DD5CD-C271-4960-84CE-0B364C96F039"),
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Epoxy Resin River Table",
                    Description = "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.",
                    Price = 1199.50m,
                    ImageUrl = "/images/table-4.jpeg",
                    IsDeleted = false,
                    CategoryId = Guid.Parse("A1042FEE-F95A-4BF3-A758-49B13CFF3E79"),
                    TreeTypeId = Guid.Parse("133A6AF3-1B7D-4D6E-AA41-33BE63184766"),
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rustic Live Edge Tree Table",
                    Description = "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.",
                    Price = 799.99m,
                    ImageUrl = "/images/table-5.jpeg",
                    IsDeleted = false,
                    CategoryId = Guid.Parse("A1042FEE-F95A-4BF3-A758-49B13CFF3E79"),
                    TreeTypeId = Guid.Parse("632BFA2F-AA06-4C1B-913D-33EF43A44D34"),
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Custom Epoxy and Olive Wood Decorative Mirror",
                    Description = "Adorn your living space with our exquisite Epoxy and Olive Wood Decorative Bathroom Mirror – a fusion of artistry and practicality that transcends ordinary decor. Crafted with meticulous attention to detail, this handmade masterpiece is more than just a mirror",
                    Price = 99.99m,
                    ImageUrl = "/images/mirror-1.jpeg",
                    IsDeleted = false,
                    CategoryId = Guid.Parse("6ACD5822-A59E-4427-B8AC-FBCA0751CD98"),
                    TreeTypeId = Guid.Parse("133A6AF3-1B7D-4D6E-AA41-33BE63184766"),
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Olive Wooden Wall Mirror, Wooden Mirror",
                    Description = "This special design, crafted from olive wood, has been meticulously prepared, preserving the natural edge and bark of the wood. The cracks have been filled with special epoxy, and a custom matte varnish has been applied to the wood surface to provide resistance against scratches without losing its natural texture",
                    Price = 115.99m,
                    ImageUrl = "/images/mirror-2.jpg",
                    IsDeleted = false,
                    CategoryId = Guid.Parse("6ACD5822-A59E-4427-B8AC-FBCA0751CD98"),
                    TreeTypeId = Guid.Parse("401DD5CD-C271-4960-84CE-0B364C96F039"),
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Wooden bathroom countertop",
                    Description = "Elevate your bathroom with our handcrafted wooden countertop, made from sustainably sourced oak. Each piece is carefully treated for durability, offering a unique blend of natural beauty and modern functionality to complement any decor style.",
                    Price = 235.99m,
                    ImageUrl = "/images/bathroom-countertop-1.jpg",
                    IsDeleted = false,
                    CategoryId = Guid.Parse("61BC3294-73CA-441B-9B53-0D4F26B673F3"),
                    TreeTypeId = Guid.Parse("401DD5CD-C271-4960-84CE-0B364C96F039"),
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "A set of boutique natural wood bathroom countertops",
                    Description = "Transform your bathroom with this set of boutique natural wood countertops, expertly crafted from premium, sustainably sourced wood.",
                    Price = 199.00m,
                    ImageUrl = "/images/bathroom-countertop-2.jpg",
                    IsDeleted = false,
                    CategoryId = Guid.Parse("61BC3294-73CA-441B-9B53-0D4F26B673F3"),
                    TreeTypeId = Guid.Parse("632BFA2F-AA06-4C1B-913D-33EF43A44D34"),
                },
            };

            return products;
        }
    }
}
