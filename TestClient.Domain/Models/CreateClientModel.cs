namespace TestClient.Domain.Models
{
    public class CreateClientModel
    {
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryRegioneCode { get; set; }
    }
}
