using System;
using System.Threading.Tasks;

namespace SuggeBookScrapper
{
    public static class LogHelper
    {
        public static async Task LogAuthorError (string url, string error)
        {
            var errorLog = $"[{DateTime.Now.ToShortDateString()}] Error while creating author {url} : {error}";

            using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"../logs/AuthorLogs.txt"))
            {
                await file.WriteLineAsync(errorLog);
            }
        }

        public static async Task LogBookError (string url, string error)
        {
            var errorLog = $"[{DateTime.Now.ToShortDateString()}] Error while creating book {url} : {error}";

            using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"../logs/BooksLogs.txt"))
            {
                await file.WriteLineAsync(errorLog);
            }
        }

        public static async Task LogSagaError (string title, string error)
        {
            var errorLog = $"[{DateTime.Now.ToShortDateString()}] Error while creating saga {title} : error";

            using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"../logs/SagaLogs.txt"))
            {
                await file.WriteLineAsync(errorLog);
            }
        }
    }
}
