using System;
using System.Threading.Tasks;
using HamgoonAPI.Services.Users;
using Microsoft.AspNetCore.Mvc;
using User = Hamgoon.API.Models.User;

namespace Hamgoon.API.Controllers.Users
{
    [ApiController]
    [Route("register")]
    public class UserRegisterController : ControllerBase
    {
        private readonly IUserRegisterService _service;

        public UserRegisterController(IUserRegisterService service) => _service = service;
        [HttpPost]
        public async Task<object> Register([FromBody]User user)
        {
            try
            {
                var newUser = await _service.Register(user);
                return new
                {
                    user = newUser,
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Status = false,
                    ex.Message
                };
            }

        }
    }
}