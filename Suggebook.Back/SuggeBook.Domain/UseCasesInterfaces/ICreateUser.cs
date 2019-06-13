using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface ICreateUser
    {
        Task<User> Create(User user);
    }
}
