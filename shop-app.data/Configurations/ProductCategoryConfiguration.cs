using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop_app.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(pc => new { pc.CategoryId, pc.ProductId });
            builder.HasOne(pc => pc.Product).WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId).IsRequired();
            builder.HasOne(pc => pc.Category).WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId).IsRequired();
            builder.HasData(SampleDatas.ProductCategories);
        }
    }
}
