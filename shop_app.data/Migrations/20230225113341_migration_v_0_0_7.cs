using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_app.data.Migrations
{
    public partial class migration_v_0_0_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

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

            migrationBuilder.AddColumn<Guid>(
                name: "SellerId",
                table: "Category",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("41abe068-fb60-4728-890c-90d91aa41ce8"), 0, "ed7621d1-6d41-4306-beab-8a20a07f4e25", "bataryadunyasi@gmail.com", false, false, null, "Batarya Dünyası", null, "BATARYADUNYASI", "13f8aa151a8bfcb071dd915abce080a19ef198b8298552eedc5ccc5a9d0a3e3e", null, false, null, false, "bataryadunyasi" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_SellerId",
                table: "Category",
                column: "SellerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AspNetUsers_SellerId",
                table: "Category",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_AspNetUsers_SellerId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropIndex(
                name: "IX_Category_SellerId",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("41abe068-fb60-4728-890c-90d91aa41ce8"));

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Category");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "Created", "Description", "Name", "Price", "SellerId", "Uri" },
                values: new object[,]
                {
                    { new Guid("0e45eb73-3656-49f5-b693-bce9064a97c9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar", "Sahibinden temiz İphone", 10000.00m, new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), "bef371bd-b267-4a3e-983e-c1aa467ba300" },
                    { new Guid("183a1e3d-7c2d-47c1-bd74-aa2b4296db40"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hobi amaçlı matkap", "Matkap", 100.00m, new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), "46d2ef77-4003-4d56-ad7d-31da8be18e0b" },
                    { new Guid("692469d0-19d9-4fbb-8cb5-72ca30c016d1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciddi alıcılar", "Temiz kullanılmış Macbook M1 Air", 20000.00m, new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), "cfdb0719-57ff-4c7c-8fed-1e65747dc4b2" },
                    { new Guid("781e93ba-34d9-4cb4-a367-eb363a56fbba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Güzel soğutur, benim cesedi 10 gün sakladı", "Buz Dolabı", 100.00m, new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), "574a0e28-9447-4e3c-b8e7-b0f43af32e61" },
                    { new Guid("a1bfa642-119c-4b22-a510-43b694c7eefa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duvara as, tablo diye izle", "LG nin incecik televizyonu", 100.00m, new Guid("3988518e-2f7f-45e9-8f40-cd9b6693ea52"), "ec4173d3-97a5-46f2-a012-5684101a7cc9" }
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

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");
        }
    }
}
