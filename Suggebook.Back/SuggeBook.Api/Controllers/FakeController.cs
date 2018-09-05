using Microsoft.AspNetCore.Mvc;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public FakeController (IFakeBooksService fakeBooks,
            IFakeAuthorService fakeAuthors,
            IBookService bookService,
            IAuthorService authorService)
        {
            _fakeBooks = fakeBooks;
            _fakeAuthors = fakeAuthors;
            _bookService = bookService;
            _authorService = authorService;            
        }

        [Route("addBooks/{howMany}")]
        public async Task GenerateBooks (int howMany)
        {
            var fakeBooks = _fakeBooks.Generate(howMany);
            await _bookService.InsertSeveral(fakeBooks);
        }

        [Route("addAuthors/{howMany}")]
        public async Task GenerateAuthors (int howMany)
        {
            var fakeAuthors = _fakeAuthors.Generate(howMany);
            await _authorService.InsertSeveral(fakeAuthors);
        }
    }
}
