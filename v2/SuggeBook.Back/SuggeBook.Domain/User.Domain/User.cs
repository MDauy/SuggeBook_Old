using System.Collections.Generic;

namespace SuggeBook.Domain
{
    public class User
    {
        public string UserName { get; set; }

        public List<Book> Books { get; set; }

        public List<Suggestion> Suggestions { get; set; }

        public List<CategoryEnum> FavoriteCategories { get; set; }
    }
}
