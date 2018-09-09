using Microsoft.AspNetCore.Mvc;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Mocks;
using SuggeBook.Dto.Models;
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
        private readonly IFakeUserService _fakeUsers;


        public FakeController (IFakeBooksService fakeBooks,
            IFakeAuthorService fakeAuthors,
            IBookService bookService,
            IAuthorService authorService,
            IUserService userService)
        {
            _fakeBooks = fakeBooks;
            _fakeAuthors = fakeAuthors;
            _bookService = bookService;
            _authorService = authorService;
            _userService = userService;
        }

        [Route("addBooks/{howMany}")]
        public async Task GenerateBooks (int howMany)
        {
            var fakeBooks = _fakeBooks.Generate(howMany);
            foreach (BookDto book in fakeBooks)
            {
               var author = await _authorService.GetRandom();
                await _bookService.Insert(book, author.Id);
            }
        }

        [Route("addAuthors/{howMany}")]
        public async Task GenerateAuthors (int howMany)
        {
            var fakeAuthors = _fakeAuthors.Generate(howMany);
            await _authorService.InsertSeveral(fakeAuthors);
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
    }
}
