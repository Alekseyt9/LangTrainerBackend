using LangTrainerClientModel.Services.DataLoader;
using LangTrainerEntity.Entities;

namespace LangTrainerServices.ServicesModel.DataLoader
{
    internal interface IDataLoaderService
    {
        /// <summary>
        /// Find and load data from sites
        /// </summary>
        Task<Expression> LoadExpressionData(WordInfo info);
    }
}
