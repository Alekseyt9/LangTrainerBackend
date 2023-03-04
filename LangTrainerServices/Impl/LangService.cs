
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities.Lang;
using LangTrainerServices.Services;
using LangTrainerServices.Services.LangService;

namespace LangTrainerServices.Impl
{
    internal class LangService : ILangService
    {
        private IDataLoaderService _dataLoader;

        public LangService(IDataLoaderService dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public Expression AddExpression(Expression model)
        {
            throw new NotImplementedException();
        }

        public Task<Expression> LoadExpressionData(TokenInfo info)
        {
            return _dataLoader.LoadExpressionData(info);
        }

        public FindResult FindExpressions(string str)
        {
            throw new NotImplementedException();
        }
    }
}
