using MongoDB.Bson;

namespace SuggeBookDAL.Dao
{
    public abstract class BaseDao
    {
        public ObjectId Id{ get; set; }
    }
}
