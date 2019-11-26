using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using System;
using System.Threading.Tasks;
using static SuggeBook.Api.ViewModels.SuggestionViewModel;

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
                var suggestion = CustomAutoMapper.Map<Suggestion>(suggestionToCreate);
                suggestion = await _createSuggestion.Create(suggestion);
                var suggestionViewModel= CustomAutoMapper.Map<SuggestionViewModel>(suggestion);
                return new JsonResult(suggestionViewModel);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}
