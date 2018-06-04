using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using SuggeBook.Dto.Mocks;
using SuggeBook.Dto.Models;
using System;

namespace SuggeBook.Api.Controllers
{
    [Route("suggestion")]
    public class SuggestionController : Controller
    {
        private ITestsBank _testsBank;
        public SuggestionController(ITestsBank testsBank)
        {
            _testsBank = testsBank;
        }

        [HttpGet]
        [Route ("home/{userId}")]
        public JsonResult Home(int userId)
        {
            //TODO : Appel à la DAL ici 
            var testSuggestions = _testsBank.Suggestions(30);
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
