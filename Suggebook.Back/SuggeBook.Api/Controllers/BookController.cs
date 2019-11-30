using Microsoft.AspNetCore.Mvc;
using SuggeBook.Api.Exceptions;
using SuggeBook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace SuggeBook.Api.Controllers
{
    [Route("book")]
    public class BookController : Controller
    {
        private readonly IGetBook _getBook;
        private readonly ICreateBook _createBook;
        private readonly IGetHomeBooks _getHomeBooks;
        private readonly IGetSaga _getSaga;
        private readonly IMapper _mapper;

        public BookController(IGetBook getBook,
            ICreateBook createBook,
            IGetHomeBooks getHomeBooks,
            IGetSaga getSaga,
            IMapper mapper)
        {
            _getBook = getBook;
            _createBook = createBook;
            _getHomeBooks = getHomeBooks;
            _getSaga = getSaga;
            _mapper = mapper;
        }

        [Route("{bookId}")]
        public async Task<JsonResult> Get(string bookId)
        {
            var book = await _getBook.Get(bookId);

            var bookViewModel = _mapper.Map<Book, BookViewModel>(book);
            return new JsonResult(bookViewModel);
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] CreateBookViewModel book)
        {
            var bookModel = _mapper.Map<Book>(book);
            if (!string.IsNullOrEmpty(book.SagaId))
            {
                bookModel.Saga = await _getSaga.GetSaga(book.SagaId);
            }
            var authors = new List<Author>();
            foreach (var authorId in book.AuthorsIds)
            {
                authors.Add(new Author
                {
                    Id = authorId
                });
            }
            if (bookModel == null)
            {
                throw new ObjectCreationException("Book");
            }
            bookModel.Authors = authors;
            bookModel = await _createBook.Create(bookModel);
            var bookViewModel = _mapper.Map<BookViewModel>(bookModel);
            return new JsonResult(bookViewModel);
        }

        [HttpGet]
        [Route("home")]
        public async Task<JsonResult> GetHomeBooks()
        {
            var booksModels = await _getHomeBooks.Get();
            var viewModels = new List<BookViewModel>();
            foreach (var model in booksModels)
            {
                var bookViewModel = _mapper.Map<Book, BookViewModel>(model);
                viewModels.Add(bookViewModel);
            }
            return new JsonResult(viewModels);
        }
    }
}
