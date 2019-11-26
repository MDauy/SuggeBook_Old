using Microsoft.AspNetCore.Mvc;
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
        private readonly IConnectUser _connectUser;

        public UserController(IGetUser getUser, ICreateUser createUser, IConnectUser connectUser)
        {
            _getUser = getUser;
            _createUser = createUser;
            _connectUser = connectUser;
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
                var user = CustomAutoMapper.Map<User>(userToCreate);
                user = await _createUser.Create(user);
                return new JsonResult(CustomAutoMapper.Map<UserViewModel>(user));

            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
        [HttpPut]
        [Route("connect")]
        public async Task<JsonResult> Connect([FromBody] UserToConnectViewModel userToConnect)
        {
            try
            {
                return new JsonResult(await _connectUser.Connect(userToConnect.UsernameOrEmail, userToConnect.Password));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }


    }
}
