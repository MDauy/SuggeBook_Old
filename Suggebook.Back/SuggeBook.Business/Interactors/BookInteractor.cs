using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Interactors
{
    public class BookInteractor : BaseInteractor<BookDao>, IBookInteractor
    {
        public BookInteractor(BaseRepository<BookDao> repo)
        {
            _repo = repo;
        }

        public Task<List<BookDao>> GetFromAuthor(string authorId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<BookDao>> GetFromCategory(string category)
        {
            throw new System.NotImplementedException();
        }
    }
}
