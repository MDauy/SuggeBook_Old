using System;
using System.Collections.Generic;

namespace SuggeBook.Persistence.Documents
{
    public class Book
    {
        public string Title { get; set; }

        public string AuthorFullName { get; set; }

        public int NumberOfSuggestions { get; set; }

        public List<Category> Categories { get; set; }

        public int Year { get; set; }

        public Guid ISBN { get; set; }
    }
}
