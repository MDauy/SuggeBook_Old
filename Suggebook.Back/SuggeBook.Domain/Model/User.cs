using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Domain.Model
{
    public class User : Oeuvre
    {
        public User()
        {
            WrongProperties = string.Empty;
        }
        public string Firstname{ get; set; }
        public string Lastname { get; set; }
        public string Email{ get; set; }      
        public string Username { get; set; }
        public IList<string> FavoriteCategories { get; set; }
        public IList<Book> LikedBooks { get; set; }
        public IList<Show> LikedShows { get; set; }
        // Users to whom user is subscribed
        public IList<User> SubscribtionsTo{ get; set; }

        public override void IsValid()
        {
            if (string.IsNullOrEmpty(Email))
            {
                WrongProperties += "Mail is null or empty";
            }

            if (string.IsNullOrEmpty(Username))
            {
                WrongProperties += "UserName is null or empty";
            }

            TestWrongProperties();
        }
    }
}
