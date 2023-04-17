using Backend.Core.Models;
using Backend.Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Metods
{
    public class JWT
    {
        public static string GenarateJWT(string secret, string issuer, string audience, LoginDTO profile)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.GivenName, profile.Login),
                new Claim(ClaimTypes.Sid, profile.ProfileId.ToString()),
                new Claim(ClaimTypes.Role, profile.Role.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }
}
