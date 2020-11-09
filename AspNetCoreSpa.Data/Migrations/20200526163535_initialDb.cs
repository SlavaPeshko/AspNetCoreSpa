using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace AspNetCoreSpa.Data.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AddressType",
                table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AddressType", x => x.Id); });

            migrationBuilder.CreateTable(
                "Countries",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(60)", nullable: true),
                    RegionCode = table.Column<string>("nvarchar(3)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Countries", x => x.Id); });

            migrationBuilder.CreateTable(
                "Roles",
                table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

            migrationBuilder.CreateTable(
                "SecurityCodes",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderType = table.Column<int>(nullable: false),
                    Provider = table.Column<string>(nullable: true),
                    Code = table.Column<string>("nvarchar(6)", nullable: true),
                    CodeActionType = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_SecurityCodes", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>("nvarchar(100)", nullable: true),
                    LastName = table.Column<string>("nvarchar(100)", nullable: true),
                    Email = table.Column<string>("nvarchar(100)", nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>("nvarchar(450)", nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "Addresses",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        "FK_Addresses_Countries_CountryId",
                        x => x.CountryId,
                        "Countries",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "RoleClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_RoleClaims_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Posts",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        "FK_Posts_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "UserImage",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalName = table.Column<string>(nullable: true),
                    OriginalImagePath = table.Column<string>(nullable: true),
                    ProfileImagePath = table.Column<string>(nullable: true),
                    Position = table.Column<Point>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                "XrefUserRole",
                table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XrefUserRole", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_XrefUserRole_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_XrefUserRole_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "XreUserAddress",
                table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    AddressTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XreUserAddress", x => new {x.UserId, x.AddressId});
                    table.ForeignKey(
                        "FK_XreUserAddress_Addresses_AddressId",
                        x => x.AddressId,
                        "Addresses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_XreUserAddress_AddressType_AddressTypeId",
                        x => x.AddressTypeId,
                        "AddressType",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_XreUserAddress_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Comments",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        "FK_Comments_Posts_PostId",
                        x => x.PostId,
                        "Posts",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Comments_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Images",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        "FK_Images_Posts_PostId",
                        x => x.PostId,
                        "Posts",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Likes",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLike = table.Column<bool>(nullable: false),
                    CommentId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        "FK_Likes_Comments_CommentId",
                        x => x.CommentId,
                        "Comments",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Likes_Posts_PostId",
                        x => x.PostId,
                        "Posts",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Likes_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Addresses_CountryId",
                "Addresses",
                "CountryId");

            migrationBuilder.CreateIndex(
                "IX_Comments_PostId",
                "Comments",
                "PostId");

            migrationBuilder.CreateIndex(
                "IX_Comments_UserId",
                "Comments",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_Images_PostId",
                "Images",
                "PostId");

            migrationBuilder.CreateIndex(
                "IX_Likes_CommentId",
                "Likes",
                "CommentId");

            migrationBuilder.CreateIndex(
                "IX_Likes_PostId",
                "Likes",
                "PostId");

            migrationBuilder.CreateIndex(
                "IX_Likes_UserId",
                "Likes",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_Posts_UserId",
                "Posts",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_RoleClaims_RoleId",
                "RoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_UserImage_UserId",
                "UserImage",
                "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Users_Email",
                "Users",
                "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_Users_PhoneNumber",
                "Users",
                "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_XrefUserRole_RoleId",
                "XrefUserRole",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_XreUserAddress_AddressId",
                "XreUserAddress",
                "AddressId");

            migrationBuilder.CreateIndex(
                "IX_XreUserAddress_AddressTypeId",
                "XreUserAddress",
                "AddressTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Images");

            migrationBuilder.DropTable(
                "Likes");

            migrationBuilder.DropTable(
                "RoleClaims");

            migrationBuilder.DropTable(
                "SecurityCodes");

            migrationBuilder.DropTable(
                "UserImage");

            migrationBuilder.DropTable(
                "XrefUserRole");

            migrationBuilder.DropTable(
                "XreUserAddress");

            migrationBuilder.DropTable(
                "Comments");

            migrationBuilder.DropTable(
                "Roles");

            migrationBuilder.DropTable(
                "Addresses");

            migrationBuilder.DropTable(
                "AddressType");

            migrationBuilder.DropTable(
                "Posts");

            migrationBuilder.DropTable(
                "Countries");

            migrationBuilder.DropTable(
                "Users");
        }
    }
}