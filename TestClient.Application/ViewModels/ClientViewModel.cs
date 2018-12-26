using TestClient.Domain.Enities;

namespace TestClient.Application.ViewModels
{
    public class ClientViewModel
    {
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string CountryName { get; set; }
        public string CountryRegioneCode { get; set; }
    }

    public static class ExtensionMethods
    {
        public static ClientViewModel ToEntity(this Client client)
        {
            if (client == null) return null;

            return new ClientViewModel
            {
                ClientName = client.ClientName,
                ClientCode = client.ClinetCode,
            };
        }
    }
}
