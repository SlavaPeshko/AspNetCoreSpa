using System;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Application.Models
{
    public class CountryViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string RegioneCode { get; set; }
    }

    public static class CountryViewModelExtensionMethods
    {
        public static CountryViewModel ToViewModel(this CountryDto country)
        {
            if (country == null) return null;

            return new CountryViewModel
            {
                Id = country.Id,
                Name = country.Name,
                RegioneCode = country.RegionCode
            };
        }
    }
}
