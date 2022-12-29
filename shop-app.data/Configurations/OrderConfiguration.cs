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
            builder.HasKey(m => m.Id);;
            builder.Property(m => m.CustomerNote).IsRequired().HasMaxLength(100);
            builder.Property(m => m.SellerNote).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Status).IsRequired().HasMaxLength(20);
            builder.Property(m => m.Created).HasDefaultValueSql("NOW()");
            builder.Property(m => m.Updated).HasDefaultValueSql("NOW()");

            builder.HasOne(o => o.Address).WithMany()
                .HasForeignKey(o => o.AddressId).IsRequired();
            builder.HasOne(o => o.Product).WithMany()
                .HasForeignKey(o => o.ProductId).IsRequired();
            builder.HasOne(o => o.Customer).WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId).IsRequired();
            builder.HasOne(o => o.Seller).WithMany(s => s.Orders)
                .HasForeignKey(o => o.SellerId).IsRequired();
        }
    }
}
