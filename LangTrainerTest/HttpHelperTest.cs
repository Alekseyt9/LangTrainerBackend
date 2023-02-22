using LangTrainerServices.Helpers;
using Xunit;

namespace LangTrainerTest
{
    public class HttpHelperTest
    {
        [Fact]
        public async void Test()
        {
            var res = await HttpHelper.GetHttpAsync(
                "https://dictionary.cambridge.org/dictionary/english-italian/face");
            Assert.NotNull(res);
        }
    }
}
