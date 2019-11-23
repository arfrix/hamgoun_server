using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HamgoonAPIV1.Services.RocketChat
{
    public class RocketChatService: IRocketChatService
    {
        private IHttpClientFactory _clientFactory;
        public RocketChatService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<RocketIdentityPayload> Login(string username, string password)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://0.0.0.0:3000/api/v1/login")
            };
        
            request.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                user = username,
                pass = password
            }));
            var client = _clientFactory.CreateClient();
            var resp = await client.SendAsync(request);
            if (!resp.IsSuccessStatusCode)
            {
                throw new RocketChatLoginFailed(resp.StatusCode.ToString());
            }

            var rocketLoginResponse = RocketLoginResponse.FromJson(resp.Content.ToString());
            return new RocketIdentityPayload
            {
                AuthToken = rocketLoginResponse.Data.AuthToken
            };
        }

        public async Task<RocketIdentityPayload> Register(string username, string email, string pass, string name)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://0.0.0.0:3000/api/v1/users.register")
            };
            var client = _clientFactory.CreateClient();
            request.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                username = username,
                email = email,
                pass = pass, 
                name = name,
            }));
            var resp = await client.SendAsync(request);
            var rocketRegisterResponse =  RocketRegisterResponse.FromJson(resp.Content.ToString());
            if (!resp.IsSuccessStatusCode)
            {
                throw new RocketChatLoginFailed(resp.StatusCode.ToString());
            }

            return await this.Login(username, pass);
        }
    }
}