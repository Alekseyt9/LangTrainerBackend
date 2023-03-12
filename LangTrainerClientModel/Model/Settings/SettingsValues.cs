
using LangTrainerClientModel.Model.Settings;

namespace LangTrainerClientModel.Model
{
    public class SettingsValues
    {
        public ICollection<SettingsValue> Items { get; set; } = new List<SettingsValue>();
    }
}
