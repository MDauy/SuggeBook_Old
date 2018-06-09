using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBookDataAccess.Dao
{
    public class Author
    {
        public ObjectId Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
    }
}
