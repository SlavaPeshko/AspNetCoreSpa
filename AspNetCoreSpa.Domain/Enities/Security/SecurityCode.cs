using AspNetCoreSpa.Domain.Enities.Base;
using System;

namespace AspNetCoreSpa.Domain.Enities.Security
{
    public class SecurityCode : BaseEntity<Guid>
    {
        public ProviderType ProviderType { get; set; }
        public string Provider { get; set; }
        public string Code { get; set; }
        public CodeActionType CodeActionType { get; set; }

        public static SecurityCode Create(ProviderType providerType, string provider, CodeActionType codeActionType)
        {
            return new SecurityCode
            {
                ProviderType = providerType,
                CodeActionType = codeActionType,
                Code = new Random().Next(100000, 999999).ToString(),
                Provider = provider,
            };
        }
    }
}
