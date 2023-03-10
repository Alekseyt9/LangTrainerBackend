
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

        public static string WrapText(string text, int lengthWrap)
        {
            var tText = text.Split(' ');
            var rText = "";
            var finalText = "";

            for (int i = 0; i < tText.Length; i++)
            {
                if (rText.Length < lengthWrap)
                {
                    rText += tText[i] + " ";
                }
                else
                {
                    finalText += rText + "\n";
                    rText = tText[i] + " ";
                }

                if (tText.Length == i + 1)
                {
                    finalText += rText;
                }
            }

            return finalText;
        }
    }
}
