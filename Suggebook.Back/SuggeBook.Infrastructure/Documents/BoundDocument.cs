using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Infrastructure.Documents
{
    public class BoundDocument : BaseDocument
    {
        [BsonElement("ShowId")]
        public int ShowId { get; set; }

        [BsonElement("BookId")]
        public int BookId { get; set; }

        [BsonElement("Weight")]
        public int Weight { get; set; }
    }
}
