using SuggeBook.Business.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using SuggeBookDAL.DataServices.Contracts;
using System.Threading.Tasks;

namespace SuggeBook.Business.Implementations
{
    public class BookInteractor : BaseInteractor<BookDao, BookDto>
    {
        public BookInteractor(IBaseRepository<BookDao> repository)
        {
            _repo = repository;
        }
    }
}
