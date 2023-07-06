using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.Domain.UseCasesInterfaces;

namespace SuggeBook.Api.Controllers
{
    public class RecommanderController : Controller
    {
        private IGetYouMightLikeSuggestions _getYouMightLikeSuggestions;
        public RecommanderController (IGetYouMightLikeSuggestions getYouMightLikeSuggestions)
        {
            _getYouMightLikeSuggestions = getYouMightLikeSuggestions;
        }
        
        [HttpGet("you-might-like")]
        public async Task<JsonResult> YouMightLike(string userId)
        {
            return new JsonResult(await _getYouMightLikeSuggestions.Get(userId));
        }
    }
}