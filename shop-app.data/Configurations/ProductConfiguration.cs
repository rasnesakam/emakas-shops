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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Description).IsRequired().HasMaxLength(100);
            builder.Property(m => m.ImageUrl).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Price).IsRequired().HasColumnType("NUMERIC(12,2)");
            builder.Property(m => m.Created).HasDefaultValueSql("NOW()");
            builder.HasData(SampleDatas.Products);
        }
    }
}
