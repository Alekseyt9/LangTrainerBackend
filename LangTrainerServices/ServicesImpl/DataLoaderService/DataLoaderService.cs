
using System.Reflection;
using LangTrainerClientModel.Services.DataLoader;
using LangTrainerEntity.Entities;
using LangTrainerEntity.Helpers;
using LangTrainerServices.Model.DataFillers;
using LangTrainerServices.Services;
using LangTrainerServices.Services.DataLoader;
using LangTrainerServices.ServicesModel.DataLoader;

namespace LangTrainerServices.ServicesImpl.DataLoaderService
{
    internal class DataLoaderService : IDataLoaderService
    {
        private readonly IAppRepository _repository;
        private readonly ILanguageService _languageService;

        private readonly Dictionary<DataLoaderInfo, IDataLoader> m_Loaders = new();
        private IDictionary<Guid, string> _langMap;

        public DataLoaderService(IAppRepository repository, ILanguageService languageService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _languageService = languageService ?? throw new ArgumentNullException(nameof(languageService));

            InitLoaders();
        }

        private void InitLoaders()
        {
            var asms = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var type in asms
                         .Where(x => x.GetCustomAttributes(typeof(DataLoaderAssemblyAttribute)).Any())
                         .SelectMany(x => x.GetTypes()))
            {
                if (typeof(IDataLoader).IsAssignableFrom(type))
                {
                    var attr = type.GetCustomAttribute<DataLoaderAttribute>();
                    if (attr != null)
                    {
                        m_Loaders.Add(
                            new DataLoaderInfo() { Languages = attr.Languages },
                            (IDataLoader)Activator.CreateInstance(type)
                        );
                    }
                }
            }
        }

        private string GetLangName(Guid id)
        {
            if (_langMap == null)
            {
                _langMap = new Dictionary<Guid, string>();
                foreach (var lang in _repository.GetLanguages())
                {
                    _langMap.Add(lang.Id, lang.Name);
                }
            }
            return _langMap[id];
        }

        public async Task<Expression> LoadExpressionData(WordInfo info)
        {
            Expression target = null;

            var ctx = new DataLoaderContext(_languageService);
            var langName = GetLangName(info.LanguageId);

            var taskList = new List<Task<Expression>>();
            foreach (var key in m_Loaders.Keys
                         .Where(x => x.Languages.Contains(langName)))
            {
                var loader = m_Loaders[key];
                var pars = new DataLoaderParams(info.Expression, langName);
                taskList.Add(loader.GetData(ctx, pars));
            }

            var resList = await Task.WhenAll(taskList);
            foreach (var expr in resList)
            {
                target = target.Union(expr);
            }

            return target;
        }

    }
}
