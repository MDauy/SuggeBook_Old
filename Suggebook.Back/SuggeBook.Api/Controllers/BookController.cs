using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route ("book")]
    public class BookController : Controller
    {
        private readonly IGetBook _getBook;

        public BookController(IGetBook getBook, ICreateBook)
        {
            _getBook = getBook;
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
            var createBookViewModel = book.ToObject<CreateBookViewModel>();
            if (createBookViewModel != null)
            {
               var bookModel = CustomAutoMapper.Map<CreateBookViewModel, Book>(createBookViewModel);

            }
        }


    }
}
