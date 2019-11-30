using System;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Threading.Tasks;
using SuggeBook.Framework;
using SuggeBook.Domain.Model;
using SuggeBook.ViewModels;
using AutoMapper;

namespace SuggeBook.Api.Controllers
{
    [Route("author")]
    public class AuthorController : Controller
    {
        private readonly IGetAuthor _getAuthor;
        private readonly ICreateAuthor _createAuthor;
        private readonly IMapper _mapper;
        public AuthorController(IGetAuthor getAuthor, ICreateAuthor createAuthor,
            IMapper mapper)
        {
            _getAuthor = getAuthor;
            _createAuthor = createAuthor;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("{authorId}")]
        public async Task<JsonResult> Get(string authorId)
        {
            var author = await _getAuthor.Get(authorId);

            var authorViewModel =_mapper.Map<AuthorViewModel>(author);

            return new JsonResult(authorViewModel);
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] CreateAuthorViewModel author)
        {
            try
            {
                var authorModel = _mapper.Map<Author>(author);
                authorModel = await _createAuthor.Create(authorModel);
                return new JsonResult(_mapper.Map<AuthorViewModel>(authorModel));
            }
            catch (Exception exception)
            {
                return new JsonResult(exception.Message);
            }
        }
    }
}
