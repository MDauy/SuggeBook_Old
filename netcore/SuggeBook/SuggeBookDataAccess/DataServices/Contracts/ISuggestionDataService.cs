using MongoDB.Bson;
using SuggeBookDAL.Dao;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
    public interface ISuggestionDataService
    {
        Task<Suggestion> Get(ObjectId id);

        Task<Suggestion> Create(Suggestion suggestion);

        Task<bool> Remove(ObjectId id);

        Task<bool> Update(ObjectId id, Suggestion suggestion);
    }
}
