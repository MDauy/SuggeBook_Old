using SuggeBook.Dto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Contracts
{
    public interface IBookService
    {
        Task Insert(InsertBookDto book);

        Task<BookDto> GetRandom();

        Task<BookDto> Get(string id);

        Task<List<BookDto>> GetFromAuthor(string authorId);

        Task<List<BookDto>> GetFromCategories(List<CategoryEnum> categories);

        Task UpdateSuggestions(string bookId, SuggestionDto suggestion);
    }
}
