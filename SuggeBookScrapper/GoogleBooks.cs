using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SuggeBook.Api.ViewModels;
using SuggeBookScrapper.JsonObjects;

namespace SuggeBookScrapper
{
    public class GoogleBooks
    {
        private string _baseUrl = "https://www.googleapis.com/books/v1/volumes";
        public async void GetAuthorBooks(string authorName, int authorBabelioId)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters["q"] = $"inauthor:\"{authorName}\"";
            parameters["langRestrict"] = "\"fr\"";

            UriBuilder builder = new UriBuilder(_baseUrl)
            {
                Query = parameters.ToString()
            };
            string trimmedResponse = await HttpClientHelper.CallWithJsonResponse(builder, "GET");
            if (trimmedResponse != null)
            {
                RootObject responseObject = JsonConvert.DeserializeObject<RootObject>(trimmedResponse);
                CreateAuthorViewModel authorViewModel = new CreateAuthorViewModel()
                {
                    BabelioId = authorBabelioId.ToString(),
                    Name = authorName
                };
                var author = await RegisterAuthor(authorViewModel);

                foreach (var item in responseObject.Items)
                {
                    await Registerbook(CreateBookViewModel(item, author));
                }
            }

        }

        private async Task<BookViewModel> Registerbook (CreateBookViewModel book)
        {
            UriBuilder builder = new UriBuilder();
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["book"] = JsonConvert.SerializeObject(book);
            builder.Query = parameters.ToString();

            var result = await HttpClientHelper.CallWithJsonResponse(builder, "POST");
            return JsonConvert.DeserializeObject<BookViewModel>(result);
        }


        private async Task<AuthorViewModel> RegisterAuthor (CreateAuthorViewModel author)
        {
            UriBuilder builder = new UriBuilder($"{ConfigurationManager.AppSettings["sbapi_url"]}/author/create");
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["author"] = JsonConvert.SerializeObject(author);
            builder.Query = parameters.ToString();

            var result = await HttpClientHelper.CallWithJsonResponse(builder, "POST");
            return JsonConvert.DeserializeObject<AuthorViewModel>(result);
        }

        private CreateBookViewModel CreateBookViewModel(Item item, AuthorViewModel author)
        {
            var bookVieWModel = new CreateBookViewModel
            {
               Isbn10 = item.VolumeInfo.IndustryIdentifiers.FirstOrDefault(i => string.Equals(i.Type, "ISBN_10"))?.Type,
               Isbn13 = item.VolumeInfo.IndustryIdentifiers.FirstOrDefault(i => string.Equals(i.Type, "ISBN_13"))?.Type,
               Title = item.VolumeInfo.Title,
               Year = DateTime.Parse(item.VolumeInfo.PublishedDate),
               AuthorId = author.Id
            };

            return bookVieWModel;
        }
    }
}
