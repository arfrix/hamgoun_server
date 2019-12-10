using System;
using System.Threading.Tasks;
using HamgoonAPI.Requests;
using HamgoonAPI.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Hamgoon.API.Controllers.Users
{
    [Route("login")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _service;
        public UserLoginController(IUserLoginService service)
            => (_service) = (service);

        [HttpPost]
        public async Task<object> Login([FromBody] UserLoginRequest request)
        {
            try
            {
                var loginResponse = await _service.LoginAsync(request.UserName, request.Password);
                return new {
                    Token = loginResponse.BearerToken,
                    loginResponse.UserId,
                    Status = true
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
