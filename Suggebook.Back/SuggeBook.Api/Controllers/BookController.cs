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

        public BookController(IGetBook getBook)
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

        //public async Task<JsonResult> Create ([FromBody] JObject bookToCreate)
        //{
        //    var book = bookToCreate.ToObject<CreateBookViewModel>();
        //    if (book != null)
        //    {

        //    }
        //}


    }
}
