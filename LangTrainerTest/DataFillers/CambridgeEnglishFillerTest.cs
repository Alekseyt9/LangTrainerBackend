
using HtmlAgilityPack;
using LangTrainerServices.Impl.DataFillers;
using Xunit;

namespace LangTrainerTest.DataFillers
{
    public class CambridgeEnglishFillerTest
    {
        [Fact]
        public async Task TestFull()
        {
            var f = new CambridgeEnglishLoader();
            var res = await f.GetData("face");

            Assert.NotNull(res);
        }

        [Fact]
        public async Task TestGetSound()
        {
            var web = new HtmlWeb();
            var doc = web.Load("https://dictionary.cambridge.org/dictionary/english-italian/face");

            var audioNode = doc.DocumentNode.SelectSingleNode("//audio[@id='audio2']/source[@type='audio/mpeg']");
            var url = audioNode.GetAttributeValue("src", null);
            var soundUrl = $"https://dictionary.cambridge.org{url}";

            using var client = new HttpClient();
            using var response = await client.GetAsync(soundUrl);
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                Assert.True(stream.Length > 0);
            }
        }

    }
}
