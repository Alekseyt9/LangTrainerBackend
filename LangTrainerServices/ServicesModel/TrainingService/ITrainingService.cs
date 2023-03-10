
using LangTrainerClientModel.Model.Training;
using LangTrainerEntity.Entities;
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
