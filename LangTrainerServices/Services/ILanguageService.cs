

using LangTrainerEntity.Entities;

namespace LangTrainerServices.Services
{
    public interface ILanguageService
    {
        List<Language> GetLanguages();

        List<Language> GetTranslateLanguages();

        Language GetLanguage(string name);
    }
}
