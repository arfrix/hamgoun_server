using System;
using Xunit;

namespace HamgoonTests.Services
{
    public class HashServiceTest
    {
        [Fact]
        public void TestHashPassword()
        {
            var hashed = new HamgoonAPI.Services.HashService().HashPassword(null, "somePassword");
            Assert.True(new HamgoonAPI.Services.HashService().VerifyHashedPassword(null,
                hashed, "somePassword") == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success ? true : false);
        }

    }
}
