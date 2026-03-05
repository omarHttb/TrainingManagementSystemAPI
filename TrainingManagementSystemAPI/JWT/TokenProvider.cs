using Application.DTOS.UsersDTOS;
using Application.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace TrainingManagementSystemAPI.JWT
{
    public sealed class TokenProvider(IConfiguration configuration)
    {
        public string create(LoggedInUserDTO loginDTO)
        {
            string secretKey = configuration["Jwt:Secret"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256 );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                  new List<Claim>
                  {
                      new Claim(JwtRegisteredClaimNames.Sub, loginDTO.Id.ToString()),
                      new Claim(JwtRegisteredClaimNames.Email, loginDTO.Email)
                  }
                  .Union(loginDTO.Roles.Select(role => new Claim(ClaimTypes.Role, role)))
                ),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = credentials,
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]
                
            };
            var handler = new JsonWebTokenHandler();

            string token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
