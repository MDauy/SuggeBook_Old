using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Mocks;
using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route("author")]
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            this._authorService = authorService;
        }


        [HttpGet]
        [Route("{authorId}")]
        public async Task<JsonResult> Get (string authorId)
        {
            var bookDto = await _authorService.Get(authorId);

            return new JsonResult(bookDto);
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> Add ([FromBody] InsertAuthorDto author)
        {
            try
            {
               await  _authorService.Insert(author);
                return Ok();
            }
            catch
            {
                throw;
            }

        }
    }
}
