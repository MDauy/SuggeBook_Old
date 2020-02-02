using Microsoft.AspNetCore.Mvc;
using SuggeBook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using System;
using System.Threading.Tasks;
using AutoMapper;
using System.Net;
using Suggebook.ViewModels;

namespace SuggeBook.Api.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IGetUser _getUser;
        private readonly ICreateUser _createUser;
        private readonly IConnectUser _connectUser;
        private readonly IMapper _mapper;
        public UserController(IGetUser getUser, ICreateUser createUser, IConnectUser connectUser,
            IMapper mapper)
        {
            _getUser = getUser;
            _createUser = createUser;
            _connectUser = connectUser;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("from-username/{username}")]
        public async Task<JsonResult> GetFromUsername(string username)
        {
            var user = await _getUser.GetFromUsername(username);
            return new JsonResult(user);
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> Get(string id)
        {
            var user = await _getUser.Get(id);

            return new JsonResult(user);
        }

        [HttpPost]
        public async Task<JsonResult> Create([FromBody] CreateUserViewModel userToCreate)
        {
            try
            {
                var user = _mapper.Map<User>(userToCreate);
                user = await _createUser.Create(user);
                return new JsonResult(new HttpResultViewModel(HttpStatusCode.Created, string.Empty));

            }
            catch (Exception e)
            {
                return new JsonResult(new HttpResultViewModel(HttpStatusCode.InternalServerError, e.InnerException.Message));
            }
        }
        [HttpPut]
        public async Task<JsonResult> Connect([FromBody] UserToConnectViewModel userToConnect)
        {
            var user = await _connectUser.Connect(userToConnect.UsernameOrEmail, userToConnect.Password);
            return new JsonResult(user);
        }


    }
}
