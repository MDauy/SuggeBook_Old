using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Interactors
{
    public class UserInteractor : BaseInteractor<UserDao>
    {
        public UserInteractor(BaseRepository<UserDao> repo)
        {
            _repo = repo;
        }       
    }
}
