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
            _createSuggestion = createSuggestion;
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Add([FromBody]CreateSuggestionViewModel suggestionToCreate)
        {
            try
            {
                var suggestion = suggestionToCreate.ToModel();
                suggestion = await _createSuggestion.Create(suggestion);
                return new JsonResult(new SuggestionViewModel(suggestion));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}
