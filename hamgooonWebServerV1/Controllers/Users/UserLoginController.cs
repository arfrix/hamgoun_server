using System;
using System.Threading.Tasks;
using hamgooonWebServerV1.Data;
using hamgooonWebServerV1.Models.Requests;
using hamgooonWebServerV1.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace hamgooonWebServerV1.Controllers.Users
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
