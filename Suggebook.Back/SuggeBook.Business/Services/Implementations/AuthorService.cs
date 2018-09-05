using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;

namespace SuggeBook.Business.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IInsertAuthorCommandHandler _authorCommandHandler;
        public AuthorService (IInsertAuthorCommandHandler authorCommandHandler)
        {
            _authorCommandHandler = authorCommandHandler;
        }

        public async Task Insert(AuthorDto dto)
        {
            await _authorCommandHandler.ExecuteAsync(SuggeBookAutoMapper.Map<AuthorDto, AuthorDao>(dto));
        }

        public async Task InsertSeveral(List<AuthorDto> dtos)
        {
            foreach (var item in dtos)
            {
                await _authorCommandHandler.ExecuteAsync(SuggeBookAutoMapper.Map<AuthorDto, AuthorDao>(item));
            }
        }
    }
}
