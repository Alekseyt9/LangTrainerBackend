
using LangTrainerClientModel.Services;
using LangTrainerClientModel.Services.LangService;
using LangTrainerEntity.Entities.Lang;

namespace LangTrainerServices.Services.LangService
{
    public interface ILangService
    {
        Expression AddExpression(Expression model);

        Task<Expression> LoadExpressionData(TokenInfo token);

        FindResult FindExpressions(FindModel model);

        List<Language> GetLanguages();


    }

}
