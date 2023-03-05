
using LangTrainerEntity.Entities.Lang;
using LangTrainerEntity.Entities.User;

namespace LangTrainerServices.Services
{
    public interface IAppRepository
    {
        ICollection<Expression> FindExpressions(string str);

        void SaveExpression(Expression expr);

        void SaveTraining(ICollection<TrainingInfo> trInfos);
    }
}
