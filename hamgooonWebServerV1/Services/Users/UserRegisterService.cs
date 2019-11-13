using System;
using System.Threading.Tasks;
using hamgooonWebServerV1.Data;
using hamgooonWebServerV1.Models;
using hamgooonWebServerV1.Models.Requests;
using Microsoft.AspNetCore.Identity;

namespace hamgooonWebServerV1.Services.Users
{
    public class UserRegisterService
    {
        private readonly HamgooonMySQLContext _context;
        private readonly IPasswordHasher<User> _hasher;

        public UserRegisterService(HamgooonMySQLContext context, IPasswordHasher<User> hasher)
        {
            _context = context;
            _hasher = hasher;
        }
        public Task<User> Register(UserRegisterRequest request)
        {
            return null;
        }
    }
}
