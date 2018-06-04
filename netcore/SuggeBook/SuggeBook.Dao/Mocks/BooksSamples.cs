using Bogus;
using SuggeBook.Dto.Models;
using System.Collections.Generic;

namespace SuggeBook.Dto.Mocks
{
    public static class BooksSamples
    {

        private static string[] _booksTitle;

        public static string[] BooksTitles
        {
            get
            {
                if (_booksTitle == null || _booksTitle.Length == 0)
                {
                    _booksTitle = new string[] { "Le Seigneur des anneaux", "Le vieil homme et la mer", "Les Misérables", "Madame Bovary", "Harry Potter" };
                }
                return _booksTitle;
            }
        }

        private static string[] _booksAuthors;

        public static string[] BooksAuthors
        {
            get
            {
                if (_booksAuthors == null || _booksAuthors.Length == 0)
                {
                    _booksAuthors = new string[] { "J.R.R Tolkien", "E. Hemingway", "Victor Hugo", "Gustave Flaubert", "J.K Rowling" };
                }
                return _booksAuthors;
            }
        }

        /// <summary>
        /// retourne un certain nombe de catégories au hasard
        /// </summary>
        /// <param name="categoriesNumber"></param>
        /// <returns></returns>
        public static List<string> GetCategories(int categoriesNumber)
        {
            var categories = new List<string>();
            var faker = new Faker();
            for (int i = 0; i < categoriesNumber - 1; i++)
            {
                var cat = faker.PickRandom<CategoryEnum>();

                if (!categories.Contains(cat.ToString()))
                {
                    categories.Add(cat.ToString());
                }
                else
                {
                    i--;
                }
            }

            return categories;
        }
    }

}
