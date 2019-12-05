using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HamgoonAPI.DataContext;
using HamgoonAPI.Exceptions.Users;
using HamgoonAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HamgoonAPIV1.Services.RocketChat
{
    public class RocketChatService: IRocketChatService
    {
        private IHttpClientFactory _clientFactory;
        private HamgooonMySQLContext _context;
        public RocketChatService(IHttpClientFactory clientFactory, HamgooonMySQLContext context)
        {
            _clientFactory = clientFactory;
            _context = context;
        }
        public async Task<RocketIdentityPayload> Login(long userID)
        {
            var rocketUser = await _context.UsersRocket.Where(ru => ru.Id == userID).FirstOrDefaultAsync();
            var user = await _context.User.Where(u => u.Id == userID).FirstOrDefaultAsync();
            if (rocketUser == null || user == null)
            {
                throw new UserNotFound();
            }

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:3000/api/v1/login")
            };
            var pairs = new List<KeyValuePair<string, string>>
            {
                KeyValuePair.Create("user", user.UserName),
                KeyValuePair.Create("password", rocketUser.Password)
            }; 
            request.Content = new FormUrlEncodedContent(pairs);
            var client = _clientFactory.CreateClient();
            var resp = await client.SendAsync(request);
            if (!resp.IsSuccessStatusCode)
            {
                throw new RocketChatLoginFailed(resp.ReasonPhrase);
            }

            var rocketLoginResponse = RocketLoginResponse.FromJson(await resp.Content.ReadAsStringAsync());
            return new RocketIdentityPayload
            {
                AuthToken = rocketLoginResponse.Data.AuthToken
            };
        }
        

        public async Task<RocketIdentityPayload> Register(long userID)
        {
            var user = await _context.User.Where(u => u.Id == userID).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new UserNotFound();
            }

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:3000/api/v1/users.register")
            };
            var rocketUser = new UserRocket(userID, Guid.NewGuid().ToString());
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(new RocketChatRegisterPayload(user.UserName, rocketUser.Password,
                user.Email, user.Firstname+user.Lastname));
            request.Content = new StringContent(json, Encoding.Default, "application/json");
            var resp = await client.SendAsync(request);
            if (!resp.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<RocketChatRegisterError>(await resp.Content.ReadAsStringAsync());
                throw new RocketChatRegisterFailed(error.Error);
            }
            var rocketRegisterResponse =  RocketRegisterResponse.FromJson(await resp.Content.ReadAsStringAsync());
            return await Login(userID);
        }
    }
}