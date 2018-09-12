using Microsoft.AspNetCore.Mvc;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Mocks;
using SuggeBook.Dto.Models;
using SuggeBook.Framework;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route("testData")]
    public class FakeController : Controller
    {
        private readonly IFakeBooksService _fakeBooks;
        private readonly IFakeAuthorService _fakeAuthors;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IUserService _userService;
        private readonly ISuggestionService _suggestionsService;
        private readonly IFakeUserService _fakeUsers;
        private readonly IFakeSuggestionsService _fakeSuggestions;


        public FakeController (IFakeBooksService fakeBooks,
            IFakeAuthorService fakeAuthors,
            IBookService bookService,
            IAuthorService authorService,
            IUserService userService,
            IFakeUserService fakeUsers,IFakeSuggestionsService fakeSuggestionsService,
            ISuggestionService suggestionService)
        {
            _fakeBooks = fakeBooks;
            _fakeAuthors = fakeAuthors;
            _bookService = bookService;
            _authorService = authorService;
            _userService = userService;
            _fakeUsers = fakeUsers;
            _fakeSuggestions = fakeSuggestionsService;
            _suggestionsService = suggestionService;
        }

        [Route("addBooks/{howMany}")]
        public async Task GenerateBooks (int howMany)
        {
            var fakeBooks = _fakeBooks.Generate(howMany);
            foreach (BookDto book in fakeBooks)
            {
               var author = await _authorService.GetRandom();
                await _bookService.Insert(new InsertBookDto
                {
                    AuthorId = author.Id,
                    BookDto = book
                });
            }
        }

        [Route("addAuthors/{howMany}")]
        public async Task GenerateAuthors (int howMany)
        {
            var fakeAuthors = _fakeAuthors.Generate(howMany);
            foreach (var author in fakeAuthors)
            {
                await _authorService.Insert(CustomAutoMapper.Map<AuthorDto, InsertAuthorDto>(author));
            }
        }

        [Route("addUsers/{howMany}")]
        public async Task GenerateUsers (int howMany)
        {
            var fakeUsers = _fakeUsers.Generate(howMany);
            foreach (var user in fakeUsers)
            {
                await _userService.Insert(user);
            }           
        }

        [Route("addSuggestions/{howMany}")]
        public async Task GenerateSuggestions (int howMany)
        {
            var fakeSuggestions = _fakeSuggestions.Generate(howMany);
            foreach (var suggestion in fakeSuggestions)
            {
                var book = await _bookService.GetRandom();
                suggestion.BookAuthor = book.AuthorFullName;
                suggestion.BookTitle = book.Title;
                var user = await _userService.GetRandom();
                var sugg = new InsertSuggestionDto
                {
                    Suggestion = suggestion,
                    UserId =  user.Id,
                    BookId = book.Id
                };
                await _suggestionsService.Insert(sugg);
            }
        }
    }
}
