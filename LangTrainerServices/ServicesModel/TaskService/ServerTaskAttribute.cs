

namespace LangTrainerServices.Services.Tasks
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServerTaskAttribute : Attribute
    {
        public string Id { get; set; }
    }
}
