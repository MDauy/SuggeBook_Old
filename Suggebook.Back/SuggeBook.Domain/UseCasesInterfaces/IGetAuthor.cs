using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IGetAuthor
    {
        Task<Author> Get(string authorId);
    }
}
