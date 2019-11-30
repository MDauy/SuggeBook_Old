
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SuggeBook.Domain.Model;

namespace SuggeBook.Infrastructure.Documents
{
    public abstract class BaseDocument
    {
        private string _id;

        [BsonId]
        [BsonElement("_id")]
        public ObjectId Oid{ get; set; }
    }
}
