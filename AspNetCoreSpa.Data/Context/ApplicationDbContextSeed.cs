using Microsoft.EntityFrameworkCore;
using AspNetCoreSpa.Domain.Enities;

namespace AspNetCoreSpa.Data.Context
{
    public static class AspNetCoreSpaContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasData(
                    new Country
                    {
                        CountryRegioneCode = "BY",
                        CountryName = "Belarus",
                    },
                    new Country
                    {
                        CountryRegioneCode = "GB",
                        CountryName = "United Kingdom",
                    }
                );

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        UserCode = "A1001",
                        CountryId = 1
                    },
                    new User
                    {
                        UserCode = "M1002",
                        CountryId = 2
                    }
                );
        }
    }
}
