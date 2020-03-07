using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSpa.Data.Migrations
{
    public partial class Add_RoleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("28524d58-4ddc-4fbc-a475-fedf2d0bbb63"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a91cbc7e-a2b5-454a-bce6-3dff1dde8ff3"));

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Roles",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Roles");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnum" },
                values: new object[] { new Guid("28524d58-4ddc-4fbc-a475-fedf2d0bbb63"), 0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleEnum" },
                values: new object[] { new Guid("a91cbc7e-a2b5-454a-bce6-3dff1dde8ff3"), 1 });
        }
    }
}
