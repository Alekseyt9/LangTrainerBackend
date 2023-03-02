
using System.Text;

namespace LangTrainerCommon.Helpers
{
    public static class StringHelper
    {
        public static string FromBase64(this string val)
        {
            var data = Convert.FromBase64String(val);
            var decodedString = Encoding.UTF8.GetString(data);
            return decodedString;
        }



    }
}
