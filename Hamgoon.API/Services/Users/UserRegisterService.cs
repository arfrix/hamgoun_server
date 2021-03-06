﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Hamgoon.API.Models;
using HamgoonAPI.DataContext;
using HamgoonAPI.Exceptions.Users;
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
            var count = await _context.User
                .Where(u => request.Email == u.Email || u.UserName == request.UserName || u.PhoneNumber == request.PhoneNumber)
                .CountAsync();

            if (count !=0)
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
