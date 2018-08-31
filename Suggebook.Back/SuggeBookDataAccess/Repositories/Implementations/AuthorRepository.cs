using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDAL.Repositories.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IBaseRepository<AuthorDao> _repo;

        public AuthorRepository (IBaseRepository<AuthorDao> repo)
        {
            _repo = repo;
        }

        public async Task Insert(AuthorDao author)
        {
             await _repo.Insert(author);
        }

        public async Task<AuthorDao> Get(string id)
        {
            return await _repo.Get(id);
        }

        public async Task<List<AuthorDao>> GetSeveral(List<string> ids)
        {
            return await _repo.GetSeveral(ids);
        }

        public async Task<bool> Delete(AuthorDao dao)
        {
            return await _repo.Delete(dao);
        }

        public async Task<bool> Update(AuthorDao author)
        {
            return await _repo.Update(author) ;
        }
    }
}
