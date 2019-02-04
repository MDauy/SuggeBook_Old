using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Application.WebApi.Controllers
{
    [Route("author")]
    public class AuthorController
    {
        [HttpGet]
        [Route("{id}")]
        public JsonResult GetAuthor(int id)
        {
            return new JsonResult("auteur 1");
        }
    }
}
