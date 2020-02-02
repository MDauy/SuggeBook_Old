using Nito.AsyncEx;

namespace SuggeBookScrapper
{
    public class Program
    {
        //private static readonly GoogleBooks _googleBooks = new GoogleBooks();


        static void Main(string[] args)
        {
            BabelioScrapper bScrapper = new BabelioScrapper();
            AsyncContext.Run(() => bScrapper.Scrapp());
        }

        
    }
}
