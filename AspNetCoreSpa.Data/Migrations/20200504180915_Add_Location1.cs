using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace AspNetCoreSpa.Data.Migrations
{
    public partial class Add_Location1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Point>(
                name: "Position",
                table: "UserImage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "UserImage");
        }
    }
}
