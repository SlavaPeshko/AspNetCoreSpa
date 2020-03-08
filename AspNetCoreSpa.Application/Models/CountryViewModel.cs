using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Application.Models
{
    public class CountryViewModel
    {
        public string CountryName { get; set; }
        public string CountryRegioneCode { get; set; }
    }

    public static class CountryViewModelExtensionMethods
    {
        public static CountryViewModel ToViewModel(this CountryDto country)
        {
            if (country == null) return null;

            return new CountryViewModel
            {
                CountryName = country.CountryName,
                CountryRegioneCode = country.RegionCode
            };
        }
    }
}
