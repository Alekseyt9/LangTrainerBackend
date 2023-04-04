
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities;

namespace LangTrainerServices.Services
{
    public interface IDictionaryService
    {
        Expression AddExpression(Expression model);

        Task<Expression> LoadExpressionData(WordInfo word);

        FindResult FindExpressions(FindModel model);

        Task<LoadResult> LoadInBase(WordInfo word);
    }

}
