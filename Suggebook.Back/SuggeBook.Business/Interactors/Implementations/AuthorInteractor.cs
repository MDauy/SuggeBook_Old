using SuggeBook.Business.Contracts;
using SuggeBook.Business.Interactors.Contracts;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories.Contracts;

namespace SuggeBook.Business.Interactors.Implementations
{
    public class AuthorInteractor : BaseInteractor<AuthorDao, AuthorDto>, IAuthorInteractor
    {
        public AuthorInteractor(IBaseRepository<AuthorDao> baseRepository)
        {
            _repo = baseRepository;
        }   
    }
}
