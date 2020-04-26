﻿using System;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities.Security
{
    public class SecurityCode : BaseEntity<int>
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
