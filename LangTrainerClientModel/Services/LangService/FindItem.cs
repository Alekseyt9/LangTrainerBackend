
using LangTrainerClientModel.Services;

namespace LangTrainerServices.Services
{
    public class FindItem
    {
        public string Expression { get; set; }

        public ICollection<TranslateInfo> Translates { get; set; }

        public ICollection<FindItemSound> Sounds { get; set; }

    }
}
