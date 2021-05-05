using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Template.Project.Util.Models;
using System.Security.Claims;
using System.Text;
using System;

namespace Template.Project.Util.Auth
{
    public class TokenBuilder
    {
        public static string BuildToken(UserResponseUtil userResponseUtil, string secret)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userResponseUtil.UserID),
                new Claim(JwtRegisteredClaimNames.Email, userResponseUtil.Email),
                new Claim(ClaimTypes.Role, userResponseUtil.Role)
                //new Claim(JwtRegisteredClaimNames.Iss, key),
            };

            var secretKey =
                Encoding.UTF8.GetBytes(secret);

            var expiration =
                DateTime.UtcNow.AddHours(1);

            var creds =
                new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
