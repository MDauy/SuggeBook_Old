using SuggeBook.Business.Contracts;
using SuggeBook.Business.Interactors.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Implementations
{
    public class BookInteractor : IBookInteractor
    {
        private readonly IBaseInteractor<BookDao, BookDto> _baseInteractor;

        public BookInteractor(IBaseInteractor<BookDao, BookDto> baseInteractor)
        {
            _baseInteractor = baseInteractor;
        }

        public async Task<BookDto> Get(string id)
        {
            return await _baseInteractor.Get(id);
        }

        public async Task<BookDto> GetRandom()
        {
            return await _baseInteractor.GetRandom();
        }

        public async Task<List<BookDto>> GetSeveral(List<string> ids)
        {
            return await _baseInteractor.GetSeveral(ids);
        }
    }
}
