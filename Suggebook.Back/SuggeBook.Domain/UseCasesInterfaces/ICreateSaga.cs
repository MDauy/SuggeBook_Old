using System.Threading.Tasks;
using SuggeBook.Domain.Model;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface ICreateSaga
    {
        Task<Saga> Create(Saga saga);
    }
}
