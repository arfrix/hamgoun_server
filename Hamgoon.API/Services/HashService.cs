using System;
using Hamgoon.API.Models;
using Microsoft.AspNetCore.Identity;

namespace HamgoonAPI.Services
{
    public class HashService: IPasswordHasher<User>
    {
        public string HashPassword(User _, string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public PasswordVerificationResult VerifyHashedPassword
            (User _, string hashedPassword, string providedPassword)
        => BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword) 
                ? PasswordVerificationResult.Success
                : PasswordVerificationResult.Failed;
                
        
    }
}
