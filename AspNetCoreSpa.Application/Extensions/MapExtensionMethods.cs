using AspNetCoreSpa.Application.Models.Countries;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Application.Extensions
{
    public static class MapExtensionMethods
    {
        public static CountryViewModel ToViewModel(this CountryDto country)
        {
            if (country == null) return null;

            return new CountryViewModel
            {
                Id = country.Id,
                Name = country.Name,
                RegionCode = country.RegionCode
            };
        }
    }
}