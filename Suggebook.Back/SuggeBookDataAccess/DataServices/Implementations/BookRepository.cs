using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SuggeBookDAL.Dao;
using SuggeBookDAL.DataServices.Contracts;

namespace SuggeBookDAL.DataServices.Implementations
{
    public class BookRepository : IBookRepository
    {
        public IBaseRepository<BookDao> _repo;

        public BookRepository(IBaseRepository<BookDao> repo)
        {
            _repo = repo;
        }

        public async Task<BookDao> Get(string id)
        {
            return await _repo.Get(id);
        }

        public async Task<IEnumerable<BookDao>> GetSeveral(List<string> ids)
        {
            return await _repo.GetSeveral(ids);
        }

        public async Task Insert(BookDao book)
        {
            await _repo.Insert(book);
        }

        public async Task<bool> Delete(BookDao dao)
        {
            return await _repo.Delete(dao);
        }

        public async Task<bool> Update(BookDao book)
        {
            return await _repo.Update(book);
        }        
    }
}
