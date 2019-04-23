using SuggeBook.Domain.SuggestionDomain;
using System.Threading.Tasks;

namespace SuggeBookDAL.Domain.AuthorDomain
{
    public interface IAuthorRepository
    {
        Task UpdateAuthorSuggestions(string authorId, Suggestion sugge);
    }
}
