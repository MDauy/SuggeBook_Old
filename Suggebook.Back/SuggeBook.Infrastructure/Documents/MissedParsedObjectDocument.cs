using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Infrastructure.Documents
{
    public abstract class MissedParsedObjectDocument : BaseDocument
    {
        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Url")]
        public string Url { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }
    }
}
