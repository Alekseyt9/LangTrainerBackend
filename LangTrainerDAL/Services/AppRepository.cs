
using LangTrainerEntity.Entities.Lang;
using LangTrainerEntity.Entities.User;
using LangTrainerServices.Services;
using Microsoft.EntityFrameworkCore;

namespace LangTrainerDAL.Services
{
    internal class AppRepository : IAppRepository
    {
        private AppDbContext _dbContext;

        public AppRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
        }

        public ICollection<Expression> FindExpressions(string str, Guid? languageId)
        {
            return _dbContext.Expressions
                .Where(x => EF.Functions.Like(x.Text, $"%{str}%")).ToList();
        }

        public void SaveExpression(Expression expr)
        {
            throw new NotImplementedException();
        }

        public void SaveTraining(ICollection<TrainingInfo> trInfos)
        {
            throw new NotImplementedException();
        }

        public List<Language> GetLanguages()
        {
            return _dbContext.Languages.ToList();
        }

    }
}
