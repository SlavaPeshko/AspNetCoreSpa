using System.Collections.Generic;

namespace TestClient.WebApi.Models
{
    public class Country : BaseEntity<int>
    {
        public string CountryRegioneCode { get; set; }
        public string CountryName { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
