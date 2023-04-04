
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities;

namespace LangTrainerServices.ServicesModel
{
    internal interface IDataLoaderService
    {
        /// <summary>
        /// Find and load data from sites
        /// </summary>
        Task<Expression> LoadExpressionData(WordInfo info);
    }
}
