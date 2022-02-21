using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SuggeBook.Infrastructure.Documents
{
    public class ShowDocument : OeuvreDocument
    {
        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("ShowType")]
        public string ShowType { get; set; }

        [BsonElement("Categories")]
        public IEnumerable<string> Categories { get; set; }
    }
}
