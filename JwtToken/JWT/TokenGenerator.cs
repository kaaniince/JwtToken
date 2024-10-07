using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtToken.JWT
{
    public class TokenGenerator
    {
        public string GenerateJWTToken(string username, string mail, string name, string surname)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("A much longer secret phase that meets the required length"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claim = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Email, mail),
        new Claim(JwtRegisteredClaimNames.GivenName, name),
        new Claim(JwtRegisteredClaimNames.FamilyName, surname),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claim,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
