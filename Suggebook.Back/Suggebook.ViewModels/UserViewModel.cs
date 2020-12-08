using System.Collections.Generic;

namespace SuggeBook.ViewModels
{
    /// <summary>
    /// User tel qu'on voudrait l'afficher sur sa page user
    /// </summary>
    public class UserViewModel : BaseViewModel
    {
        public UserViewModel() { }


        public string UserName { get; set; }

        public List<UserBook> Books { get; set; }

        public IList<UserSuggestion> Suggestions { get; set; }

        public IList<string> FavoriteCategories { get; set; }

        public struct UserBook
        {
            public UserBook(string id, string title)
            {
                Id = id;
                Title = title;
                AuthorName = string.Empty;
            }

            public string Id { get; set; }

            public string Title { get; set; }

            public string AuthorName { get; set; }
        }

        public struct UserSuggestion
        {
            public UserSuggestion(string title)
            {
                Title = title;
            }
            public string Title { get; set; }
        }

    }
}
