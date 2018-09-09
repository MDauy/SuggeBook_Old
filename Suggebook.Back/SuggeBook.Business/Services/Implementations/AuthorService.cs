using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Interactors;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;

namespace SuggeBook.Business.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IInsertAuthorCommandHandler _authorCommandHandler;
        private readonly IBaseInteractor<AuthorDao> _interactor;
        public AuthorService (IInsertAuthorCommandHandler authorCommandHandler, BaseInteractor<AuthorDao> interactor)
        {
            _authorCommandHandler = authorCommandHandler;
            _interactor = interactor;
        }

        public async Task<AuthorDto> Get(string id)
        {
            var authorDao = await _interactor.Get(id);

            if(authorDao != null)
            {
                return Framework.CustomAutoMapper.Map<AuthorDao, AuthorDto>(authorDao);
            }
            return null;
        }

        public async Task<AuthorDto> GetRandom(int howMany = 1)
        {
            var authorDao = await _interactor.GetRandom();

            if (authorDao != null)
            {
                return Framework.CustomAutoMapper.Map<AuthorDao, AuthorDto>(authorDao);
            }
            return null;
        }

        public async Task<List<AuthorDto>> GetSeveral(List<string> ids)
        {
            var result = new List<AuthorDto>();
            foreach (var id in ids)
            {
                result.Add(await this.Get(id));
            }
            return result;
        }

        public async Task Insert(AuthorDto dto)
        {
            await _authorCommandHandler.ExecuteAsync(Framework.CustomAutoMapper.Map<AuthorDto, AuthorDao>(dto));
        }

        public async Task InsertSeveral(List<AuthorDto> dtos)
        {
            foreach (var item in dtos)
            {
                await _authorCommandHandler.ExecuteAsync(Framework.CustomAutoMapper.Map<AuthorDto, AuthorDao>(item));
            }
        }
    }
}
