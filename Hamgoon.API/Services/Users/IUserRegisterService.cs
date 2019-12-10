using System.Threading.Tasks;
using Hamgoon.API.Models;

namespace HamgoonAPI.Services.Users { 
    public interface IUserRegisterService {
        Task<User> Register(User request);
    }
}