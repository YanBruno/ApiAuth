using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiAuth.Models;
using Microsoft.IdentityModel.Tokens;

namespace ApiAuth.Services
{
        public static class TokenService{
        public static string GenerateToken(User user){

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Settings.SecretTokenKey);

            var tokenDescritor = new SecurityTokenDescriptor{

                Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                    //new Claim("Afirmação","de onde afirma")
                }),

                Expires = DateTime.UtcNow.AddHours(8),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };

            var token = tokenHandler.CreateToken(tokenDescritor);
            return tokenHandler.WriteToken(token);
        }
    }
}