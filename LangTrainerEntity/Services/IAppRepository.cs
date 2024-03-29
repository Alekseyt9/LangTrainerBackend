﻿
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

        User GetUser(string email);

        void AddUser(User user);

        UserSettings GetUserSettings(Guid userId);

        TrainingGroup GetDefaultTrainingGroup(Guid userId);

        TranslateInGroup GetTranslateInGroup(Guid groupId, Guid translateId);

        IEnumerable<TranslateInGroup> GetTranslatesInGroup(Guid groupId, string searchStr, int maxCount);

        void Save();

        PartOfSpeech GetPartOfSpeech(string name, Guid languageId);

        Translate GetTranslate(Guid translateId);

    }
}
