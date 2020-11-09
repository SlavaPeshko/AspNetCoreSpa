using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreSpa.Data.QueryRepository.Base
{
    public class QueryRepositoryBase
    {
        private const string ConnectionName = "IdentityConnection";
        private readonly IConfiguration _config;

        public QueryRepositoryBase(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection => new SqlConnection(_config.GetConnectionString(ConnectionName));
    }
}