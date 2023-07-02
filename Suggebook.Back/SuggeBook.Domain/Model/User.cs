using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Domain.Model
{
    public class User : BaseModel
    {
        public User()
        {
            WrongProperties = string.Empty;
        }

        public User(string firstName, string lastName, string email, string userName)
        {
            this.Firstname = firstName;
            this.Lastname = lastName;
            this.Email = email;
            this.Username = userName;
        }
        public string Firstname { get; }
        public string Lastname { get; }
        public string Email { get; }
        public string Username { get; }
        public IList<string> FavoriteCategories { get; set; }
        public IList<Book> LikedBooks { get; set; }
        public IList<Show> LikedShows { get; set; }
        // Users to whom user is subscribed
        public IList<User> SubscribtionsTo{ get; set; }

        public override bool TestCreationValidation()
        {
            if (string.IsNullOrEmpty(Email))
            {
                WrongProperties += "Mail is null or empty";
            }

            if (string.IsNullOrEmpty(Username))
            {
                WrongProperties += "UserName is null or empty";
            }

            return TestWrongProperties();
        }
    }
}
