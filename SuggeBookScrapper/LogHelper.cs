using System;
using System.Threading.Tasks;

namespace SuggeBookScrapper
{
    public static class LogHelper
    {
        public static async Task LogAuthorError (string url, string error)
        {
            var errorLog = $"[{DateTime.Now.ToShortDateString()}] Error while parsing author {url} : {error}";

            using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"../logs/AuthorLogstxt"))
            {
                await file.WriteLineAsync(errorLog);
            }
        }

        public static async Task LogBookError (string url, string error)
        {
            var errorLog = $"[{DateTime.Now.ToShortDateString()}] Error while parsing book {url} : {error}";

            using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"../logs/BooksLogstxt"))
            {
                await file.WriteLineAsync(errorLog);
            }
        }
    }
}
