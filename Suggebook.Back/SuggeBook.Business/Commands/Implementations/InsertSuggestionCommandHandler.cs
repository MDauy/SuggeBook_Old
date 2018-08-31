using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories.Contracts;
using System.Threading.Tasks;

namespace SuggeBook.Business.Commands.Implementations
{
    public class InsertSuggestionCommandHandler : IInsertSuggestionCommandHandler
    {
        private readonly ISuggestionRepository _repo;

        public InsertSuggestionCommandHandler (ISuggestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(SuggestionDto obj)
        {
            await _repo.Insert(SuggeBookAutoMapper.Map<SuggestionDto, SuggestionDao>(obj));

            return true;
        }

       
    }
}
