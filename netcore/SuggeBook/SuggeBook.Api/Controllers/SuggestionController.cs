using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using SuggeBook.Dao.Mocks;
using SuggeBook.Dao.Models;
using System;

namespace SuggeBook.Api.Controllers
{
    [Route("suggestion")]
    public class SuggestionController : Controller
    {
        private IFakeSuggestionsService _fakeSuggestionService;
        public SuggestionController(IFakeSuggestionsService fakeSuggestionService)
        {
            this._fakeSuggestionService = fakeSuggestionService;
        }

        [HttpGet]
        [Route ("home/{userId}")]
        public JsonResult Home(int userId)
        {
            //TODO : Appel à la DAL ici 
            var testSuggestions = _fakeSuggestionService.Generate(30);
            return new JsonResult(testSuggestions);
        }

        [HttpPost]
        [Route ("create")]
        public void Create(string jsonSuggestion, int userId)
        {
            try
            {
                var suggestion = JsonConvert.DeserializeObject<Suggestion>(jsonSuggestion);                
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
