using AspNetCoreSpa.Domain.Entities.Enum;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IUserContext
    {
        int UserId { get; }

        // bool IsAuthorized();
        bool IsInRole(UserRoleEnum userRoleEnum);
    }
}