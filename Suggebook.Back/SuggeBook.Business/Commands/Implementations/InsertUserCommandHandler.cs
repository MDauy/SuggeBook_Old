using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Commands.Implementations
{
    public class InsertUserCommandHandler : IInsertUserCommandHandler
    {
        BaseRepository<UserDao> _repo;
        public InsertUserCommandHandler(BaseRepository<UserDao> repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(UserDto obj)
        {
            var dao = CustomAutoMapper.Map<UserDto, UserDao>(obj);
            await _repo.Insert(dao);
            return true;
        }
    }
}
