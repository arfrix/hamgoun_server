using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HamgoonAPI.DataContext;
using HamgoonAPI.Exceptions.Users;
using HamgoonAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HamgoonAPI.Services.Users
{
    public class UserLoginService: IUserLoginService
    {
        private readonly HamgooonMySQLContext _context;
        private readonly IPasswordHasher<User> _hasher;

        public UserLoginService(HamgooonMySQLContext context, IPasswordHasher<User> hasher)
        {
            _hasher = hasher;
            _context = context;
        }
        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _context.User.Where(u => u.UserName == username).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new UserNotFound();
            }
            if (_hasher.VerifyHashedPassword(user, user.Pass, password) == PasswordVerificationResult.Failed)
            {
                throw new UserLoginFaild();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("HANSZIMMER-TINAGAO");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
