using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public abstract class BaseDocument
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id{ get; set; }
    }
}
