using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TableTree.Data.Models;

namespace TableTree.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasData(this.GenerateCategories());
        }

        private IEnumerable<Category> GenerateCategories()
        {
            IEnumerable<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.Parse("a1042fee-f95a-4bf3-a758-49b13cff3e79"),
                    Name = "Table",
                },
                new Category()
                {
                    Id = Guid.Parse("61bc3294-73ca-441b-9b53-0d4f26b673f3"),
                    Name = "Bathroom Countertop",
                },
                new Category()
                {
                    Id = Guid.Parse("6acd5822-a59e-4427-b8ac-fbca0751cd98"),
                    Name = "Mirrors",
                }
            };

            return categories;
        }
    }
}
