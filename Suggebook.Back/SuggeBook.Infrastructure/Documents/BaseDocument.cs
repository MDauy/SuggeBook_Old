using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public abstract class BaseDocument
    {
        [BsonId]
        [BsonElement("UserId")]
        public ObjectId Id{ get; set; }
    }
}
