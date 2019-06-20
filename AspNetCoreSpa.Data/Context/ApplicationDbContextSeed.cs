using System;
using Microsoft.EntityFrameworkCore;
using AspNetCoreSpa.Domain.Enities;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AspNetCoreSpa.Domain.Enities.Enum;

namespace AspNetCoreSpa.Data.Context
{
    public static class AspNetCoreSpaContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Role>()
            //    .HasData(new Role
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = RoleEnum.User.ToString()
            //    },
            //    new Role
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = RoleEnum.Admin.ToString()
            //    });

            // modelBuilder.Entity<Country>().HasData(PopulateCounty());
        }

        public static List<Country> PopulateCounty()
        {
            var countries = new List<Country>();
            string path = @"C:\slim-3.json";
            var content = System.IO.File.ReadAllText(path);

            foreach (var country in JsonConvert.DeserializeObject<List<JObject>>(content))
            {
                countries.Add(new Country
                {
                    Id = Guid.NewGuid(),
                    Name = country.Value<string>("name"),
                    RegioneCode = country.Value<string>("alpha-3"),
                });
            }

            return countries;
        }
    }
}
