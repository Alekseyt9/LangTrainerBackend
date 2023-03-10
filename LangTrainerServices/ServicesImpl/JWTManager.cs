
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LangTrainerClientModel.Model.User;
using LangTrainerServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LangTrainerServices.ServicesImpl
{
    internal class JWTManager : IJWTManager
    {
        private readonly IConfiguration _configuration;

        private readonly Dictionary<string, string> UsersRecords = new Dictionary<string, string>
        {
            { "user1", "password1" },
            { "user2", "password2" },
            { "user3", "password3" },
        };

        public JWTManager(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public TokensAuth Authenticate(UserAuth users)
        {
            if (!UsersRecords.Any(x => x.Key == users.Name && x.Value == users.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT_key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokensAuth() { Token = tokenHandler.WriteToken(token) };
        }

    }
}
