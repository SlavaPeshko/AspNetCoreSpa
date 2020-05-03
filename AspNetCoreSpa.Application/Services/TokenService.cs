using AspNetCoreSpa.Application.Helpers;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Services.Contracts;
using System.Threading.Tasks;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;
using System.Linq;
using AspNetCoreSpa.Data.Repositories.Contracts;
using System;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Infrastructure.Options;

namespace AspNetCoreSpa.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly IUserRepository _userRepository; 
        private readonly GlobalSettings _globalSettings;
        private readonly IUnitOfWorks _unitOfWorks;
        

        public TokenService(
            IJwtTokenHelper jwtTokenHelper, 
            IUserRepository userRepository, 
            GlobalSettings globalSettings, 
            IUnitOfWorks unitOfWorks)
        {
            _jwtTokenHelper = jwtTokenHelper;
            _userRepository = userRepository;
            _globalSettings = globalSettings;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<Result<TokenViewModel>> RefreshToken(TokenInputModel model)
        {
            // TODO check on null
            
            var principal = _jwtTokenHelper.GetPrincipalFromExpiredToken(model.AccessToken);

            var userId = principal.Claims.FirstOrDefault(x => x.Type == nameof(User.Id))?.Value;

            if(!int.TryParse(userId, out int result))
            {
                return Result.Fail<TokenViewModel>(EC.UserNotFound, ET.UserNotFound);
            }

            var user = await _userRepository.GetUserByIdAsync(result);

            if (user == null || user.RefreshToken != model.RefreshToken)
            {
                return Result.Fail<TokenViewModel>(EC.UserNotFound, ET.UserNotFound);
            }

            var newJwtToken = _jwtTokenHelper.GenerateToken(user);
            var newRefreshToken = _jwtTokenHelper.GenerateRefreshToken(user);

            user.RefreshToken = newRefreshToken;
            _userRepository.Put(user);
            await _unitOfWorks.CommitAsync();

            var tokenViewModel = new TokenViewModel
            {
                RefreshToken = newRefreshToken,
                AccessToken = new AccessToken
                {
                    Token = newJwtToken,
                    ExpiresIn = _globalSettings.Jwt.Expiration
                }
            };

            return Result.OK(tokenViewModel);
        }
    }
}
