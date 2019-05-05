using Microsoft.AspNetCore.Mvc;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.UseCasesInterfaces;
using System;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IGetUser _getUser;
        private readonly ICreateUser _createUser;

        public UserController(IGetUser getUser, ICreateUser createUser)
        {
            _getUser = getUser;
            _createUser = createUser;
        }

        [HttpGet]
        [Route("from-username/{username}")]
        public async Task<JsonResult> GetFromUsername(string username)
        {
            var user = await _getUser.GetFromUsername(username);
            return new JsonResult(user);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<JsonResult> Get(string id)
        {
            var user = await _getUser.Get(id);

            return new JsonResult(user);
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] CreateUserViewModel userToCreate)
        {
            try
            {

                var user = userToCreate.ToModel();
                user = await _createUser.Create(user);
                return new JsonResult(new UserViewModel(user));

            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

    }
}
