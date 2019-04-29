using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route("suggestion")]
    public class SuggestionController : Controller
    {
        private readonly ICreateSuggestion _createSuggestion;
        public SuggestionController(ICreateSuggestion createSuggestion)
        {
            createSuggestion = _createSuggestion;
        }

        [HttpGet]
        [Route("/home")]
        public JsonResult Home([FromQuery] int uId)
        {
            //TODO : Appel à la DAL ici 
            return null;
        }


        [HttpPost]
        [Route("add")]
        public async Task<JsonResult> Add([FromBody]JObject json)
        {
            try
            {
                CreateSuggestionViewModel createSuggestionViewModel = json.ToObject<CreateSuggestionViewModel>();
                var suggestion = CustomAutoMapper.Map<CreateSuggestionViewModel, Suggestion>(createSuggestionViewModel);
                if (suggestion != null)
                {
                    var createdSuggestion = await _createSuggestion.Create(suggestion);
                    return new JsonResult(createdSuggestion);
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
