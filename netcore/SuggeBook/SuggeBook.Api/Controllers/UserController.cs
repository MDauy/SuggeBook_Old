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
    [Route("user")]
    public class UserController : Controller
    {
        private IFakeUserService _fakeUserService;

        public UserController (IFakeUserService fakeUserService)
        {
            this._fakeUserService = fakeUserService;
        }
       

        [HttpGet]
        [Route("{userId}")]
       public JsonResult GetUser (int id)
        {
            return new JsonResult(this._fakeUserService.Generate(1));
        }

        [HttpPost]
        [Route("add")]
        public void AddUser (string userJson)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(userJson);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
