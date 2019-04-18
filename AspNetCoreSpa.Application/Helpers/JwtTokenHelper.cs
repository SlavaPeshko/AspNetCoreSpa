using AspNetCoreSpa.Application.Options;
using AspNetCoreSpa.Domain.Enities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Helpers
{
    public interface IJwtTokenHelper
    {
        Task<string> GenerateToken(User user);
    }

    public class JwtTokenHelper : IJwtTokenHelper
    {
        private readonly JwtIssuerOptions _jwtIssuerOptions;

        public JwtTokenHelper(IOptions<JwtIssuerOptions> jwtIssuerOptions)
        {
            _jwtIssuerOptions = jwtIssuerOptions.Value;
        }

        public async Task<string> GenerateToken(User user)
        {
            var key = Encoding.Default.GetBytes(_jwtIssuerOptions.Key);

            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtIssuerOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
             };

            var tokeOptions = new JwtSecurityToken(
                issuer: _jwtIssuerOptions.Issuer,
                audience: _jwtIssuerOptions.Audience,
                claims: claims,
                expires: _jwtIssuerOptions.Expiration,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return token;
        }
    }
}
