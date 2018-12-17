namespace TestClient.WebApi.Models
{
    public class Client : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ClinetCode { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
