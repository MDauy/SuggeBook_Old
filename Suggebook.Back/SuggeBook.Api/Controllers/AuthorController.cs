using System;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Threading.Tasks;
using SuggeBook.Framework;
using SuggeBook.Domain.Model;

namespace SuggeBook.Api.Controllers
{
    [Route("author")]
    public class AuthorController : Controller
    {
        private readonly IGetAuthor _getAuthor;
        private readonly ICreateAuthor _createAuthor;

        public AuthorController(IGetAuthor getAuthor, ICreateAuthor createAuthor)
        {
            _getAuthor = getAuthor;
            _createAuthor = createAuthor;
        }


        [HttpGet]
        [Route("{authorId}")]
        public async Task<JsonResult> Get(string authorId)
        {
            var author = await _getAuthor.Get(authorId);

            var authorViewModel =CustomAutoMapper.Map<Author, AuthorViewModel>(author);

            return new JsonResult(authorViewModel);
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] CreateAuthorViewModel author)
        {
            try
            {
                var authorModel = CustomAutoMapper.Map<CreateAuthorViewModel, Author>(author);
                authorModel = await _createAuthor.Create(authorModel);
                return new JsonResult(CustomAutoMapper.Map<Author, AuthorViewModel>(authorModel));
            }
            catch (Exception exception)
            {
                return new JsonResult(exception.Message);
            }
        }
    }
}
