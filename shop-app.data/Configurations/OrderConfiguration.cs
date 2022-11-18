using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop_app.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.UserId).IsRequired().HasMaxLength(20);
            builder.Property(m=> m.ProductId).IsRequired().HasMaxLength(20);
            builder.Property(m => m.Note).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Status).IsRequired().HasMaxLength(20);
            builder.Property(m => m.Created).HasDefaultValueSql("NOW()");

        }
    }
}
