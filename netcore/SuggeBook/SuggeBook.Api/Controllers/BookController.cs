using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuggeBook.Dao.Mocks;
using SuggeBook.Dao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route ("book")]
    public class BookController : Controller
    {
        private IFakeBooksService _fakeBooksService;
        public BookController(IFakeBooksService fakeBooksService)
        {
            this._fakeBooksService = fakeBooksService;
        }

        [Route("{bookId}")]
        public JsonResult GetBook (int bookId)
        {
            return new JsonResult(_fakeBooksService.Generate(1));
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
