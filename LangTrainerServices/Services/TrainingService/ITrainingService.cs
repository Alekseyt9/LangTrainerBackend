
using LangTrainerEntity.Entities.Lang;
using LangTrainerEntity.Entities.User;
using LangTrainerFrontendWinForms.Model;
using LangTrainerServices.Services.TrainingService;

namespace LangTrainerServices
{
    public interface ITrainingService
    {
        void AddToGroup(TrainingGroup group, ICollection<Expression> list);

        void CreateGroup(TrainingGroup group);

        void SaveTraining(TrainingResult result);

        ICollection<ExpressionInGroup> GetTrainingExpressions(User user);

        TrainingModel GetTraining(User user);

    }
}
