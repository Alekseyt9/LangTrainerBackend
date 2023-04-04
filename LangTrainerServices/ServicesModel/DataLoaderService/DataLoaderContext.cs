

namespace LangTrainerServices.Services
{
    internal class DataLoaderContext
    {
        private readonly ILanguageService _languageService;

        public DataLoaderContext(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        public ILanguageService LanguageService => _languageService;
    }
}
