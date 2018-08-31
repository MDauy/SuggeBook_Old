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
        public SuggestionController()
        {
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
                return null;
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
