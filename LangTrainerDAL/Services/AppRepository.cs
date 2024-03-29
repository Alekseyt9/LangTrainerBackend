﻿
using LangTrainerEntity.Entities;
using LangTrainerModel.Entities.Lang;
using LangTrainerModel.Entities.Training;
using LangTrainerServices.Services;
using Microsoft.EntityFrameworkCore;

namespace LangTrainerDAL.Services
{
    internal class AppRepository : IAppRepository
    {
        private readonly AppDbContext _dbContext;

        public AppRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
        }

        public ICollection<Expression> FindExpressions(string str, Guid? languageId)
        {
            return _dbContext.Expressions
                .Where(x => EF.Functions.Like(x.Text, $"%{str}%") && x.LanguageId == languageId)
                .Include(x => x.Language)
                .Include(x=> x.Sounds)
                .Include(x => x.Translates)
                    .ThenInclude(y => y.Language)
                .Include(x => x.Translates)
                    .ThenInclude(y => y.Samples)
                .ToList();
        }

        public void SaveExpression(Expression expr)
        {
            _dbContext.Expressions.Add(expr);
            _dbContext.SaveChanges(true);
        }

        public void SaveTraining(ICollection<TrainingInfo> trInfos)
        {
            throw new NotImplementedException();
        }

        public List<Language> GetLanguages()
        {
            return _dbContext.Languages.ToList();
        }

        public User GetUser(string email)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges(true);
        }

        public UserSettings GetUserSettings(Guid userId)
        {
            var record = _dbContext.UserSettings.FirstOrDefault(x => x.UserId == userId);
            if (record == null)
            {
                record = _dbContext.UserSettings.Add(new UserSettings() { UserId = userId }).Entity;
            }

            return record;
        }

        public TrainingGroup GetDefaultTrainingGroup(Guid userId)
        {
            var group = _dbContext.TrainingGroups.FirstOrDefault(x => x.UserId == userId);
            if (group == null)
            {
                group = new TrainingGroup()
                {
                    Name = "default",
                    UserId = userId
                };
                _dbContext.TrainingGroups.Add(group);
            }

            return group;
        }

        public TranslateInGroup GetTranslateInGroup(Guid groupId, Guid translateId)
        {
            return _dbContext.TranslateInGroup
                .FirstOrDefault(x => x.GroupId == groupId && x.TranslateId == translateId);
        }

        public IEnumerable<TranslateInGroup> GetTranslatesInGroup(Guid groupId, string searchStr, int maxCount)
        {
            return _dbContext.TranslateInGroup
                .Where(x => x.GroupId == groupId
                            && (string.IsNullOrEmpty(searchStr)
                                || !string.IsNullOrEmpty(searchStr)
                                && EF.Functions.Like(x.Translate.Expression.Text, $"%{searchStr}%")))
                .Include(x => x.Translate)
                .ThenInclude(x => x.Expression).ThenInclude(x => x.Sounds)
                .Include(x => x.Translate)
                .ThenInclude(x => x.Samples)
                .Take(maxCount)
                .ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public PartOfSpeech GetPartOfSpeech(string name, Guid languageId)
        {
            return _dbContext.PartOfSpeech
                .FirstOrDefault(x => x.LanguageId == languageId && x.Name == name);
        }

        public Translate GetTranslate(Guid translateId)
        {
            return _dbContext.Translates.First(x => x.Id == translateId);
        }

    }
}
