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
    [Route ("book")]
    public class BookController : Controller
    {
        private ITestsBank _testsBank;
        public BookController(ITestsBank testsBank)
        {
            this._testsBank = testsBank;
        }

        [Route("{bookId}")]
        public JsonResult GetBook (int bookId)
        {
            return new JsonResult(_testsBank.Book());
        }


        [HttpPost]
        [Route("add")]
        public void AddBook (string bookJson)
        {
            try
            {
                Book book = JsonConvert.DeserializeObject<Book>(bookJson);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
