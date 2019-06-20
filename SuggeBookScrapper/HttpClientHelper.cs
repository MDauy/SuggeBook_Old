using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuggeBookScrapper
{
    public static class HttpClientHelper
    {
        public static async Task<WebResponse> Call(UriBuilder builder, string method, string body = null)
        {
            var request = WebRequest.Create(builder.Uri.ToString());
            request.Method = method;
            request.ContentType = "application/json; charset=utf-8";

            if (!string.IsNullOrEmpty(body))
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(body);
                }
            }

            WebResponse response = await request.GetResponseAsync();

            return response;
        }

        public static async Task<string> CallWithJsonResponse(UriBuilder builder, string method, string body = null)
        {
            var response = await Call(builder, method, body);
            var dataStream = response.GetResponseStream();
            if (dataStream != null)
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseString = reader.ReadToEnd();
                var trimmedResponse = Regex.Replace(responseString, @"\t|\n|\r", "");
                return trimmedResponse;
            }
            return null;
        }

        public static async Task<string> CallWithJsonResponse (string url, NameValueCollection parameters, string method, string body = null)
        {
            var builder = new UriBuilder (url);
            if (parameters != null)
            {
                builder.Query = parameters.ToString();
            }

            return await CallWithJsonResponse(builder, method, body);
        }
    }
}
