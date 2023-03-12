
using LangTrainerEntity.Entities;

namespace LangTrainerModel.Entities.Lang
{
    public class PartOfSpeech
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Language Language { get; set; }

        public Guid LanguageId { get; set; }
    }
}
