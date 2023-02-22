
using System.Reflection;

namespace LangTrainerServices.Helpers
{
    public class ResourcesHelper
    {
        public static string GetFromTextFile(Assembly asm, string uri)
        {
            //var assembly = Assembly.GetExecutingAssembly();
            using var stream = asm.GetManifestResourceStream(uri);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

    }
}
