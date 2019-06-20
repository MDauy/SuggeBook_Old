using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IRegisterMissedAuthor
    {
        Task<MissedAuthor> Register(MissedAuthor missedAuthor);
    }
}
