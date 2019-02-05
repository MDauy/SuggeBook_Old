using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Interactors
{
    public class AuthorInteractor : BaseInteractor<AuthorDao>
    {
        public AuthorInteractor(BaseRepository<AuthorDao> repo)
        {
            _repo = repo;
        }        
    }
}
