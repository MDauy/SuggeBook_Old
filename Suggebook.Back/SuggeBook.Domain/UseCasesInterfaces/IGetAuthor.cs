using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IGetAuthor
    {
        async Task<Author> GetAuthor(string authorId);
    }
}
