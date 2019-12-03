using AspNetCoreSpa.Infrastructure.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AspNetCoreSpa.Data.QueryRepository.Base
{
    public class QueryRepositoryBase
    {
        private readonly IConfiguration _config;
        private const string ConnectionName = "IdentityConnection";

        public QueryRepositoryBase(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(ConnectionName));
            }
        }
    }
}
