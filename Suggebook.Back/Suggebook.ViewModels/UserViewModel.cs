using System.Collections.Generic;
using SuggeBook.Domain.Model;

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
            public UserBook(Book book)
            {
                Id = book.Id;
                Title = book.Title;
                AuthorName = string.Empty;
                foreach (var author in book.Authors)
                {
                    AuthorName += $"{author.Name} ";
                }
            }

            public string Id { get; set; }

            public string Title { get; set; }

            public string AuthorName { get; set; }
        }

        public struct UserSuggestion
        {
            public UserSuggestion(Suggestion suggestion)
            {
                Title = suggestion.Title;
            }
            public string Title { get; set; }
        }

    }
}
