
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities;
using LangTrainerServices.Services;
using LangTrainerServices.ServicesModel;

namespace LangTrainerServices.ServicesImpl
{
    internal class DictionaryService : IDictionaryService
    {
        private readonly IDataLoaderService _dataLoader;
        private readonly IAppRepository _repository;

        public DictionaryService(IDataLoaderService dataLoader, IAppRepository repository)
        {
            _dataLoader = dataLoader;
            _repository = repository;
        }

        public Expression AddExpression(Expression model)
        {
            throw new NotImplementedException();
        }

        public Task<Expression> LoadExpressionData(WordInfo info)
        {
            return _dataLoader.LoadExpressionData(info);
        }

        public FindResult FindExpressions(FindModel model)
        {
            var exprs = _repository.FindExpressions(model.SearchString, model.LanguageId);

            var res = new FindResult()
            {
                SearchString = model.SearchString
            };

            foreach (var expr in exprs)
            {
                var trs = expr.Translates
                    .Where(x => model.TranslateLanguageId.HasValue && x.LanguageId == model.TranslateLanguageId ||
                                !model.TranslateLanguageId.HasValue)
                    .Select(x => new TranslateInfo()
                    {
                        Text = x.Text,
                        LanguageId = x.LanguageId,
                        TranslateId = x.Id
                    }).ToList();

                res.Items.Add(new FindItem()
                {
                    Expression = expr.Text,
                    Translates = trs,
                    Sounds = expr.Sounds.Select(x => new SoundDto()
                    {
                        Data = Convert.ToBase64String(x.Data)
                    }).ToList() 
                });
            }

            return res;
        }

        public async Task<LoadResult> LoadInBase(WordInfo info)
        {
            try
            {
                var data = await _dataLoader.LoadExpressionData(info);
                if (data != null && data.Translates != null && data.Translates.Count > 0)
                {
                    _repository.SaveExpression(data);

                    return new LoadResult()
                    {
                        WordFound = true
                    };
                }
            }
            catch (Exception e)
            {
                return new LoadResult()
                {
                    Message = e.Message,
                    WordFound = false
                };
            }

            return new LoadResult()
            {
                WordFound = false
            };
        }

    }
}
