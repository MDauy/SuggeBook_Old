using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.Repositories
{
    public interface IMissedSagaRepository
    {
        Task<MissedSaga> Register (MissedSaga missedSaga);
    }
}
