using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using AutoMapper;

namespace SuggeBook.Api.Controllers
{
    [Produces("application/json")]
    [Route("missedBook")]
    public class MissedBookController : Controller
    {
        private readonly IRegisterMissedBook _registerMissedBook;
        private readonly IMapper _mapper;

        public MissedBookController (IRegisterMissedBook registerMissedBook,
            IMapper mapper)
        {
            _registerMissedBook =registerMissedBook;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<JsonResult> Register ([FromBody] MissedBookViewModel missedBookViewModel)
        {
            try
            {
            var missedBook = _mapper.Map<MissedBook>(missedBookViewModel);

            missedBook = await _registerMissedBook.Register(missedBook);

                return new JsonResult(_mapper.Map<MissedBookViewModel> (missedBook));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}