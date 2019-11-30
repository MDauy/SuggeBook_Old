using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;

namespace SuggeBook.Api.Controllers
{
    [Produces("application/json")]
    [Route("missedBook")]
    public class MissedBookController : Controller
    {
        private readonly IRegisterMissedBook _registerMissedBook;
        public MissedBookController (IRegisterMissedBook registerMissedBook)
        {
            _registerMissedBook =registerMissedBook;
        }

        [HttpPost]
        public async Task<JsonResult> Register ([FromBody] MissedBookViewModel missedBookViewModel)
        {
            try
            {
            var missedBook = CustomAutoMapper.Map<MissedBookViewModel, MissedBook>(missedBookViewModel);

            missedBook = await _registerMissedBook.Register(missedBook);

                return new JsonResult(CustomAutoMapper.Map<MissedBook, MissedBookViewModel> (missedBook));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}