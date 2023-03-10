
namespace LangTrainerServices.Model.DataFillers
{
    public class DataLoaderAttribute : Attribute
    {
        public DataLoaderAttribute(string desc, string lang)
        {
            Description = desc;
            Languages = new List<string>() { lang };
        }

        public DataLoaderAttribute(string desc, string[] langs)
        {
            Description = desc;
            Languages = langs;
        }

        public string Description { get; set; }

        public ICollection<string> Languages { get; set; }
    }
}
