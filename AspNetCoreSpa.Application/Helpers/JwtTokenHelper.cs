using AspNetCoreSpa.Application.Options;
using AspNetCoreSpa.Domain.Enities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
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

            var claims = new List<Claim>
            {
                 new Claim(nameof(user.FirstName), user.FirstName),
                 new Claim(nameof(user.LastName), user.LastName),
                 new Claim(ClaimTypes.Gender, user.Gender.ToString("G")),
                 new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString("G")),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtIssuerOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
             };

            foreach (var role in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name.ToString("G")));
            }

            if (string.IsNullOrEmpty(user.Phone) && string.IsNullOrEmpty(user.Email))
            {
                claims.AddRange(new List<Claim>
                    {
                        new Claim(ClaimTypes.MobilePhone, user.Phone),
                        new Claim(ClaimTypes.Email, user.Email)
                    });
            }
            else
            {
                claims.Add(user.Phone != null ? new Claim(nameof(user.Phone), user.Phone) : new Claim(JwtRegisteredClaimNames.Email, user.Email));
            }

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
