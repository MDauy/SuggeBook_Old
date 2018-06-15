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
    [Route("user")]
    public class UserController : Controller
    {
        private ITestsBank _testsBank;

        public UserController (ITestsBank testsBank)
        {
            _testsBank = testsBank ;
        }
       

        [HttpGet]
        [Route("{userId}")]
       public JsonResult GetUser (int id)
        {
            return new JsonResult(_testsBank.User());
        }

        [HttpPost]
        [Route("add")]
        public JsonResult AddUser ([FromBody] User user)
        {
            try
            {
                return new JsonResult(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
