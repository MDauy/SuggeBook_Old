using SuggeBook.Business.Commands.Contracts;
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
        IInsertUserCommandHandler _insertUserCommand;
        IUserInteractor _extraUserInteractor;

        public UserService(BaseInteractor<UserDao> userInteractor, IInsertUserCommandHandler insertUserCommand, IUserInteractor extraUserInteractor)
        {
            _userInteractor = userInteractor;
            _insertUserCommand = insertUserCommand;
            _extraUserInteractor = extraUserInteractor;
        }

        public async Task<UserDto> Get(string id)
        {
            var dao = await _userInteractor.Get(id);
            return CustomAutoMapper.Map<UserDao, UserDto>(dao);
        }

        public async Task<UserDto> GetFromUsername(string username)
        {
            var userDao = await _extraUserInteractor.GetFromUsername(username);
            return CustomAutoMapper.Map<UserDao, UserDto>(userDao);
        }

        public async Task<UserDto> GetRandom()
        {
            var dao = await _userInteractor.GetRandom();
            return CustomAutoMapper.Map<UserDao, UserDto>(dao);
        }

        public async Task Insert(UserDto dto)
        {
            await _insertUserCommand.ExecuteAsync(dto);
        }
    }
}
