using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBookDAL.Dao
{
    public class Suggestion
    {
        public ObjectId Id { get; set; }

        [BsonElement("UserId")]
        public ObjectId UserId { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("BookId")]
        public ObjectId BookId { get; set; }

    }
}
