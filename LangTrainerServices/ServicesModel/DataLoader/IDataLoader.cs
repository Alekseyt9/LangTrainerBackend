
using LangTrainerEntity.Entities;
using LangTrainerServices.Services.DataLoader;

namespace LangTrainerServices.Model.DataFillers
{
    internal interface IDataLoader
    {
        Task<Expression> GetData(DataLoaderContext ctx, DataLoaderParams pars);
    }
}
