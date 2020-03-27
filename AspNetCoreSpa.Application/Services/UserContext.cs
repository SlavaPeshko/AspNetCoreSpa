using System;
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
        
        public bool IsAuthorized()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
        public bool IsInRole(RoleEnum role)
        {
            return _httpContextAccessor.HttpContext.User.IsInRole(role.ToString("G"));
        }

        public Guid UserId
        {
            get
            {
                if (Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirstValue("Id"), out var value))
                {
                    return value;
                }

                return Guid.Empty;
            }
        }
    }
}