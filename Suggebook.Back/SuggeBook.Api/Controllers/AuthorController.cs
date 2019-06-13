using System;
using Microsoft.AspNetCore.Mvc;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Threading.Tasks;

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

            var authorViewModel = new AuthorViewModel(author);

            return new JsonResult(authorViewModel);
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] CreateAuthorViewModel author)
        {
            try
            {
                var authorModel = author.ToModel();
                authorModel = await _createAuthor.Create(authorModel);
                return new JsonResult(new AuthorViewModel(authorModel));
            }
            catch (Exception exception)
            {
                return new JsonResult(exception.Message);
            }
        }
    }
}
