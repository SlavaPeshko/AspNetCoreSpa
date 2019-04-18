using System;
using AspNetCoreSpa.Domain.Enities;

namespace AspNetCoreSpa.Application.Models
{
    public class CountryViewModel
    {
        public Guid Id { get; set; }
        public string CountryName { get; set; }
        public string CountryRegioneCode { get; set; }
    }

    public static class CountryViewModelExtensionMethods
    {
        public static CountryViewModel ToViewModel(this Country country)
        {
            if (country == null) return null;

            return new CountryViewModel
            {
                Id = country.Id,
                CountryName = country.CountryName,
                CountryRegioneCode = country.CountryRegioneCode
            };
        }
    }
}
