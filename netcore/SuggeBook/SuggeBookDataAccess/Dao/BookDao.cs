using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SuggeBookDataAccess.Dao
{
    public class BookDao
    {
        public ObjectId Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("AuthorId")]
        public int AuthorId { get; set; }

        [BsonElement("Edition")]
        public string Edition { get; set; }       

    }
}
