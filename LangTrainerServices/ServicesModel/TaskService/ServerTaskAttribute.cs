

namespace LangTrainerServices.Services
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServerTaskAttribute : Attribute
    {
        public string Id { get; set; }
    }
}
