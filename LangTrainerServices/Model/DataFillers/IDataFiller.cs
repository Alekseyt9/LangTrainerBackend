
using LangTrainerEntity.Entities.Lang;

namespace LangTrainerServices.Model.DataFillers
{
    internal interface IDataFiller
    {
        Expression GetData(string token);
    }
}
