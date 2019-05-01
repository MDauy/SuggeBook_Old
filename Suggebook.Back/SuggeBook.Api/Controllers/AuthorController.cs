using Microsoft.AspNetCore.Mvc;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SuggeBook.Api.Controllers
{
    [Route("author")]
    public class AuthorController : Controller
    {
        private readonly IGetAuthor _getAuthor;
        private readonly ICreateAuthor _createAuthor;

        public AuthorController(IGetAuthor getAuthor, ICreateAuthor createAuthor)
        {
            this._getAuthor = getAuthor;
            _createAuthor = createAuthor;
        }


        [HttpGet]
        [Route("{authorId}")]
        public async Task<JsonResult> Get(string authorId)
        {
            var author = await _getAuthor.Get(authorId);

            var authorViewModel = CustomAutoMapper.Map<Author, AuthorViewModel>(author);
            authorViewModel.Books = CustomAutoMapper.MapLists<Book, AuthorViewModel.AuthorBook>(author.Books);

            return new JsonResult(authorViewModel);
        }

        public async Task<JsonResult> Create([FromBody] JObject author)
        {
            var authorViewModel = author.ToObject<CreateAuthorViewModel>();
            if (authorViewModel != null)
            {
                var authorToCreate = CustomAutoMapper.Map<CreateAuthorViewModel, Author>(authorViewModel);
                if (authorToCreate != null)
                {
                    var authorCreated = await _createAuthor.Create(authorToCreate);
                    return new JsonResult(CustomAutoMapper.Map<Author, AuthorViewModel>(authorCreated));
                }
            }
            return null;
        }
    }
}
