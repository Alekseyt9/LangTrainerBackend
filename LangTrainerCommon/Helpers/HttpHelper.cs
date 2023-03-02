namespace LangTrainerServices.Helpers
{
    public class HttpHelper
    {
        public static Task<string> GetHttpAsync(string url)
        {
            using var client = new HttpClient();
            return client.GetAsync(url).Result.Content.ReadAsStringAsync();
        }

        public static async Task<byte[]> LoadFile(string url)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(url);
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var data = stream.ToBytes();
                return data;
            }
        }

    }
}
