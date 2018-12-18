using TestClient.Domain.Enities.Base;

namespace TestClient.Domain.Enities
{
    public class Client : BaseEntity<int>
    {
        public string ClientName { get; set; }
        public string ClinetCode { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
