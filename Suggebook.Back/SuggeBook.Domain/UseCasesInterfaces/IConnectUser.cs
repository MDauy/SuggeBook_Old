using System.Threading.Tasks;
using SuggeBook.Domain.Model;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IConnectUser
    {
        Task<User> Connect(string usernameOrEmail, string password);
    }
}
