using System.Threading.Tasks;

namespace HamgoonAPI.Services.Users
{
    public interface IUserLoginService
    {
        Task<string> LoginAsync(string username, string password);
    }
}