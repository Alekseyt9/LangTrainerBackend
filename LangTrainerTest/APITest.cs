
using LangTrainerEntity.Entities.Lang;
using Xunit;

namespace LangTrainerTest
{
    public class APITest
    {
        [Fact]
        public async Task LoadExpressionTest()
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
            Assert.NotEmpty(expr.Samples);
            Assert.NotEmpty(expr.Translates);
            Assert.NotEmpty(expr.Sounds);
            Assert.NotNull(expr.Language);
        }


    }
}
