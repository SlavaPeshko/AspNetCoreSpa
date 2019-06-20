using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Options;
using AspNetCoreSpa.Domain.Enities;
using AspNetCoreSpa.Domain.Enities.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
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
        T DecodeToken<T>(string token);
        string GenerateTokenWithSecurityCode(User user, string code);
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

            claims.AddRange(user.UserRoles.Select(u => new Claim(ClaimTypes.Role, u.Role.Name.ToString())));

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

        public string GenerateTokenWithSecurityCode(User user, string code)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("Code", code),
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

        public T DecodeToken<T>(string token)
        {
            var jwtSecurityToken =  new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            var json = JsonConvert.SerializeObject(jwtSecurityToken.Payload);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
