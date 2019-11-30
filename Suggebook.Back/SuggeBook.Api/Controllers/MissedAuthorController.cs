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
using AutoMapper;

namespace SuggeBook.Api.Controllers
{
    [Produces("application/json")]
    [Route("missedAuthor")]
    public class MissedAuthorController : Controller
    {
        private readonly IRegisterMissedAuthor _registerMissedAuthor;
        private readonly IMapper _mapper;

        public MissedAuthorController(IRegisterMissedAuthor registerMissedAuthor,
            IMapper mapper)
        {
            _registerMissedAuthor = registerMissedAuthor;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<JsonResult> Register([FromBody] MissedAuthorViewModel missedAuthorViewModel)
        {
            var model = _mapper.Map<MissedAuthor> (missedAuthorViewModel);
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