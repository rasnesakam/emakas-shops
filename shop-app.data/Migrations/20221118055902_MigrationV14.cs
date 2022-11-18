using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopapp.data.Migrations
{
    public partial class MigrationV14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Categories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("130b6119-b19d-4912-a045-38c5978408d8"), "Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar", "iphone.png", "Sahibinden temiz İphone", 10000.00m },
                    { new Guid("a0f50f65-717f-4ebb-93ab-4c193ba87d65"), "Hobi amaçlı matkap", "matkap.png", "Matkap", 100.00m },
                    { new Guid("a87d42c9-1ac9-437f-9485-15ddd01f2ca5"), "Duvara as, tablo diye izle", "lgtv.png", "LG nin incecik televizyonu", 100.00m },
                    { new Guid("f3207307-5799-4597-91bc-10b0f4f788d4"), "Ciddi alıcılar", "mbook.png", "Temiz kullanılmış Macbook M1 Air", 20000.00m },
                    { new Guid("fb5d95da-7045-4a6c-b3e4-da142ee676b5"), "Güzel soğutur, benim cesedi 10 gün sakladı", "arcelik.png", "Buz Dolabı", 100.00m }
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
