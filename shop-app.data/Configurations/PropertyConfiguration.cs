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
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Key).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Value).IsRequired().HasMaxLength(50);
            builder.HasOne<Product>().WithMany(p => p.Properties)
                .HasForeignKey(m => m.ProductId).IsRequired();
        }
    }
}
