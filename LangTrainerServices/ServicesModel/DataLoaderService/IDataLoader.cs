
using LangTrainerEntity.Entities;
using LangTrainerServices.Services;

namespace LangTrainerServices.Model
{
    internal interface IDataLoader
    {
        Task<Expression> GetData(DataLoaderContext ctx, DataLoaderParams pars);
    }
}
