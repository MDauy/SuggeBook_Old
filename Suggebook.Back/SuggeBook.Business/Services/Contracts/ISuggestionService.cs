using SuggeBook.Dto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Contracts
{
    public interface ISuggestionService
    {
        Task Insert(InsertSuggestionDto dto);

        Task<SuggestionDto> Get(string id);

        Task<List<SuggestionDto>> GetFomBook(string bookId);

        Task<int> GetNbSuggestionsForBook(string bookId);
    }
}
