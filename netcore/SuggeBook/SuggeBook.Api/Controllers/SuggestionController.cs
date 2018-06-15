using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        [Route ("/home")]
        public JsonResult Home([FromQuery] int uId)
        {
            //TODO : Appel à la DAL ici 
            var testSuggestions = _testsBank.Suggestions(30);
            return new JsonResult(testSuggestions);
        }

        [HttpPost]
        [Route ("add")]
        public JsonResult Add([FromBody] JObject data)
        {
            try
            {
                return new JsonResult(new {
                suggestion = data["suggestion"],
                userId = data["userId"]});
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
