using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.UseCasesInterfaces;

namespace SuggeBook.Api.Controllers
{
    [Produces("application/json")]
    [Route("missedAuthor")]
    public class MissedAuthorController : Controller
    {
        private readonly IRegisterMissedAuthor _registerMissedAuthor;
        public MissedAuthorController(IRegisterMissedAuthor registerMissedAuthor)
        {
            _registerMissedAuthor = registerMissedAuthor;
        }

        [HttpPost]
        [Route("register")]
        public async Task<JsonResult> Register([FromBody] RegisterMissedAuthorViewModel missedAuthorViewModel)
        {
            var model = missedAuthorViewModel.ToModel();
            try
            {
                model = await _registerMissedAuthor.Register(model);

                return new JsonResult ($"{model.Name} registered");
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}