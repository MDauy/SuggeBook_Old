using System.Collections.Generic;

namespace SuggeBook.Domain
{
    public class Suggestion
    {
        public string Title { get; set; }

        public Book Book { get; set; }

        public Author BookAuthor { get; set; }

        public User CreatorUsername { get; set; }

        public string OpinionText { get; set; }

        //A remplacer par un objet de type Category ?
        public IList<CategoryEnum> Categories { get; set; }
    }
}
