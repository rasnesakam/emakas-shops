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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            /*
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(u => u.Email)
                .IsRequired();
            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasColumnType("VARBINARY(500)");

            builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            builder.HasData(SampleDatas.Users);
            */
        }
    }
}
