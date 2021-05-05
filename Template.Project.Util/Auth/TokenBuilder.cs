using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System;

namespace Template.Project.Util.Auth
{
    public class TokenBuilder
    {
        public static string BuildToken(string userID, string email, string secret)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userID),
                new Claim(JwtRegisteredClaimNames.Email, email),
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
