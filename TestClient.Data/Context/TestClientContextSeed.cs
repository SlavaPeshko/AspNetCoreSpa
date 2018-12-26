﻿using Microsoft.EntityFrameworkCore;
using TestClient.Domain.Enities;

namespace TestClient.Data.Context
{
    public static class TestClientContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasData(
                    new Country
                    {
                        Id = 1,
                        CountryRegioneCode = "BY",
                        CountryName = "Belarus",
                    },
                    new Country
                    {
                        Id = 2,
                        CountryRegioneCode = "GB",
                        CountryName = "United Kingdom",
                    }
                );

            modelBuilder.Entity<Client>()
                .HasData(
                    new Client
                    {
                        Id = 1,
                        ClientName = "Alan",
                        ClinetCode = "A1001",
                        CountryId = 1
                    },
                    new Client
                    {
                        Id = 2,
                        ClientName = "Mark",
                        ClinetCode = "M1002",
                        CountryId = 2
                    }
                );
        }
    }
}