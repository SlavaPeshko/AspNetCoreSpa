using System;
using AspNetCoreSpa.Domain.Entities.Enum;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IUserContext
    {
        // bool IsAuthorized();
        bool IsInRole(RoleEnum role);
        Guid UserId { get; }
    }
}