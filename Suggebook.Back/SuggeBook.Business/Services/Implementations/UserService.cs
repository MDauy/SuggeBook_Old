using SuggeBook.Business.Interactors;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        BaseInteractor<UserDao> _userInteractor;

        public UserService(BaseInteractor<UserDao> userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public async Task<UserDto> Get(string id)
        {
            var dao = await _userInteractor.Get(id);
            return CustomAutoMapper.Map<UserDao, UserDto>(dao);
        }

        public async Task<UserDto> GetRandom()
        {
            var dao = await _userInteractor.GetRandom();
            return CustomAutoMapper.Map<UserDao, UserDto>(dao);
        }

        public async Task Insert(UserDto dto)
        {
            var dao = CustomAutoMapper.Map<UserDto, UserDao>(dto); 
            //insert command 
        }
    }
}
