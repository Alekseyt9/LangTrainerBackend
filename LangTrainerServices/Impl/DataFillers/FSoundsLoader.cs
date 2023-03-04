
using HtmlAgilityPack;
using LangTrainerCommon.Helpers;
using LangTrainerEntity.Entities.Lang;
using LangTrainerServices.Helpers;
using LangTrainerServices.Model.DataFillers;

namespace LangTrainerServices.Impl.DataFillers
{
    [DataLoader(@"", new []{ "english", "french", "german", "italian" })]
    internal class FSoundsLoader : IDataLoader
    {
        public async Task<Expression> GetData(string token, string language)
        {
            var url = GetUrl(token, language);

            var expr = new Expression()
            {
                Text = token,
                Language = new Language()
                {
                    Name = "english"
                }
            };

            var web = new HtmlWeb();
            var doc = web.Load(url);

            await LoadSounds(doc, expr);

            return expr;
        }

        private async Task LoadSounds(HtmlDocument doc, Expression expr)
        {
            var i = 0;

            var langsNode = doc.DocumentNode.SelectSingleNode("//ul[contains(@class, 'pronunciations-list')]");
            foreach (var node in langsNode.ChildNodes)
            {
                if (i > 2)
                {
                    break;
                }

                var div = node.SelectSingleNode(".//div[contains(@class, 'play')]");
                if (div == null)
                    continue;

                var attrVal = div.GetAttributeValue("onclick", null);

                var urlPart2 = GetUrlPart(attrVal);
                var urlPart1 = "aHR0cHM6Ly9hdWRpbzEyLmZvcnZvLmNvbS9tcDMv".FromBase64();
                var url = urlPart1 + urlPart2;

                var data = await HttpHelper.LoadFile(url);
                expr.Sounds.Add(new Sound()
                {
                    Id = Guid.NewGuid(),
                    Data = data,
                    Hash = data.GetMd5Hash(),
                    Url = url
                });
                i++;

                await Task.Delay(new TimeSpan(0, 0, 0, 0, 100));
            }
        }

        private string GetUrlPart(string val)
        {
            var str64 = val.Split(',')[1].Trim('\'');
            return str64.FromBase64();
        }

        private string GetUrl(string token, string language)
        {
            return $"{"aHR0cHM6Ly9mb3J2by5jb20vd29yZC8=".FromBase64()}{token}/#{LangToUrlPart(language)}";
        }

        private string LangToUrlPart(string language)
        {
            switch (language)
            {
                case "english": return "en";
                case "german": return "de";
                case "italian": return "it";
                case "french": return "fr";
            }

            throw new ArgumentException();
        }

    }
}
