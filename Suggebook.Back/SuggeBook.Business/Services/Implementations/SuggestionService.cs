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
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public SuggestionService (IInsertSuggestionCommandHandler insertCommand,
            BaseInteractor<SuggestionDao> suggestionInteractor,
            ISuggestionInteractor extendedSuggestionInteractor,
            IBookService bookService,
            IUserService userService)
        {
            _insertCommand = insertCommand;
            _suggestionInteractor = suggestionInteractor;
            _extendedSuggestionInteractor = extendedSuggestionInteractor;
            _bookService = bookService;
            _userService = userService;
        }

        public async Task Insert(InsertSuggestionDto dto)
        {
            await _insertCommand.ExecuteAsync(dto);
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

        public async Task<int> GetNbSuggestionsForBook(string bookId)
        {
            return (await _extendedSuggestionInteractor.GetFromBook(bookId)).Count;
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
