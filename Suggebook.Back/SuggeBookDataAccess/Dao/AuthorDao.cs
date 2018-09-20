using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBookDAL.Dao
{
    public class AuthorDao : BaseDao
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
        public List<SuggestionDao> Suggestions { get; set; }

    }

}
