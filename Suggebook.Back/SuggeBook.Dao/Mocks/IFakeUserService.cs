using SuggeBook.Dto.Models;
using System.Collections.Generic;

namespace SuggeBook.Dto.Mocks
{
    public interface IFakeUserService
    {
        List<UserDto> Generate(int howMany);
    }
}
