
namespace LangTrainerServices.Model.DataFillers
{
    public class DataLoaderAttribute : Attribute
    {
        public DataLoaderAttribute(string desc, string lang)
        {
            Description = desc;
            Language = lang;
        }

        public string Description { get; set; }

        public string Language { get; set; }
    }
}
