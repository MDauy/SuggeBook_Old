using Microsoft.AspNetCore.Mvc;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Mocks;
using SuggeBook.Dto.Models;
using SuggeBookDAL.Dao;
using SuggeBookDAL.Repositories;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route ("book")]
    public class BookController : Controller
    {
        private ITestsBank _testsBank;
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [Route("{bookId}")]
        public async Task<JsonResult> Get (string bookId)
        {
            var book = await _bookService.Get(bookId);

            return new JsonResult(book);
        }


        [HttpPost]
        [Route("add")]
        public JsonResult AddBook ([FromBody] InsertBookDto book)
        {
            try
            {
                _bookService.Insert(book);
                return new JsonResult("Book added");
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
