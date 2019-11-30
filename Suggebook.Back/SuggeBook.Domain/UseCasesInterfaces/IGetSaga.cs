using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IGetSaga
    {
        Task<Saga> GetSaga (string sagaId);
    }
}
