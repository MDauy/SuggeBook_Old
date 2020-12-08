using SuggeBook.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IGetAuthor
    {
        Task<Author> Get(string authorId);

        Task<List<Author>> GetByName(string name);
    }
}
