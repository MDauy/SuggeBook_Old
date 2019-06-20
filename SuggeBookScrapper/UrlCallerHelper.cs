using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuggeBookScrapper
{
    public static class UrlCallerHelper
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

        public static async Task<string> CallWithJsonResponse(string url, NameValueCollection parameters, string method, string body = null)
        {
            var builder = new UriBuilder(url);
            if (parameters != null)
            {
                builder.Query = parameters.ToString();
            }

            return await CallWithJsonResponse(builder, method, body);
        }

        public static async Task<string> CallUri_StringResult (HttpMethod method, string url, string body = null, NameValueCollection queryString = null)
        {
            var response = await CallUri_ReponseResult(method, url, body, queryString);
            var responseText =  await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception ($"Call {url} went wrong with status code {response.StatusCode} : {responseText}");
            }

            return responseText;
        }

        public static async Task<HttpResponseMessage> CallUri_ReponseResult(HttpMethod method, string url, string body = null, NameValueCollection queryString = null)
        {
            var handler = new HttpClientHandler();
            using (handler)
            {
                handler.AllowAutoRedirect = true;
                using (HttpClient httpClient = new HttpClient(handler))
                {
                    var builder = new UriBuilder (url);
                    if (queryString != null)
                        {
                            builder.Query = queryString.ToString();
                        }
                    using (HttpRequestMessage request = new HttpRequestMessage(method, url))
                    {
                        if (body != null)
                        {
                            request.Content = new StringContent(
                                body.ToString(),
                                Encoding.UTF8,
                                "application/json"
                                );
                        }
                        return await httpClient.SendAsync(request);
                    }
                }
            }
        }
    }
}
