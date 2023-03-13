
using LangTrainerClientModel.Services;
using LangTrainerClientModel.Services.LangService;

namespace LangTrainerServices.Services
{
    public class FindItem
    {
        public string Expression { get; set; }

        public ICollection<TranslateInfo> Translates { get; set; }

        public ICollection<FindItemSound> Sounds { get; set; }

    }
}
