using System.Threading.Tasks;
using SuggeBook.Domain.Model;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface ICreateAuthor
    {
        Task<Author> Create(Author author);
    }
}
