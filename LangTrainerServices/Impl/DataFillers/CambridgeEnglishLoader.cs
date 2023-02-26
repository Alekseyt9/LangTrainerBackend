
using HtmlAgilityPack;
using LangTrainerEntity.Entities.Lang;
using LangTrainerServices.Helpers;
using LangTrainerServices.Model.DataFillers;

namespace LangTrainerServices.Impl.DataFillers
{
    [DataLoader("dictionary.cambridge.org_eng", "english")]
    internal class CambridgeEnglishLoader : IDataLoader
    {
        public async Task<Expression> GetData(string token)
        {
            var res = new Expression();

            var web = new HtmlWeb();
            var doc = web.Load($"https://dictionary.cambridge.org/dictionary/english-italian/{token}");

            var audioNode = doc.DocumentNode.SelectSingleNode("//audio[@id='audio2']/source[@type='audio/mpeg']");
            var url = audioNode.GetAttributeValue("src", null);
            var soundUrl = $"https://dictionary.cambridge.org{url}";

            using var client = new HttpClient();
            using var response = await client.GetAsync(soundUrl);
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var data = stream.ToBytes();
                res.Sounds.Add(new Sound()
                {
                    Id = Guid.NewGuid(),
                    Data = data,
                    Hash = data.GetMd5Hash()
                });
            }

            return res;
        }

    }
}
