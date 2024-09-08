using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop_app.entity;

namespace shop_app.data.Configurations;

public class ProductTagConfiguration:  IEntityTypeConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Tag).HasMaxLength(50);
        builder.HasOne<Product>()
            .WithMany(p => p.Tags)
            .HasForeignKey(t => t.ProductId);
    }
}