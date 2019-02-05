using System.Collections.Generic;
using SuggeBook.Domain.AuthorDomain;

namespace SuggeBook.Domain.BookDomain
{
    public class Book
    {
        public string Title { get; set; }
        public string Edition { get; set; }
        public string ISBN { get; set; }
        public List<string> Categories { get; set; }
        public Author Author { get; set; }
    }
}
