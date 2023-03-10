
using LangTrainerClientModel.Model.User;

namespace LangTrainerServices.Services
{
    public interface IJWTManager
    {
        TokensAuth Authenticate(UserAuth users);
    }
}
