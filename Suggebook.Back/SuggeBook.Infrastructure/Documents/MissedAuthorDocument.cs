using MongoDB.Bson.Serialization.Attributes;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public class MissedAuthorDocument : BaseDocument
    {
        public MissedAuthorDocument() { }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("TriedUrl")]
        public string TriedUrl { get; set; }

        [BsonElement("StatusCode")]
        public string StatusCode { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }
    }
}
