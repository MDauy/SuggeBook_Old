using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost]
        [Route("add")]
        public ActionResult CreateAuthor ([FromBody] AuthorDto author)
        {
            try
            {              
                return new JsonResult(author);
            }
            catch
            {
                throw;
            }

        }
    }
}
