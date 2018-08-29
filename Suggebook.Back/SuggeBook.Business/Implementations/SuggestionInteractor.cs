using SuggeBook.Business.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.DataServices.Contracts;

namespace SuggeBook.Business.Implementations
{
    public class SuggestionInteractor : BaseInteractor, ISuggestionInteractor
    {
        private readonly ISuggestionDataService _suggestionDataService;

        public SuggestionInteractor (ISuggestionDataService suggestionDataService)
        {
            _suggestionDataService = suggestionDataService;
        }

        public SuggestionDto GetSuggestion(string id)
        {
            var dao = _suggestionDataService.Get(id);
        }

    }
}
