using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
    [Route ("book")]
    public class BookController : Controller
    {
        private readonly IGetBook _getBook;
        private readonly ICreateBook _createBook;

        public BookController(IGetBook getBook, ICreateBook createBook)
        {
            _getBook = getBook;
            _createBook = createBook;
        }

        [Route("{bookId}")]
        public async Task<JsonResult> Get (string bookId)
        {
            var book = await _getBook.Get(bookId);
            var bookViewModel = CustomAutoMapper.Map<Book, BookViewModel>(book);
            return new JsonResult(bookViewModel); 
        }

        public async Task<JsonResult> Create([FromBody] JObject book)
        {
            try
            {
                var createBookViewModel = book.ToObject<CreateBookViewModel>();
                if (createBookViewModel != null)
                {
                    var bookToCreate = CustomAutoMapper.Map<CreateBookViewModel, Book>(createBookViewModel);
                    if (bookToCreate != null)
                    {
                        bookToCreate = await _createBook.Create(bookToCreate);
                        var bookViewModel = CustomAutoMapper.Map<Book, BookViewModel>(bookToCreate);
                        return new JsonResult(bookViewModel);
                    }
                }
                throw new ObjectCreationException("Book", book.ToString());
            }
             catch (Exception e)
            {
                return new JsonResult(e.Message);
            }            
        }

        public async Task<JsonResult> CreateSeveral([FromBody] JObject books)
        {
            try
            {
                var booksViewModels = books.ToObject<List<CreateBookViewModel>>();
                if (booksViewModels != null)
                {
                    var booksToCreate = CustomAutoMapper.MapLists<CreateBookViewModel, Book>(booksViewModels);
                    var createdBooks = await _createBook.CreateSeveral(booksToCreate);
                    return new JsonResult(CustomAutoMapper.MapLists<Book, BookViewModel>(createdBooks));
                }
                throw new ObjectCreationException("Book", books.ToString());
            }
            catch(Exception e)
            {
                return new JsonResult(e.Message);
            }
        }


    }
}
