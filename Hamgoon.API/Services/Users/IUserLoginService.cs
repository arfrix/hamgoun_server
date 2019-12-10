using System.Threading.Tasks;

namespace HamgoonAPI.Services.Users
{
    public interface IUserLoginService
    {
        Task<UserLoginResponse> LoginAsync(string username, string password);
    }
}