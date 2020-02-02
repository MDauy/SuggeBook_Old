using HtmlAgilityPack;
using Newtonsoft.Json;
using Suggebook.ViewModels;
using SuggeBook.ViewModels;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
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
            var formattedName = Regex.Replace(RemoveDiacritics(name), @"\.| ", "-");
            var finalUrl = $"{ConfigurationManager.AppSettings["livraddict_author_url"]}{formattedName?.ToLower()}.html";
            Console.Write($"fetching {finalUrl}");
            try
            {
                using (var response = await UrlCallerHelper.CallUri_ReponseResult(HttpMethod.Get, finalUrl))
                {
                    Console.WriteLine($"response for {finalUrl} {response.StatusCode}");
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

                        Console.WriteLine($"Author createion : {authorToCreate.Name}");
                        var authorString = await UrlCallerHelper.CallUri_StringResult(HttpMethod.Post, ApiUrls.CREATE_AUTHOR, JsonConvert.SerializeObject(authorToCreate));
                        if (JsonConvert.DeserializeObject<AuthorViewModel>(authorString) != null)
                        {
                            Console.WriteLine($"Author {authorToCreate.Name} created !");
                            var htmlDocument = new HtmlDocument();
                            var pageContent = await response.Content.ReadAsStringAsync();
                            if (pageContent != null)
                            {
                                htmlDocument.LoadHtml(pageContent);
                                var tBody = htmlDocument.DocumentNode.SelectSingleNode("//table[contains(@id, 'bookAuthor')]//tbody[1]");

                                var sagaPosition = 1;
                                var curentSagaId = string.Empty;
                                var books = tBody.SelectNodes("tr");
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

                                        Console.WriteLine($"Saga {saga.Title} creation...");
                                        var jsonResult = await UrlCallerHelper.CallUri_StringResult(HttpMethod.Post, ApiUrls.CREATE_SAGA, JsonConvert.SerializeObject(saga));
                                        var resultVm = JsonConvert.DeserializeObject<HttpResultViewModel>(jsonResult);
                                        if (resultVm == null)
                                        {
                                            await LogHelper.LogSagaError(saga.Title, "Deserialization went wrong");
                                            break;
                                        }
                                        if (resultVm.HttpStatus != HttpStatusCode.Created)
                                        {
                                           await LogHelper.LogSagaError(saga.Title, resultVm.Message);
                                            break;
                                        }
                                        sagaPosition = 1;
                                        continue;
                                    }
                                    var bookTitle = bookElt.SelectSingleNode("td/a");
                                    if (bookTitle != null)
                                    {
                                        var bookUrl = bookTitle.GetAttributeValue("href", "");
                                        if (bookUrl != null)
                                        {
                                            await ScrappBookPage(bookUrl, sagaPosition, curentSagaId);
                                        }
                                        if (!string.IsNullOrEmpty(curentSagaId))
                                        {
                                            sagaPosition++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                await LogHelper.LogAuthorError(finalUrl, e.InnerException.Message);
                await UrlCallerHelper.CallUri_StringResult(HttpMethod.Post, ApiUrls.REGISTER_MISSED_AUTHOR, name);
            }
        }

        private async Task ScrappBookPage(string url, double sagaPosition, string sagaId = null)
        {
            try
            {
                var bookUrl = $"{ApiUrls.LIVRADDICT_BASE_URL}{url}";
                Console.WriteLine($"Fetching {bookUrl}");
                using (var response = await UrlCallerHelper.CallUri_ReponseResult(HttpMethod.Get, bookUrl))
                {
                    Console.WriteLine($"response for {bookUrl} {response.StatusCode.ToString()}");
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var pageContent = await response.Content.ReadAsStringAsync();
                        if (pageContent != null)
                        {
                            var viewModel = new CreateBookViewModel();
                            var htmlDocument = new HtmlDocument();
                            htmlDocument.LoadHtml(pageContent);

                            //TITLE
                            viewModel.Title = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'page-title')]/h1").InnerText;

                            //SYNOPSIS
                            viewModel.Synopsis = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@id, 'synopsis')]").ChildNodes[2]?.InnerText;

                            //CATEGORIES
                            var categoriesNodes = htmlDocument.DocumentNode.SelectNodes("//ul[contains(@class, 'sidebar-tags')]/li/a");
                            if (categoriesNodes != null && categoriesNodes.Count > 0)
                            {
                                viewModel.Categories = new System.Collections.Generic.List<string>();
                                foreach (var category in categoriesNodes)
                                {
                                    viewModel.Categories.Add(category.InnerText);
                                }
                            }

                            //COVER
                            var coverLink = htmlDocument.DocumentNode.SelectSingleNode("//a[contains(@class, 'couvertureLivre')]").Attributes["href"].Value;
                            if (coverLink != null)
                            {
                                using (WebClient webClient = new WebClient())
                                {
                                    byte[] cover = webClient.DownloadData(coverLink);
                                    if (cover.Length != 0)
                                    {
                                        viewModel.Cover = cover;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"No coverlink found for {viewModel.Title}");
                            }
                            viewModel.SagaId = sagaId;
                            viewModel.SagaPosition = sagaPosition;

                            var jsonResult = await UrlCallerHelper.CallUri_StringResult(HttpMethod.Post, ApiUrls.CREATE_BOOK, JsonConvert.SerializeObject(viewModel));

                        }
                    }
                }
            }
            catch (Exception e)
            {
                await LogHelper.LogBookError(url, e.InnerException.Message);
                await UrlCallerHelper.CallUri_StringResult (HttpMethod.Post, ApiUrls.REGISTER_MISSED_BOOK, url);
            }
        }

        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}
