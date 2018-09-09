using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;
using System.Threading.Tasks;

namespace SuggeBook.Business.Commands.Implementations
{
    public class InsertSuggestionCommandHandler : IInsertSuggestionCommandHandler
    {
        private readonly BaseRepository<SuggestionDao> _repo;

        public InsertSuggestionCommandHandler (BaseRepository<SuggestionDao> repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(SuggestionDto obj)
        {
            await _repo.Insert(Framework.CustomAutoMapper.Map<SuggestionDto, SuggestionDao>(obj));

            return true;
        }

       
    }
}
