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
            
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(u => u.Email)
                .IsRequired();
            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("UserEmailIndex").IsUnique();
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("NOW()");
            builder.HasData(SampleDatas.Users);
            
        }
    }
}
