using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Interactors.Contracts;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;

namespace SuggeBook.Business.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IInsertAuthorCommandHandler _authorCommandHandler;
        private readonly IAuthorInteractor _authorInteractor;

        public AuthorService (IInsertAuthorCommandHandler authorCommandHandler, IAuthorInteractor authorInteractor)
        {
            _authorCommandHandler = authorCommandHandler;
            _authorInteractor = authorInteractor;
        }

        public async Task<AuthorDto> Get(string id)
        {
            return await _authorInteractor.Get(id);
        }

        public async Task<AuthorDto> GetRandom(int howMany = 1)
        {
            return await _authorInteractor.GetRandom();
        }

        public async Task<List<AuthorDto>> GetSeveral(List<string> ids)
        {
            return await _authorInteractor.GetSeveral(ids);
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
