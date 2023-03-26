
using LangTrainerClientModel.Services;
using LangTrainerCommon.Helpers;
using LangTrainerEntity.Entities;
using LangTrainerServices.Services;
using Xunit;

namespace LangTrainerTest
{
    public class LangControllerTest
    {
        /*
        [Fact]
        public async Task GetTokenDataTest()
        {
            var token = "test";
            var lang = "english";

            var expr = await WebClientHelper.Get<Expression>(@"https://localhost:44329/api/Dictionary/GetTokenData",
                new Dictionary<string, object>()
                {
                    { "expression", token },
                    { "language", lang }
                });

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
        */

        /*
        [Fact]
        public async void FindInDictionary()
        {
            var fModel = new FindModel()
            {
                SearchString = "test",
            };

            var res = await WebClientHelper.Get<FindResult>(@"https://localhost:44329/api/Dictionary/FindInDictionary",
                new Dictionary<string, object>()
                {
                    { "SearchString", fModel.SearchString },
                    { "LanguageId", fModel.LanguageId },
                    { "TranslateLanguageId", fModel.TranslateLanguageId }
                });

            Assert.NotNull(res);
        }
        */

        /*
        [Fact]
        public async void GetLanguages()
        {
            var res = await WebClientHelper.Get<List<Language>>(@"https://localhost:44329/api/Dictionary/GetLanguages");
            Assert.NotNull(res);
            Assert.True(res.Count > 0);
        }

        [Fact]
        public async void GetTranslateLanguages()
        {
            var res = await WebClientHelper.Get<List<Language>>(@"https://localhost:44329/api/Dictionary/GetTranslateLanguages");
            Assert.NotNull(res);
            Assert.True(res.Count > 0);
        }
        */

    }
}
