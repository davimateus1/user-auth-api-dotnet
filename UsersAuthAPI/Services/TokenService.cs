
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersAuthAPI.Models;

namespace UsersAuthAPI.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            Claim[] claims = new Claim[]
            {
                new("id" , user.Id),
                new("username", user.UserName),
                new(ClaimTypes.DateOfBirth, user.BirthDate.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding
                .UTF8
                .GetBytes(_configuration["SymmetricSecurityKey"]));

            var signInCredentials = new SigningCredentials
                (key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}