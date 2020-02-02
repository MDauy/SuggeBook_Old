using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IRegisterMissedSaga
    {
        Task Register (string title, string message);
    }
}
