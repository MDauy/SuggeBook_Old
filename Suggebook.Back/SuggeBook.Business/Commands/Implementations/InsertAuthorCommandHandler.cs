using SuggeBook.Business.Commands.Contracts;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;
using System.Threading.Tasks;

namespace SuggeBook.Business.Commands.Implementations
{
    public class InsertAuthorCommandHandler : IInsertAuthorCommandHandler
    {
        private readonly BaseRepository<AuthorDao> _repo;
        public InsertAuthorCommandHandler (BaseRepository<AuthorDao> repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(AuthorDao obj)
        {
            await _repo.Insert(obj);
            return true;
        }
    }
}
