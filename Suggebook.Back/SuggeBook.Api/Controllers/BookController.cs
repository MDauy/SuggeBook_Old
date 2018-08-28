using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuggeBook.Dto.Mocks;
using SuggeBook.Dto.Models;
using SuggeBookDAL.DataServices.Contracts;
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
        private readonly IBookDataService _bookService;
        public BookController(IBookDataService bookService)
        {
            this._bookService = bookService;
        }

        [Route("{bookId}")]
        public async Task<JsonResult> GetBook (int bookId)
        {
            var book = _bookService.GetBook(bookId);
        }


        [HttpPost]
        [Route("add")]
        public JsonResult AddBook ([FromBody] BookDto book)
        {
            try
            {
                return new JsonResult(book);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
