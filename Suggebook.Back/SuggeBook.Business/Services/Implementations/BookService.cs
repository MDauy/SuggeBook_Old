using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Interactors;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IInsertBookCommandHandler _insertBookCommandHandler;
        private readonly BaseInteractor<BookDao> _interactor;
        private readonly BaseInteractor<AuthorDao> _authorInteractor;

        public BookService(IInsertBookCommandHandler insertBookCommandHandler, BaseInteractor<BookDao> interactor,
            BaseInteractor<AuthorDao> authorInteractor
        )
        {
            _insertBookCommandHandler = insertBookCommandHandler;
            _interactor = interactor;
            _authorInteractor = authorInteractor;
        }

        public async Task Insert(BookDto book, string authorId)
        {
            await _insertBookCommandHandler.ExecuteAsync(new InsertBookCommandRequest { BookDto = book, AuthorId = authorId });
        }

        public async Task<BookDto> GetRandom ()
        {
            var bookDao = await _interactor.GetRandom();
            return await BuildBook(bookDao);
        }

        public async Task<BookDto> Get (string id)
        {
            var bookDao = await _interactor.Get(id);
            return await BuildBook(bookDao);
        }

        private async Task<BookDto> BuildBook (BookDao bookDao)
        {
            var author = CustomAutoMapper.Map<AuthorDao, AuthorDto>(await _authorInteractor.Get(bookDao.AuthorId.ToString()));
            var book = CustomAutoMapper.Map<BookDao, BookDto>(bookDao);
            book.AuthorFullName = author.FullName;

            return book;
        }
    }
}
