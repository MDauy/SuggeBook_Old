using System.Collections.Generic;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.ViewModels
{
    /// <summary>
    /// User tel qu'on voudrait l'afficher sur sa page user
    /// </summary>
    public class UserViewModel : BaseViewModel
    {
        public UserViewModel() { }

        public UserViewModel(User user)
        {
            Id = user.Id;
            UserName = user.Username;
            FavoriteCategories = user.FavoriteCategories;
        }

        public string UserName { get; set; }

        public List<UserBook> Books { get; set; }

        public IList<UserSuggestion> Suggestions { get; set; }

        public IList<string> FavoriteCategories{ get; set; }

        public struct UserBook
        {
            public UserBook(Book book)
            {
                Id = book.Id;
                AuthorName = book.Author.Name;
                Title = book.Title;
                
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
