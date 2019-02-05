using SuggeBook.Domain.UserDomain;
using System.Threading.Tasks;

namespace SuggeBookDAL.Domain.UserDomain
{
    public interface IUserRepository
    {
        Task<User> GetFromUsername(string username);
    }
}
