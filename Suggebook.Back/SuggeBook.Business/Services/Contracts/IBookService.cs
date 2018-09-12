using SuggeBook.Dto.Models;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Contracts
{
    public interface IBookService
    {
        Task Insert(InsertBookDto book);

        Task<BookDto> GetRandom();

        Task<BookDto> Get(string id);
    }
}
