﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using shop_app.data.Concrete.EfCore;

#nullable disable

namespace shopapp.data.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("shop_app.entity.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("URI")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7c680942-d110-4287-b7a3-a8b85a63cd8e"),
                            Name = "Telefon",
                            URI = "telefon"
                        },
                        new
                        {
                            Id = new Guid("fdf68a8e-d6de-4aa1-bf84-50fae1a38e74"),
                            Name = "Bilgisayar",
                            URI = "bilgisayar"
                        },
                        new
                        {
                            Id = new Guid("06278cc2-bfe2-4d4d-b263-53328ceccaf7"),
                            Name = "TV",
                            URI = "tv"
                        },
                        new
                        {
                            Id = new Guid("6886aae3-b01e-4251-8b21-f9503bf9c759"),
                            Name = "Beyaz Eşya",
                            URI = "beyaz-esya"
                        },
                        new
                        {
                            Id = new Guid("0fd93b55-a1b6-45d5-90ed-421f07da7ec7"),
                            Name = "Hobi",
                            URI = "hobi"
                        });
                });

            modelBuilder.Entity("shop_app.entity.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("shop_app.entity.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(12,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cfc86f34-f381-4966-9101-594e4a4b3004"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar",
                            ImageUrl = "iphone.png",
                            Name = "Sahibinden temiz İphone",
                            Price = 10000.00m
                        },
                        new
                        {
                            Id = new Guid("90e1222b-aaa3-451a-b7b3-6d74a0b7f43f"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ciddi alıcılar",
                            ImageUrl = "mbook.png",
                            Name = "Temiz kullanılmış Macbook M1 Air",
                            Price = 20000.00m
                        },
                        new
                        {
                            Id = new Guid("81e07c43-cce6-498c-870e-b4a0a1297b1a"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Duvara as, tablo diye izle",
                            ImageUrl = "lgtv.png",
                            Name = "LG nin incecik televizyonu",
                            Price = 100.00m
                        },
                        new
                        {
                            Id = new Guid("e21d4813-2048-4e5b-a059-9f0c0f1d9c2d"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Güzel soğutur, benim cesedi 10 gün sakladı",
                            ImageUrl = "arcelik.png",
                            Name = "Buz Dolabı",
                            Price = 100.00m
                        },
                        new
                        {
                            Id = new Guid("06f66af9-bc34-4e5b-b1de-7a42610da41d"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Hobi amaçlı matkap",
                            ImageUrl = "matkap.png",
                            Name = "Matkap",
                            Price = 100.00m
                        });
                });

            modelBuilder.Entity("shop_app.entity.ProductCategory", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("7c680942-d110-4287-b7a3-a8b85a63cd8e"),
                            ProductId = new Guid("cfc86f34-f381-4966-9101-594e4a4b3004"),
                            Id = new Guid("a767b33f-cb52-4c4c-bbe4-c398bfe279c6")
                        },
                        new
                        {
                            CategoryId = new Guid("fdf68a8e-d6de-4aa1-bf84-50fae1a38e74"),
                            ProductId = new Guid("90e1222b-aaa3-451a-b7b3-6d74a0b7f43f"),
                            Id = new Guid("5bf91bb0-86f7-45e2-8b46-979cb140f9d0")
                        },
                        new
                        {
                            CategoryId = new Guid("06278cc2-bfe2-4d4d-b263-53328ceccaf7"),
                            ProductId = new Guid("81e07c43-cce6-498c-870e-b4a0a1297b1a"),
                            Id = new Guid("77564277-6e67-466e-8655-173a49aa7f15")
                        },
                        new
                        {
                            CategoryId = new Guid("6886aae3-b01e-4251-8b21-f9503bf9c759"),
                            ProductId = new Guid("e21d4813-2048-4e5b-a059-9f0c0f1d9c2d"),
                            Id = new Guid("d5315c39-0d03-455c-8551-65f9da20f3b7")
                        },
                        new
                        {
                            CategoryId = new Guid("0fd93b55-a1b6-45d5-90ed-421f07da7ec7"),
                            ProductId = new Guid("06f66af9-bc34-4e5b-b1de-7a42610da41d"),
                            Id = new Guid("3609493b-5642-4e07-a2f3-965d60bab240")
                        });
                });

            modelBuilder.Entity("shop_app.entity.Order", b =>
                {
                    b.HasOne("shop_app.entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("shop_app.entity.ProductCategory", b =>
                {
                    b.HasOne("shop_app.entity.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shop_app.entity.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("shop_app.entity.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("shop_app.entity.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
