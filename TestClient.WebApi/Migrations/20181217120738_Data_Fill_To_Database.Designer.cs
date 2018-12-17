﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestClient.WebApi.Context;

namespace TestClient.WebApi.Migrations
{
    [DbContext(typeof(TestClientContext))]
    [Migration("20181217120738_Data_Fill_To_Database")]
    partial class Data_Fill_To_Database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestClient.WebApi.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientName");

                    b.Property<string>("ClinetCode")
                        .HasColumnType("varchar(5)");

                    b.Property<int>("CountryId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientName = "Alan",
                            ClinetCode = "A1001",
                            CountryId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClientName = "Mark",
                            ClinetCode = "M1002",
                            CountryId = 2
                        });
                });

            modelBuilder.Entity("TestClient.WebApi.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName");

                    b.Property<string>("CountryRegioneCode")
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryName = "Belarus",
                            CountryRegioneCode = "BY"
                        },
                        new
                        {
                            Id = 2,
                            CountryName = "United Kingdom",
                            CountryRegioneCode = "GB"
                        });
                });

            modelBuilder.Entity("TestClient.WebApi.Models.Client", b =>
                {
                    b.HasOne("TestClient.WebApi.Models.Country", "Country")
                        .WithMany("Clients")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
