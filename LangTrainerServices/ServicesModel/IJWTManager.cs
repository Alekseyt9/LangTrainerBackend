using LangTrainerClientModel.Services.AuthService;

namespace LangTrainerServices.Services
{
    public interface IJWTManager
    {
        TokensAuth Authenticate(UserAuth userAuth);
    }
}
