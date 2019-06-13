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

        static async void MainAsync(string[] args)
        {
            var index = 1;

            var baseUrl = "https://www.babelio.com/auteur/xx/";
            var url = $"{baseUrl}{index}";

            //var proxy = new WebProxy()
            //{
            //    Address = new Uri("http://127.0.0.1:8888")
            //};

            var handler = new HttpClientHandler();

            using (handler)
            {
                handler.AllowAutoRedirect = true;
                using (HttpClient httpClient = new HttpClient(handler))
                    while (index < 30)
                    {
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
                        using (var response = await httpClient.SendAsync(request))
                        {
                            //checker response.RequestMessage
                            var uri = response.RequestMessage.RequestUri;
                            if (string.Equals(uri, "https://babelio.com"))
                            {
                                index++;
                                continue;
                            }
                            else
                            {
                                var content = await httpClient.GetStringAsync(uri);
                                Console.WriteLine(content);
                                //Récupérer le nom
                                //appeler la google api
                                Console.ReadLine();
                                index++;
                            }
                        }
                    }
            }
        }
    }
}
