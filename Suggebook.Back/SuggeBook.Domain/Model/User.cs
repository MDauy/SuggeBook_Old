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
        public string Firstname{ get; set; }
        public string Lastname { get; set; }
        public string Email{ get; set; }      
        public string Username { get; set; }
        public IList<string> FavoriteCategories { get; set; }
        public override bool TestValidation()
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
