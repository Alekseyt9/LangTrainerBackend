
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities.Lang;

namespace LangTrainerServices.Model
{
    public interface ILangService
    {
        Expression AddExpression(Expression model);

        Task<Expression> LoadExpressionData(TokenInfo token);
    }

}
