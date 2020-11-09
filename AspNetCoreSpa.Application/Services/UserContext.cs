using System.Security.Claims;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Domain.Entities.Enum;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreSpa.Application.Services
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsInRole(UserRoleEnum userRoleEnum)
        {
            return _httpContextAccessor.HttpContext.User.IsInRole(userRoleEnum.ToString("G"));
        }

        public int UserId
        {
            get
            {
                if (int.TryParse(_httpContextAccessor.HttpContext.User.FindFirstValue("Id"), out var value))
                    return value;

                return -1;
            }
        }

        public bool IsAuthorized()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}