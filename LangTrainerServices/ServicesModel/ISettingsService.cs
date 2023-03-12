
using LangTrainerFrontendWinForms.Services;

namespace LangTrainerServices.ServicesModel
{
    public interface ISettingsService
    {
        Settings LoadUserSettings(Guid userId);

        void SaveUserSettings(Guid userId, Settings settings);
    }
}
