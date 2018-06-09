using MongoDB.Bson;
using SuggeBookDataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDataAccess.DataServices
{
    public interface ISuggestionDataService
    {
        Task<Suggestion> Get(ObjectId id);

        Task<Suggestion> Create(Suggestion suggestion);

        Task<bool> Remove(ObjectId id);

        Task<bool> Update(ObjectId id, Suggestion suggestion);
    }
}
