using SuggeBook.Domain.SuggestionDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBookDAL.Domain.SuggestionDomain
{
    public interface ISuggestionRepository
    {
        Task<List<Suggestion>> GetFromBook(string bookId);

        Task<List<Suggestion>> GetLastFromBook(string bookId);

        Task<List<Suggestion>> GetLastFromAuthor(string authorId);

        Task<List<Suggestion>> GetLastFromCategories(List<string> categories);
    }
}
