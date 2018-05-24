using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Mocks
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
                    _booksTitle =  new string[] { "Le Seigneur des anneaux", "Le vieil homme et la mer", "Les Misérables", "Madame Bovary", "HarryPotter" };
                }
                return _booksTitle;
            }
        }
    }
}
