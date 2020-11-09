namespace AspNetCoreSpa.Application.Models.Addresses
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }

        public int? CountryId { get; set; }
        public string CountryName { get; set; }
    }
}