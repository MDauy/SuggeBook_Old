using System.Collections.Generic;
using MongoDB.Bson;
using SuggeBook.Infrastructure;

namespace SuggeBook.Persistence
{
    public class BaseRepository<T> : IDataService<T>  where T : BaseDocument, new()
    {
        
        public 

        public bool Delete(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        public T Get(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        public T GetSeveral(IList<ObjectId> ids)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(T objectToInsert)
        {
            throw new System.NotImplementedException();
        }
    }
}
