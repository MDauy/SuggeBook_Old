using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Interactors;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Implementations
{
    public class SuggestionService : ISuggestionService
    {
        private readonly IInsertSuggestionCommandHandler _insertCommand;
        private readonly BaseInteractor<SuggestionDao> _suggestionInteractor;

        public SuggestionService (IInsertSuggestionCommandHandler insertCommand,
            BaseInteractor<SuggestionDao> suggestionInteractor)
        {
            _insertCommand = insertCommand;
            _suggestionInteractor = suggestionInteractor;
        }

        public async Task Insert(InsertSuggestionDto dto)
        {
            await _insertCommand.ExecuteAsync(dto);
        }

        public async Task<SuggestionDto> Get (string id)
        {
            var suggestionDao = await _suggestionInteractor.Get(id);
            if (suggestionDao != null)
            {
                return Framework.CustomAutoMapper.Map<SuggestionDao, SuggestionDto>(suggestionDao);
            }
            return null;
        }
    }
}
