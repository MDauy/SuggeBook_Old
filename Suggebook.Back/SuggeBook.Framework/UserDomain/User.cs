using System.Collections.Generic;

namespace SuggeBook.Domain.UserDomain
{
    public class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<string> FavoriteCategories { get; set; }
        public string Mail { get; set; }
        public string UserName { get; set; }
    }
}
