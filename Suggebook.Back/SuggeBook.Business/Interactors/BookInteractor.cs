using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Interactors
{
    public class BookInteractor : BaseInteractor<BookDao>
    {
        public BookInteractor(BaseRepository<BookDao> repo)
        {
            _repo = repo;
        }

    }
}
