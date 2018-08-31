using System.Collections.Generic;

namespace SuggeBook.Dto.Models
{
    /// <summary>
    /// User tel qu'on voudrait l'afficher sur sa page user
    /// </summary>
    public class User : BaseDto
    {
        public string UserName { get; set; }

        public List<Book> Books { get; set; }

        public List<Suggestion> Suggestions { get; set; }

        public List<string> FavoriteCategories{ get; set; }

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
        
        public struct Category
        {
            public string Label { get; set; }
        }
    }
}
