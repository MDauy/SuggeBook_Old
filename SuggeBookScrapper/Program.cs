using Nito.AsyncEx;
using System;
using System.Net;
using System.Net.Http;

namespace SuggeBookScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));

        }

        static async void MainAsync (string[] args)
        {
            var index = 1;

            var baseUrl = "https://www.babelio.com/auteur/xx/";
            var url = $"{baseUrl}{index}";

            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.AllowAutoRedirect = false;
                using (HttpClient httpClient = new HttpClient(handler))
                    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url))
                using (var response = await httpClient.SendAsync(request))
                {
                    var location = response.Headers.Location;
                }
            }


                //    var httpClient = new HttpClient();
                //var response = await httpClient.GetAsync(url);
                /*var html = await httpClient.GetStringAsync($"{baseUrl}{index}")*/
                
            index++;

        }
    }
}
