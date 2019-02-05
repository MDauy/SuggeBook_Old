using System.Threading.Tasks;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;

namespace SuggeBook.Business.Interactors
{
    public class UserInteractor : BaseInteractor<UserDao>, IUserInteractor
    {
        private readonly IUserRepository _extraRepo;

        public UserInteractor(BaseRepository<UserDao> repo, IUserRepository extraRepo)
        {
            _repo = repo;
            _extraRepo = extraRepo;
        }

        public async Task<UserDao> GetFromUsername(string username)
        {
            return await _extraRepo.GetFromUsername(username);
        }
    }
}
