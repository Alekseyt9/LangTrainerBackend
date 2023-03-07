

namespace LangTrainerClientModel.Services.LangService
{
    public class FindModel
    {
        public string SearchString { get; set; }

        public Guid? LanguageId { get; set; }

        public Guid? TranslateLanguageId { get; set; }
    }
}
