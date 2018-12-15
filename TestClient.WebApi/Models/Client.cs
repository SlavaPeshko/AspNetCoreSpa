namespace TestClient.WebApi.Models
{
    public class Client : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public Country Country { get; set; }
    }
}
