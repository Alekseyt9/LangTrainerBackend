
using LangTrainerEntity.Entities;

namespace LangTrainerServices.Services
{
    public interface IAppRepository
    {
        ICollection<Expression> FindExpressions(string str, Guid? languageId);

        void SaveExpression(Expression expr);

        void SaveTraining(ICollection<TrainingInfo> trInfos);

        List<Language> GetLanguages();

    }
}
