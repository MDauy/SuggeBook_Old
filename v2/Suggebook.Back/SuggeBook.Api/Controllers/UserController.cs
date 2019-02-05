using Microsoft.AspNetCore.Mvc;
using SuggeBook.Business.Services.Contracts;
using SuggeBook.Dto.Models;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController (IUserService userService)
        {
            _userService = userService;
        }
       
        [HttpGet]
        [Route("from-username/{username}")]
        public async Task<JsonResult> GetFromUsername (string username)
        {
            var user = await _userService.GetFromUsername(username);
            return new JsonResult(user);
        }

        [HttpGet]
        [Route("{userId}")]
       public async Task<JsonResult> GetUser (string id)
        {
            var user = await _userService.Get(id);

            return new JsonResult(user);
        }

        [HttpPost]
        [Route("add")]
        public JsonResult AddUser ([FromBody] UserDto user)
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
