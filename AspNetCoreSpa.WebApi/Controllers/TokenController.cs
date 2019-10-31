using System.Threading.Tasks;
using AspNetCoreSpa.Application.Contracts;
using AspNetCoreSpa.Application.Helpers;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : ApiController
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(string accessToken, string refreshToken)
        {
            var result = await _tokenService.RefreshToken(accessToken, refreshToken);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result.Data);

            //var principal = _jwtTokenHelper.GetPrincipalFromExpiredToken(authenticationToken);
            //var username = principal.Identity.Name;

            //var user = await _userService.GerUserByNameAsync(username);

            //if (user == null || user.RefreshToken != refreshToken) return BadRequest();

            //var newJwtToken = _jwtTokenHelper.GenerateToken(user);
            //var newRefreshToken = _jwtTokenHelper.GenerateRefreshToken(user);

            //user.RefreshToken = newRefreshToken;
            //_userService.Put(user);

            //return Ok(new
            //{
            //    AccessToken = newJwtToken,
            //    RerfreshToken = newRefreshToken
            //});
        }
    }
}