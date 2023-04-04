using LangTrainerClientModel.Services.SettingsService;
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

        public SettingsValues LoadUserSettings(Guid userId)
        {
            var obj = _repository.GetUserSettings(userId);
            var snapshot = obj.Data != null
                ? (SettingsValues)JsonConvert.DeserializeObject(
                    obj.Data, typeof(SettingsValues))
                : new SettingsValues();
           
            return snapshot;
        }

        public void SaveUserSettings(Guid userId, SettingsValues settings)
        {
            var obj = _repository.GetUserSettings(userId);
            obj.Data = JsonConvert.SerializeObject(settings);
            _repository.Save();
        }

    }
}
