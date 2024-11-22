using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTree.Data.Models;

namespace TableTree.Data.Configuration
{
    public class OrderItemInfoConfiguration : IEntityTypeConfiguration<OrderItemInfo>
    {
        public void Configure(EntityTypeBuilder<OrderItemInfo> builder)
        {
            builder.HasKey(oi => new { oi.OrderId, oi.ProductId });

            builder
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
