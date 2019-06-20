using System;
using System.Collections.Generic;
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
                            //Inscrire le nom loupé dans la base
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
