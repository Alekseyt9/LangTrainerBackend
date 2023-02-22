
namespace LangTrainerServices.Model.DataFillers
{
    public class DataFillerAttribute : Attribute
    {
        public DataFillerAttribute(string desc, string lang)
        {
            Description = desc;
            Language = lang;
        }

        public string Description { get; set; }

        public string Language { get; set; }
    }
}
