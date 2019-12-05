﻿using System;
using System.Threading.Tasks;
using HamgoonAPI.Services.Users;
using HamgoonAPI.DataContext;
using HamgoonAPI.Requests;
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
