using LangTrainerClientModel.Services.SettingsService;

namespace LangTrainerServices.ServicesModel
{
    public interface ISettingsService
    {
        SettingsValues LoadUserSettings(Guid userId);

        void SaveUserSettings(Guid userId, SettingsValues settings);
    }
}
