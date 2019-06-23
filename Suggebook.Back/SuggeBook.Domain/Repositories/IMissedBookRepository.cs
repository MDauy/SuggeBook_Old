using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.Repositories
{
    public interface IMissedBookRepository
    {
        Task<MissedBook> Register(MissedBook missedBook);
    }
}
