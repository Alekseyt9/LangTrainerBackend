

using LangTrainerEntity.Entities;

namespace LangTrainerClientModel.Services
{
    public class TrainingListItem
    {
        public string Word { get; set; }

        public string Translate { get; set; }

        public string Sample { get; set; }

        public ICollection<Sound> Sounds { get; set; }

        public Guid TranslateInGroupId { get; set; }

    }
}
