
using LangTrainerEntity.Entities.Lang;
using LangTrainerEntity.Entities.User;

namespace LangTrainerServices.Model
{
    public interface ITrainingService
    {
        void AddToGroup(ExpressionGroup group, ICollection<Expression> list);

        void CreateGroup(ExpressionGroup group);

        void SaveTraining(ICollection<TrainingInfo> infos);

        ICollection<ExpressionInGroup> GetTraining(User user);
    }
}
