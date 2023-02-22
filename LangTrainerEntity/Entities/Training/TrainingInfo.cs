

namespace LangTrainerEntity.Entities.User
{
    public class TrainingInfo
    {
        public Guid Id { get; set; }

        public bool LastSuccess { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public DateTime LastSuccessTime { get; set; }

        public int Stage { get; set; }

    }
}
