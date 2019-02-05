using SuggeBook.Domain.SuggestionDomain;

namespace SuggeBook.Domain.AuthorDomain
{
    public class Author
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int NbSuggestions { get; set; }

    }
}
