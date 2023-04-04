namespace LangTrainerClientModel.Services.SettingsService
{
    public class SettingsValues
    {
        public ICollection<SettingsValue> Items { get; set; } = new List<SettingsValue>();
    }
}
