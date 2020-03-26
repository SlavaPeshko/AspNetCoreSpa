using System;

namespace AspNetCoreSpa.Contracts.QueryRepositories.Dto
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RegionCode { get; set; }
    }
}
