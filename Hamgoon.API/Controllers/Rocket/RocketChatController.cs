using System;
using System.Threading.Tasks;
using HamgoonAPI.Request;
using HamgoonAPIV1.Services.RocketChat;
using Microsoft.AspNetCore.Mvc;

namespace Hamgoon.API.Controllers.Rocket
{
    [ApiController]
    [Route("[controller]")]
    public class RocketChatController: ControllerBase
    {
        private IRocketChatService _rocketChatService;

        public RocketChatController(IRocketChatService service)
        {
            _rocketChatService = service;
        }

        [HttpPost("login")]
        public async Task<object> Login([FromBody] RocketLoginRequest request)
        {
            try
            {
                return await _rocketChatService.Login(Convert.ToInt64(HttpContext.User.Identity.Name));
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost("register")]
        public async Task<object> Register([FromBody] RocketChatRegisterRequest request)
        {
            try
            {
                return await _rocketChatService.Register(Convert.ToInt64(HttpContext.User.Identity.Name));
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}