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

            var bookViewModel = CustomAutoMapper.Map<Book, BookViewModel>(book);
            bookViewModel.Authors = CustomAutoMapper.MapLists<Author, BookAuthorViewModel>(book.Authors);
            return new JsonResult(bookViewModel);
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] CreateBookViewModel book)
        {
            try
            {
                var bookModel = CustomAutoMapper.Map<CreateBookViewModel, Book>(book);
                bookModel.Authors = new List<Author>();
                foreach (var authorId in book.AuthorsIds)
                {
                    bookModel.Authors.Add(new Author
                    {
                        Id = authorId
                    });
                }
                if (bookModel == null)
                {
                    throw new ObjectCreationException("Book");
                }           
                
                bookModel = await _createBook.Create(bookModel);
                var bookViewModel = CustomAutoMapper.Map<Book, BookViewModel>(bookModel);
                bookViewModel.Authors = CustomAutoMapper.MapLists<Author, BookAuthorViewModel>(bookModel.Authors);
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
                var bookViewModel = CustomAutoMapper.Map<Book, BookViewModel>(model);
                bookViewModel.Authors = CustomAutoMapper.MapLists<Author, BookAuthorViewModel>(model.Authors);
                viewModels.Add(bookViewModel);
            }
            return new JsonResult(viewModels);
        }
    }
}
