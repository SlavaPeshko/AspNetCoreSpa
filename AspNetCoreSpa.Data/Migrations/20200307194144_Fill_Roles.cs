using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSpa.Data.Migrations
{
    public partial class Fill_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnum", "RoleName" },
                values: new object[] { new Guid("8ede10e9-4443-47a9-b342-e58b485d461f"), 0, "User" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnum", "RoleName" },
                values: new object[] { new Guid("ad45d8db-07f6-4b03-adb9-169c21e8682d"), 1, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8ede10e9-4443-47a9-b342-e58b485d461f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ad45d8db-07f6-4b03-adb9-169c21e8682d"));
        }
    }
}
