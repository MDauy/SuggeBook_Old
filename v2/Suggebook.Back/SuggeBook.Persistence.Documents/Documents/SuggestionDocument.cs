using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SuggeBookDAL.Persistence.Documents
{
    public class SuggestionDocument : BaseDocument
    {
        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("BookId")]
        public ObjectId BookId { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("Categories")]
        public List<string> Categories { get; set; }

        [BsonElement("Creation_Date")]
        public DateTime CreationDate { get; set; }
    }
}
