using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Contracts
{
    public interface IUserService
    {
        Task<UserDto> Get(string id);
        Task Insert(UserDto dto);
        Task<UserDto> GetFromUsername(string username);
        Task<UserDto> GetRandom();
    }
}
