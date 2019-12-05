using System.Threading.Tasks;
using HamgoonAPI.Models;

namespace HamgoonAPI.Services.Users
{
    public interface IUserLoginService
    {
        Task<UserLoginResponse> LoginAsync(string username, string password);
    }
}