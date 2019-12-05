using System;
using System.Threading.Tasks;
using HamgoonAPI.Models.Requests;
using HamgoonAPI.Services.Users;
using HamgoonAPI.DataContext;
using Microsoft.AspNetCore.Mvc;
using HamgoonAPIV1.Services.RocketChat;

namespace HamgoonAPI.Controllers.Users
{
    [Route("login")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _service;
        private readonly IRocketChatService _rocketChatService;
        public UserLoginController(IUserLoginService service, IRocketChatService rocketChat)
            => (_service, _rocketChatService) = (service, rocketChat);

        [HttpPost]
        public async Task<object> Login([FromBody]UserLoginRequest request)
        {
            try
            {
                return new {
                    Token = await _service.LoginAsync(request.UserName, request.Password),
//                    RocketToken = (await _rocketChatService.Login(request.UserName, request.Password)).AuthToken
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
