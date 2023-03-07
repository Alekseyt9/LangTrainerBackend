

namespace LangTrainerEntity.Entities
{
    public class ExpressionInGroup
    {
        public Guid Id { get; set; }

        public TrainingInfo TrainingInfo { get; set; }

        public Exception Exception { get; set; }
    }
}
