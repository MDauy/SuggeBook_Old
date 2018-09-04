using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Mocks;
using SuggeBook.Dto.Models;
using System;

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


        public JsonResult GetFromBookId (int bookId)
        {
            return null;
        }
    }
}
