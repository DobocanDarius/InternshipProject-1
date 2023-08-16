using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RequestResponseModels.Users.Request;
using RequestResponseModels.Users.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Helpers
{
    public class TokenManager
    {
        private IConfiguration _configuration;

        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(LoginRequest user)
        {
            List<Claim> claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
