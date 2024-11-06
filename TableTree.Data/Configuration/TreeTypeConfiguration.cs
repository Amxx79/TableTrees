using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TableTree.Data.Models;

namespace TableTree.Data.Configuration
{
    public class TreeTypeConfiguration : IEntityTypeConfiguration<TreeType>
    {
        public void Configure(EntityTypeBuilder<TreeType> builder)
        {
            builder
                .HasData(this.GenerateTreeTypes());
        }

        private IEnumerable<TreeType> GenerateTreeTypes()
        {
            IEnumerable<TreeType> treeTypes = new List<TreeType>()
            {
                new TreeType()
                {
                    Id = Guid.Parse("632bfa2f-aa06-4c1b-913d-33ef43a44d34"),
                    Name = "Tree",
                },
                new TreeType()
                {
                    Id = Guid.Parse("133a6af3-1b7d-4d6e-aa41-33be63184766"),
                    Name = "Beech",
                },
                new TreeType()
                {
                    Id = Guid.Parse("401dd5cd-c271-4960-84ce-0b364c96f039"),
                    Name = "Оак",
                },
            };

            return treeTypes;
        }
    }
}
