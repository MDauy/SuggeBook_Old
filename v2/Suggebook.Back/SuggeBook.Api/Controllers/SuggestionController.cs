using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Mocks;
using SuggeBook.Dto.Models;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route("suggestion")]
    public class SuggestionController : Controller
    {
        private ISuggestionService _service;
        private IBookService _bookService;
        private IAuthorService _authorService;
        private readonly IFakeSuggestionsService _fakeSuggestionsService;
        public SuggestionController(ISuggestionService service, IFakeSuggestionsService fakeSuggestionsService,
            IBookService bookService, IAuthorService authorService)
        {
            _service = service;
            _fakeSuggestionsService = fakeSuggestionsService;
            _bookService = bookService;
            _authorService = authorService;
        }

        [HttpGet]
        [Route ("/home")]
        public JsonResult Home([FromQuery] int uId)
        {
            //TODO : Appel à la DAL ici 
            return null;
        }

        public void Deserialize([FromBody] string dto)
        {
            
        }

        [HttpPost]
        [Route ("add")]
        public async Task<JsonResult> Insert([FromBody]JObject json)
        {
            try
            {
                var dto = json.ToObject<InsertSuggestionDto>();
                await _service.Insert(dto);
                var book = await _bookService.Get(dto.BookId);
                var author = await _authorService.GetFull(dto.AuthorId);
                return new JsonResult(new
                {
                    updatedAuthor = author,
                    updatedBook = book
                });
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [Route("frombook/{bookId}")]
        public async Task<JsonResult> GetFromBookId (string bookId)
        {
            var suggestions = await _service.GetFomBook(bookId);
            return new JsonResult(suggestions);
        }
    }
}
