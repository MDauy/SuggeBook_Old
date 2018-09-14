using SuggeBookDAL.Dao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Interactors
{
    public interface IUserInteractor
    {
        Task<UserDao> GetFromUsername(string username);

    }
}
