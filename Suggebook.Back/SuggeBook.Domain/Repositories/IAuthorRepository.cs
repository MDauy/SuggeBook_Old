using System.Threading.Tasks;

namespace SuggeBook.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task UpdateNbSuggestions(string authorId, string suggestionId);
    }
}
