using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IRegisterMissedSaga
    {
        Task<MissedSaga> Register (MissedSaga missedSaga);
    }
}
