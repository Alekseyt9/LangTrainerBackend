

namespace LangTrainerClientModel.Model.Settings
{
    public class SettingsValue
    {
        public SettingsValue()
        {
        }

        public SettingsValue(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }

    }
}
