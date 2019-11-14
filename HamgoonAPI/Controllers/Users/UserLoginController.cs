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
    public class UserLoginController
    {
        private readonly UserLoginService _service;
        public UserLoginController(UserLoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<object> Login(UserLoginRequest request)
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
