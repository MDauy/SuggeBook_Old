using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SuggeBookDAL.Dao
{
    public class SuggestionDao : BaseDao
    {
        [BsonElement("UserId")]
        public ObjectId UserId { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("BookId")]
        public ObjectId BookId { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("Categories")]
        public List<string> Categories{ get; set; }

        [BsonElement("Creation_Date")]
        public DateTime CreationDate{ get; set; }
    }
}
