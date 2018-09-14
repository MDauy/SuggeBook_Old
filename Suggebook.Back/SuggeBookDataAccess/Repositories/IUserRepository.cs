using SuggeBookDAL.Dao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBookDAL.Repositories
{
    public interface IUserRepository
    {
        Task<UserDao> GetFromUsername(string username);
    }
}
