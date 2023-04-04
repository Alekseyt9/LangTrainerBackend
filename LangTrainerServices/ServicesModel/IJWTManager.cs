
using LangTrainerClientModel.Services;

namespace LangTrainerServices.Services
{
    public interface IJWTManager
    {
        TokensAuth Authenticate(UserAuth userAuth);
    }
}
