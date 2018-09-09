using System.Collections.Generic;

namespace SuggeBookDAL.Dao
{
    public class UserDao : BaseDao
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public List<string> FavoriteCategories { get; set; }

        public string Mail { get; set; }

        public string Pseudo { get; set; }
    }
}
