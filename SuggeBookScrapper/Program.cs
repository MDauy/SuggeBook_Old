using HtmlAgilityPack;
using Nito.AsyncEx;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;

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
