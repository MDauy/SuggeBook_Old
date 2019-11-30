using Nito.AsyncEx;

namespace SuggeBookScrapper
{
    public class Program
    {
        private static readonly GoogleBooks _googleBooks = new GoogleBooks();


        static void Main(string[] args)
        {
            LivraddictScrapper laScrapper = new LivraddictScrapper();
            AsyncContext.Run(() => laScrapper.ScrappAuthorPage("Katherine Pancol"));

        }

        
    }
}
