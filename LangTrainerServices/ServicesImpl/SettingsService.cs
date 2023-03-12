
using LangTrainerFrontendWinForms.Services;
using LangTrainerServices.Services;
using LangTrainerServices.ServicesModel;
using Newtonsoft.Json;

namespace LangTrainerServices.ServicesImpl
{
    internal class SettingsService : ISettingsService
    {
        private readonly IAppRepository _repository;

        public SettingsService(IAppRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Settings LoadUserSettings(Guid userId)
        {
            var obj = _repository.GetUserSettings(userId);
            var snapshot = obj.Data != null
                ? (Dictionary<string, object>)JsonConvert.DeserializeObject(
                    obj.Data, typeof(Dictionary<string, object>))
                : new Dictionary<string, object>();
            var settings = new Settings(snapshot);
            return settings;
        }

        public void SaveUserSettings(Guid userId, Settings settings)
        {
            var obj = _repository.GetUserSettings(userId);
            obj.Data = JsonConvert.SerializeObject(settings.GetSnapshot());
            _repository.Save();
        }

    }
}
