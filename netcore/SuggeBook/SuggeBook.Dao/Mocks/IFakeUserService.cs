using SuggeBook.Dao.Models;
using System.Collections.Generic;

namespace SuggeBook.Dao.Mocks
{
    public interface IFakeUserService
    {
        List<User> Generate(int howMany);
    }
}
