using System.Threading.Tasks;
using HamgoonAPIV1.Services.RocketChat;
using Microsoft.AspNetCore.Mvc;

namespace HamgoonAPI.Controllers.Rocket
{
    public class RocketChatController
    {
        private IRocketChatService _rocketChatService;
        public RocketChatController(IRocketChatService service)
        {
            _rocketChatService = service;
        }

        public async Task<RocketIdentityPayload> Login([FromBody] string username, string password)
        {
            return await _rocketChatService.Login(username, password);
        }

        public async Task<RocketIdentityPayload> Register([FromBody] string username, string email, string name,
            string pass)
        {
            return await _rocketChatService.Register(username, email, pass, name);
        }
    }
}