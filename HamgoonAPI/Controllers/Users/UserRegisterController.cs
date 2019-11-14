using System;
using System.Linq;
using System.Threading.Tasks;
using HamgoonAPI.Models;
using HamgoonAPI.Services.Users;
using HamgoonAPI.Data;
using HamgoonAPI.Exceptions.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamgoonAPI.Controllers.Users
{
    [Route("register")]
    public class UserRegisterController : ControllerBase
    {
        private readonly UserRegisterService _service;
        public UserRegisterController(UserRegisterService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<User> Register(User user)
        {
            return await _service.Register(user);
        }
    }
}