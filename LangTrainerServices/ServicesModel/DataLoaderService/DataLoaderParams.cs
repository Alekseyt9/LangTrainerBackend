

namespace LangTrainerServices.Services
{
    internal class DataLoaderParams
    {
        public DataLoaderParams(string token, string language)
        {
            Token = token;
            Language = language;
        }

        public string Token { get; set; }

        public string Language { get; set; }
    }
}
