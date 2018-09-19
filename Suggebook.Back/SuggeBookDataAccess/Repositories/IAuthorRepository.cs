using MongoDB.Bson;
using SuggeBookDAL.Dao;
using System.Threading.Tasks;

namespace SuggeBookDAL.Repositories
{
    public interface IAuthorRepository
    {
        Task UpdateAuthorSuggestions(string authorId, SuggestionDao sugge);
    }
}
