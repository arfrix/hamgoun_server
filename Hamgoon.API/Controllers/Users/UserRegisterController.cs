using System;
using System.Threading.Tasks;
using HamgoonAPI.Services.Users;
using HamgoonAPIV1.Services.RocketChat;
using Microsoft.AspNetCore.Mvc;
using User = Hamgoon.API.Models.User;

namespace Hamgoon.API.Controllers.Users
{
    [ApiController]
    [Route("register")]
    public class UserRegisterController : ControllerBase
    {
        private readonly IUserRegisterService _service;
        private readonly IRocketChatService _rocketChatService;

        public UserRegisterController(IUserRegisterService service, IRocketChatService rocketChat)
        {
            _service = service;
            _rocketChatService = rocketChat;
        }
        [HttpPost]
        public async Task<object> Register([FromBody]User user)
        {
            try
            {
                var newuser = await _service.Register(user);
                return new
                {
                    user = newuser,
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Status = false,
                    Message = ex.Message
                };
            }

        }
    }
}