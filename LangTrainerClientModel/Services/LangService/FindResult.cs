

namespace LangTrainerServices.Services
{
    public class FindResult
    {
        public string SearchString { get; set; }

        public ICollection<FindItem> Items { get; set; } = new List<FindItem>();
    }
}
