

namespace LangTrainerClientModel.Services
{
    public class TranslateInfo
    {
        public Guid TranslateId { get; set; }

        public string Text { get; set; }

        public Guid LanguageId { get; set; }
    }
}
