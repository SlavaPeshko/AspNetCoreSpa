using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace AspNetCoreSpa.Data.Migrations
{
    public partial class changeImageTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Images");

            migrationBuilder.CreateTable(
                "PostImages",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalName = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.Id);
                    table.ForeignKey(
                        "FK_PostImages_Posts_PostId",
                        x => x.PostId,
                        "Posts",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserPhotos",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalName = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotos", x => x.Id);
                    table.ForeignKey(
                        "FK_UserPhotos_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_PostImages_PostId",
                "PostImages",
                "PostId");

            migrationBuilder.CreateIndex(
                "IX_UserPhotos_UserId",
                "UserPhotos",
                "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "PostImages");

            migrationBuilder.DropTable(
                "UserPhotos");

            migrationBuilder.CreateTable(
                "Images",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalName = table.Column<string>("nvarchar(max)", nullable: true),
                    Path = table.Column<string>("nvarchar(max)", nullable: true),
                    Position = table.Column<Point>("geography", nullable: true),
                    PostId = table.Column<int>("int", nullable: true),
                    UserId = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        "FK_Images_Posts_PostId",
                        x => x.PostId,
                        "Posts",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Images_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Images_PostId",
                "Images",
                "PostId");

            migrationBuilder.CreateIndex(
                "IX_Images_UserId",
                "Images",
                "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}