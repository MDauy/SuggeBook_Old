using SuggeBook.Business.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using SuggeBookDAL.DataServices.Contracts;

namespace SuggeBook.Business.Implementations
{
    public class BookInteractor : IBookInteractor
    {
        private readonly IBookDataService _bookDataService;

        public BookInteractor(IBookDataService bookDataService)
        {
            _bookDataService = bookDataService;
        }

        public BookDto GetBook(string bookId)
        {
            var dao = _bookDataService.GetBook(bookId);
            var book = CustomAutoMapper.Map<BookDao, BookDto>(dao);
            book.Id = dao.Id.ToString();

            return book;
        }
    }
}
