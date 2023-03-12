

using LangTrainerEntity.Entities;
using LangTrainerModel.Entities.Lang;

namespace LangTrainerServices.Services
{
    public interface ILanguageService
    {
        List<Language> GetLanguages();

        List<Language> GetTranslateLanguages();

        Language GetLanguage(string name);

        PartOfSpeech GetPartOfSpeech(string name, Guid languageId);

    }
}
