using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Business.Commands.Implementations;
using SuggeBook.Business.Interactors;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using SuggeBookDAL.Dao;

namespace SuggeBook.Business.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IInsertAuthorCommandHandler _insertAuthorCommandHandler;
        private readonly IBaseInteractor<AuthorDao> _interactor;
        private readonly IBookService _bookService;
        private readonly IUpdateAuthorSuggestionsCommandHandler _updateAuthorSuggestionsCommandHandler;

        public AuthorService(IInsertAuthorCommandHandler authorCommandHandler, BaseInteractor<AuthorDao> interactor
            , IBookService bookService,
            IUpdateAuthorSuggestionsCommandHandler updateAuthorSuggestionsCommandHandler)
        {
            _insertAuthorCommandHandler = authorCommandHandler;
            _interactor = interactor;
            _bookService = bookService;
            _updateAuthorSuggestionsCommandHandler = updateAuthorSuggestionsCommandHandler;
        }

        public async Task<AuthorDto> Get(string id)
        {
            var authorDao = await _interactor.Get(id);

            if (authorDao != null)
            {
                return Framework.CustomAutoMapper.Map<AuthorDao, AuthorDto>(authorDao);
            }
            return null;
        }

        public async Task<AuthorDto> GetFull(string id)
        {
            var books = await _bookService.GetFromAuthor(id);
            var bestBooks = books.OrderBy(b => b.NbSuggestions).Take(Constants.NUMBER_OF_BEST_BOOKS_TO_GET).ToList();

            var author = await this.Get(id);
            author.Books = CustomAutoMapper.MapLists<BookDto, AuthorDto.Book>(bestBooks);

            return author;
        }

        public async Task<AuthorDto> GetRandom(int howMany = 1)
        {
            var authorDao = await _interactor.GetRandom();

            if (authorDao != null)
            {
                return Framework.CustomAutoMapper.Map<AuthorDao, AuthorDto>(authorDao);
            }
            return null;
        }

        public async Task<List<AuthorDto>> GetSeveral(List<string> ids)
        {
            var result = new List<AuthorDto>();
            foreach (var id in ids)
            {
                result.Add(await this.Get(id));
            }
            return result;
        }

        public async Task Insert(InsertAuthorDto dto)
        {
            await _insertAuthorCommandHandler.ExecuteAsync(dto);
        }

        public async Task UpdateSuggestions(string authorId, SuggestionDto sugge)
        {
            await _updateAuthorSuggestionsCommandHandler.ExecuteAsync(new UpdateAuthorSuggestionsDto
            {
                AuthorId = authorId,
                Suggestion = CustomAutoMapper.Map<SuggestionDto, SuggestionDao>(sugge)
            });
        }
    }
}
