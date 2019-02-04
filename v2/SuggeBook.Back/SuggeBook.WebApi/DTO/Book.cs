using System;
using System.Collections.Generic;

namespace SuggeBook.WebApi.DTO
{
    public class Book
    {
        public string Title { get; set; }

        public string AuthorFullName { get; set; }

        public int NumberOfSuggestions { get; set; }

        public List<string> Categories { get; set; }

        public int Year { get; set; }

        public Guid ISBN { get; set; }
    }
}
