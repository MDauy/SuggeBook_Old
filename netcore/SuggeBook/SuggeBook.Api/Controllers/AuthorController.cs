using Microsoft.AspNetCore.Mvc;
using SuggeBook.Dao.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    public class AuthorController : Controller
    {
        private IFakeAuthorService _fakeAuthorService;

        public AuthorController(IFakeAuthorService fakeAuthorService)
        {
            this._fakeAuthorService = fakeAuthorService;
        }


        [HttpGet]
        [Route("{id}")]
        public JsonResult GetAuthor (int id)
        {
            return null;
        }
    }
}
