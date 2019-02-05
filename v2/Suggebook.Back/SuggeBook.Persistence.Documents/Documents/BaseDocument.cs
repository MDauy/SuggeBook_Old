using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggeBookDAL.Persistence.Documents
{
    public abstract class BaseDocument
    {
        [BsonId]
        [BsonElement("UserId")]
        public ObjectId Id{ get; set; }
    }
}
