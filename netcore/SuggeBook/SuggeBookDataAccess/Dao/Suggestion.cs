using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBookDataAccess.Dao
{
    public class Suggestion
    {
        public ObjectId Id { get; set; }

        [BsonElement("UserId")]
        public int UserId { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("BookId")]
        public int BookId { get; set; }

    }
}
