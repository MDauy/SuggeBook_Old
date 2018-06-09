using MongoDB.Bson;
using SuggeBookDataAccess.Dao;
using System.Threading.Tasks;

namespace SuggeBookDataAccess.DataServices.Contracts
{
    public interface IAuthorDataService
    {
        Task<Author> Get(ObjectId id);

        Task<Author> Create(Author author);

        Task<bool> Remove(ObjectId id);

        Task<bool> Update(ObjectId id, Suggestion suggestion);
    }
}
