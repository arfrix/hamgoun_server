using System;
using System.Threading.Tasks;
using HamgoonAPI.Request;
using HamgoonAPIV1.Services.RocketChat;
using Microsoft.AspNetCore.Mvc;

namespace HamgoonAPI.Controllers.Rocket
{
    [ApiController]
    [Route("[controller]")]
    public class RocketChatController
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
                return await _rocketChatService.Login(request.Username, request.Password);
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
                return await _rocketChatService.Register(request.Username, request.Email, request.Password,
                    request.Name);
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}