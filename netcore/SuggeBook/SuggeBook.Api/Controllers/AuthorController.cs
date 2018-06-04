using Microsoft.AspNetCore.Mvc;
using SuggeBook.Dto.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    public class AuthorController : Controller
    {
        private ITestsBank _banksTest;

        public AuthorController(ITestsBank banksTest)
        {
            this._banksTest = banksTest;
        }


        [HttpGet]
        [Route("{id}")]
        public JsonResult GetAuthor (int id)
        {
           return new JsonResult(_banksTest.Author());
        }
    }
}
