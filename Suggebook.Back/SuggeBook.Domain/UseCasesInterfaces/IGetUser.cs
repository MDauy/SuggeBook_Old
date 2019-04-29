using SuggeBook.Domain.Model;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IGetUser
    {
        Task<User> GetFromUsername(string username);

        Task<User> Get(string userId);
    }
}
