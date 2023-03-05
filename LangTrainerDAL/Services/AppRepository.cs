
using LangTrainerEntity.Entities.Lang;
using LangTrainerEntity.Entities.User;
using LangTrainerServices.Services;

namespace LangTrainerDAL.Services
{
    internal class AppRepository : IAppRepository
    {
        private AppDbContext _dbContext;

        public AppRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
        }

        public ICollection<Expression> FindExpressions(string str)
        {
            throw new NotImplementedException();
        }

        public void SaveExpression(Expression expr)
        {
            throw new NotImplementedException();
        }

        public void SaveTraining(ICollection<TrainingInfo> trInfos)
        {
            throw new NotImplementedException();
        }

    }
}
