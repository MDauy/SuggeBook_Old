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
    [Route("saga")]
    public class SagaController : Controller
    {
        private readonly ICreateSaga _createSaga;
        private readonly IMapper _mapper;
        public SagaController(ICreateSaga createSaga,
            IMapper mapper)
        {
            _createSaga = createSaga;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] CreateSagaViewModel saga)
        {
            try
            {
                return new JsonResult (await _createSaga.Create(_mapper.Map<Saga>(saga)));
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