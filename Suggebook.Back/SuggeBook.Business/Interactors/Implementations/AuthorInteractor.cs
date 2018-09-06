using System.Collections.Generic;
using System.Threading.Tasks;
using SuggeBook.Business.Interactors.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;

namespace SuggeBook.Business.Interactors.Implementations
{
    public class AuthorInteractor : IAuthorInteractor
    {
        private IBaseInteractor<AuthorDao, AuthorDto> _baseInteractor;

        public AuthorInteractor(IBaseInteractor<AuthorDao, AuthorDto> baseInteractor)
        {
            _baseInteractor = baseInteractor;
        }

        public async Task<AuthorDto> Get(string id)
        {
            return await _baseInteractor.Get(id);
        }

        public async Task<AuthorDto> GetRandom()
        {
            return await _baseInteractor.GetRandom();
        }

        public async Task<List<AuthorDto>> GetSeveral(List<string> ids)
        {
            return await GetSeveral(ids);
        }
    }
}
