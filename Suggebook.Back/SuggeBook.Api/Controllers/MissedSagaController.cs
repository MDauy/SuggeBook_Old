using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Suggebook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.ViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/missedSaga")]
    public class MissedSagaController : Controller
    {
        private readonly IRegisterMissedSaga _registerMissedSaga;
        private readonly IMapper _mapper;

        public MissedSagaController(IRegisterMissedSaga registerMissedSaga, IMapper mapper)
        {
            _registerMissedSaga = registerMissedSaga;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<StatusCodeResult> Register([FromBody] MissedSagaViewModel missedSagaViewModel)
        {
                var missedSaga = _mapper.Map<MissedSaga>(missedSagaViewModel);

                await _registerMissedSaga.Register(missedSaga);

                return new StatusCodeResult((int)HttpStatusCode.Created);
            
        }
    }
}
