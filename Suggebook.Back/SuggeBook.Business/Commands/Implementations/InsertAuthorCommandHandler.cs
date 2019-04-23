using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Tools;
using SuggeBookDAL.Persistence;
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

        public async Task<bool> ExecuteAsync(InsertAuthorDto obj)
        {
            var dao = CustomAutoMapper.Map<InsertAuthorDto, AuthorDao>(obj);
            dao.Suggestions = new System.Collections.Generic.List<SuggestionDao>();
            await _repo.Insert(dao);
            return true;
        }
    }
}
