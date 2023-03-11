

namespace LangTrainerEntity.Entities
{
    public class TrainingGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }

    }
}
