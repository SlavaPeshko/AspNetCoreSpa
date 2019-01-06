using TestClient.Domain.Enities;

namespace TestClient.Application.ViewModels
{
    public class CountryViewModel
    {
        public int Id { get; set; }
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
