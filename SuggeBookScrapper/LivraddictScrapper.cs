using HtmlAgilityPack;
using Newtonsoft.Json;
using SuggeBook.Api.ViewModels;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuggeBookScrapper
{
    public class LivraddictScrapper
    {
        public LivraddictScrapper()
        {
        }

        public async Task ScrappAuthorPage(string name)
        {
            var formattedName = Regex.Replace(name, @"\.| ", "-");
            var finalUrl = $"{ConfigurationManager.AppSettings["livraddict_author_url"]}{formattedName.ToLower()}.html";
            using (var response = await UrlCallerHelper.CallUri_ReponseResult(HttpMethod.Get, finalUrl))
            {
                //Auteur non trouvé
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var missedAuthorViewModel = new MissedAuthorViewModel
                    {
                        Name = name,
                        Message = response.RequestMessage.ToString(),
                        StatusCode = response.StatusCode.ToString(),
                        TriedUrl = finalUrl
                    };

                    Console.WriteLine(await UrlCallerHelper.CallUri_StringResult(HttpMethod.Post, ApiUrls.REGISTER_MISSED_AUTHOR, JsonConvert.SerializeObject(missedAuthorViewModel)));
                }
                //Auteur trouvé
                else
                {
                    //Création de l'auteur
                    var authorToCreate = new CreateAuthorViewModel
                    {
                        Name = name
                    };
                    var authorString = await UrlCallerHelper.CallUri_StringResult(HttpMethod.Post, ApiUrls.CREATE_AUTHOR, JsonConvert.SerializeObject(authorToCreate));
                    if (JsonConvert.DeserializeObject<AuthorViewModel>(authorString) != null)
                    {
                        var htmlDocument = new HtmlDocument();
                        var pageContent = await response.Content.ReadAsStringAsync();
                        if (pageContent != null)
                        {
                            htmlDocument.LoadHtml(pageContent);
                            var tBody = htmlDocument.DocumentNode.SelectSingleNode("//table[contains(@id, 'bookAuthor')]//tbody[1]");

                            var sagaPosition = 1;
                            var curentSagaId = string.Empty;
                            var books = tBody.SelectNodes("//tr");
                            foreach (var bookElt in books)
                            {
                                var sagaH3 = bookElt.SelectSingleNode("td/h3[contains(@class, 'author_saga_title')]");
                                if (sagaH3 != null)
                                {
                                    var saga = new CreateSagaViewModel
                                    {
                                        Title = sagaH3.InnerText
                                    };
                                    //Création de la saga
                                    try
                                    {
                                        var jsonResult = await UrlCallerHelper.CallUri_StringResult(HttpMethod.Post, ApiUrls.CREATE_SAGA, JsonConvert.SerializeObject(saga));
                                        curentSagaId = JsonConvert.DeserializeObject<SagaViewModel>(jsonResult).Id;
                                        sagaPosition = 1;
                                        continue;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    };
                                }
                                var bookTitle = bookElt.SelectSingleNode("td/a");
                                if (bookTitle != null)
                                {
                                    var bookUrl = bookTitle.GetAttributeValue("href", "");
                                    if (bookUrl != null)
                                    {
                                        await ScrappBookPage(bookUrl, bookTitle.InnerText, sagaPosition, curentSagaId);
                                    }
                                }
                            }
                        }
                        //scrapper la page des auteurs
                    }
                }
            }
        }

        private async Task ScrappBookPage(string url, string bookTitle, double sagaPositionl, string sagaId = null)
        {
            var bookUrl = $"{ApiUrls.LIVRADDICT_BASE_URL}{url}";
            using (var response = await UrlCallerHelper.CallUri_ReponseResult(HttpMethod.Get, bookUrl))
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {

                }
            }
        }

    }
}
