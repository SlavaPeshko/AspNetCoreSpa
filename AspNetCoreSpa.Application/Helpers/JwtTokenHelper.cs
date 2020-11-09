using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Enum;
using AspNetCoreSpa.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AspNetCoreSpa.Application.Helpers
{
    public interface IJwtTokenHelper
    {
        string GenerateToken(User user);
        string GenerateRefreshToken(User user);
        T DecodeToken<T>(string token);
        string GenerateTokenWithSecurityCode(string id, string email, string code);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
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

        public string GenerateToken(User user)
        {
            var claims = InitClaims(user);

            var tokeOptions = new JwtSecurityToken(
                _jwtIssuerOptions.Issuer,
                _jwtIssuerOptions.Audience,
                claims,
                expires: _jwtIssuerOptions.Expiration,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_key),
                    SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return token;
        }

        public string GenerateRefreshToken(User user)
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public string GenerateTokenWithSecurityCode(string id, string email, string code)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", id),
                new Claim("Email", email),
                new Claim("Code", code)
            };

            var tokeOptions = new JwtSecurityToken(
                _jwtIssuerOptions.Issuer,
                _jwtIssuerOptions.Audience,
                claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_key),
                    SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return token;
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtIssuerOptions.Key)),
                ValidateLifetime = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public T DecodeToken<T>(string token)
        {
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            if (jwtSecurityToken == null) return default;
            var json = JsonConvert.SerializeObject(jwtSecurityToken.Payload);

            return JsonConvert.DeserializeObject<T>(json);
        }

        private List<Claim> InitClaims(User user)
        {
            var claims = new List<Claim> {new Claim(nameof(user.Id), user.Id.ToString())};


            if (user.FirstName != null)
                claims.Add(new Claim(nameof(user.FirstName), user.FirstName));

            if (user.LastName != null)
                claims.Add(new Claim(nameof(user.LastName), user.LastName));

            if (user.Gender != Gender.None)
                claims.Add(new Claim(nameof(ClaimTypes.Gender), user.Gender.ToString("G")));

            claims.Add(new Claim(nameof(ClaimTypes.DateOfBirth), user.DateOfBirth.ToString("G")));

            if (user.Email != null)
            {
                claims.Add(new Claim(nameof(ClaimTypes.Email), user.Email));
                claims.Add(new Claim(ClaimTypes.Name, user.Email));
            }

            if (user.PhoneNumber != null)
            {
                claims.Add(new Claim(nameof(ClaimTypes.MobilePhone), user.PhoneNumber));
                claims.Add(new Claim(ClaimTypes.Name, user.PhoneNumber));
            }

            claims.AddRange(user.UserRoles.Select(r => new Claim(ClaimTypes.Role, r.RoleId.ToString())));

            return claims;
        }
    }
}