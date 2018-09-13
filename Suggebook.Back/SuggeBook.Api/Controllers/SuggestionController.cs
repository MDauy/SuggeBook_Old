using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        private readonly IFakeSuggestionsService _fakeSuggestionsService;
        public SuggestionController(ISuggestionService service, IFakeSuggestionsService fakeSuggestionsService)
        {
            _service = service;
            _fakeSuggestionsService = fakeSuggestionsService;
        }

        [HttpGet]
        [Route ("/home")]
        public JsonResult Home([FromQuery] int uId)
        {
            //TODO : Appel à la DAL ici 
            return null;
        }

        [HttpPost]
        [Route ("add")]
        public JsonResult Insert([FromBody] InsertSuggestionDto dto)
        {
            try
            {
                _service.Insert(dto);
                return new JsonResult("true");
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
