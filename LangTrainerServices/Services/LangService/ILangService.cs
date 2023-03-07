
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities;

namespace LangTrainerServices.Services
{
    public interface ILangService
    {
        Expression AddExpression(Expression model);

        Task<Expression> LoadExpressionData(TokenInfo token);

        FindResult FindExpressions(FindModel model);

        List<Language> GetLanguages();


    }

}
