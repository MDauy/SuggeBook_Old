using MongoDB.Bson;
using SuggeBookDAL.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDAL.Repositories.Contracts
{
    public interface IAuthorRepository
    {
        Task<AuthorDao> Get(string id);

        Task Insert(AuthorDao author);

        Task<List<AuthorDao>> GetSeveral(List<string> ids);

        Task<bool> Delete(AuthorDao id);

        Task<bool> Update(AuthorDao dao);
    }
}
