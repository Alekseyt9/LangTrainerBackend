namespace LangTrainerServices.Helpers
{
    public class HttpHelper
    {
        public static Task<string> GetHttpAsync(string url)
        {
            using var client = new HttpClient();
            return client.GetAsync(url).Result.Content.ReadAsStringAsync();
        }

    }
}
