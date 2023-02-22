
using LangTrainerServices.Helpers;
using System.Reflection;
using Xunit;

namespace LangTrainerTest
{
    public class ResourcesHelperTest
    {
        [Fact]
        public void TestLoadText()
        {
            var str = ResourcesHelper.GetFromTextFile(
                Assembly.GetExecutingAssembly(), "LangTrainerTest.DataFillers.Data.TextFile1.txt");
            Assert.NotNull(str);
        }
    }
}
