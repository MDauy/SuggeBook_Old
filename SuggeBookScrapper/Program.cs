using Newtonsoft.Json;
using Nito.AsyncEx;
using SuggeBook.ViewModels;
using System.Net.Http;

namespace SuggeBookScrapper
{
    public class Program
    {
        //private static readonly GoogleBooks _googleBooks = new GoogleBooks();


        static void Main(string[] args)
        {
            var missedSagaViewModel = new MissedSagaViewModel
            {
                Title = "hello from scrapper",
               Message = "oopsy",
                Url = "http://oopsy"
            };
            var result = AsyncContext.Run(() =>  UrlCallerHelper.CallUri_ReponseResult (HttpMethod.Post, ApiUrls.REGISTER_MISSED_BOOK, JsonConvert.SerializeObject(missedSagaViewModel)));
                if (!result.IsSuccessStatusCode)
                {
                     AsyncContext.Run(() =>LogHelper.LogBookError("http://oopsy", result.Content.ToString()));
                }

            //BabelioScrapper bScrapper = new BabelioScrapper();
            //AsyncContext.Run(() => bScrapper.Scrapp());
        }

        
    }
}
