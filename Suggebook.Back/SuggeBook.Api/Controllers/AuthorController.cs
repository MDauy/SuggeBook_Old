using Microsoft.AspNetCore.Mvc;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route("author")]
    public class AuthorController : Controller
    {
        private IGetAuthor _getAuthor;

        public AuthorController(IGetAuthor getAuthor)
        {
            this._getAuthor = getAuthor;
        }


        [HttpGet]
        [Route("{authorId}")]
        public async Task<JsonResult> Get (string authorId)
        {
            var author = await _getAuthor.Get(authorId);

            var authorViewModel = CustomAutoMapper.Map<Author, AuthorViewModel>(author);
            authorViewModel.Books = CustomAutoMapper.MapLists<Book, AuthorViewModel.AuthorBook>(author.Books);

            return new JsonResult(authorViewModel);
        }
    }
}
