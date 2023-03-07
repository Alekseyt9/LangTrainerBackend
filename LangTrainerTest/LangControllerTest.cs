
using LangTrainerClientModel.Services.LangService;
using LangTrainerCommon.Helpers;
using LangTrainerEntity.Entities.Lang;
using LangTrainerServices.Services;
using Xunit;

namespace LangTrainerTest
{
    public class LangControllerTest
    {
        [Fact]
        public async Task GetTokenDataTest()
        {
            var token = "test";
            var lang = "english";

            var client = new HttpClient();
            Expression expr = null;
            var url = @$"https://localhost:44329/api/lang/gettokendata/?expression={token}&language={lang}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                expr = await response.Content.ReadAsAsync<Expression>();
            }

            Assert.NotNull(expr);
            Assert.NotNull(expr.Text);
            
            Assert.NotEmpty(expr.Translates);
            foreach (var tr in expr.Translates)
            {
                Assert.NotEmpty(tr.Samples);
            }

            Assert.NotEmpty(expr.Sounds);
            Assert.NotNull(expr.Language);
        }

        [Fact]
        public async void FindInDictionary()
        {
            var client = new HttpClient();
            var fModel = new FindModel()
            {
                SearchString = "test",
            };
            var url = @$"https://localhost:44329/api/lang/FindInDictionary/?SearchString={fModel.SearchString}&LanguageId={fModel.LanguageId}&TranslateLanguageId={fModel.TranslateLanguageId}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsAsync<FindResult>();
            }
        }

        [Fact]
        public async void GetLanguages()
        {
            var res = await WebClientHelper.Get<List<Language>>(@"https://localhost:44329/api/lang/GetLanguages");
        }

        [Fact]
        public async void GetTranslateLanguages()
        {
            var client = new HttpClient();
            var url = @$"https://localhost:44329/api/lang/GetTranslateLanguages";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsAsync<List<Language>>();
            }
        }

    }
}
