using Microsoft.EntityFrameworkCore.Migrations;

namespace TestClient.Data.Migrations
{
    public partial class Data_Fill_To_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName", "CountryRegioneCode" },
                values: new object[] { 1, "Belarus", "BY" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName", "CountryRegioneCode" },
                values: new object[] { 2, "United Kingdom", "GB" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientName", "ClinetCode", "CountryId" },
                values: new object[] { 1, "Alan", "A1001", 1 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientName", "ClinetCode", "CountryId" },
                values: new object[] { 2, "Mark", "M1002", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
