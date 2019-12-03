using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSpa.Data.Migrations
{
    public partial class Add_ForegnKey_RoleClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Users_UserXref",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "UserXref",
                table: "Images",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_UserXref",
                table: "Images",
                newName: "IX_Images_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Images",
                newName: "UserXref");

            migrationBuilder.RenameIndex(
                name: "IX_Images_UserId",
                table: "Images",
                newName: "IX_Images_UserXref");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Users_UserXref",
                table: "Images",
                column: "UserXref",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
