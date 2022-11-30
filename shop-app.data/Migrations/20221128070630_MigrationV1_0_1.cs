using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopapp.data.Migrations
{
    public partial class MigrationV1_0_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("1df1e587-49eb-4166-ab32-b7ab50ba0f0b"), new Guid("9cdcccd1-3566-4ff2-8b81-8dea75d05ac9") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("6e4b7b94-ecf9-4604-90b1-a2c0c955d534"), new Guid("b7da2e64-35d2-4309-8cd8-08d48456e7f7") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("7fb254bd-76a9-4ad0-9a55-410d82ae07d5"), new Guid("66f6a0dc-df0b-4b74-bd83-387d6cef90df") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("bb19189d-c3cd-4965-bc09-63d47cb8e4b2"), new Guid("384587a1-d04b-4a93-a214-1f2100745bd1") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("e8e2f0b3-50cd-4ec5-823d-99ca5994a758"), new Guid("2d662d20-c01d-4db1-8fa5-365a4d2ec06d") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1df1e587-49eb-4166-ab32-b7ab50ba0f0b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6e4b7b94-ecf9-4604-90b1-a2c0c955d534"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7fb254bd-76a9-4ad0-9a55-410d82ae07d5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bb19189d-c3cd-4965-bc09-63d47cb8e4b2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e8e2f0b3-50cd-4ec5-823d-99ca5994a758"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d662d20-c01d-4db1-8fa5-365a4d2ec06d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("384587a1-d04b-4a93-a214-1f2100745bd1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66f6a0dc-df0b-4b74-bd83-387d6cef90df"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9cdcccd1-3566-4ff2-8b81-8dea75d05ac9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b7da2e64-35d2-4309-8cd8-08d48456e7f7"));

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Categories",
                newName: "URI");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "URI" },
                values: new object[,]
                {
                    { new Guid("06278cc2-bfe2-4d4d-b263-53328ceccaf7"), "TV", "tv" },
                    { new Guid("0fd93b55-a1b6-45d5-90ed-421f07da7ec7"), "Hobi", "hobi" },
                    { new Guid("6886aae3-b01e-4251-8b21-f9503bf9c759"), "Beyaz Eşya", "beyaz-esya" },
                    { new Guid("7c680942-d110-4287-b7a3-a8b85a63cd8e"), "Telefon", "telefon" },
                    { new Guid("fdf68a8e-d6de-4aa1-bf84-50fae1a38e74"), "Bilgisayar", "bilgisayar" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("06f66af9-bc34-4e5b-b1de-7a42610da41d"), "Hobi amaçlı matkap", "matkap.png", "Matkap", 100.00m },
                    { new Guid("81e07c43-cce6-498c-870e-b4a0a1297b1a"), "Duvara as, tablo diye izle", "lgtv.png", "LG nin incecik televizyonu", 100.00m },
                    { new Guid("90e1222b-aaa3-451a-b7b3-6d74a0b7f43f"), "Ciddi alıcılar", "mbook.png", "Temiz kullanılmış Macbook M1 Air", 20000.00m },
                    { new Guid("cfc86f34-f381-4966-9101-594e4a4b3004"), "Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar", "iphone.png", "Sahibinden temiz İphone", 10000.00m },
                    { new Guid("e21d4813-2048-4e5b-a059-9f0c0f1d9c2d"), "Güzel soğutur, benim cesedi 10 gün sakladı", "arcelik.png", "Buz Dolabı", 100.00m }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "Id" },
                values: new object[,]
                {
                    { new Guid("06278cc2-bfe2-4d4d-b263-53328ceccaf7"), new Guid("81e07c43-cce6-498c-870e-b4a0a1297b1a"), new Guid("77564277-6e67-466e-8655-173a49aa7f15") },
                    { new Guid("0fd93b55-a1b6-45d5-90ed-421f07da7ec7"), new Guid("06f66af9-bc34-4e5b-b1de-7a42610da41d"), new Guid("3609493b-5642-4e07-a2f3-965d60bab240") },
                    { new Guid("6886aae3-b01e-4251-8b21-f9503bf9c759"), new Guid("e21d4813-2048-4e5b-a059-9f0c0f1d9c2d"), new Guid("d5315c39-0d03-455c-8551-65f9da20f3b7") },
                    { new Guid("7c680942-d110-4287-b7a3-a8b85a63cd8e"), new Guid("cfc86f34-f381-4966-9101-594e4a4b3004"), new Guid("a767b33f-cb52-4c4c-bbe4-c398bfe279c6") },
                    { new Guid("fdf68a8e-d6de-4aa1-bf84-50fae1a38e74"), new Guid("90e1222b-aaa3-451a-b7b3-6d74a0b7f43f"), new Guid("5bf91bb0-86f7-45e2-8b46-979cb140f9d0") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("06278cc2-bfe2-4d4d-b263-53328ceccaf7"), new Guid("81e07c43-cce6-498c-870e-b4a0a1297b1a") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("0fd93b55-a1b6-45d5-90ed-421f07da7ec7"), new Guid("06f66af9-bc34-4e5b-b1de-7a42610da41d") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("6886aae3-b01e-4251-8b21-f9503bf9c759"), new Guid("e21d4813-2048-4e5b-a059-9f0c0f1d9c2d") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("7c680942-d110-4287-b7a3-a8b85a63cd8e"), new Guid("cfc86f34-f381-4966-9101-594e4a4b3004") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("fdf68a8e-d6de-4aa1-bf84-50fae1a38e74"), new Guid("90e1222b-aaa3-451a-b7b3-6d74a0b7f43f") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("06278cc2-bfe2-4d4d-b263-53328ceccaf7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0fd93b55-a1b6-45d5-90ed-421f07da7ec7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6886aae3-b01e-4251-8b21-f9503bf9c759"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7c680942-d110-4287-b7a3-a8b85a63cd8e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fdf68a8e-d6de-4aa1-bf84-50fae1a38e74"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("06f66af9-bc34-4e5b-b1de-7a42610da41d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("81e07c43-cce6-498c-870e-b4a0a1297b1a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("90e1222b-aaa3-451a-b7b3-6d74a0b7f43f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfc86f34-f381-4966-9101-594e4a4b3004"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e21d4813-2048-4e5b-a059-9f0c0f1d9c2d"));

            migrationBuilder.RenameColumn(
                name: "URI",
                table: "Categories",
                newName: "URL");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "URL" },
                values: new object[,]
                {
                    { new Guid("1df1e587-49eb-4166-ab32-b7ab50ba0f0b"), "Hobi", "hobi" },
                    { new Guid("6e4b7b94-ecf9-4604-90b1-a2c0c955d534"), "Telefon", "telefon" },
                    { new Guid("7fb254bd-76a9-4ad0-9a55-410d82ae07d5"), "Bilgisayar", "bilgisayar" },
                    { new Guid("bb19189d-c3cd-4965-bc09-63d47cb8e4b2"), "TV", "tv" },
                    { new Guid("e8e2f0b3-50cd-4ec5-823d-99ca5994a758"), "Beyaz Eşya", "beyaz-esya" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2d662d20-c01d-4db1-8fa5-365a4d2ec06d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Güzel soğutur, benim cesedi 10 gün sakladı", "arcelik.png", "Buz Dolabı", 100.00m },
                    { new Guid("384587a1-d04b-4a93-a214-1f2100745bd1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duvara as, tablo diye izle", "lgtv.png", "LG nin incecik televizyonu", 100.00m },
                    { new Guid("66f6a0dc-df0b-4b74-bd83-387d6cef90df"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciddi alıcılar", "mbook.png", "Temiz kullanılmış Macbook M1 Air", 20000.00m },
                    { new Guid("9cdcccd1-3566-4ff2-8b81-8dea75d05ac9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hobi amaçlı matkap", "matkap.png", "Matkap", 100.00m },
                    { new Guid("b7da2e64-35d2-4309-8cd8-08d48456e7f7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar", "iphone.png", "Sahibinden temiz İphone", 10000.00m }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "Id" },
                values: new object[,]
                {
                    { new Guid("1df1e587-49eb-4166-ab32-b7ab50ba0f0b"), new Guid("9cdcccd1-3566-4ff2-8b81-8dea75d05ac9"), new Guid("dd73968e-d5da-4433-87e4-af8c486672b6") },
                    { new Guid("6e4b7b94-ecf9-4604-90b1-a2c0c955d534"), new Guid("b7da2e64-35d2-4309-8cd8-08d48456e7f7"), new Guid("55c62d78-fba3-481d-a972-8a354c198488") },
                    { new Guid("7fb254bd-76a9-4ad0-9a55-410d82ae07d5"), new Guid("66f6a0dc-df0b-4b74-bd83-387d6cef90df"), new Guid("24c94c85-58f8-4796-96b0-b9d3b8e7343f") },
                    { new Guid("bb19189d-c3cd-4965-bc09-63d47cb8e4b2"), new Guid("384587a1-d04b-4a93-a214-1f2100745bd1"), new Guid("aaec0757-97f5-4a69-a439-21fc4eaed81d") },
                    { new Guid("e8e2f0b3-50cd-4ec5-823d-99ca5994a758"), new Guid("2d662d20-c01d-4db1-8fa5-365a4d2ec06d"), new Guid("b92769b2-ddfc-4052-8fa0-fa3320c6feeb") }
                });
        }
    }
}
