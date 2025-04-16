using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_app.data.Migrations
{
    public partial class migration_v_0_0_9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b633bee4-f820-4e18-9dbe-f928d172a308"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("11be2cf2-56aa-4c65-b40f-126cfa86f985"), 0, "9fb3b54d-6edd-4db2-ab0f-18797782b9d3", "bataryadunyasi@gmail.com", false, false, null, "Batarya Dünyası", null, "BATARYADUNYASI", "13f8aa151a8bfcb071dd915abce080a19ef198b8298552eedc5ccc5a9d0a3e3e", null, false, null, false, "bataryadunyasi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("11be2cf2-56aa-4c65-b40f-126cfa86f985"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b633bee4-f820-4e18-9dbe-f928d172a308"), 0, "a06667f3-afe9-4a97-b05f-9bfe55017ed4", "bataryadunyasi@gmail.com", false, false, null, "Batarya Dünyası", null, "BATARYADUNYASI", "13f8aa151a8bfcb071dd915abce080a19ef198b8298552eedc5ccc5a9d0a3e3e", null, false, null, false, "bataryadunyasi" });
        }
    }
}
