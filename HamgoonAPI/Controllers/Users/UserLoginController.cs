using System;
using System.Threading.Tasks;
using HamgoonAPI.Models.Requests;
using HamgoonAPI.Services.Users;
using HamgoonAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace HamgoonAPI.Controllers.Users
{
    [Route("login")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _service;
        public UserLoginController(IUserLoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<object> Login([FromBody]UserLoginRequest request)
        {
            try
            {
                return new {
                    Token = await _service.LoginAsync(request.UserName, request.Password)
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
