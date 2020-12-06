using Microsoft.AspNetCore.Mvc;
using SuggeBook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System;

namespace SuggeBook.Api.Controllers
{
    [Route("api/book")]
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

        [HttpGet("{bookId}")]
        public async Task<JsonResult> Get(string bookId)
        {
            var book = await _getBook.Get(bookId);

            var bookViewModel = _mapper.Map<Book, BookViewModel>(book);
            return new JsonResult(bookViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> Create([FromBody] CreateBookViewModel book)
        {
            try
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
            bookModel.Authors = authors;
            bookModel = await _createBook.Create(bookModel);
            var bookViewModel = _mapper.Map<BookViewModel>(bookModel);
            return new JsonResult(new HttpResultViewModel(System.Net.HttpStatusCode.Created, bookViewModel.Id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new HttpResultViewModel(System.Net.HttpStatusCode.InternalServerError, ex.InnerException.Message));
            }
        }

        public async Task<JsonResult> Index()
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
