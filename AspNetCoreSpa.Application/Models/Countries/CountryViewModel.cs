using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Application.Models.Countries
{
    public class CountryViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string RegionCode { get; set; }
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
                RegionCode = country.RegionCode
            };
        }
    }
}