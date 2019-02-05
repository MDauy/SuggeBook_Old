using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace SuggeBook.Infrastructure
{
    public interface IDataService<T, S>
    {
        T Get(ObjectId id);
        T GetSeveral(IList<ObjectId> ids);

        bool Insert(T objectToInsert);

        bool Delete(ObjectId id);
    }
}
