using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Data.QueryRepository.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
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
                try
                {
                    string query = "Select Name, RegioneCode From Contries";

                    connection.Open();

                    return await connection.QueryAsync<CountryDto>(query);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
