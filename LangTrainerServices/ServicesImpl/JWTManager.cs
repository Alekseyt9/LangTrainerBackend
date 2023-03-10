
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
        private readonly IAppRepository _repository;

        public JWTManager(IConfiguration configuration, IAppRepository repository)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public TokensAuth Authenticate(UserAuth userAuth)
        {
            if (!_repository.GetUsers(userAuth.Login).Any())
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT_key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userAuth.Login)
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
