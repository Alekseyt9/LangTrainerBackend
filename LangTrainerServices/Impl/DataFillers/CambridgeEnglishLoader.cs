
using System.Text;
using HtmlAgilityPack;
using LangTrainerEntity.Entities.Lang;
using LangTrainerServices.Helpers;
using LangTrainerServices.Model.DataFillers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LangTrainerServices.Impl.DataFillers
{
    [DataLoader("dictionary.cambridge.org_eng", "english")]
    internal class CambridgeEnglishLoader : IDataLoader
    {
        public async Task<Expression> GetData(string token, string language)
        {
            var expr = new Expression()
            {
                Text = token,
                Language = new Language()
                {
                    Name = "english"
                }
            };

            var web = new HtmlWeb();
            var doc = web.Load($"https://dictionary.cambridge.org/dictionary/english/{token}");

            LoadTranslates(doc, expr);
            //LoadSamples(doc, expr);
            await LoadSounds(doc, expr);

            return expr;
        }

        private void LoadTranslates(HtmlDocument doc, Expression expr)
        {
            var meanNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'dsense')]");
            var defNode = meanNode.SelectSingleNode(".//div[contains(@class, 'ddef_d')]");
            var tr = new Translate()
            {
                Language = new Language() { Name = "english" },
                Text = GetText(defNode)
            };
            expr.Translates.Add(tr);

            LoadSamples(meanNode, tr);
        }

        private void LoadSamples(HtmlNode meanNode, Translate tr)
        {
            //var meanNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'dsense')]");
            var exsNode = meanNode.SelectSingleNode(".//div[contains(@class, 'ddef_b')]");
            var exNodes = exsNode.SelectNodes(".//span[contains(@class, 'eg deg')]");
            foreach (var child in exNodes)
            {
                tr.Samples.Add(new Sample()
                {
                    Text = GetText(child)
                });
            }
        }

        private string GetText(HtmlNode node)
        {
            var sb = new StringBuilder(node.InnerHtml.Length);
            foreach (var child in node.ChildNodes)
            {
                sb.Append(child.InnerHtml);
            }

            return sb.ToString();
        }

        private async Task LoadSounds(HtmlDocument doc, Expression expr)
        {
            var audioNode = doc.DocumentNode.SelectSingleNode("//audio[@id='audio2']/source[@type='audio/mpeg']");
            var url = audioNode.GetAttributeValue("src", null);
            var soundUrl = $"https://dictionary.cambridge.org{url}";

            var data = await HttpHelper.LoadFile(soundUrl);
            expr.Sounds.Add(new Sound()
            {
                Id = Guid.NewGuid(),
                Data = data,
                Hash = data.GetMd5Hash(),
                Url = soundUrl
            });

        }

    }
}
