using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlayTogether.Infrastructure.Dto;
using PlayTogether.Infrastructure.Extensions;
using PlayTogether.Infrastructure.Settings;
using System.Security.Cryptography;
using PlayTogether.Core;
using PlayTogether.Core.Domains;

namespace PlayTogether.Infrastructure.Services.Jwt
{
    public class JwtHandler : IJwthandler
    {
        private readonly JwtSettings _settings;

        public JwtHandler(JwtSettings settings)
        {
            _settings = settings;
        }

        public RefreshToken CreateRefreshToken(string email, string role)
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return new RefreshToken {
                     Email = email,
                     Role = role,
                     Token = Convert.ToBase64String(randomNumber),
                };

            }
        }

        public JsonWebToken CreateToken(string email, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, email.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.toTimeStamp().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = now.AddMinutes(_settings.Time);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key)),
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JsonWebToken
            {
                AccessToken = token
            };
        }

    }
}
