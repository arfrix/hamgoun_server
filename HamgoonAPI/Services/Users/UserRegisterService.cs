using System;
using System.Linq;
using System.Threading.Tasks;
using HamgoonAPI.DataContext;
using HamgoonAPI.Exceptions.Users;
using HamgoonAPI.Models;
using HamgoonAPI.Models.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamgoonAPI.Services.Users
{
    public class UserRegisterService: IUserRegisterService
    {
        private readonly HamgooonMySQLContext _context;
        private readonly IPasswordHasher<User> _hasher;

        public UserRegisterService(HamgooonMySQLContext context)
        {
            _context = context;
            _hasher = new HashService();
        }
        public async Task<User> Register(User request)
        {
            var exists = await _context.User
                .Where(u => request.Email == u.Email || u.UserName == request.UserName)
                .FirstOrDefaultAsync();

            if (exists != null)
            {
                throw new UserAlreadyExists();
            }
            request.Pass = _hasher.HashPassword(request, request.Pass);
            _context.User.Add(request);
            await _context.SaveChangesAsync();
            return request;

        }
    }
}
