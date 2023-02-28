using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_app.data.Migrations
{
    public partial class migration_v_0_0_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Category_SellerId",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("41abe068-fb60-4728-890c-90d91aa41ce8"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b633bee4-f820-4e18-9dbe-f928d172a308"), 0, "a06667f3-afe9-4a97-b05f-9bfe55017ed4", "bataryadunyasi@gmail.com", false, false, null, "Batarya Dünyası", null, "BATARYADUNYASI", "13f8aa151a8bfcb071dd915abce080a19ef198b8298552eedc5ccc5a9d0a3e3e", null, false, null, false, "bataryadunyasi" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_SellerId",
                table: "Category",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Category_SellerId",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b633bee4-f820-4e18-9dbe-f928d172a308"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("41abe068-fb60-4728-890c-90d91aa41ce8"), 0, "ed7621d1-6d41-4306-beab-8a20a07f4e25", "bataryadunyasi@gmail.com", false, false, null, "Batarya Dünyası", null, "BATARYADUNYASI", "13f8aa151a8bfcb071dd915abce080a19ef198b8298552eedc5ccc5a9d0a3e3e", null, false, null, false, "bataryadunyasi" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_SellerId",
                table: "Category",
                column: "SellerId",
                unique: true);
        }
    }
}
