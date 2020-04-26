using System;
using AspNetCoreSpa.Domain.Entities.Enum;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IUserContext
    {
        // bool IsAuthorized();
        bool IsInRole(UserRoleEnum userRoleEnum);
        int UserId { get; }
    }
}