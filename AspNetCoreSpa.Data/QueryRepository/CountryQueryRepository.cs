using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Data.QueryRepository.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Data.QueryRepository
{
    public class CountryQueryRepository : QueryRepositoryBase, ICountryQueryRepository
    {
        public CountryQueryRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT [Id], [Name], [RegionCode]
                    FROM [AspNetCoreSpa].[dbo].[Countries]";

                return await connection.QueryAsync<CountryDto>(query);
            }
        }
    }
}
