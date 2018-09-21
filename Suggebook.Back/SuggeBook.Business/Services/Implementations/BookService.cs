﻿using SuggeBook.Business.Commands.Contracts;
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
        private readonly BaseInteractor<AuthorDao> _authorInteractor;
        private readonly ISuggestionService _suggestionService;
        private readonly IBookInteractor _bookInteractor;

        public BookService(IInsertBookCommandHandler insertBookCommandHandler, BaseInteractor<BookDao> interactor,
            BaseInteractor<AuthorDao> authorInteractor, ISuggestionService suggestionService,
            IBookInteractor bookInteractor, IUpdateBookSuggestionsCommandHandler updateBookSuggestionsCommandHandler)
        {
            _insertBookCommandHandler = insertBookCommandHandler;
            _interactor = interactor;
            _authorInteractor = authorInteractor;
            _suggestionService = suggestionService;
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
            return await BuildBook(bookDao);
        }

        public async Task<BookDto> Get (string id)
        {
            var bookDao = await _interactor.Get(id);
            var bookDto = await BuildBook(bookDao);
            bookDto.NumberOfSuggestions = await _suggestionService.GetNbSuggestionsForBook(bookDto.Id);
            return bookDto;
        }

        private async Task<BookDto> BuildBook (BookDao bookDao)
        {
            var author = CustomAutoMapper.Map<BookDao.BookDaoAuthor, AuthorDto>(bookDao.Author);
            var suggestions = CustomAutoMapper.MapLists<SuggestionDao, SuggestionDto>(bookDao.Suggestions);
            var book = CustomAutoMapper.Map<BookDao, BookDto>(bookDao);
            book.AuthorFullName = author.FullName;

            return book;
        }

        public Task<List<BookDto>> GetFromAuthor(string authorId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<BookDto>> GetFromCategory(List<CategoryEnum> categories)
        {
            var books =  await _bookInteractor.GetFromCategories(categories.Select(c => c.ToString()).ToList());
            return CustomAutoMapper.MapLists<BookDao, BookDto>(books);
        }

        public Task<List<BookDto>> GetFromCategory(CategoryEnum category)
        {
            throw new System.NotImplementedException();
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
