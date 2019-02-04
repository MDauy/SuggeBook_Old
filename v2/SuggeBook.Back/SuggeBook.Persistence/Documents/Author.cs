using System;
using System.Collections.Generic;

namespace SuggeBook.Domain
{
    public class Author
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Book> Books { get; set; }

        public struct Book
        {
            public Guid ISBN { get; set; }

            public string Title { get; set; }

            public int Year { get; set; }

            public string NumberOfSuggestions { get; set; }
        }
    }
}
