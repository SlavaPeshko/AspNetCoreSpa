using System.Collections.Generic;
using TestClient.Domain.Enities.Base;

namespace TestClient.Domain.Enities
{
    public class Country : BaseEntity<int>
    {
        public string CountryRegioneCode { get; set; }
        public string CountryName { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
