using Microsoft.AspNetCore.Mvc;
using SuggeBook.Api.Exceptions;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route("book")]
    public class BookController : Controller
    {
        private readonly IGetBook _getBook;
        private readonly ICreateBook _createBook;
        private readonly IGetHomeBooks _getHomeBooks;

        public BookController(IGetBook getBook, ICreateBook createBook, IGetHomeBooks getHomeBooks)
        {
            _getBook = getBook;
            _createBook = createBook;
            _getHomeBooks = getHomeBooks;
        }

        [Route("{bookId}")]
        public async Task<JsonResult> Get(string bookId)
        {
            var book = await _getBook.Get(bookId);
            var bookViewModel = new BookViewModel(book);
            return new JsonResult(bookViewModel);
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] CreateBookViewModel book)
        {
            try
            {
                var bookModel = book.ToModel();
                if (bookModel == null)
                {
                    throw new ObjectCreationException("Book");
                }

                bookModel.Author = new Author {Id = book.AuthorId};
                bookModel = await _createBook.Create(bookModel);
                var bookViewModel = new BookViewModel(bookModel);
                return new JsonResult(bookViewModel);
            }
            catch (Exception exception)
            {
                return new JsonResult(exception.Message);
            }
        }

        [HttpGet]
        [Route("home")]
        public async Task<JsonResult> GetHomeBooks()
        {
            var booksModels = await _getHomeBooks.Get();
            var viewModels = new List<BookViewModel>();
            foreach (var model in booksModels)
            {
                viewModels.Add(new BookViewModel(model));
            }
            return new JsonResult(viewModels);
        }
    }
}
