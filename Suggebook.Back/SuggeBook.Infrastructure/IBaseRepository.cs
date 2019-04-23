﻿using MongoDB.Bson;
using SuggeBookDAL.Persistence.Documents;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuggeBook.Infrastructure
{
    public interface IBaseRepository<T>
    {
        string GetCollectionName(BaseDocument document);

        Task<T> Get(ObjectId id);

        Task<List<T>> Get(Expression<Func<T, bool>> expression);

        Task<T> Insert(T document);

        Task<bool> Delete(T document);

        Task<bool> Update(T document);

        Task<IList<T>> GetSeveral(IList<ObjectId> ids);
    }
}
