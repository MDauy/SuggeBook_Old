using SuggeBook.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);

        Task<User> GetFromUsername(string username);

        Task<User> Get(string userId);
    }
}
