using System.Threading.Tasks;
using SuggeBook.Domain.Model;

namespace SuggeBook.Domain.Repositories
{
    public interface ISuggestionRepository
    {
        Task<Suggestion> Insert(Suggestion suggestion);
        Task<Suggestion> Get(string id);
    }
}
