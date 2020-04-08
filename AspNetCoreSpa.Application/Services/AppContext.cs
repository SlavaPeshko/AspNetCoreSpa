using System.Text;
using AspNetCoreSpa.Application.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace AspNetCoreSpa.Application.Services
{
    public class AppContext : IAppContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetHostUrl()
        {
            var result = new StringBuilder();
            result.Append(_httpContextAccessor.HttpContext?.Request?.Scheme);
            result.Append("://");
            result.Append(_httpContextAccessor.HttpContext?.Request?.Host.Value);
            
            return result.ToString();
        }
    }
}