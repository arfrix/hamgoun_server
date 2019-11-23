using System.Threading.Tasks;

namespace HamgoonAPIV1.Services.RocketChat
{
    public interface IRocketChatService
    {
        Task<RocketIdentityPayload> Login(string username, string password);
        Task<RocketIdentityPayload> Register(string username, string email, string pass, string name);
    }
}