using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggeBookDAL.Dao
{
    public abstract class BaseDao
    {
        [BsonId]
        public ObjectId Id{ get; set; }
    }
}
