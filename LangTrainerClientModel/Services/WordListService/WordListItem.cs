

using LangTrainerEntity.Entities;

namespace LangTrainerClientModel.Services
{
    public class WordListItem
    {
        public string Word { get; set; }

        public Guid TranslateId { get; set; }

        public string TrainingState { get; set; }

        public SoundDto[] Sounds { get; set; }

        public string Translate { get; set; }

        public string Sample { get; set; }

    }
}
