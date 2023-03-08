

using System.Text;

namespace LangTrainerCommon.Helpers
{
    public static class WebClientHelper
    {
        private static readonly HttpClient _client = new();

        public static async Task<T> Get<T>(string url, Dictionary<string, object> pars)
        {
            var sb = new StringBuilder();
            if (pars.Count > 0)
            {
                sb.Append("?");
            }

            var first = true;
            foreach (var pair in pars)
            {
                if (pair.Value != null)
                {
                    if (!first)
                    {
                        sb.Append("&");
                    }
                    sb.Append($@"{pair.Key}={pair.Value.ToString()}");
                }

                first = false;
            }

            return await Get<T>(url + sb);
        }

        public static async Task<T> Get<T>(string url)
        {
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsAsync<T>();
                return res;
            }

            return default;
        }

    }
}
