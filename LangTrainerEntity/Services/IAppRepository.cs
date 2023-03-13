
using LangTrainerEntity.Entities;
using LangTrainerModel.Entities.Lang;
using LangTrainerModel.Entities.Training;

namespace LangTrainerServices.Services
{
    public interface IAppRepository
    {
        ICollection<Expression> FindExpressions(string str, Guid? languageId);

        void SaveExpression(Expression expr);

        void SaveTraining(ICollection<TrainingInfo> trInfos);

        List<Language> GetLanguages();

        User GetUser(string login);

        UserSettings GetUserSettings(Guid userId);

        TrainingGroup GetDefaultTrainingGroup(Guid userId);

        TranslateInGroup GetTranslateInGroup(Guid groupId, Guid translateId);

        void Save();

        PartOfSpeech GetPartOfSpeech(string name, Guid languageId);

        Translate GetTranslate(Guid translateId);

    }
}
