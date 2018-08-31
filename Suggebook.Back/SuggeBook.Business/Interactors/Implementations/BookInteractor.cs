using SuggeBook.Business.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories.Contracts;
using System.Threading.Tasks;

namespace SuggeBook.Business.Implementations
{
    public class BookInteractor : BaseInteractor<BookDao, BookDto>, IBookInteractor
    {
        public BookInteractor(IBaseRepository<BookDao> repository)
        {
            _repo = repository;
        }
             
    }
}
