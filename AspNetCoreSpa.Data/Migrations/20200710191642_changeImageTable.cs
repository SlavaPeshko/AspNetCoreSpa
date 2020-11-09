using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace AspNetCoreSpa.Data.Migrations
{
    public partial class changeImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Images_Posts_PostId",
                "Images");

            migrationBuilder.DropTable(
                "UserImage");

            migrationBuilder.DropColumn(
                "Name",
                "Images");

            migrationBuilder.AlterColumn<int>(
                "PostId",
                "Images",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                "OriginalName",
                "Images",
                nullable: true);

            migrationBuilder.AddColumn<Point>(
                "Position",
                "Images",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "UserId",
                "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Images_UserId",
                "Images",
                "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                "FK_Images_Posts_PostId",
                "Images",
                "PostId",
                "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Images_Users_UserId",
                "Images",
                "UserId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Images_Posts_PostId",
                "Images");

            migrationBuilder.DropForeignKey(
                "FK_Images_Users_UserId",
                "Images");

            migrationBuilder.DropIndex(
                "IX_Images_UserId",
                "Images");

            migrationBuilder.DropColumn(
                "OriginalName",
                "Images");

            migrationBuilder.DropColumn(
                "Position",
                "Images");

            migrationBuilder.DropColumn(
                "UserId",
                "Images");

            migrationBuilder.AlterColumn<int>(
                "PostId",
                "Images",
                "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                "Name",
                "Images",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                "UserImage",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalImagePath = table.Column<string>("nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>("nvarchar(max)", nullable: true),
                    Position = table.Column<Point>("geography", nullable: true),
                    ProfileImagePath = table.Column<string>("nvarchar(max)", nullable: true),
                    UserId = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImage", x => x.Id);
                    table.ForeignKey(
                        "FK_UserImage_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_UserImage_UserId",
                "UserImage",
                "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                "FK_Images_Posts_PostId",
                "Images",
                "PostId",
                "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}