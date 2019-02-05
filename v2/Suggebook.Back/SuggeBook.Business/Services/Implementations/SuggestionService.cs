using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Interactors;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Implementations
{
    public class SuggestionService : ISuggestionService
    {
        private readonly IInsertSuggestionCommandHandler _insertCommand;
        private readonly BaseInteractor<SuggestionDao> _suggestionInteractor;
        private readonly ISuggestionInteractor _extendedSuggestionInteractor;
        private readonly IUpdateAuthorSuggestionsCommandHandler _updateAuthorSuggestionsCommandHandler;
        private readonly IUpdateBookSuggestionsCommandHandler _updateBookSuggestionsCommandHandler;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IUserService _userService;

        public SuggestionService(IInsertSuggestionCommandHandler insertCommand,
            BaseInteractor<SuggestionDao> suggestionInteractor,
            ISuggestionInteractor extendedSuggestionInteractor,
            IBookService bookService,
            IAuthorService authorService,
            IUserService userService,
            IUpdateBookSuggestionsCommandHandler updateBookSuggestionsCommandHandler,
            IUpdateAuthorSuggestionsCommandHandler updateAuthorSuggestionsCommandHandler)
        {
            _insertCommand = insertCommand;
            _suggestionInteractor = suggestionInteractor;
            _extendedSuggestionInteractor = extendedSuggestionInteractor;
            _bookService = bookService;
            _authorService = authorService;
            _userService = userService;
            _updateAuthorSuggestionsCommandHandler = updateAuthorSuggestionsCommandHandler;
            _updateBookSuggestionsCommandHandler = updateBookSuggestionsCommandHandler;
        }

        public async Task Insert(InsertSuggestionDto dto)
        {
            var newSuggestion = await _insertCommand.ExecuteAsync(dto);

            await _updateBookSuggestionsCommandHandler.ExecuteAsync(new UpdateBookSuggestionsDto
            {
                BookId = dto.BookId,
                Suggestion = newSuggestion
            });
            await _updateAuthorSuggestionsCommandHandler.ExecuteAsync(new UpdateAuthorSuggestionsDto
            {
                AuthorId = dto.AuthorId,
                Suggestion = newSuggestion
            });
        }

        public async Task<SuggestionDto> Get (string id)
        {
            var suggestionDao = await _suggestionInteractor.Get(id);
            var book = await _bookService.Get(suggestionDao.BookId.ToString());
            var user = await _userService.Get(suggestionDao.UserId.ToString());

            if (suggestionDao != null && book != null)
            {
                var suggestion = Framework.CustomAutoMapper.Map<SuggestionDao, SuggestionDto>(suggestionDao);
                suggestion.BookAuthor = book.AuthorFullName;
                suggestion.BookTitle = book.Title;
                suggestion.CreatorUsername = user.UserName;
                return suggestion;
            }
            return null;
        }

        public async Task<List<SuggestionDto>> GetFomBook(string bookId)
        {
            var suggestionDaos = await _extendedSuggestionInteractor.GetFromBook(bookId);
            var book = await _bookService.Get(bookId);
            
            var suggestionDtos = new List<SuggestionDto>();
            foreach (var suggestionDao in suggestionDaos)
            {
               
                var suggestionDto = CustomAutoMapper.Map<SuggestionDao, SuggestionDto>(suggestionDao);
                 var user = await _userService.Get(suggestionDao.UserId.ToString());
                suggestionDto.BookAuthor = book.AuthorFullName;
                suggestionDto.BookTitle = book.Title;
                suggestionDto.CreatorUsername = user.UserName;
                suggestionDtos.Add(suggestionDto);
            }
            return suggestionDtos;
        }       

        public async Task<List<SuggestionDto>> GetLastFromBook(string bookId)
        {
            var suggestionDaos = await _extendedSuggestionInteractor.GetFromBook(bookId);
            return CustomAutoMapper.MapLists<SuggestionDao, SuggestionDto>(suggestionDaos);
        }

        public async Task<List<SuggestionDto>> GetLastFromAuthor(string authorId)
        {
            var suggeDaos = await _extendedSuggestionInteractor.GetLastFromAuthor(authorId);
            return CustomAutoMapper.MapLists<SuggestionDao, SuggestionDto>(suggeDaos);
        }

        public  async Task<List<SuggestionDto>> GetLastFromCategories(List<string> categories)
        {
            var suggeDaos = await _extendedSuggestionInteractor.GetLastFromCategories(categories);
            return CustomAutoMapper.MapLists<SuggestionDao, SuggestionDto>(suggeDaos);
        }
    }
}
