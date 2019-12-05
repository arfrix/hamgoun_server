using System;
using System.Threading.Tasks;
using HamgoonAPI.Services.Users;
using Microsoft.AspNetCore.Mvc;
using HamgoonAPIV1.Services.RocketChat;

namespace HamgoonAPI.Controllers.Users
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
        public async Task<object> Register([FromBody]Models.User user)
        {
            try
            {
                var newuser = await _service.Register(user);
//                var rocketToken = (await _rocketChatService.Register(user.UserName, user.Email, user.Pass, user.UserName)).AuthToken;
                return new
                {
                    user = newuser,
//                    rocketToken
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