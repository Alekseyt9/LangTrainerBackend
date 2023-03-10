
using System.Collections.Concurrent;
using LangTrainerEntity.Entities;
using LangTrainerServices.Services;

namespace LangTrainerServices.Impl
{
    internal class LanguageService : ILanguageService
    {
        private readonly IAppRepository _repository;

        private IDictionary<string, Language> _langMap;

        public LanguageService(IAppRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Language GetLanguage(string name)
        {
            if (_langMap == null)
            {
                _langMap = new ConcurrentDictionary<string, Language>();
                foreach (var lang in _repository.GetLanguages())
                {
                    _langMap.Add(lang.Name, lang);
                }
            }
            return _langMap[name];
        }

        public List<Language> GetLanguages()
        {
            return _repository.GetLanguages();
        }

        public List<Language> GetTranslateLanguages()
        {
            var keys = new HashSet<string>() { "russian", "english" };
            var langs = GetLanguages();
            var res = langs.Where(x => keys.Contains(x.Name)).ToList();
            return res;
        }

    }
}
