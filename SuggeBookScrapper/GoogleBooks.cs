using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using SuggeBookScrapper.JsonObjects;

namespace SuggeBookScrapper
{
    public class GoogleBooks
    {
        private string _baseUrl = "https://www.googleapis.com/books/v1/volumes";
        public void GetAuthorBooks(string authorName)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters["q"] = $"inauthor:\"{authorName}\"";
            parameters["langRestrict"] = "\"fr\"";

            UriBuilder builder = new UriBuilder(_baseUrl)
            {
                Query = parameters.ToString()
            };

            var request = WebRequest.Create(builder.Uri.ToString());
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            WebResponse response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            if (dataStream != null)
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseString = reader.ReadToEnd();
                var trimmedResponse = Regex.Replace(responseString, @"\t|\n|\r", "");
                RootObject responseObject = JsonConvert.DeserializeObject<RootObject>(trimmedResponse);
            }

        }
    }
}
