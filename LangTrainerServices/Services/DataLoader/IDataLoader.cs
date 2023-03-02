
using LangTrainerEntity.Entities.Lang;

namespace LangTrainerServices.Model.DataFillers
{
    internal interface IDataLoader
    {
        Task<Expression> GetData(string token, string language);
    }
}
