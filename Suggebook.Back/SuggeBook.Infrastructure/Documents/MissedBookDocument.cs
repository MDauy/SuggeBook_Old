using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Infrastructure.Documents
{
    public class MissedBookDocument : BaseDocument
    {
        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Url")]
        public string Url { get; set; }
    }
}
