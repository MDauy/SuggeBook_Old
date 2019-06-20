using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.Repositories
{
    public interface IMissedAuthorRepository
    {
        Task<MissedAuthor> Register(MissedAuthor missedAuthor);
    }
}
