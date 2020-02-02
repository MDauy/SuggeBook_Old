using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using AutoMapper;
using Suggebook.ViewModels;

namespace SuggeBook.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/saga")]
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
        public async Task<JsonResult> Create([FromBody] CreateSagaViewModel saga)
        {
            try
            {
                var sagaModel = await _createSaga.Create(_mapper.Map<Saga>(saga));
                return new JsonResult(new  HttpResultViewModel(System.Net.HttpStatusCode.Created, sagaModel.Id));
            }
            catch (Exception e)
            {
                return new JsonResult(new HttpResultViewModel(System.Net.HttpStatusCode.InternalServerError, e.InnerException.Message));
            }
        }

        [HttpGet("{sagaId}")]
        public Task<JsonResult> Get(string sagaId)
        {
            return null;
        }
    }
}