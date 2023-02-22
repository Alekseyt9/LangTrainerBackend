
using LangTrainerEntity.Entities.Lang;
using LangTrainerServices.Helpers;
using LangTrainerServices.Model.DataFillers;

namespace LangTrainerServices.Impl.DataFillers
{
    [DataFiller("dictionary.cambridge.org_eng", "english")]
    internal class CambridgeEnglishFiller : IDataFiller
    {
        public Expression GetData(string token)
        {
            var res = new Expression();

            var http = HttpHelper.GetHttpAsync(
                $"https://dictionary.cambridge.org/dictionary/english-italian/{token}");


            return res;
        }

    }
}
