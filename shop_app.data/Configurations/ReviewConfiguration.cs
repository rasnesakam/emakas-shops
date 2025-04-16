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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Title).IsRequired().HasMaxLength(50);
            builder.Property(r => r.Message).IsRequired().HasMaxLength(100);
            builder.HasOne(r => r.Customer).WithMany()
                .HasForeignKey(r => r.CustomerId).IsRequired();
            builder.HasOne(r => r.Product).WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId).IsRequired();
        }
    }
}
