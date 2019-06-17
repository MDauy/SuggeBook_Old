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
    [Route("saga")]
    public class SagaController : Controller
    {
        private readonly ICreateSaga _createSaga;
        public SagaController(ICreateSaga createSaga)
        {
            _createSaga = createSaga;
        }

        [HttpPost]
        public async Task<JsonResult> Create([FromBody] CreateSagaViewModel saga)
        {
            try
            {
                return new JsonResult (await _createSaga.Create(saga.ToModel()));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        public Task<JsonResult> Get(string sagaId)
        {
            return null;
        }
    }
}