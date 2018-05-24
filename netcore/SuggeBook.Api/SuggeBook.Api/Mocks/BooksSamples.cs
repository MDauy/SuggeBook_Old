using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Api.Mocks
{
    public static class BooksSamples
    {

        private static string[] _booksTitle;

        public static string[] BooksTitles
        {
            get
            {
                if (_booksTitle == null ||_booksTitle.Length == 0)
                {
                    _booksTitle =  new string[] { "Le Seigneur des anneaux", "Le vieil homme et la mer", "Les Misérables", "Madame Bovary", "Harry Potter" };
                }
                return _booksTitle;
            }
        }

        private static string[] _booksAuthors;

        public static string[] BooksAuthors
        {
            get
            {
                if (_booksTitle == null || _booksTitle.Length == 0)
                {
                    _booksTitle = new string[] { "J.R.R Tolkien", "E. Hemingway", "Victor Hugo", "Gustave Flaubert", "J.K Rowling" };
                }
                return _booksTitle;
            }
        }
    }
}
