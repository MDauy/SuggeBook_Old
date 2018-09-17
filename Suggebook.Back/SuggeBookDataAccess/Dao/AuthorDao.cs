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
        
        public List<Suggestion> Suggestions { get; set; }

        public struct Suggestion
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Username { get; set; }
            public ObjectId SuggestionId { get; set; }
        }
    }

}
