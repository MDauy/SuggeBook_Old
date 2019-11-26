using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;

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
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] CreateSagaViewModel saga)
        {
            try
            {
                return new JsonResult (await _createSaga.Create(CustomAutoMapper.Map<Saga>(saga)));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpGet]
        public Task<JsonResult> Get(string sagaId)
        {
            return null;
        }
    }
}