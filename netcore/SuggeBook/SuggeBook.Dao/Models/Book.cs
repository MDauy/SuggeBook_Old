using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Dto.Models
{
    public class Book
    {
        public string Title { get; set; }

        public string AuthorFullName { get; set; }

        public int NumberOfSuggestions { get; set; }

        public List<string> Categories { get; set; }

        public Guid ISBN { get; set; }
    }

}
