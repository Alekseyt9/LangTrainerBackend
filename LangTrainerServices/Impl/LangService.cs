
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities;
using LangTrainerServices.Services;

namespace LangTrainerServices.Impl
{
    internal class LangService : ILangService
    {
        private readonly IDataLoaderService _dataLoader;
        private readonly IAppRepository _repository;

        public LangService(IDataLoaderService dataLoader, IAppRepository repository)
        {
            _dataLoader = dataLoader;
            _repository = repository;
        }

        public Expression AddExpression(Expression model)
        {
            throw new NotImplementedException();
        }

        public Task<Expression> LoadExpressionData(TokenInfo info)
        {
            return _dataLoader.LoadExpressionData(info);
        }

        public FindResult FindExpressions(FindModel model)
        {
            var exprs = _repository.FindExpressions(model.SearchString, model.LanguageId);
            if (exprs == null)
            {
                return null;
            }

            var res = new FindResult()
            {
                SearchString = model.SearchString
            };

            foreach (var expr in exprs)
            {
                var trs = expr.Translates.Where(x => x.LanguageId == model.TranslateLanguageId)
                    .Select(x => new TranslateInfo()
                    {
                        Text = x.Text,
                        LanguageId = x.LanguageId,
                        TranslateId = x.Id
                    }).ToList();

                res.Items.Add(new FindItem()
                {
                    Expression = expr.Text,
                    Translates = trs
                });
            }

            return res;
        }

        public List<Language> GetLanguages()
        {
            return _repository.GetLanguages();
        }

    }
}
