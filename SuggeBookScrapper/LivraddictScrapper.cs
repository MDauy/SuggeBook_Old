using Newtonsoft.Json;
using SuggeBook.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuggeBookScrapper
{
    public class LivraddictScrapper
    {
        private const string AUTHORS_URL = "https://www.livraddict.com/biblio/auteur";
        private const string BOOK_URL = "";

        public LivraddictScrapper()
        {
        }

        public async Task ScrappAuthorPage(string name)
        {
            var formattedName = Regex.Replace(name, @"\.| ", "-");
            var finalUrl = $"{AUTHORS_URL}/{formattedName}.html";
            var handler = new HttpClientHandler();
            using (handler)
            {
                handler.AllowAutoRedirect = true;
                using (HttpClient httpClient = new HttpClient(handler))
                {
                    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUrl))
                        using (var response = await httpClient.SendAsync(request))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            var missedAuthorViewModel = new RegisterMissedAuthorViewModel
                            {
                                Name = name,
                                Message = response.RequestMessage.ToString(),
                                StatusCode = response.StatusCode.ToString(),
                                TriedUrl = finalUrl
                            };

                            var registeringUrl = $"{ConfigurationManager.AppSettings["register_missed_author_url"]}";
                            Console.WriteLine(await HttpClientHelper.CallWithJsonResponse(registeringUrl, null, "GET", JsonConvert.SerializeObject(missedAuthorViewModel)));
                        }
                        else
                        {
                            //scrapper la page des auteurs
                        }
                    }
                }
            }
        }

        public void ScrappBookPage()
        {

        }

    }
}
