using System.Collections.Generic;

namespace SuggeBook.Api.Dto
{
    /// <summary>
    /// User tel qu'on voudrait l'afficher sur sa page user
    /// </summary>
    public class UserViewModel : BaseViewModel
    {
        public string UserName { get; set; }

        public List<UserBook> Books { get; set; }

        public List<UserSuggestion> Suggestions { get; set; }

        public List<CategoryEnum> FavoriteCategories{ get; set; }

        public struct UserBook
        {
            public string Id { get; set; }

            public string Title { get; set; }

            public string AuthorFullName { get; set; }

            public int Year { get; set; }
        }
    
        public struct UserSuggestion
        {
            public string Title { get; set; }

            public string BookTitle { get; set; }
        }  
        
        public struct UserCategory
        {
            public string Label { get; set; }
        }
    }
}
