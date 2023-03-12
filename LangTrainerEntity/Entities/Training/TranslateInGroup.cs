

namespace LangTrainerEntity.Entities
{
    public class TranslateInGroup
    {
        public Guid Id { get; set; }

        public TrainingInfo TrainingInfo { get; set; }

        public Guid TrainingInfoId { get; set; }

        public Translate Translate { get; set; }

        public Guid TranslateId { get; set; }

        public TrainingGroup Group { get; set; }

        public Guid GroupId { get; set; }

        public DateTime AddTime { get; set; }
    }
}
