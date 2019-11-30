using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;

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
        public async Task<JsonResult> Register([FromBody] MissedAuthorViewModel missedAuthorViewModel)
        {
            var model = CustomAutoMapper.Map<MissedAuthorViewModel, MissedAuthor> (missedAuthorViewModel);
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