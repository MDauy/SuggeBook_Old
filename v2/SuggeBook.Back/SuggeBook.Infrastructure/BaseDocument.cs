using MongoDB.Bson;

namespace SuggeBook.Infrastructure
{
    public abstract class BaseDocument
    {
        public ObjectId Id{ get; set; }
    }
}
