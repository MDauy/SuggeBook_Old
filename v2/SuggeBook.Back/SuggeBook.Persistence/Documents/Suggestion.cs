using SuggeBook.Infrastructure;
using System.Collections.Generic;

namespace SuggeBook.Persistence.Documents
{
    public class Suggestion : BaseDocument
    {
        public string Title { get; set; }

        public string BookTitle { get; set; }

        public string BookAuthor { get; set; }

        public string CreatorUsername { get; set; }

        public string OpinionText { get; set; }

        //A remplacer par un objet de type Category ?
        public IList<Category> Categories { get; set; }
    }
}
