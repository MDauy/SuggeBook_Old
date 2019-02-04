using System;
using System.Collections.Generic;

namespace SuggeBook.Domain
{
    public class Book
    {
        public string Title { get; set; }

        public Author AuthorFullName { get; set; }

        public int NumberOfSuggestions { get; set; }

        public List<CategoryEnum> Categories { get; set; }

        public int Year { get; set; }

        public Guid ISBN { get; set; }
    }
}
