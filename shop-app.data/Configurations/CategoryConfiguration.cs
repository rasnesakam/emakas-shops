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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.URI).IsRequired().HasMaxLength(50);
            builder.HasOne(m => m.Seller).WithMany();
            builder.HasMany(m => m.Products)
                .WithMany(p => p.Categories);
        }
    }
}
