using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            //        RoleEnum = Domain.Entities.Enum.RoleEnum.User,
            //        RoleName = Domain.Entities.Enum.RoleEnum.User.ToString()
            //    },
            //    new Role
            //    {
            //        Id = Guid.NewGuid(),
            //        RoleEnum = Domain.Entities.Enum.RoleEnum.Admin,
            //        RoleName = Domain.Entities.Enum.RoleEnum.Admin.ToString()
            //    });

            // modelBuilder.Entity<Country>().HasData(PopulateCounty());
        }

        public static List<Country> PopulateCounty()
        {
            var countries = new List<Country>();
            string path = @"C:\Countries.json";
            var content = System.IO.File.ReadAllText(path);

            foreach (var country in JsonConvert.DeserializeObject<List<JObject>>(content))
            {
                countries.Add(new Country
                {
                    Id = Guid.NewGuid(),
                    Name = country.Value<string>("name"),
                    RegionCode = country.Value<string>("alpha3code"),
                });
            }

            return countries;
        }
    }
}
