﻿// <auto-generated />
using System;
using AspNetCoreSpa.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCoreSpa.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191203184413_Add_ForegnKey_RoleClaims")]
    partial class Add_ForegnKey_RoleClaims
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("RegioneCode")
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsLike")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.RoleClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Security.SecurityCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("CodeActionType")
                        .HasColumnType("int");

                    b.Property<string>("Provider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProviderType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SecurityCodes");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("XrefUserRole");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Comment", b =>
                {
                    b.HasOne("AspNetCoreSpa.Domain.Enities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("AspNetCoreSpa.Domain.Enities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Image", b =>
                {
                    b.HasOne("AspNetCoreSpa.Domain.Enities.Post", "Post")
                        .WithMany("Images")
                        .HasForeignKey("PostId");

                    b.HasOne("AspNetCoreSpa.Domain.Enities.User", "User")
                        .WithOne("Image")
                        .HasForeignKey("AspNetCoreSpa.Domain.Enities.Image", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Like", b =>
                {
                    b.HasOne("AspNetCoreSpa.Domain.Enities.Comment", "Comment")
                        .WithMany("Likes")
                        .HasForeignKey("CommentId");

                    b.HasOne("AspNetCoreSpa.Domain.Enities.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId");

                    b.HasOne("AspNetCoreSpa.Domain.Enities.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.Post", b =>
                {
                    b.HasOne("AspNetCoreSpa.Domain.Enities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.RoleClaim", b =>
                {
                    b.HasOne("AspNetCoreSpa.Domain.Enities.Role", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.User", b =>
                {
                    b.HasOne("AspNetCoreSpa.Domain.Enities.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("AspNetCoreSpa.Domain.Enities.UserRole", b =>
                {
                    b.HasOne("AspNetCoreSpa.Domain.Enities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCoreSpa.Domain.Enities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
