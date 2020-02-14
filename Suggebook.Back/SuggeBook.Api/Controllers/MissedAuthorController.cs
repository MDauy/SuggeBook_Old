using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using AutoMapper;
using System.Net;

namespace SuggeBook.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/missedAuthor")]
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
        public async Task<StatusCodeResult> Register([FromBody] MissedAuthorViewModel missedAuthorViewModel)
        {
            var model = _mapper.Map<MissedAuthor> (missedAuthorViewModel);

                 await _registerMissedAuthor.Register(model);

                return new StatusCodeResult((int)HttpStatusCode.Created);   
        }
    }
}