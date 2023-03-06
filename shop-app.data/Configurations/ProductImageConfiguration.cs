using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop_app.entity;

namespace shop_app.data.Configurations;

public class ProductImageConfiguration: IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.AltText).IsRequired();
        builder.Property(i => i.FileUri).IsRequired();
    }
}