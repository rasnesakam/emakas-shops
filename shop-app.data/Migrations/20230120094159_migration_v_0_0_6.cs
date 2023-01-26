using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_app.data.Migrations
{
    public partial class migration_v_0_0_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("0904d749-5e8f-490d-8003-a013b8461c7a"), new Guid("52003a5f-1a5e-4ff9-8e33-cf00658dd8a7") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("92b4992d-b794-44ba-9206-9b6651411a5d"), new Guid("7aeb3920-57ed-435a-908e-574f1ef3f7d5") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("b48f8a7e-a348-417e-87e7-8463c596ff17"), new Guid("7edfebff-d14a-4494-a1ce-28b49103a804") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("dc134571-ed2e-484c-ada7-28953ef21544"), new Guid("2fe4bc88-1cdc-4c0f-b13a-a47d98f9abc9") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("df2a9610-bf10-4851-ada3-0c4e92f9028b"), new Guid("1e8c107a-dc0e-42ae-97e6-ec08b61fce73") });

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("15411684-1347-4994-a4da-8b12d03b8e72"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("1c3bb973-4800-496e-8d3f-911f016c0651"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("49d81000-c432-4c08-8bfa-73298a05f986"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("bb14538a-3ad4-433d-8552-0ba67b056e66"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("ec3a8c30-bcd0-40da-9eb1-17b278ec24b2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("0904d749-5e8f-490d-8003-a013b8461c7a"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("92b4992d-b794-44ba-9206-9b6651411a5d"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b48f8a7e-a348-417e-87e7-8463c596ff17"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("dc134571-ed2e-484c-ada7-28953ef21544"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("df2a9610-bf10-4851-ada3-0c4e92f9028b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1e8c107a-dc0e-42ae-97e6-ec08b61fce73"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("2fe4bc88-1cdc-4c0f-b13a-a47d98f9abc9"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("52003a5f-1a5e-4ff9-8e33-cf00658dd8a7"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("7aeb3920-57ed-435a-908e-574f1ef3f7d5"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("7edfebff-d14a-4494-a1ce-28b49103a804"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("12a671ec-12b8-45f0-9953-dcddb3180588"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Order",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Order",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "SellerNote",
                table: "Order",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerNote",
                table: "Order",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Order",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Temporary",
                table: "Customer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), 0, "f6c2ec2d-b1b7-4327-ba39-bb0df2bc8449", "bataryadunyasi@gmail.com", false, false, null, "Batarya Dünyası", null, "BATARYADUNYASI", "13f8aa151a8bfcb071dd915abce080a19ef198b8298552eedc5ccc5a9d0a3e3e", null, false, null, false, "bataryadunyasi" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "URI" },
                values: new object[,]
                {
                    { new Guid("2226de31-63bc-40d4-89cd-0baa5e7fd099"), "Telefon", "telefon" },
                    { new Guid("492f9f83-2a90-426b-82bd-b75a587a0351"), "Beyaz Eşya", "beyaz-esya" },
                    { new Guid("87bc9408-e860-474c-ae51-026320645825"), "TV", "tv" },
                    { new Guid("a7573984-701e-498e-8dda-181dd0d5ea06"), "Hobi", "hobi" },
                    { new Guid("d5fb8c9c-ec25-4ff5-b717-20d846e63c93"), "Bilgisayar", "bilgisayar" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name", "Price", "SellerId", "Uri" },
                values: new object[,]
                {
                    { new Guid("0e45eb73-3656-49f5-b693-bce9064a97c9"), "Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar", "Sahibinden temiz İphone", 10000.00m, new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), "bef371bd-b267-4a3e-983e-c1aa467ba300" },
                    { new Guid("183a1e3d-7c2d-47c1-bd74-aa2b4296db40"), "Hobi amaçlı matkap", "Matkap", 100.00m, new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), "46d2ef77-4003-4d56-ad7d-31da8be18e0b" },
                    { new Guid("692469d0-19d9-4fbb-8cb5-72ca30c016d1"), "Ciddi alıcılar", "Temiz kullanılmış Macbook M1 Air", 20000.00m, new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), "cfdb0719-57ff-4c7c-8fed-1e65747dc4b2" },
                    { new Guid("781e93ba-34d9-4cb4-a367-eb363a56fbba"), "Güzel soğutur, benim cesedi 10 gün sakladı", "Buz Dolabı", 100.00m, new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), "574a0e28-9447-4e3c-b8e7-b0f43af32e61" },
                    { new Guid("a1bfa642-119c-4b22-a510-43b694c7eefa"), "Duvara as, tablo diye izle", "LG nin incecik televizyonu", 100.00m, new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), "ec4173d3-97a5-46f2-a012-5684101a7cc9" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "Id" },
                values: new object[,]
                {
                    { new Guid("2226de31-63bc-40d4-89cd-0baa5e7fd099"), new Guid("0e45eb73-3656-49f5-b693-bce9064a97c9"), new Guid("0e0ddb64-fb0d-4c6c-bd47-8f571e4dbed9") },
                    { new Guid("492f9f83-2a90-426b-82bd-b75a587a0351"), new Guid("781e93ba-34d9-4cb4-a367-eb363a56fbba"), new Guid("e4c65299-978f-4273-91c4-d7b6f49a03b8") },
                    { new Guid("87bc9408-e860-474c-ae51-026320645825"), new Guid("a1bfa642-119c-4b22-a510-43b694c7eefa"), new Guid("9adb7028-f3b3-4fec-86d0-1d9766befe58") },
                    { new Guid("a7573984-701e-498e-8dda-181dd0d5ea06"), new Guid("183a1e3d-7c2d-47c1-bd74-aa2b4296db40"), new Guid("bf2310d4-27ec-48d8-ac4a-8bda5c5e4402") },
                    { new Guid("d5fb8c9c-ec25-4ff5-b717-20d846e63c93"), new Guid("692469d0-19d9-4fbb-8cb5-72ca30c016d1"), new Guid("3a5eb4b2-7108-40ec-a3c7-604909c68727") }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "AltText", "FileUri", "ProductId" },
                values: new object[,]
                {
                    { new Guid("005012e8-cb77-4e9c-9218-bbdb23cda966"), "buz dolabı", "front.png", new Guid("781e93ba-34d9-4cb4-a367-eb363a56fbba") },
                    { new Guid("0de3df23-6474-4bb7-bda4-6eb8d07a10a9"), "macbook m1", "front.png", new Guid("692469d0-19d9-4fbb-8cb5-72ca30c016d1") },
                    { new Guid("38821c7e-565b-4e05-a919-4622a41861a4"), "matkap", "front.png", new Guid("183a1e3d-7c2d-47c1-bd74-aa2b4296db40") },
                    { new Guid("caa49102-b554-4bb7-9061-d86a9deb0ae5"), "televizyon", "front.png", new Guid("a1bfa642-119c-4b22-a510-43b694c7eefa") },
                    { new Guid("d16690df-0e77-4a1a-9b54-046d366ff296"), "iphone", "front.png", new Guid("0e45eb73-3656-49f5-b693-bce9064a97c9") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("2226de31-63bc-40d4-89cd-0baa5e7fd099"), new Guid("0e45eb73-3656-49f5-b693-bce9064a97c9") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("492f9f83-2a90-426b-82bd-b75a587a0351"), new Guid("781e93ba-34d9-4cb4-a367-eb363a56fbba") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("87bc9408-e860-474c-ae51-026320645825"), new Guid("a1bfa642-119c-4b22-a510-43b694c7eefa") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("a7573984-701e-498e-8dda-181dd0d5ea06"), new Guid("183a1e3d-7c2d-47c1-bd74-aa2b4296db40") });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("d5fb8c9c-ec25-4ff5-b717-20d846e63c93"), new Guid("692469d0-19d9-4fbb-8cb5-72ca30c016d1") });

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("005012e8-cb77-4e9c-9218-bbdb23cda966"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("0de3df23-6474-4bb7-bda4-6eb8d07a10a9"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("38821c7e-565b-4e05-a919-4622a41861a4"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("caa49102-b554-4bb7-9061-d86a9deb0ae5"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("d16690df-0e77-4a1a-9b54-046d366ff296"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2226de31-63bc-40d4-89cd-0baa5e7fd099"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("492f9f83-2a90-426b-82bd-b75a587a0351"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("87bc9408-e860-474c-ae51-026320645825"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a7573984-701e-498e-8dda-181dd0d5ea06"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d5fb8c9c-ec25-4ff5-b717-20d846e63c93"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("0e45eb73-3656-49f5-b693-bce9064a97c9"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("183a1e3d-7c2d-47c1-bd74-aa2b4296db40"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("692469d0-19d9-4fbb-8cb5-72ca30c016d1"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("781e93ba-34d9-4cb4-a367-eb363a56fbba"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("a1bfa642-119c-4b22-a510-43b694c7eefa"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"));

            migrationBuilder.DropColumn(
                name: "Temporary",
                table: "Customer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Order",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Order",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "SellerNote",
                table: "Order",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerNote",
                table: "Order",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Order",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("12a671ec-12b8-45f0-9953-dcddb3180588"), 0, "1ba39c01-5457-4444-9a84-dd41e797db2f", "bataryadunyasi@gmail.com", false, false, null, "Batarya Dünyası", null, "BATARYADUNYASI", "13f8aa151a8bfcb071dd915abce080a19ef198b8298552eedc5ccc5a9d0a3e3e", null, false, null, false, "bataryadunyasi" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "URI" },
                values: new object[,]
                {
                    { new Guid("0904d749-5e8f-490d-8003-a013b8461c7a"), "TV", "tv" },
                    { new Guid("92b4992d-b794-44ba-9206-9b6651411a5d"), "Bilgisayar", "bilgisayar" },
                    { new Guid("b48f8a7e-a348-417e-87e7-8463c596ff17"), "Beyaz Eşya", "beyaz-esya" },
                    { new Guid("dc134571-ed2e-484c-ada7-28953ef21544"), "Hobi", "hobi" },
                    { new Guid("df2a9610-bf10-4851-ada3-0c4e92f9028b"), "Telefon", "telefon" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Created", "Description", "Name", "Price", "SellerId", "Uri" },
                values: new object[,]
                {
                    { new Guid("1e8c107a-dc0e-42ae-97e6-ec08b61fce73"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar", "Sahibinden temiz İphone", 10000.00m, new Guid("12a671ec-12b8-45f0-9953-dcddb3180588"), "19a5cc4a-7b21-4040-a76e-9f949a6fb42b" },
                    { new Guid("2fe4bc88-1cdc-4c0f-b13a-a47d98f9abc9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hobi amaçlı matkap", "Matkap", 100.00m, new Guid("12a671ec-12b8-45f0-9953-dcddb3180588"), "13765236-64af-49b8-866e-14f19c19b3d1" },
                    { new Guid("52003a5f-1a5e-4ff9-8e33-cf00658dd8a7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duvara as, tablo diye izle", "LG nin incecik televizyonu", 100.00m, new Guid("12a671ec-12b8-45f0-9953-dcddb3180588"), "44e4a16a-f58a-445f-89a8-dc7d7a3c9489" },
                    { new Guid("7aeb3920-57ed-435a-908e-574f1ef3f7d5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciddi alıcılar", "Temiz kullanılmış Macbook M1 Air", 20000.00m, new Guid("12a671ec-12b8-45f0-9953-dcddb3180588"), "f079b892-cd67-4f65-adcb-e21750e97af3" },
                    { new Guid("7edfebff-d14a-4494-a1ce-28b49103a804"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Güzel soğutur, benim cesedi 10 gün sakladı", "Buz Dolabı", 100.00m, new Guid("12a671ec-12b8-45f0-9953-dcddb3180588"), "c4255da3-3341-4285-a454-2bc2db04d335" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId", "Id" },
                values: new object[,]
                {
                    { new Guid("0904d749-5e8f-490d-8003-a013b8461c7a"), new Guid("52003a5f-1a5e-4ff9-8e33-cf00658dd8a7"), new Guid("30f4d949-bf18-4b03-bbbf-96e9b1a62cc2") },
                    { new Guid("92b4992d-b794-44ba-9206-9b6651411a5d"), new Guid("7aeb3920-57ed-435a-908e-574f1ef3f7d5"), new Guid("7d531fe4-1895-4b83-8fb3-1e7cdcaf4f96") },
                    { new Guid("b48f8a7e-a348-417e-87e7-8463c596ff17"), new Guid("7edfebff-d14a-4494-a1ce-28b49103a804"), new Guid("9b218fe8-a550-49bc-9b10-3acaa25a395c") },
                    { new Guid("dc134571-ed2e-484c-ada7-28953ef21544"), new Guid("2fe4bc88-1cdc-4c0f-b13a-a47d98f9abc9"), new Guid("2e5cbc3a-97a4-49fa-980f-1cfba41c69f0") },
                    { new Guid("df2a9610-bf10-4851-ada3-0c4e92f9028b"), new Guid("1e8c107a-dc0e-42ae-97e6-ec08b61fce73"), new Guid("f38f4f8b-bea7-4607-a0d7-fd30bdd345d6") }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "AltText", "FileUri", "ProductId" },
                values: new object[,]
                {
                    { new Guid("15411684-1347-4994-a4da-8b12d03b8e72"), "matkap", "front.png", new Guid("2fe4bc88-1cdc-4c0f-b13a-a47d98f9abc9") },
                    { new Guid("1c3bb973-4800-496e-8d3f-911f016c0651"), "macbook m1", "front.png", new Guid("7aeb3920-57ed-435a-908e-574f1ef3f7d5") },
                    { new Guid("49d81000-c432-4c08-8bfa-73298a05f986"), "televizyon", "front.png", new Guid("52003a5f-1a5e-4ff9-8e33-cf00658dd8a7") },
                    { new Guid("bb14538a-3ad4-433d-8552-0ba67b056e66"), "iphone", "front.png", new Guid("1e8c107a-dc0e-42ae-97e6-ec08b61fce73") },
                    { new Guid("ec3a8c30-bcd0-40da-9eb1-17b278ec24b2"), "buz dolabı", "front.png", new Guid("7edfebff-d14a-4494-a1ce-28b49103a804") }
                });
        }
    }
}
