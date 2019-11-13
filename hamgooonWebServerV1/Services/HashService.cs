using System;
using hamgooonWebServerV1.Models;
using Microsoft.AspNetCore.Identity;

namespace hamgooonWebServerV1.Services
{
    public class HashService: IPasswordHasher<User>
    {
        public string HashPassword(User _, string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public PasswordVerificationResult VerifyHashedPassword(User _, string hashedPassword, string providedPassword) =>
            BCrypt.Net.BCrypt.HashPassword(providedPassword) == hashedPassword ?
                PasswordVerificationResult.Success :
                PasswordVerificationResult.Failed;
    }
}
