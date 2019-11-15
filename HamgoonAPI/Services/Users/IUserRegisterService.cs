using System.Threading.Tasks;
using HamgoonAPI.Models;

namespace HamgoonAPI.Services.Users { 
    public interface IUserRegisterService {
        Task<User> Register(User request);
    }
}