using SuggeBook.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task UpdateNbSuggestions(string authorId, string suggestionId);

        Task<Author> Get(string authorId);

        Task<List<Author>> GetByName(string name);

        Task<Author> Create(Author author);

        Task<Author> GetSimilar(Author author);
    }
}
