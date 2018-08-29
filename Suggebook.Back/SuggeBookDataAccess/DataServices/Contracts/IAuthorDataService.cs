using MongoDB.Bson;
using SuggeBookDAL.Dao;
using System.Threading.Tasks;

namespace SuggeBookDAL.DataServices.Contracts
{
    public interface IAuthorDataService
    {
        Task<AuthorDao> Get(ObjectId id);

        Task<AuthorDao> Create(AuthorDao author);

        Task<bool> Remove(ObjectId id);

        Task<bool> Update(ObjectId id, SuggestionDao suggestion);
    }
}
