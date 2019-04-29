using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IGetUser _getUser;
        private readonly ICreateUser _createUser;

        public UserController (IGetUser getUser, ICreateUser createUser)
        {
            _getUser = getUser;
            _createUser = createUser;
        }
       
        [HttpGet]
        [Route("from-username/{username}")]
        public async Task<JsonResult> GetFromUsername (string username)
        {
            var user = await _getUser.GetFromUsername(username);
            return new JsonResult(user);
        }

        [HttpGet]
        [Route("{userId}")]
       public async Task<JsonResult> GetUser (string id)
        {
            var user = await _getUser.Get(id);

            return new JsonResult(user);
        }

        [HttpPost]
        [Route("add")]
        public async Task<JsonResult> AddUser ([FromBody] JObject userToCreateJson)
        {
            try
            {
                var viewModel = userToCreateJson.ToObject<CreateUserViewModel>();
                if (viewModel != null)
                {
                    var user = CustomAutoMapper.Map<CreateUserViewModel, User>(viewModel);
                    user = await _createUser.Create(user);
                    return new JsonResult(user);
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
