using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Application.WebApi.Controllers
{
    public class BookController
    {
        [Route("{bookId}")]
        public JsonResult GetBook(int bookId)
        {
            return new JsonResult(_testsBank.Book());
        }


        [HttpPost]
        [Route("add")]
        public JsonResult AddBook([FromBody] Book book)
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
