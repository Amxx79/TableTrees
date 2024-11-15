using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTree.Data.Models;

namespace TableTree.Data.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {

            builder
                .HasData(GenerateStores());
        }

        private IEnumerable<Store> GenerateStores()
        {
            IEnumerable<Store> stores = new List<Store>()
            {
                new()
                {
                    Id = Guid.Parse("5f69b658-4422-4bb6-94b1-46a5f146f826"),
                    Address = "Bulgaria, Sofia, Druzhba",
                },
                new()
                {
                    Id = Guid.Parse("be64604e-12e3-4872-bd07-242f1e45d0f2"),
                    Address = "Bulgaria, Plovdiv, Trakiya",
                },
                new()
                {
                    Id = Guid.Parse("8e37d43e-cdc4-48ca-ade3-63147766cbce"),
                    Address = "Bulgaria, Bourgas, Trakiya",
                }
            };

            return stores;
        }
    }
}
