using System.Threading.Tasks;

namespace HamgoonAPIV1.Services.RocketChat
{
    public interface IRocketChatService
    {
        Task<RocketIdentityPayload> Login(long userID);
        Task<RocketIdentityPayload> Register(long userID);
    }
}