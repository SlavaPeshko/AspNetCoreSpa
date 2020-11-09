using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Data.QueryRepository.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreSpa.Data.QueryRepository
{
    public class SecurityCodeQueryRepository : QueryRepositoryBase, ISecurityCodeQueryRepository
    {
        public SecurityCodeQueryRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<string> GetSecurityCodeAsync(int providerType, int codeActionType, string provider,
            DateTimeOffset time)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT TOP(1) [Code]
                                      FROM [AspNetCoreSpa].[dbo].[SecurityCodes]
                                      WHERE [ProviderType] = @providerType 
                                          AND [CodeActionType] = @codeActionType 
                                          AND [Provider] = @provider 
                                          AND [CreateDate] > @createDate
                                      ORDER BY [Id] DESC";

                return await connection.ExecuteScalarAsync<string>(query,
                    new {providerType, codeActionType, provider, createDate = time});
            }
        }

        public async Task<string> GetSecurityCodeAsync(int providerType, int codeActionType, string provider)
        {
            using (var connection = Connection)
            {
                var query = @"SELECT TOP(1) [Code]
                                      FROM [AspNetCoreSpa].[dbo].[SecurityCodes]
                                      WHERE [ProviderType] = @providerType 
                                          AND [CodeActionType] = @codeActionType 
                                          AND [Provider] = @provider 
                                      ORDER BY [Id] DESC";

                return await connection.ExecuteScalarAsync<string>(query,
                    new {providerType, codeActionType, provider});
            }
        }
        
        public async Task<IEnumerable<int>> GetExpiredSecurityCodesAsync()
        {
            using (var connection = Connection)
            {
                var query = @"SELECT [Id] FROM [AspNetCoreSpa].[dbo].[SecurityCodes]
                                      WHERE [ProviderType] = 1 AND [CreateDate] < DATEADD(day, -1, GETUTCDATE()) 
                                      OR [ProviderType] = 2 AND [CreateDate] > DATEADD(minute, -5, GETUTCDATE())";

                return await connection.QueryAsync<int>(query);
            }
        }
    }
}