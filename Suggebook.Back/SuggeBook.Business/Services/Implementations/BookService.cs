using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Interactors;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IInsertBookCommandHandler _insertBookCommandHandler;
        private readonly IUpdateBookSuggestionsCommandHandler _updateBookSuggestionsCommandHandler;
        private readonly BaseInteractor<BookDao> _interactor;
        private readonly IBookInteractor _bookInteractor;

        public BookService(IInsertBookCommandHandler insertBookCommandHandler, BaseInteractor<BookDao> interactor,
            IBookInteractor bookInteractor, IUpdateBookSuggestionsCommandHandler updateBookSuggestionsCommandHandler)
        {
            _insertBookCommandHandler = insertBookCommandHandler;
            _interactor = interactor;
            _bookInteractor = bookInteractor;
            _updateBookSuggestionsCommandHandler = updateBookSuggestionsCommandHandler;
        }

        public async Task Insert(InsertBookDto book)
        {
            await _insertBookCommandHandler.ExecuteAsync(book);
        }

        public async Task<BookDto> GetRandom ()
        {
            var bookDao = await _interactor.GetRandom();
            return BuildBook(bookDao);
        }

        public async Task<BookDto> Get (string id)
        {
            var bookDao = await _interactor.Get(id);
            var bookDto = bookDao != null ? BuildBook(bookDao) : null;            
            return bookDto;
        }

        private BookDto BuildBook (BookDao bookDao)
        {
            var author = CustomAutoMapper.Map<BookDao.BookDaoAuthor, AuthorDto>(bookDao.Author);
            var suggestions = CustomAutoMapper.MapLists<SuggestionDao, SuggestionDto>(bookDao.Suggestions);
            var book = CustomAutoMapper.Map<BookDao, BookDto>(bookDao);
            book.AuthorFullName = author.FullName;

            return book;
        }

        public async Task<List<BookDto>> GetFromAuthor(string authorId)
        {
            var dtos = CustomAutoMapper.MapLists<BookDao, BookDto>( await _bookInteractor.GetFromAuthor(authorId));
            return dtos;
        }

        public async Task<List<BookDto>> GetFromCategory(List<CategoryEnum> categories)
        {
            var books =  await _bookInteractor.GetFromCategories(categories.Select(c => c.ToString()).ToList());
            return CustomAutoMapper.MapLists<BookDao, BookDto>(books);
        }

        public async Task<List<BookDto>> GetFromCategories(List<CategoryEnum> categories)
        {
            var daos = await _bookInteractor.GetFromCategories(categories.Select(c => c.ToString()).ToList());

            return CustomAutoMapper.MapLists<BookDao, BookDto>(daos) ;
        }

        public async Task UpdateSuggestions(string bookId, SuggestionDto suggestion)
        {
            var dao = CustomAutoMapper.Map<SuggestionDto, SuggestionDao>(suggestion);

            await _updateBookSuggestionsCommandHandler.ExecuteAsync(new UpdateBookSuggestionsDto
            {
                BookId = bookId,
                Suggestion = dao
            });
        }
    }
}
