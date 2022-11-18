using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopapp.data.Migrations
{
    public partial class MigrationV15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("21754c4b-1477-4ef2-9f43-715211c166c4"), new Guid("f3207307-5799-4597-91bc-10b0f4f788d4") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("6b47cf74-690b-4ceb-9cb2-652428a1f633"), new Guid("a0f50f65-717f-4ebb-93ab-4c193ba87d65") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("7f3366b7-951d-4119-8483-c2734d4ce6a7"), new Guid("a87d42c9-1ac9-437f-9485-15ddd01f2ca5") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("ea6e9239-6052-4f0a-9776-bb0063bb71f4"), new Guid("fb5d95da-7045-4a6c-b3e4-da142ee676b5") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("f869e2ab-6007-47cf-9e35-ba5d176dc5ef"), new Guid("130b6119-b19d-4912-a045-38c5978408d8") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("21754c4b-1477-4ef2-9f43-715211c166c4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b47cf74-690b-4ceb-9cb2-652428a1f633"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7f3366b7-951d-4119-8483-c2734d4ce6a7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ea6e9239-6052-4f0a-9776-bb0063bb71f4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f869e2ab-6007-47cf-9e35-ba5d176dc5ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("130b6119-b19d-4912-a045-38c5978408d8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0f50f65-717f-4ebb-93ab-4c193ba87d65"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a87d42c9-1ac9-437f-9485-15ddd01f2ca5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3207307-5799-4597-91bc-10b0f4f788d4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fb5d95da-7045-4a6c-b3e4-da142ee676b5"));

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
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2d662d20-c01d-4db1-8fa5-365a4d2ec06d"), "Güzel soğutur, benim cesedi 10 gün sakladı", "arcelik.png", "Buz Dolabı", 100.00m },
                    { new Guid("384587a1-d04b-4a93-a214-1f2100745bd1"), "Duvara as, tablo diye izle", "lgtv.png", "LG nin incecik televizyonu", 100.00m },
                    { new Guid("66f6a0dc-df0b-4b74-bd83-387d6cef90df"), "Ciddi alıcılar", "mbook.png", "Temiz kullanılmış Macbook M1 Air", 20000.00m },
                    { new Guid("9cdcccd1-3566-4ff2-8b81-8dea75d05ac9"), "Hobi amaçlı matkap", "matkap.png", "Matkap", 100.00m },
                    { new Guid("b7da2e64-35d2-4309-8cd8-08d48456e7f7"), "Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar", "iphone.png", "Sahibinden temiz İphone", 10000.00m }
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "URL" },
                values: new object[,]
                {
                    { new Guid("21754c4b-1477-4ef2-9f43-715211c166c4"), "Bilgisayar", "bilgisayar" },
                    { new Guid("6b47cf74-690b-4ceb-9cb2-652428a1f633"), "Hobi", "telefon" },
                    { new Guid("7f3366b7-951d-4119-8483-c2734d4ce6a7"), "TV", "telefon" },
                    { new Guid("ea6e9239-6052-4f0a-9776-bb0063bb71f4"), "Beyaz Eşya", "telefon" },
                    { new Guid("f869e2ab-6007-47cf-9e35-ba5d176dc5ef"), "Telefon", "telefon" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("130b6119-b19d-4912-a045-38c5978408d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar", "iphone.png", "Sahibinden temiz İphone", 10000.00m },
                    { new Guid("a0f50f65-717f-4ebb-93ab-4c193ba87d65"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hobi amaçlı matkap", "matkap.png", "Matkap", 100.00m },
                    { new Guid("a87d42c9-1ac9-437f-9485-15ddd01f2ca5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duvara as, tablo diye izle", "lgtv.png", "LG nin incecik televizyonu", 100.00m },
                    { new Guid("f3207307-5799-4597-91bc-10b0f4f788d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciddi alıcılar", "mbook.png", "Temiz kullanılmış Macbook M1 Air", 20000.00m },
                    { new Guid("fb5d95da-7045-4a6c-b3e4-da142ee676b5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Güzel soğutur, benim cesedi 10 gün sakladı", "arcelik.png", "Buz Dolabı", 100.00m }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "Id" },
                values: new object[,]
                {
                    { new Guid("21754c4b-1477-4ef2-9f43-715211c166c4"), new Guid("f3207307-5799-4597-91bc-10b0f4f788d4"), new Guid("ad83faaa-bf9c-49ed-a405-7986605abfb2") },
                    { new Guid("6b47cf74-690b-4ceb-9cb2-652428a1f633"), new Guid("a0f50f65-717f-4ebb-93ab-4c193ba87d65"), new Guid("a66d2a58-d500-4cde-a1b3-daa07387d71d") },
                    { new Guid("7f3366b7-951d-4119-8483-c2734d4ce6a7"), new Guid("a87d42c9-1ac9-437f-9485-15ddd01f2ca5"), new Guid("3b4d9f6a-8aa8-4c93-a0a0-8148e366c31e") },
                    { new Guid("ea6e9239-6052-4f0a-9776-bb0063bb71f4"), new Guid("fb5d95da-7045-4a6c-b3e4-da142ee676b5"), new Guid("8fecbb50-8ff7-42b4-a290-4126212efdaa") },
                    { new Guid("f869e2ab-6007-47cf-9e35-ba5d176dc5ef"), new Guid("130b6119-b19d-4912-a045-38c5978408d8"), new Guid("e0328ef8-ed9d-4e16-95ab-bd8543d27b5d") }
                });
        }
    }
}
