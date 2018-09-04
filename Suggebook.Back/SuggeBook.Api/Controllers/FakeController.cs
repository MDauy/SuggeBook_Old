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
        private readonly IBookService _bookService;

        public FakeController (IFakeBooksService fakeBooks,
            IBookService bookService)
        {
            _fakeBooks = fakeBooks;
            _bookService = bookService;
        }

        [Route("addBooks/{howMany}")]
        public async Task GenerateBooks (int howMany)
        {
            var fakeBooks = _fakeBooks.Generate(howMany);
            await _bookService.InsertSeveral(fakeBooks);
        }
    }
}
