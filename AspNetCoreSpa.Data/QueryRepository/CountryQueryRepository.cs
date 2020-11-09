using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Data.QueryRepository.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreSpa.Data.QueryRepository
{
    public class CountryQueryRepository : QueryRepositoryBase, ICountryQueryRepository
    {
        public CountryQueryRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
        {
            using (var connection = Connection)
            {
                var query = @"SELECT [Id], [Name], [RegionCode]
                    FROM [AspNetCoreSpa].[dbo].[Countries] ORDER BY [Name]";

                return await connection.QueryAsync<CountryDto>(query);
            }
        }
    }
}