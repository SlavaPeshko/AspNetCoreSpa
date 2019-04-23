using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Options;
using AspNetCoreSpa.Domain.Enities;
using AspNetCoreSpa.Domain.Enities.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Helpers
{
    public interface IJwtTokenHelper
    {
        Task<string> GenerateTokenAsync(User user);
        EmailUpdateToken DecodeToken(string token);
        string GenerateTokenWithSecurityCode(User user, CodeActionType codeActionType, string code);
    }

    public class JwtTokenHelper : IJwtTokenHelper
    {
        private readonly JwtIssuerOptions _jwtIssuerOptions;
        private readonly byte[] _key;

        public JwtTokenHelper(IOptions<JwtIssuerOptions> jwtIssuerOptions)
        {
            _jwtIssuerOptions = jwtIssuerOptions.Value;
            _key = Encoding.Default.GetBytes(_jwtIssuerOptions.Key);
        }

        public async Task<string> GenerateTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                 new Claim(nameof(user.FirstName), user.FirstName),
                 new Claim(nameof(user.LastName), user.LastName),
                 new Claim(ClaimTypes.Gender, user.Gender.ToString("G")),
                 new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString("G")),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtIssuerOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
             };

            claims.AddRange(user.UserRoles.Select(u => new Claim(ClaimTypes.Role, u.Role.Name.ToString("G"))));

            if (string.IsNullOrEmpty(user.PhoneNumber) && string.IsNullOrEmpty(user.Email))
            {
                claims.AddRange(new List<Claim>
                    {
                        new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                        new Claim(ClaimTypes.Email, user.Email)
                    });
            }
            else
            {
                claims.Add(user.PhoneNumber != null ? new Claim(nameof(user.PhoneNumber), user.PhoneNumber) : new Claim(JwtRegisteredClaimNames.Email, user.Email));
            }

            var tokeOptions = new JwtSecurityToken(
                issuer: _jwtIssuerOptions.Issuer,
                audience: _jwtIssuerOptions.Audience,
                claims: claims,
                expires: _jwtIssuerOptions.Expiration,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return token;
        }

        public string GenerateTokenWithSecurityCode(User user, CodeActionType codeActionType, string code)
        {
            var claims = new List<Claim>
            {
                new Claim(nameof(user.Id), user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(nameof(code), code),
                new Claim(nameof(codeActionType), codeActionType.ToString("G")),
             };

            var tokeOptions = new JwtSecurityToken(
                issuer: _jwtIssuerOptions.Issuer,
                audience: _jwtIssuerOptions.Audience,
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return token;
        }

        public EmailUpdateToken DecodeToken(string token)
        {
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

            return new EmailUpdateToken
            {
                Id = Guid.Parse(jwtSecurityToken.Claims.FirstOrDefault(c => string.Equals(c.Type, nameof(EmailUpdateToken.Id), StringComparison.OrdinalIgnoreCase)).Value),
                Code = jwtSecurityToken.Claims.FirstOrDefault(c => string.Equals(c.Type, nameof(EmailUpdateToken.Code), StringComparison.OrdinalIgnoreCase)).Value,
                Email = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                CodeActionType = Enum.Parse<CodeActionType>(jwtSecurityToken.Claims.FirstOrDefault(c => string.Equals(c.Type, nameof(EmailUpdateToken.CodeActionType), StringComparison.OrdinalIgnoreCase)).Value)
            };
        }
    }
}
