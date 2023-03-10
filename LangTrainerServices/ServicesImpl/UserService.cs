
using LangTrainerServices.ServicesModel;
using Microsoft.Extensions.Configuration;

namespace LangTrainerServices.ServicesImpl
{
    internal class UserService : IUserService
    {
        private IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }



    }
}
