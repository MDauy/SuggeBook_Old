using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    public class AuthorController : Controller
    {
        public AuthorController()
        {

        }


        [HttpGet]
        [Route("{id}")]
        public JsonResult GetAuthor (int id)
        {
            return null;
        }
    }
}
