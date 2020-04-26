using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class TokenController : ApiController
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(TokenInputModel model)
        {
            var result = await _tokenService.RefreshToken(model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
    }
}