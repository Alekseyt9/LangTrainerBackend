
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities;

namespace LangTrainerServices.Services
{
    internal interface IDataLoaderService
    {
        /// <summary>
        /// Find and load data from sites
        /// </summary>
        Task<Expression> LoadExpressionData(TokenInfo info);
    }
}
