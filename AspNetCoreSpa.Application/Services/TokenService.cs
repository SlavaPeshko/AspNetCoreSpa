using AspNetCoreSpa.Application.Helpers;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Services.Contracts;
using System.Threading.Tasks;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;
using System.Linq;
using AspNetCoreSpa.Data.Repositories.Contracts;
using System;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository; 

        public TokenService(
            IJwtTokenHelper jwtTokenHelper, 
            IUserService userService,
            IUserRepository userRepository)
        {
            _jwtTokenHelper = jwtTokenHelper;
            _userService = userService;
            _userRepository = userRepository;
        }

        public async Task<Result<UserViewModel>> RefreshToken(string authenticationToken, string refreshToken)
        {
            var principal = _jwtTokenHelper.GetPrincipalFromExpiredToken(authenticationToken);
            var username = principal.Identity.Name;

            var userId = principal.Claims.FirstOrDefault(x => x.Type == nameof(User.Id))?.Value;

            var isParse = Guid.TryParse(userId, out Guid result);

            if(!isParse)
            {
                return Result.Fail<UserViewModel>(EC.UserNotFound, ET.UserNotFound);
            }

            var user = await _userRepository.GetUserByIdAsync(result);

            if (user == null || user.RefreshToken != refreshToken)
            {
                return Result.Fail<UserViewModel>(EC.UserNotFound, ET.UserNotFound);
            }

            var newJwtToken = _jwtTokenHelper.GenerateToken(user);
            var newRefreshToken = _jwtTokenHelper.GenerateRefreshToken(user);

            user.RefreshToken = newRefreshToken;
            _userRepository.Put(user);

            return Result.OK(user.ToViewModel());
        }
    }
}
