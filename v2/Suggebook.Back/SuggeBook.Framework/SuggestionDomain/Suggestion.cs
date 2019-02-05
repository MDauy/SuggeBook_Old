using SuggeBook.Domain.BookDomain;
using SuggeBook.Domain.UserDomain;
using System;
using System.Collections.Generic;

namespace SuggeBook.Domain.SuggestionDomain
{
    public class Suggestion
    {
        public string Title { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public IList<string> Categories { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
