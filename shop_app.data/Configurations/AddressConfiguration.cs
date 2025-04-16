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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.Property(a => a.AddressType).IsRequired().HasMaxLength(50);
            builder.Property(a => a.AddressLine1).IsRequired().HasMaxLength(140);
            builder.Property(a => a.AddressLine2).IsRequired(false).HasMaxLength(140);
            builder.Property(a => a.Province).IsRequired().HasMaxLength(50);
            builder.Property(a => a.City).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Country).IsRequired().HasMaxLength(50);
            builder.Property(a => a.PostalCode).IsRequired().HasMaxLength(50);
        }
    }
}
