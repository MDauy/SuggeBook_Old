using System.Net.Http;
using System.Threading.Tasks;

namespace SuggeBookScrapper
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> Call(string url)
        {
            var handler = new HttpClientHandler();
            using (handler)
            {
                handler.AllowAutoRedirect = true;
                using (HttpClient httpClient = new HttpClient(handler))
                {
                    var response = await httpClient.GetAsync((url));

                    return response;

                }
            }
        }
    }
}
