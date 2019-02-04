using System.Collections.Generic;

namespace SuggeBook.Persistence.Documents
{
    public class User
    {
        public string UserName { get; set; }

        public List<Book> Books { get; set; }

        public List<Suggestion> Suggestions { get; set; }

        public List<Category> FavoriteCategories { get; set; }

        public struct Book
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public string AuthorFullName { get; set; }

            public int Year { get; set; }
        }

        public struct Suggestion
        {
            public string Title { get; set; }

            public string BookTitle { get; set; }
        }
    }
}
