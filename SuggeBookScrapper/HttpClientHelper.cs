﻿using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuggeBookScrapper
{
    public static class HttpClientHelper
    {
        public static async Task<WebResponse> Call(UriBuilder builder, string method)
        {
            var request = WebRequest.Create(builder.Uri.ToString());
            request.Method = method;
            request.ContentType = "application/json; charset=utf-8";

            WebResponse response = await request.GetResponseAsync();

            return response;
        }

        public static async Task<string> CallWithJsonResponse(UriBuilder builder, string method)
        {
            var response = await Call(builder, method);
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
    }
}
