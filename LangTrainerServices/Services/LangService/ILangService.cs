
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities.Lang;

namespace LangTrainerServices.Services.LangService
{
    public interface ILangService
    {
        Expression AddExpression(Expression model);

        Task<Expression> LoadExpressionData(TokenInfo token);

        FindResult FindExpressions(string str);

    }

}
